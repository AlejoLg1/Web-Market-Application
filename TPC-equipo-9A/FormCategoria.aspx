<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormCategoria.aspx.cs" Inherits="TPC_equipo_9A.FromCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            </div>

            <!-- Botón para habilitar la edición -->
            <div class="mb-3 text-center">
                <asp:Button ID="btnModificar" CssClass="btn btn-warning" Text="Modificar Categoria" OnClick="btnModificar_Click" runat="server" />
                <asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Guardar Cambios" OnClick="btnGuardar_Click" runat="server" Visible="false" />
                <asp:Button ID="btnEliminar" CssClass="btn btn-danger" Text="Eliminar Categoria" OnClick="btnEliminar_Click" runat="server" />
            </div>
        </div>

    </div>

</asp:Content>
