<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ControlAcceso.aspx.cs" Inherits="TPC_equipo_9A.ControlAcceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .image-thumbnail {
            width: 35px;  /* Ajusta el tamaño según tu necesidad */
            height: auto;
            border-radius: 50%; /* Redondear las esquinas de la imagen */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Control de Acceso</h2>
        <asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
            <Columns>
                <asp:ImageField DataImageUrlField="FotoPerfil" HeaderText="" ControlStyle-CssClass="image-thumbnail" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
                <asp:BoundField DataField="Rol" HeaderText="Rol" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
