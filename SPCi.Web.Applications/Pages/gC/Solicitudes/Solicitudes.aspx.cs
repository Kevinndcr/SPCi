using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;

namespace SPCi.Web.Applications.Pages.gC.Solicitudes
{
    public partial class Solicitudes : System.Web.UI.Page
    {
        private const int MaxFileSizeMB = 5; // Tamaño máximo permitido en MB
        private const int MaxPdfFiles = 5; // Número máximo de archivos PDF permitidos

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (!ValidarCampos())
            {
                return;
            }

            // Si todas las validaciones pasan, se procede a insertar en la base de datos
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["op_SPC"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("AT_InsertarClienteUsuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Pasar todos los parámetros requeridos
                        cmd.Parameters.AddWithValue("@CorreoSolicitante", txtCorreo.Text);
                        cmd.Parameters.AddWithValue("@RazonSocial", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Identificacion", txtCedula.Text);
                        cmd.Parameters.AddWithValue("@RepresentanteLegal", txtRepresentante.Text);
                        cmd.Parameters.AddWithValue("@IdCedulaRepresentanteLegal", txtCedulaRepresentante.Text);
                        cmd.Parameters.AddWithValue("@CorreoElectronico", txtCorreo.Text);
                        cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                        cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@IxCUTipoAutorizacion", 1);
                        cmd.Parameters.AddWithValue("@IxCUEstado", 1); 
                        cmd.Parameters.AddWithValue("@FcClienteUsuario", DateTime.Now); 

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // Obtener el ID del cliente
                int clienteId = ObtenerUltimoClienteUsuarioId();

                if (clienteId <= 0)
                {
                    MostrarMensaje("No se pudo obtener el ID del cliente.");
                    return;
                }

                // Registrar en la bitácora
                RegistrarBitacoraClienteUsuario(clienteId);

                // Hacer visible el control de carga de archivos y el botón
                fileUploadPDF.Visible = true;
                btnSubirPDF.Visible = true;

                MostrarMensaje("Los datos se han guardado correctamente.");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Ocurrió un error al guardar los datos: " + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || !IsValidNombre(txtNombre.Text))
            {
                MostrarMensaje("Por favor, ingresa un nombre válido (solo letras y espacios).");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCedula.Text) || !IsValidCedula(txtCedula.Text))
            {
                MostrarMensaje("Por favor, ingresa una cédula válida (solo números).");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MostrarMensaje("La dirección no puede estar vacía.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text) || !IsValidTelefono(txtTelefono.Text))
            {
                MostrarMensaje("Por favor, ingresa un número de teléfono válido (solo números).");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || !IsValidEmail(txtCorreo.Text))
            {
                MostrarMensaje("El correo electrónico no es válido.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRepresentante.Text) || !IsValidNombre(txtRepresentante.Text))
            {
                MostrarMensaje("Por favor, ingresa un nombre de representante válido (solo letras y espacios).");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCedulaRepresentante.Text) || !IsValidCedula(txtCedulaRepresentante.Text))
            {
                MostrarMensaje("Por favor, ingresa una cédula de representante válida (solo números).");
                return false;
            }

            return true;
        }

        protected void fileUploadPDF_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar tamaño del archivo
            foreach (HttpPostedFile uploadedFile in fileUploadPDF.PostedFiles)
            {
                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {
                    if (uploadedFile.ContentLength > MaxFileSizeMB * 1024 * 1024)
                    {
                        MostrarMensaje($"El archivo {uploadedFile.FileName} excede el tamaño máximo permitido de {MaxFileSizeMB} MB.");
                        return;
                    }
                }
            }
        }

        protected void btnSubirPDF_Click(object sender, EventArgs e)
        {
            // Validar que se han subido archivos
            if (fileUploadPDF.HasFiles)
            {
                int pdfCount = 0;

                foreach (HttpPostedFile uploadedFile in fileUploadPDF.PostedFiles)
                {
                    if (uploadedFile != null && uploadedFile.ContentLength > 0)
                    {
                        string fileExtension = Path.GetExtension(uploadedFile.FileName);

                        if (fileExtension.ToLower() == ".pdf")
                        {
                            // Solo contar los archivos PDF válidos
                            pdfCount++;
                        }
                        else
                        {
                            MostrarMensaje($"El archivo {uploadedFile.FileName} no es un PDF válido.");
                            return;
                        }
                    }
                }

                // Verificar si se han seleccionado entre 1 y 5 archivos
                if (pdfCount > 0 && pdfCount <= MaxPdfFiles)
                {
                    // Guardar archivos
                    GuardarArchivos(pdfCount);
                }
                else
                {
                    MostrarMensaje($"Debes seleccionar entre 1 y {MaxPdfFiles} archivos PDF.");
                }
            }
            else
            {
                MostrarMensaje("Debes seleccionar archivos PDF para procesar.");
            }
        }

        private void GuardarArchivos(int pdfCount)
        {
            string basePath = @"C:\PDFs";       //en este caso, se guardan de manera local en el equipo
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            int clienteId = ObtenerUltimoClienteUsuarioId();
            if (clienteId <= 0)
            {
                MostrarMensaje("No se pudo obtener el ID del cliente para guardar los archivos.");
                return;
            }

            string clientePath = Path.Combine(basePath, clienteId.ToString());
            if (!Directory.Exists(clientePath))
            {
                Directory.CreateDirectory(clientePath);
            }

            foreach (HttpPostedFile uploadedFile in fileUploadPDF.PostedFiles)
            {
                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(uploadedFile.FileName);
                    string filePath = Path.Combine(clientePath, fileName);
                    uploadedFile.SaveAs(filePath);

                    // Aquí se llama el metodo para insertar el archivo en la base de datos
                    InsertarArchivoAdjunto(clienteId, fileName, filePath);
                }
            }

            // Registrar en la bitácora
            RegistrarBitacoraArchivoAdjunto(clienteId);

            // Mostrar mensaje de éxito y luego recargar la página
            MostrarMensaje("Solicitud y datos almacenados con éxito!");
            LimpiarFormulario();
        }

        private void InsertarArchivoAdjunto(int clienteId, string nombreArchivo, string rutaArchivo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["op_SPC"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("AT_InsertarCUArchivoAdjunto", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@FcCUArchivoAdjunto", DateTime.Now);
                        cmd.Parameters.AddWithValue("@IxClienteUsuario", clienteId);
                        cmd.Parameters.AddWithValue("@DsCUArchivoAdjunto", "Achivo adjunto para la solicitud de tramite"); 
                        cmd.Parameters.AddWithValue("@NombreArchivo", nombreArchivo);
                        cmd.Parameters.AddWithValue("@NombreArchivoWeb", nombreArchivo); 
                        cmd.Parameters.AddWithValue("@CarpetaArchivoWeb", rutaArchivo); 

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Ocurrió un error al guardar la información del archivo: " + ex.Message);
            }
        }

        private void RegistrarBitacoraClienteUsuario(int clienteId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["op_SPC"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("AT_InsClienteUsuarioB", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        int ixSession = ObtenerIxSession();

                        cmd.Parameters.AddWithValue("@IxClienteUsuario", clienteId);
                        cmd.Parameters.AddWithValue("@IxCUEstado", 1); 
                        cmd.Parameters.AddWithValue("@IxSession", ixSession);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Ocurrió un error al registrar la bitácora de cliente: " + ex.Message);
            }
        }

        private void RegistrarBitacoraArchivoAdjunto(int clienteId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["op_SPC"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("AT_InsCUArchivoAdjuntoB", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        int ixSession = ObtenerIxSession();

                        cmd.Parameters.AddWithValue("@IxClienteUsuario", clienteId);
                        cmd.Parameters.AddWithValue("@IxSession", ixSession);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Ocurrió un error al registrar la bitácora de archivo adjunto: " + ex.Message);
            }
        }

        private int ObtenerIxSession()
        {
            if (Session["IxSesion"] != null && int.TryParse(Session["IxSesion"].ToString(), out int ixSesion))
            {
                return ixSesion;
            }

            return 0;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtRepresentante.Text = string.Empty;
            txtCedulaRepresentante.Text = string.Empty;

        }

        private int ObtenerUltimoClienteUsuarioId()
        {
            int clienteId = 0;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["op_SPC"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AT_ObtenerUltimoClienteUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out clienteId))
                    {
                        return clienteId;
                    }
                }
            }

            return clienteId;
        }

        private void MostrarMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.Attributes.Add("style", "white-space: pre-line;"); // Para permitir el uso de <br />
            RadWindow1.VisibleOnPageLoad = true; 
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidNombre(string nombre)
        {
            return Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$");
        }

        private bool IsValidCedula(string cedula)
        {
            return Regex.IsMatch(cedula, @"^\d+$");
        }

        private bool IsValidTelefono(string telefono)
        {
            return Regex.IsMatch(telefono, @"^\d+$");
        }
    }
}
