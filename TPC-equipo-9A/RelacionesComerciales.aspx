<%@ Page Title="Relaciones Comerciales" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RelacionesComerciales.aspx.cs" Inherits="TPC_equipo_9A.RelacionesComerciales" %>

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
            margin-left: 25px;
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
        <h2>Relaciones Comerciales</h2>
        <div class="row mb-3">

            <div class="col-md-2">
                <label for="txtNombreRelacion">Nombre</label>
                <asp:TextBox ID="txtNombreRelacion" runat="server" CssClass="form-control w-75" />
            </div>

            <div class="col-md-2">
                <label for="ddlTipoRelacion">Tipo de Relación</label>
                <asp:DropDownList ID="ddlTipoRelacion" runat="server" CssClass="form-control w-75">
                    <asp:ListItem Text="Seleccionar" Value="" Selected="True" />
                    <asp:ListItem Text="Cliente" Value="Cliente"></asp:ListItem>
                    <asp:ListItem Text="Proveedor" Value="Proveedor"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-md-2 d-flex align-items-end">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="btnBuscar_Click" />
            </div>

            <div class="col-md-2 offset-md-4 d-flex align-items-end justify-content-end">
                <asp:Button ID="btnAgregarRelacion" runat="server" Text="Agregar Relación" CssClass="btn btn-primary" OnClick="btnAgregarRelacion_Click" />
            </div>
        </div>


        <div class="row mt-5">
            <div class="col">
                <asp:GridView ID="gvRelaciones" runat="server" CssClass="table table-striped" DataKeyNames="IdRelacion" AutoGenerateColumns="False" OnRowCommand="gvRelaciones_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Correo" HeaderText="Correo" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />

                        <asp:TemplateField HeaderText="Relación">
                            <ItemTemplate>
                                <asp:Label ID="lblRelacion" runat="server" Text='<%# Eval("Relacion") %>'
                                    ForeColor='<%# Eval("Relacion").ToString() == "Proveedor" ? System.Drawing.Color.Green : System.Drawing.Color.Blue %>'
                                    Font-Bold="True">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning btn-sm" />
                                <span class="btn-separator"></span>
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-danger btn-sm" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>



            </div>
        </div>
    </div>
</asp:Content>
