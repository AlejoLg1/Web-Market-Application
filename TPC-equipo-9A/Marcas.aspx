<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TPC_equipo_9A.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Forzar tamaño y centrado de la tabla */
        .table {
            width: 50% !important; /* Forzar ancho a 50% del contenedor */
            max-width: 600px; /* Limitar el tamaño máximo a 600px */
            margin: 20px auto !important; /* Centrando la tabla horizontalmente */
            border-collapse: collapse;
            font-size: 18px;
            background-color: #f9f9f9;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        /* Bordes de las celdas */
        .table th, .table td {
            padding: 12px 15px;
            border: 1px solid #dddddd;
            text-align: left;
        }

        /* Encabezado de la tabla */
        .table th {
            background-color: #4CAF50;
            color: white;
            text-align: center;
        }

        /* Alternar color de las filas */
        .table tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        /* Efecto hover */
        .table tr:hover {
            background-color: #e0e0e0;
        }

         Centrando el texto 
        .table th, .table td {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h1>Listado de Marcas</h1>
         <!-- Caja de búsqueda -->
<div class="row mb-3 justify-content-center">
    <div class="col-md-6">
        <div class="input-group">
            <asp:TextBox ID="txtBuscar" CssClass="form-control" runat="server" Placeholder="Buscar marca..."></asp:TextBox>
            <asp:Button ID="btnBuscar" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" runat="server" />
        </div>
    </div>
</div>
    <asp:GridView ID="dgvMarca" runat="server" OnSelectedIndexChanged="dgvMarca_SelectedIndexChanged" DataKeyNames="IdMarca" CssClass="table" AutoGenerateColumns="false" AllowPaging="True" PageSize="5" OnPageIndexChanging="dgvMarca_PageIndexChanging">
        <Columns>
            <%--<asp:BoundField DataField="IdMarca" HeaderText="ID Marca" Visible="false" />--%>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:CommandField ShowSelectButton="true" SelectText="Ver detalle" HeaderText="Acción" />

        </Columns>
    </asp:GridView>
  <div style="text-align: center; margin-top: 20px;">
     <asp:Button ID="btnAgregarMarca" runat="server" CssClass="btn btn-success mt-3" Text="Agregar" OnClick="btnAgregarMarca_Click" />
 </div>
</asp:Content>
