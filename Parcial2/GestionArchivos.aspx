<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GestionArchivos.aspx.cs" Inherits="Parcial2.GestionArchivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   <div class="gestion-archivos">
        <h2>Gestión de Archivos</h2>
        
        <!-- Carga de archivo -->
        <div class="file-upload-container">
            <asp:FileUpload ID="fileUploader" runat="server" />
            <asp:Button ID="btnUpload" Text="Subir Archivo" OnClick="btnUpload_Click" runat="server" CssClass="button2" />
        </div>

        <!-- Tabla de archivos -->
        <asp:GridView ID="gvArchivos" runat="server" AutoGenerateColumns="false" CssClass="table">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Nombre de Archivo" />
                <asp:TemplateField HeaderText="Descargar">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownload" runat="server" Text="Descargar" CommandArgument='<%# Eval("Path") %>' OnCommand="lnkDownload_Command"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
