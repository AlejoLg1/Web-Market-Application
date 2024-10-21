<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPC_equipo_9A.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h1>Listado de categorías</h1>
    
    <asp:GridView ID="dgvCategoria" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="IdCategoria" HeaderText="ID Categoria" Visible="false" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        </Columns>
    </asp:GridView>
</asp:Content>
