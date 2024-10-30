<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_equipo_9A.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilo para la tabla */
        .table {
            width: 50%;
            max-width: 900px; /* Limitar el tamaño máximo a 900px */
            margin: 20px auto !important; /* Centrando la tabla horizontalmente */
            border-collapse: collapse; /* Asegúrate de que los bordes se colapsen */
            font-size: 18px;
            background-color: #f9f9f9;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

            /* Bordes de las celdas */
            .table th, .table td {
                padding: 12px 15px;
                border: 1px solid #dddddd; /* Cambia de border-bottom a border */
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
    <!-- Caja de búsqueda -->
    <div class="row mb-3 justify-content-center">
        <div class="col-md-6">
            <div class="input-group">
                <asp:TextBox ID="txtBuscar" CssClass="form-control" runat="server" Placeholder="Buscar producto, marca o categoría..."></asp:TextBox>
                <asp:Button ID="btnBuscar" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" runat="server" />
            </div>
        </div>
    </div>
    <asp:GridView ID="dgvProductos" runat="server" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged" DataKeyNames="IdProducto" CssClass="table" AutoGenerateColumns="False" AllowPaging="True" PageSize="6" OnPageIndexChanging="dgvProductos_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="StockMinimo" HeaderText="Stock Mínimo" />
            <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" />
            <asp:BoundField DataField="Categoria.Nombre" HeaderText="Categoría" />
            <asp:BoundField DataField="Marca.Nombre" HeaderText="Marca" />
            <asp:BoundField DataField="PorcentajeGanancia" HeaderText="Porcentaje Ganancia" />
            <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha de vencimiento" Visible="false" />
            <asp:CommandField ShowSelectButton="true" SelectText="Ver detalle" HeaderText="Acción" />
        </Columns>
    </asp:GridView>
    <div style="text-align: center; margin-top: 20px;">
        <asp:Button ID="btnAgregarProducto" runat="server" CssClass="btn btn-success mt-3" Text="Agregar" OnClick="btnAgregarProducto_Click" />
    </div>
</asp:Content>
