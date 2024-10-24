<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormMarca.aspx.cs" Inherits="TPC_equipo_9A.FormMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
 function confirmarEliminacion(idMarca, nombreMarca) {
     var mensaje = "¿Estás seguro que deseas eliminar la categoría con ID: " + idMarca + " y Nombre: " + nombreMarca + "?";
     return confirm(mensaje);
 }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row justify-content-center mt-5">
     <div class="col-md-6">
         <!-- Título dinámico -->
         <h1 class="text-center">
             <asp:Label ID="lblTitulo" runat="server" Text="Detalle de Categoría"></asp:Label>
         </h1>

         <!-- Fila para ID Marca -->
         <div class="mb-3">
             <label for="txtIdMarca" class="form-label">ID Marca</label>
             <asp:TextBox ID="txtIdMarca" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
         </div>

         <!-- Fila para Nombre -->
         <div class="mb-3">
             <label for="txtNombreMarca" class="form-label">Nombre</label>
             <asp:TextBox ID="txtNombreMarca" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
         </div>

         <!-- Botón para habilitar la edición -->
         <div class="mb-3 text-center">
             <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-success" OnClick="btnVolver_Click" />
             <asp:Button ID="btnModificar" CssClass="btn btn-warning" Text="Modificar Marca" OnClick="btnModificar_Click" runat="server" />
             <asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Guardar Cambios" OnClick="btnGuardar_Click" runat="server" Visible="false" />
             <asp:Button ID="btnEliminar" CssClass="btn btn-danger" Text="Eliminar Marca" OnClick="btnEliminar_Click" runat="server" />
         </div>
     </div>

 </div>
</asp:Content>
