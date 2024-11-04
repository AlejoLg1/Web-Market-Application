﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormCategoria.aspx.cs" Inherits="TPC_equipo_9A.FromCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirmarEliminacion(idCategoria, nombreCategoria) {
            var mensaje = "¿Estás seguro que deseas eliminar la categoría con ID: " + idCategoria + " y Nombre: " + nombreCategoria + "?";
            return confirm(mensaje);
        }
    </script>
    <style>
        h1 {
            font-family: 'Arial', sans-serif;
            text-align: center;
            font-size: 2em;
            color: #333;
        }

        .row {
            font-weight: bold;
        }

        .btn {
            font-size: 16px;
            padding: 10px 20px;
            border-radius: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center mt-5">
        <div class="col-md-6">
            <!-- Título dinámico -->
            <h1 class="text-center">
                <asp:Label ID="lblTitulo" runat="server" Text="Detalle de Categoría"></asp:Label>
            </h1>

            <!-- Fila para ID Categoria -->
            <div class="mb-3">
                <label for="txtIdCategoria" class="form-label">ID Categoria</label>
                <asp:TextBox ID="txtIdCategoria" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
            </div>

            <!-- Fila para Nombre -->
            <div class="mb-3">
                <label for="txtNombreCategoria" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombreCategoria" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>

                <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
                    ControlToValidate="txtNombreCategoria"
                    ErrorMessage="El Nombre es obligatorio."
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>

            <!-- Botón para habilitar la edición -->
            <div class="row mt-5">
                <div class="col text-center">
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-primary me-3 mb-2" OnClick="btnVolver_Click" CausesValidation="false" />
                    <asp:Button ID="btnModificar" CssClass="btn btn-warning me-3 mb-2" Text="Modificar Categoria" OnClick="btnModificar_Click" runat="server" />
                    <asp:Button ID="btnGuardar" CssClass="btn btn-success me-3 mb-2" Text="Guardar Cambios" OnClick="btnGuardar_Click" runat="server" Visible="false" />
                    <asp:Button ID="btnEliminar" CssClass="btn btn-danger me-3 mb-2" Text="Eliminar Categoria" OnClick="btnEliminar_Click" runat="server" />
                </div>
            </div>
            <!-- label error-->
            <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

        </div>
    </div>
</asp:Content>
