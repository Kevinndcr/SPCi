<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPages/RLSiteMenu.Master" AutoEventWireup="true" CodeBehind="visualizarSolicitud.aspx.cs" Inherits="SPCi.Web.Applications.Pages.gC.visualizarSolicitud.visualizarSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div style="width: 80%; max-width: 650px; margin-left: auto; margin-right: auto; margin-top: 2%;">
         <header >
            <h1>Sociedad Portuaria de Caldera S.A</h1>
            <h3>Solicitudes de empresas pendientes</h3>
            <img src="../../../Images/logo/logo.png" alt="Logo" style="position: absolute; right: 0; width: 67px; height: auto; top: 0; margin-right:15%; margin-top:-10px " />
        </header>
        <hr />
        <main>
            <div style="width: 70%; margin: 0 auto; padding-top: 2%;" >
                <div>
                    <asp:Label style="margin-top: 10%; padding-right: 21%;" runat="server" Text="ID Cliente:" />
                    <telerik:RadLabel style="width: 200px; border: 1px solid #ccc;" ID="RadLabelIDCliente" runat="server"></telerik:RadLabel><br /> 
                </div>
                <br />
                <div>
                    <asp:Label style="padding-right: 17.68%;"  runat="server" Text="Razón Social: " />
                    <telerik:RadLabel style="width: 200px; border: 1px solid #ccc;" ID="RadLabelRazonSocial" runat="server" ></telerik:RadLabel><br />
                </div>
                <br />
                <div>
                    <asp:Label style="padding-right: 16.75%;" runat="server" Text= "Identificación: " />
                    <telerik:RadLabel style="width: 200px; border: 1px solid #ccc;" ID="RadLabelIdentificacion" runat="server" ></telerik:RadLabel><br />
                </div>
                <br />
                <div>
                     <asp:Label style="padding-right: 21.45%;"  runat="server" Text="Dirección: "/>
                     <telerik:RadLabel style="width: 200px; border: 1px solid #ccc;" ID="RadLabelDireccion" runat="server" ></telerik:RadLabel><br />
                </div>
                <br />
                <div>
                    <asp:Label style="padding-right: 22.40%;"  runat="server" Text="Teléfono: "/>
                    <telerik:RadLabel style="width: 200px; border: 1px solid #ccc;" ID="RadLabelTelefono" runat="server" ></telerik:RadLabel><br />
                </div>
                <br />
                <div>
                    <asp:Label style="padding-right: 11.58%;" runat="server" Text="Correo Solicitante: " />
                    <telerik:RadLabel style="width: 200px; border: 1px solid #ccc;" ID="RadLabelCorreoSolicitante" runat="server" ></telerik:RadLabel><br />
                </div>
                <br />
                <div>
                    <asp:Label style="padding-right: 8.70%;" runat="server" Text="Representante Legal: " />
                    <telerik:RadLabel style="width: 200px; border: 1px solid #ccc;" ID="RadLabelRepresentanteLegal" runat="server" ></telerik:RadLabel><br />
                </div>
                <br />
                <div>
                    <asp:Label style="padding-right: 4.90%;" runat="server" Text="ID Representante Legal:: " />
                    <telerik:RadLabel style="width: 200px; border: 1px solid #ccc;" ID="RadLabelIDRepresentanteLegal" runat="server" ></telerik:RadLabel><br />
                </div>

                <br />
                <br />
                <asp:Button ID="btnAprobar" runat="server" Text="Enviar" />
                <asp:Button ID="btnRechazar" runat="server" Text="Rechazar" />
            
  
           </div>
        </main>
    </div>  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
