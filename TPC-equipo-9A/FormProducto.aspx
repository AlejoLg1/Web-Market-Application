<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormProducto.aspx.cs" Inherits="TPC_equipo_9A.FormProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirmarEliminacion(idProducto, nombreProducto) {
            var mensaje = "¿Estás seguro que deseas eliminar el producto con ID: " + idProducto + " y Nombre: " + nombreProducto + "?";
            return confirm(mensaje);
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center mt-5">
        <div class="col-md-6">
            <!-- Título dinámico -->
            <h1 class="text-center">
                <asp:Label ID="lblTitulo" runat="server" Text="Detalle del Producto"></asp:Label>
            </h1>

            <!-- Fila para ID Producto -->
            <div class="mb-3">
                <label for="txtIdProducto" class="form-label">ID Producto</label>
                <asp:TextBox ID="txtIdProducto" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
            </div>

            <!-- Fila para Nombre -->
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
            </div>

            <!-- Fila para Marca -->
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
            </div>

            <!-- Fila para Categoría -->
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
            </div>

            <!-- Fila para Stock Actual -->
            <div class="mb-3">
                <label for="txtStockActual" class="form-label">Stock Actual</label>
                <asp:TextBox ID="txtStockActual" CssClass="form-control" ReadOnly="true" runat="server" type="number" min="0" step="1"></asp:TextBox>
            </div>

            <!-- Fila para Stock Mínimo -->
            <div class="mb-3">
                <label for="txtStockMinimo" class="form-label">Stock Mínimo</label>
                <asp:TextBox ID="txtStockMinimo" CssClass="form-control" ReadOnly="true" runat="server" type="number" min="0" step="1"></asp:TextBox>
            </div>

            <!-- Fila para Porcentaje de Ganancia -->
            <div class="mb-3">
                <label for="txtPorcentajeGanancia" class="form-label">Porcentaje de Ganancia</label>
                <asp:TextBox ID="txtPorcentajeGanancia" CssClass="form-control" ReadOnly="true" runat="server" type="number" step="0.01"></asp:TextBox>
            </div>

            <!-- Botones de acción -->
            <div class="mb-3 text-center">
                <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-success" OnClick="btnVolver_Click" />
                <asp:Button ID="btnModificar" CssClass="btn btn-warning" Text="Modificar Producto" OnClick="btnModificar_Click" runat="server" />
                <asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Guardar Cambios" OnClick="btnGuardar_Click" runat="server" Visible="false" />
                <asp:Button ID="btnEliminar" CssClass="btn btn-danger" Text="Eliminar Producto"  OnClick="btnEliminar_Click"  runat="server" />
            </div>
        </div>
    </div>

</asp:Content>
