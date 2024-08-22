
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SPCi.Web.Applications.Pages.gC.Autorizados
{
    public partial class Autorizados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el IdEntidad desde la sesión del MasterPage
                string idEntidad = (string)Session["IdEntidad"];
                // Llamar a BindGrid con el IdEntidad
                BindGrid(idEntidad);
            }
        }


        private void BindGrid(string idEntidad = null)
        {
            string connStr = ConfigurationManager.ConnectionStrings["op_SPC"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("AT_SeleccionarAutorizadoPorIdEntidad", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!string.IsNullOrEmpty(idEntidad))
                    {
                        cmd.Parameters.AddWithValue("@IdEntidad", idEntidad);
                    }
                    else
                    {
                        // Si no se proporciona IdEntidad, se podría optar por manejar el caso o mostrar un mensaje.
                        cmd.Parameters.AddWithValue("@IdEntidad", DBNull.Value);
                    }

                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            gvAutorizados.DataSource = dt;
                            gvAutorizados.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores
                        throw new ApplicationException("Error al acceder a la base de datos", ex);
                    }
                }
            }
        }







        protected void btnAgregarAutorizado(object sender, EventArgs e)
        {
            int ixClienteUsuario;
            string cedula = txtCedula.Text.Trim();

            if (int.TryParse(txtIxClienteUsuario.Text.Trim(), out ixClienteUsuario) && !string.IsNullOrEmpty(cedula))
            {
                InsertCuUsuario(ixClienteUsuario, cedula);
                // Re-bind the Grid to show the updated data
                BindGrid();
                lblAgregar.Text = "Usuario agregado exitosamente.";
            }
            else
            {
                // Manejo de error si el ID o la cédula no son válidos
                lblAgregar.Text = "ID del cliente o cédula inválidos.";
            }
        }

        private void InsertCuUsuario(int ixClienteUsuario, string cedula)
        {
            string connStr = ConfigurationManager.ConnectionStrings["op_SPC"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("AT_InsertCuUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IxClienteUsuario", ixClienteUsuario);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores
                        throw new ApplicationException("Error al ejecutar el procedimiento almacenado", ex);
                    }
                }
            }
        }

        protected void btnEliminarAutorizado(object sender, EventArgs e)
        {
            int ixCUUsuario;
            if (int.TryParse(txtIxCUUsuario.Text.Trim(), out ixCUUsuario))
            {
                DeleteCuUsuario(ixCUUsuario);
                // Re-bind the Grid to show the updated data
                BindGrid();
                lblEliminar.Text = "Usuario eliminado exitosamente.";
            }
            else
            {
                // Manejo de error si el ID no es válido
                lblEliminar.Text = "ID de usuario inválido.";
            }
        }

        private void DeleteCuUsuario(int ixCUUsuario)
        {
            string connStr = ConfigurationManager.ConnectionStrings["op_SPC"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("AT_DeleteCuUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IxCUUsuario", ixCUUsuario);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores
                        throw new ApplicationException("Error al ejecutar el procedimiento almacenado", ex);
                    }
                }
            }
        }
    }
}

