<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPages/RLSiteMenu.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="https://web.spcaldera.com/SPC/Public/Shared/CSS/default.css" rel="stylesheet" />
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


  <body>
        <div style=" width: 80%; max-width: 650px; margin-left: auto; margin-right: auto; margin-top:2% " > 
      <h1  >Sociedad Portuaria de Caldera S.A</h1> 
      <h2>Crear cuenta nueva</h2> 
     <!--revisar esto-->  <p style=" background-color: whitesmoke;" />Su cuenta estará relacionada con un correo eletrónico que luego será confirmado enviándole un mensaje<p />
        <hr />
        
      <div style="  width: 70%; margin: 0 auto; padding-top:2% " >
          <div style="  ">
               <asp:Label style="margin-top:10%; padding-right:20.1% " ID="lblCorreo" runat="server" Text="Cuenta correo:" ></asp:Label>
                <asp:TextBox ID="txtcorreo" runat="server" style=" width:50%;  " ></asp:TextBox>
          </div>
               <br />
          <div> 
           <asp:Label style="padding-right:23.4%" ID="lblPasswd" runat="server" Text="Contraseña:"></asp:Label>
           <asp:TextBox ID="txtPasswd" runat="server" style="width: 50%" ></asp:TextBox>                
          </div>
          <br />
          <div> 
           <asp:Label style="padding-right:7%" ID="lblPasswd2" runat="server" Text="Comprobante contraseña:"></asp:Label>
           <asp:TextBox ID="txtPasswd2" runat="server" style="width: 50%"></asp:TextBox>
          </div>
           <br />
          <div> 
              <asp:Label style="padding-right:15%" ID="lblCedula" runat="server" Text="Número de cédula:"></asp:Label>
               <asp:TextBox ID="txtCedula" runat="server" style="width: 50%"></asp:TextBox>
          </div>
          <br />
          <div> 
              <asp:Label style="padding-right:26.98%" ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
              <asp:TextBox ID="txtNombre" runat="server" style="width: 50%"></asp:TextBox>
          </div>
           <br /> 
           <div> 
              <asp:Label style="padding-right:18.50%" ID="lblApellido" runat="server" Text="Primer Apellido:"></asp:Label>
              <asp:TextBox ID="txtApellido1" runat="server" style="width: 50%"></asp:TextBox>
          </div>
          <br />
           <div> 
               <asp:Label style="padding-right:15.70%" ID="lblApellido2" runat="server" Text="Segundo Apellido:"></asp:Label>
               <asp:TextBox ID="txtApellido2" runat="server" style="width: 50%"></asp:TextBox>
          </div>
          <br />
          <div>
              <asp:Label style="padding-right:18.10%" ID="lblNumero" runat="server" Text="Número Celular:"></asp:Label>
              <asp:TextBox ID="txtNumero" runat="server" placeholder="(506) - ___ " style="width: 50%" ></asp:TextBox>
          </div>  
          <br /> 
           <asp:Button ID="btnSubmit" runat="server" Text="Enviar" OnClick="btnSubmit_Click" />
      
      </div>
      
       <hr />     
  </div>
  </body>





</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
