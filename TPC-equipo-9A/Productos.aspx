<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_equipo_9A.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilo para la tabla */
        .table {
            width: 50%;
            max-width: 900px;
            margin: 20px auto;
            border-collapse: collapse;
            font-size: 18px;
            background-color: #f9f9f9;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15); /* Sombra suave */
            border-radius: 10px; /* Bordes redondeados */
            overflow: hidden;
        }

        /* Bordes de las celdas */
        .table th, .table td {
            padding: 12px 15px;
            border: 1px solid #dddddd;
        }

        /* Estilo para el encabezado */
        .table th {
            background-color: #4CAF50;
            color: #ffffff;
            font-weight: bold;
            text-align: center;
        }

        /* Cambiar color de las filas alternas */
        .table tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        /* Efecto hover en las filas */
        .table tr:hover {
            background-color: #e0e0e0; /* Resalta la fila */
            cursor: pointer;
        }

        /* Centrar texto de las celdas */
        .table td {
            text-align: center;
            color: #333333; /* Color con buen contraste */
        }

        /* Estilo del título */
        h1 {
            text-align: center;
            font-family: Arial, sans-serif; /* Fuente más moderna */
            font-size: 2em;
            font-weight: bold;
            color: #333333;
            text-decoration: underline;
            text-decoration-color: #4CAF50; /* Subrayado en verde */
        }

        /* Botón de Agregar Producto */
        .btn-success {
            background-color: #28a745;
            color: #ffffff;
            font-size: 18px;
            padding: 10px 20px;
            border-radius: 5px;
            transition: background-color 0.3s ease;
        }

        .btn-success:hover {
            background-color: #218838;
        }

        /* Botón Ver detalle */
        .btn-ver-detalle {
            background-color: #007bff;
            color: #ffffff;
            border: none;
            padding: 5px 10px;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn-ver-detalle:hover {
            background-color: #0056b3;
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
            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:Button ID="btnVerDetalle" runat="server" CssClass="btn-ver-detalle" Text="Ver detalle" CommandName="Select" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div style="text-align: center; margin-top: 20px;">
        <asp:Button ID="btnAgregarProducto" runat="server" CssClass="btn btn-success mt-3" Text="Agregar" OnClick="btnAgregarProducto_Click" />
    </div>
</asp:Content>
