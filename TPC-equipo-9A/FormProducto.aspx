﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormProducto.aspx.cs" Inherits="TPC_equipo_9A.FormProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirmarEliminacion(idProducto, nombreProducto) {
            var mensaje = "¿Estás seguro que deseas eliminar el producto con ID: " + idProducto + " y Nombre: " + nombreProducto + "?";
            return confirm(mensaje);
        }
    </script>
    <style>
        .text-green-bold {
            color: green;
            font-weight: bold;
        }

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
        .btn:hover{
             transform: translateY(-2px); /* Efecto de elevar el botón */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center mt-5">
        <div class="col-md-8">
            <!-- Título dinámico -->
            <h1 class="text-center">
                <asp:Label ID="lblTitulo" runat="server" Text="Detalle del Producto"></asp:Label>
            </h1>

            <div class="row">
                <!-- Columna Izquierda (ID Producto, Nombre, Marca, Categoría) -->
                <div class="col-md-6">
                    <!-- Fila para ID Producto -->
                    <div class="mb-3">
                        <asp:label ID="lblIdProducto" runat="server" for="txtIdProducto" class="form-label">ID Producto</asp:label>
                        <asp:TextBox ID="txtIdProducto" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </div>

                    <!-- Fila para Nombre -->
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio." CssClass="text-danger" Display="Dynamic" />
                    </div>

                    <!-- Fila para Marca -->
                    <div class="mb-3">
                        <label for="ddlMarca" class="form-label">Marca</label>
                        <asp:DropDownList ID="ddlMarca" CssClass="form-control" runat="server" Enabled="false"></asp:DropDownList>
                        <asp:ListItem Text="Elija una marca" Value="" Selected="True" />
                        <asp:RequiredFieldValidator ID="rfvMarca" runat="server" ControlToValidate="ddlMarca" ErrorMessage="La marca es obligatoria." CssClass="text-danger" Display="Dynamic" InitialValue="" />
                    </div>

                    <!-- Fila para Categoría -->
                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-label">Categoría</label>
                        <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server" Enabled="false"></asp:DropDownList>
                        <asp:ListItem Text="Elija una Categoría" Value="" Selected="True" />
                        <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="ddlCategoria" ErrorMessage="La categoría es obligatoria." CssClass="text-danger" Display="Dynamic" InitialValue="" />
                    </div>
                </div>

                <!-- Columna Derecha (Stock Actual, Stock Mínimo, Porcentaje de Ganancia) -->
                <div class="col-md-6">
                    <!-- Fila para Stock Actual -->
                    <div class="mb-3">
                        <asp:label ID="lblStockActual" runat="server" for="txtStockActual" class="form-label">Stock Actual</asp:label>
                        <asp:TextBox ID="txtStockActual" CssClass="form-control" runat="server" type="number" min="0" step="1" ReadOnly="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvStockActual" runat="server" ControlToValidate="txtStockActual" ErrorMessage="El stock actual es obligatorio." CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revStockActual" runat="server" ControlToValidate="txtStockActual" ErrorMessage="Solo se permiten números." CssClass="text-danger" ValidationExpression="^\d+$" Display="Dynamic" />
                    </div>

                    <!-- Fila para Stock Mínimo -->
                    <div class="mb-3">
                        <label for="txtStockMinimo" class="form-label">Stock Mínimo</label>
                        <asp:TextBox ID="txtStockMinimo" CssClass="form-control" runat="server" type="number" min="0" step="1" ReadOnly="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvStockMinimo" runat="server" ControlToValidate="txtStockMinimo" ErrorMessage="El stock mínimo es obligatorio." CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revStockMinimo" runat="server" ControlToValidate="txtStockMinimo" ErrorMessage="Solo se permiten números." CssClass="text-danger" ValidationExpression="^\d+$" Display="Dynamic" />
                    </div>

                    <!-- Fila para Porcentaje de Ganancia -->
                    <div class="mb-3">
                        <label for="txtPorcentajeGanancia" class="form-label">Porcentaje de Ganancia</label>
                        <asp:TextBox ID="txtPorcentajeGanancia" CssClass="form-control" runat="server" step="0.01" ReadOnly="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPorcentajeGanancia" runat="server" ControlToValidate="txtPorcentajeGanancia" ErrorMessage="El porcentaje de ganancia es obligatorio." CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revPorcentajeGanancia"
                            runat="server"
                            ControlToValidate="txtPorcentajeGanancia"
                            ErrorMessage="Por favor ingrese un número decimal válido."
                            CssClass="text-danger"
                            Display="Dynamic"
                            ValidationExpression="^\d+(\,\d{1,2})?$" />
                    </div>
                    <div class="mb-3">
                        <label for="txtFechaVencimiento" class="form-label">Fecha de Vencimiento</label>
                        <asp:Label ID="lblOpcional" runat="server" Text="(Opcional)" CssClass="text-green-bold"></asp:Label>
                        <asp:TextBox ID="txtFechaVencimiento" CssClass="form-control" runat="server" ReadOnly="true" Type="date"></asp:TextBox>
                    </div>
                </div>
            </div>

            <!-- Botones de acción centrados -->
            <div class="row mt-5">
                <div class="col text-center">
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary me-3 mb-2" OnClick="btnVolver_Click" CausesValidation="false" />
                    <asp:Button ID="btnModificar" CssClass="btn btn-warning me-3 mb-2" Text="Editar Producto" OnClick="btnModificar_Click" runat="server" />
                    <asp:Button ID="btnGuardar" CssClass="btn btn-success me-3 mb-2" Text="Guardar Cambios" OnClick="btnGuardar_Click" runat="server" Visible="false" />
                    <asp:Button ID="btnEliminar" CssClass="btn btn-danger me-3 mb-2" Text="Eliminar Producto" OnClientClick="return confirmarEliminacion(txtIdProducto.Text, txtNombre.Text);" OnClick="btnEliminar_Click" runat="server" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>
