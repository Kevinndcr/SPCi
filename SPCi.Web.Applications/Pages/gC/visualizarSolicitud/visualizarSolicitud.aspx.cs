using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Telerik.Web.UI;

namespace SPCi.Web.Applications.Pages.gC.visualizarSolicitud
{
    public partial class visualizarSolicitud : System.Web.UI.Page
    {
        private int idSolicitud; // Cambiado a int para que coincida con el tipo en la base de datos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el parámetro de la URL
                string IdSolicitud = Request.QueryString["IxClienteUsuario"];

                if (!string.IsNullOrEmpty(IdSolicitud))
                {
                    int clienteId;
                    if (int.TryParse(IdSolicitud, out clienteId))
                    {
                        BindLabels(clienteId);
                    }
                    else
                    {
                        // Manejar error si el parámetro no es válido
                        Response.Write("Parámetro de cliente no válido.");
                    }
                }
                else
                {
                    // Manejar error si el parámetro no está presente
                    Response.Write("Parámetro de cliente faltante.");
                }
            }
        }

        private void BindLabels(int clientId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["op_SPC"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "AT_SeleccionarDatosPorIdSolicitud";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IxClienteUsuario", clientId);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                RadLabelIDCliente.Text = reader["IxClienteUsuario"].ToString(); // Corrigiendo el campo
                                RadLabelRazonSocial.Text = reader["RazonSocial"].ToString();
                                RadLabelIdentificacion.Text = reader["Identificacion"].ToString();
                                RadLabelDireccion.Text = reader["Direccion"].ToString();
                                RadLabelTelefono.Text = reader["Telefono"].ToString();
                                RadLabelCorreoSolicitante.Text = reader["CorreoSolicitante"].ToString();
                                RadLabelRepresentanteLegal.Text = reader["RepresentanteLegal"].ToString();
                                RadLabelIDRepresentanteLegal.Text = reader["IdCedulaRepresentanteLegal"].ToString();
                                
                            }
                            else
                            {
                                // Manejar caso si no se encuentra el cliente
                                Response.Write("Cliente no encontrado.");
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo específico de errores de SQL
                        Response.Write("Error SQL: " + sqlEx.Message);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de otros errores
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
        }

    }
}