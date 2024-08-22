<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPages/RLSiteMenu.Master" AutoEventWireup="true" CodeBehind="Autorizados.aspx.cs" Inherits="SPCi.Web.Applications.Pages.gC.Autorizados.Autorizados" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center; margin-bottom: 20px; position: relative; width: 100%; max-width: 800px; margin-left: auto; margin-right: auto;">
        <div style="display: inline-block; vertical-align: middle;">
            <h3>Sociedad Portuaria de Caldera S.A</h3>
            <h4>Registro de Autorizados</h4>
        </div>
        <img src="../../../Images/logo/logo.png" alt="Logo" style="position: absolute; right: 0; width: 67px; height: auto; top: 0;" />
    </div>

    <hr style="border: 1px solid #000; margin: 20px 0;" />

    <div style="text-align: center; margin-bottom: 20px;">
        <asp:Label ID="lblDescripcion" runat="server" Text="Personas encargadas de realizar trámites de permisos de ingreso a la Terminal de Caldera por sistema digital"></asp:Label>
    </div>

    <!-- Grid de Autorizados -->
    <div style="text-align: center; margin: 0 auto; max-width: 800px;">
<telerik:RadGrid 
    ID="gvAutorizados" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" GridLines="None" PageSize="10" Width="100%">
    <MasterTableView>
        <Columns>
            <telerik:GridBoundColumn DataField="IDAutorizado" HeaderText="ID Autorizado" SortExpression="IDAutorizado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <telerik:GridBoundColumn DataField="Cedula" HeaderText="Cédula" SortExpression="Cedula" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <telerik:GridBoundColumn DataField="PrimerApellido" HeaderText="Primer Apellido" SortExpression="PrimerApellido" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <telerik:GridBoundColumn DataField="SegundoApellido" HeaderText="Segundo Apellido" SortExpression="SegundoApellido" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </MasterTableView>
</telerik:RadGrid>


    </div>

    <hr style="border: 1px solid #000; margin: 20px 0;" />




    <!-- Pestañas -->
    <div style="text-align: left; margin: 0 auto; max-width: 800px; ">
        <telerik:RadTabStrip 
            RenderMode="Lightweight" runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="Office2010Blue" CssClass="custom-telerik-tabstrip" Width="100%">
            <Tabs>
                <telerik:RadTab Text="Agregar Autorizado" Width="200px"></telerik:RadTab>
                <telerik:RadTab Text="Eliminar Autorizado" Width="200px"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
    </div>


    <!-- Contenedor con borde para el contenido de las pestañas -->
    <div style="text-align: left; margin: 0 auto; max-width: 800px; border: 1px solid #000; padding: 10px; border-radius: 5px; margin-top: 20px;">
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Width="100%">
            <!-- Página para Agregar -->
            <telerik:RadPageView ID="RadPageView1" runat="server">
                <div style="display: flex; justify-content: center; align-items: center; flex-direction: column;">
                    <h4>Agregar Autorizado</h4>
                    <asp:TextBox ID="txtIxClienteUsuario" runat="server" Placeholder="Ingrese ID del Cliente"></asp:TextBox>
                    <asp:TextBox ID="txtCedula" runat="server" Placeholder="Ingrese Cédula del Usuario"></asp:TextBox>
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Usuario" OnClick="btnAgregarAutorizado" />
                    <asp:Label ID="lblAgregar" runat="server" ForeColor="Green"></asp:Label>
                </div>
            </telerik:RadPageView>

            <!-- Página para Eliminar -->
            <telerik:RadPageView ID="RadPageView2" runat="server">
                <div style="display: flex; justify-content: center; align-items: center; flex-direction: column;">
                    <h4>Eliminar Autorizado</h4>
                    <asp:TextBox ID="txtIxCUUsuario" runat="server" Placeholder="Ingrese ID del Usuario"></asp:TextBox>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Usuario" OnClick="btnEliminarAutorizado" />
                    <asp:Label ID="lblEliminar" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
    <hr style="border: 1px solid #ccc; margin: 20px 0;" />
    <div style="text-align: left; padding: 10px 0;">
        <p style="margin: 0;">2006-2023 Sociedad Portuaria de Caldera S.A.</p>
    </div>
</asp:Content>
