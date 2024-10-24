<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ControlAcceso.aspx.cs" Inherits="TPC_equipo_9A.ControlAcceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .image-thumbnail {
            width: 45px;
            height: 45px;
            border-radius: 50%;
        }

        .table td, .table th {
            vertical-align: middle; 
            text-align: center;
        }

        .btn-separator {
            margin-left: 100px; 
        }

        .estado-activo {
            color: green;
            font-weight: bold;
        }

        .estado-inactivo {
            color: red;
            font-weight: bold;
        }

        .btn {
            min-width: 100px; 
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Control de Acceso</h2>
        <asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-striped" DataKeyNames="IdUsuario" AutoGenerateColumns="False" OnRowCommand="gvUsuarios_RowCommand">
            <Columns>
                <asp:BoundField DataField="UsuarioID" HeaderText="ID" Visible="False" />
                <asp:ImageField DataImageUrlField="FotoPerfil" HeaderText="" ControlStyle-CssClass="image-thumbnail" NullDisplayText="/images/user.png"/>
                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
                <asp:BoundField DataField="Rol" HeaderText="Rol" />
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <span class='<%# Convert.ToBoolean(Eval("Estado")) ? "estado-activo" : "estado-inactivo" %>'>
                            <%# Convert.ToBoolean(Eval("Estado")) ? "Activo" : "Inactivo" %>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning btn-sm" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-danger btn-sm" />
                        <asp:Button ID="btnVerPerfil" runat="server" Text="Ver Perfil" CommandName="VerPerfil" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-info btn-sm" />

                        <span class="btn-separator"></span>

                        <asp:Button ID="btnActivar" runat="server" Text="Activar" CommandName="Activar" CommandArgument='<%# Container.DataItemIndex %>' 
                            CssClass="btn btn-success btn-sm" Visible='<%# !Convert.ToBoolean(Eval("Estado")) %>' />

                        <asp:Button ID="btnDesactivar" runat="server" Text="Desactivar" CommandName="Desactivar" CommandArgument='<%# Container.DataItemIndex %>' 
                            CssClass="btn btn-secondary btn-sm" Visible='<%# Convert.ToBoolean(Eval("Estado")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
