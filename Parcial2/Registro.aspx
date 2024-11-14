<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Parcial2.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Formulario de Registro</h2>
        
    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="txtEmail" ErrorMessage="Email es requerido" runat="server" CssClass="error-message"/>
    <asp:RegularExpressionValidator ControlToValidate="txtEmail" ValidationExpression="\w+@\w+\.\w+" ErrorMessage="Formato de email incorrecto" runat="server" CssClass="error-message"/>

    <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="txtUsername" ErrorMessage="Username es requerido" runat="server" CssClass="error-message"/>

    <asp:TextBox ID="txtEdad" runat="server" placeholder="Edad" TextMode="Number" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="txtEdad" ErrorMessage="Edad es requerida" runat="server" CssClass="error-message"/>
    <asp:RangeValidator ControlToValidate="txtEdad" MinimumValue="16" MaximumValue="100" Type="Integer" ErrorMessage="Debe ser mayor de 15 años" runat="server" CssClass="error-message"/>

    <asp:TextBox ID="txtPassword" runat="server" placeholder="Contraseña" TextMode="Password" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="txtPassword" ErrorMessage="Contraseña es requerida" runat="server" CssClass="error-message"/>

    <asp:TextBox ID="txtConfirmPassword" runat="server" placeholder="Confirmar Contraseña" TextMode="Password" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="txtConfirmPassword" ErrorMessage="Debe confirmar la contraseña" runat="server" CssClass="error-message"/>
    <asp:CompareValidator ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Las contraseñas no coinciden" runat="server" CssClass="error-message"/>

    <asp:Button ID="btnRegistrar" Text="Registrar" OnClick="btnRegistrar_Click" runat="server" CssClass="button" />
</asp:Content>
