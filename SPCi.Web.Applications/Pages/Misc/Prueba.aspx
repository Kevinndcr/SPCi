<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPages/RLSiteMenu.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="SPCi.Web.Applications.Pages.Misc.Pruebas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Menú principal</h1>
 <telerik:RadGrid ID="grdMenu" runat="server" CellSpacing="-1" Culture="es-ES" DataSourceID="sdsMenu" GridLines="Both">
  <MasterTableView DataSourceID="sdsMenu" AutoGenerateColumns="False">
   <Columns>
    <telerik:GridBoundColumn DataField="IxMenu" HeaderText="IxMenu" SortExpression="IxMenu" ShowNoSortIcon="False" UniqueName="IxMenu" DataType="System.Int32" FilterControlAltText="Filter IxMenu column"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="DataFieldID" HeaderText="DataFieldID" SortExpression="DataFieldID" ShowNoSortIcon="False" UniqueName="DataFieldID" FilterControlAltText="Filter DataFieldID column"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="DataFieldParentID" HeaderText="DataFieldParentID" SortExpression="DataFieldParentID" ShowNoSortIcon="False" UniqueName="DataFieldParentID" FilterControlAltText="Filter DataFieldParentID column"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="DataText" HeaderText="DataText" SortExpression="DataText" ShowNoSortIcon="False" UniqueName="DataText" FilterControlAltText="Filter DataText column"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="DataValue" HeaderText="DataValue" SortExpression="DataValue" ShowNoSortIcon="False" UniqueName="DataValue" FilterControlAltText="Filter DataValue column"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="DataNavigatUrlField" HeaderText="DataNavigatUrlField" SortExpression="DataNavigatUrlField" ShowNoSortIcon="False" UniqueName="DataNavigatUrlField" FilterControlAltText="Filter DataNavigatUrlField column"></telerik:GridBoundColumn>
   </Columns>

  </MasterTableView>
 </telerik:RadGrid>
 <asp:SqlDataSource runat="server" ID="sdsMenu" ConnectionString='<%$ ConnectionStrings:op_SPC %>' SelectCommand="SELECT IxMenu, DataFieldID, DataFieldParentID, DataText, DataValue, DataNavigatUrlField FROM Menu"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
