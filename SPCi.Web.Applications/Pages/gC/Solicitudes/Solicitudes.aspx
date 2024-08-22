<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPages/RLSiteMenu.Master" AutoEventWireup="true" CodeBehind="Solicitudes.aspx.cs" Inherits="SPCi.Web.Applications.Pages.gC.Solicitudes.Solicitudes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header">
        <img src="../../../Images/logo/logo.png" alt="Logo" />
        <h2>Sociedad Portuaria de Caldera S.A</h2>
        <h3>Solicitudes de empresas pendientes</h3>
        <link rel="stylesheet" type="text/css" href="styles/style.css" />
    </div>

    <div class="form-container">
        <table>
            <tr>
                <td><label for="txtNombre">Nombre o razón social:</label></td>
                <td>
                    <telerik:RadTextBox ID="txtNombre" runat="server" CssClass="telerik-input" />
                </td>
            </tr>
            <tr>
                <td><label for="txtCedula">Cédula:</label></td>
                <td>
                    <telerik:RadTextBox ID="txtCedula" runat="server" CssClass="telerik-input" />
                </td>
            </tr>
            <tr>
                <td><label for="txtDireccion">Dirección:</label></td>
                <td>
                    <telerik:RadTextBox ID="txtDireccion" runat="server" CssClass="telerik-input" />
                </td>
            </tr>
            <tr>
                <td><label for="txtTelefono">Número Teléfono:</label></td>
                <td>
                    <telerik:RadTextBox ID="txtTelefono" runat="server" CssClass="telerik-input" />
                </td>
            </tr>
            <tr>
                <td><label for="txtCorreo">Correo electrónico:</label></td>
                <td>
                    <telerik:RadTextBox ID="txtCorreo" runat="server" CssClass="telerik-input" />
                </td>
            </tr>
            <tr>
                <td><label for="txtRepresentante">Nombre del representante legal:</label></td>
                <td>
                    <telerik:RadTextBox ID="txtRepresentante" runat="server" CssClass="telerik-input" />
                </td>
            </tr>
            <tr>
                <td><label for="txtCedulaRepresentante">Cédula de identidad:</label></td>
                <td>
                    <telerik:RadTextBox ID="txtCedulaRepresentante" runat="server" CssClass="telerik-input" />
                </td>
            </tr>
        </table>

        <div class="btn-container">
            <telerik:RadButton ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnEnviar_Click" />
        </div>

        <asp:FileUpload ID="fileUploadPDF" runat="server" CssClass="file-upload" AllowMultiple="true" Visible="false" OnChanged="fileUploadPDF_SelectedIndexChanged" AutoPostBack="true" />
        <telerik:RadButton ID="btnSubirPDF" runat="server" Text="Subir PDFs" CssClass="btn btn-secondary" OnClick="btnSubirPDF_Click" Visible="false" />
        
        <asp:GridView ID="gvArchivosSeleccionados" runat="server" AutoGenerateColumns="false" CssClass="grid-view">
            <Columns>
                <asp:BoundField DataField="FileName" HeaderText="Archivo" />
            </Columns>
        </asp:GridView>
    </div>

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server"></telerik:RadWindowManager>

    <telerik:RadWindow ID="RadWindow1" runat="server" Title="Confirmación" Modal="true" Width="400px" Height="200px" VisibleOnPageLoad="false">
        <ContentTemplate>
            <div id="messageContainer">
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            </div>
        </ContentTemplate>
    </telerik:RadWindow>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FooterContent" runat="server">
    <hr style="border: 1px solid #ccc; margin: 20px 0;" />
    <div style="text-align: left; padding: 10px 0;">
        <p style="margin: 0;">2006-2023 Sociedad Portuaria de Caldera S.A.</p>
    </div>
</asp:Content>
