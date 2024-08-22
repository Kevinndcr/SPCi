using System;
using System.Web.ModelBinding;

namespace SPCi.Web.Public.Shared.MasterPages
{
    public partial class RLSiteMenu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("IxSesion", "170");
            Session.Add("Email", "unusuario@compania.com");
            Session.Add("Alias", "yperez");
            Session.Add("IdCedula", "601230456");
            Session.Add("Nombre", "Yenci");
            Session.Add("Apellido1", "Perez");
            Session.Add("Apellido2", "Arias");
            Session.Add("NombreCorto", "Yenci Perez");
            Session.Add("IdEntidad", "0001");
            Session.Add("DsEntidad", "Una compañía cualquiera");
            Session.Add("IxEntidadTipo", "");


            lblNombreCorto.Text = Session["NombreCorto"].ToString();


        }
    }
}

