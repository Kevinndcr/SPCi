using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class Usuario: System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Código de inicialización aquí, si es necesario
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ValidarCampos())
        {
            string redirectUrl = ResolveUrl("~/Pages/gC/Pantalla1/Pantalla1.aspx");
            Response.Write($"<script>alert('Usuario creado exitosamente!'); setTimeout(function() {{ window.location.href = '{redirectUrl}'; }}, 99);</script>");
        }
        else
        {
            // Manejo de la validación fallida, por ejemplo, mostrar un mensaje de error.
            Response.Write("<script>alert('Por favor, complete todos los campos.');</script>");
        }
    }
    private bool ValidarCampos()
    {
        // Guardar valores en variables
        string correo = txtcorreo.Text;
        string passwd = txtPasswd.Text;
        string passwd2 = txtPasswd2.Text;
        string cedula = txtCedula.Text;
        string nombre = txtNombre.Text;
        string apellido1 = txtApellido1.Text;
        string apellido2 = txtApellido2.Text;
        string numeroCelular = txtNumero.Text;

        // Verificar que ningún campo esté vacío
        if (string.IsNullOrWhiteSpace(correo) ||
            string.IsNullOrWhiteSpace(passwd) ||
            string.IsNullOrWhiteSpace(passwd2) ||
            string.IsNullOrWhiteSpace(cedula) ||
            string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(apellido1) ||
            string.IsNullOrWhiteSpace(apellido2) ||
            string.IsNullOrWhiteSpace(numeroCelular))
        {
            return false; // Retorna falso si algún campo está vacío
        }

        return true; // Retorna verdadero si todos los campos están llenos
    }
}
