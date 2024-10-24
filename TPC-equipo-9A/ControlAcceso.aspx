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
        <div class="row mb-3">

            <div class="col-md-2">
                <label for="txtNombreUsuario">Nombre de Usuario</label>
                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control w-75" />
            </div>

            <div class="col-md-2">
                <label for="ddlRol">Rol</label>
                <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control w-75">
                    <asp:ListItem Text="" Value="" Selected="True" />
                    <asp:ListItem Text="Vendedor" Value="Vendedor"></asp:ListItem>
                    <asp:ListItem Text="Administrador" Value="Administrador"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <label for="ddlEstado">Estado</label>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control w-75">
                    <asp:ListItem Text="" Value="" Selected="True" />
                    <asp:ListItem Text="Activo" Value="true"></asp:ListItem>
                    <asp:ListItem Text="Inactivo" Value="false"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-md-3 d-flex align-items-end">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="btnBuscar_Click"/>
            </div>

            <div class="col-md-3 d-flex justify-content-end align-items-center">
                <asp:Button ID="btnAgregarUsuario" runat="server" Text="Agregar Usuario" CssClass="btn btn-primary" />
            </div>
        </div>

        <div class="row mt-5">
            <div class="col">
                <asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-striped" DataKeyNames="IdUsuario" AutoGenerateColumns="False" OnRowCommand="gvUsuarios_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="UsuarioID" HeaderText="ID" Visible="False" />
                        <asp:ImageField DataImageUrlField="FotoPerfil" HeaderText="" ControlStyle-CssClass="image-thumbnail" NullDisplayText="/images/user.png" />
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
        </div>
    </div>
</asp:Content>
