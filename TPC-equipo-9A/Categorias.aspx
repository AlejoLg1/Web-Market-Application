<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPC_equipo_9A.Categorias" %>

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
            border-bottom: 1px solid #ddd;
            text-align: left;
        }

        /* Encabezado de la tabla */
        .table th {
            background-color: #4CAF50;
            color: white;
            text-align: center
        }

        /* Alternar color de las filas */
        .table tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        /* Efecto hover */
        .table tr:hover {
            background-color: #e0e0e0;
        }

         centrando el texto 
        .table th, .table td {
            text-align: center;
         }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h1>Listado de categorías</h1>
    
    <asp:GridView ID="dgvCategoria" runat="server" OnSelectedIndexChanged="dgvCategoria_SelectedIndexChanged" DataKeyNames="IdCategoria" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <%--<asp:BoundField DataField="IdCategoria" HeaderText="ID Categoria" Visible="false" />--%>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:CommandField ShowSelectButton="true" SelectText="Ver detalle" HeaderText="Acción" />

        </Columns>
    </asp:GridView>
    <div style="text-align: center; margin-top: 20px;">
        <asp:Button ID="btnAgregarCategoria" runat="server" CssClass="btn btn-success mt-3" Text="Agregar" OnClick="btnAgregarCategoria_Click" />
    </div>
</asp:Content>
