<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TPC_equipo_9A.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h1>Listado de Marcas</h1>

    <asp:GridView ID="dgvMarca" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="IdMarca" HeaderText="ID Marca" Visible="false" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        </Columns>
    </asp:GridView>
</asp:Content>
