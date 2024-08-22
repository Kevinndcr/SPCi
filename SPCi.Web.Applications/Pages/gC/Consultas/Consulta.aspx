<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPages/RLSiteMenu.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="SPCi.Web.Applications.Pages.gC.Consulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Hola</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div style="margin-top: 2%;" >
    <header >
        <h1>Sociedad Portuaria de Caldera S.A</h1>
        <h3>Solicitudes de empresas pendientes</h3>
        <img src="../../../Images/logo/logo.png" alt="Logo" style="position: absolute; right: 0; width: 67px; height: auto; top: 0; margin-right:5%; margin-top:-10px " />
    </header>
     <br />
    <hr />
    <main >
            <telerik:RadGrid ID="RadGrid1" runat="server" PageSize="50" AllowPaging="True" AllowSorting="True" ShowGroupPanel="True"
        OnNeedDataSource="RadGrid1_NeedDataSource" AllowFilteringByColumn="True"   OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged" >
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="IdSolicitud" AllowRowSelect="True">
            <Columns>
                <telerik:GridBoundColumn DataField="IdSolicitud" HeaderText="ID Cliente" SortExpression="IdSolicitud" UniqueName="IdSolicitud" />
                <telerik:GridBoundColumn DataField="NombreEmpresa" HeaderText="Razón Social" SortExpression="NombreEmpresa" UniqueName="NombreEmpresa" />
                <telerik:GridBoundColumn DataField="FechaAutorizacion" HeaderText="Fecha" SortExpression="FechaAutorizacion" UniqueName="FechaAutorizacion" />
                <telerik:GridBoundColumn DataField="Solicitud" HeaderText="Estado" SortExpression="Solicitud" UniqueName="Solicitud" />
                
            </Columns>
        </MasterTableView>
        <ClientSettings AllowColumnsReorder="True" AllowColumnHide="True" AllowDragToGroup="True">
            <Selecting AllowRowSelect="True" />
            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
        </ClientSettings>
    </telerik:RadGrid>

     </main>
 </div>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
