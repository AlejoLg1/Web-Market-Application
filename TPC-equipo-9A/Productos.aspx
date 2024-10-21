<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_equipo_9A.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilo para la tabla */
.table {
    width: 100%;
    border-collapse: collapse;
    margin: 20px 0;
    font-size: 18px;
    text-align: left;
    background-color: #f9f9f9;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

/* Bordes de las celdas */
.table th, .table td {
    padding: 12px 15px;
    border-bottom: 1px solid #dddddd;
}

/* Estilo para el encabezado */
.table th {
    background-color: #4CAF50;
    color: white;
    font-weight: bold;
}

/* Cambiar color de las filas alternas */
.table tr:nth-child(even) {
    background-color: #f2f2f2;
}

/* Efecto hover */
.table tr:hover {
    background-color: #f1f1f1;
}

/* Estilo para alinear los números en el centro */
.table td {
    text-align: center;
}

/* Centrar texto del encabezado */
.table th {
    text-align: center;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h1>Listado de productos</h1>
    <asp:GridView ID="dgvProductos" runat="server" CssClass="table" AutoGenerateColumns="False">
          <Columns>
        <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" Visible ="false" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="StockMinimo" HeaderText="Stock Mínimo" />
        <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" />
        <asp:BoundField DataField="Categoria.Nombre" HeaderText="Categoría" />
        <asp:BoundField DataField="Marca.Nombre" HeaderText="Marca" />
        <asp:BoundField DataField="PorcentajeGanancia" HeaderText="Porcentaje Ganancia" />
    </Columns>
    </asp:GridView>
</asp:Content>
