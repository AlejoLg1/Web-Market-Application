<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarRelacion.aspx.cs" Inherits="TPC_equipo_9A.AgregarRelacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hidden {
            display: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Agregar Relación</h2>
        <div class="row mb-3">
            <div class="col-md-4">
                <label for="ddlTipoRelacion">Tipo de Relación</label>
                <asp:DropDownList ID="ddlTipoRelacion" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoRelacion_SelectedIndexChanged">
                    <asp:ListItem Text="Seleccionar" Value="" Selected="True" />
                    <asp:ListItem Text="Cliente" Value="Cliente"></asp:ListItem>
                    <asp:ListItem Text="Proveedor" Value="Proveedor"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvTipoRelacion" runat="server" ControlToValidate="ddlTipoRelacion" InitialValue="" ErrorMessage="Seleccione un tipo de relación" CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>

        <div id="clienteFields" runat="server" class="hidden">
            <div class="row">
                <div class="col-md-4">
                    <label for="txtNombreCliente">Nombre</label>
                    <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvNombreCliente" runat="server" ControlToValidate="txtNombreCliente" ErrorMessage="Nombre es requerido" CssClass="text-danger" Display="Dynamic" />
                </div>
                <div class="col-md-4">
                    <label for="txtApellidoCliente">Apellido</label>
                    <asp:TextBox ID="txtApellidoCliente" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label for="txtCorreoCliente">Correo</label>
                    <asp:TextBox ID="txtCorreoCliente" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvCorreoCliente" runat="server" ControlToValidate="txtCorreoCliente" ErrorMessage="Correo es requerido" CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revCorreoCliente" runat="server" ControlToValidate="txtCorreoCliente" ErrorMessage="Formato de correo no válido" CssClass="text-danger" Display="Dynamic" ValidationExpression="^\S+@\S+\.\S+$" />
                </div>
                <div class="col-md-4">
                    <label for="txtTelefonoCliente">Teléfono</label>
                    <asp:TextBox ID="txtTelefonoCliente" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvTelefonoCliente" runat="server" ControlToValidate="txtTelefonoCliente" ErrorMessage="Teléfono es requerido" CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revTelefonoCliente" runat="server" ControlToValidate="txtTelefonoCliente" ErrorMessage="Teléfono solo debe contener números, espacios, guiones y el signo +." CssClass="text-danger" Display="Dynamic" ValidationExpression="^[\d\s-+]+$" />
                </div>
                <div class="col-md-4">
                    <label for="txtDireccionCliente">Dirección</label>
                    <asp:TextBox ID="txtDireccionCliente" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvDireccionCliente" runat="server" ControlToValidate="txtDireccionCliente" ErrorMessage="Dirección es requerida" CssClass="text-danger" Display="Dynamic" />
                </div>
            </div>
        </div>

        <div id="proveedorFields" runat="server" class="hidden">
            <div class="row">
                <div class="col-md-4">
                    <label for="txtNombreProveedor">Nombre</label>
                    <asp:TextBox ID="txtNombreProveedor" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvNombreProveedor" runat="server" ControlToValidate="txtNombreProveedor" ErrorMessage="Nombre es requerido" CssClass="text-danger" Display="Dynamic" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label for="txtCorreoProveedor">Correo</label>
                    <asp:TextBox ID="txtCorreoProveedor" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvCorreoProveedor" runat="server" ControlToValidate="txtCorreoProveedor" ErrorMessage="Correo es requerido" CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revCorreoProveedor" runat="server" ControlToValidate="txtCorreoProveedor" ErrorMessage="Formato de correo no válido" CssClass="text-danger" Display="Dynamic" ValidationExpression="^\S+@\S+\.\S+$" />
                </div>
                <div class="col-md-4">
                    <label for="txtTelefonoProveedor">Teléfono</label>
                    <asp:TextBox ID="txtTelefonoProveedor" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvTelefonoProveedor" runat="server" ControlToValidate="txtTelefonoProveedor" ErrorMessage="Teléfono es requerido" CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revTelefonoProveedor" runat="server" ControlToValidate="txtTelefonoProveedor" ErrorMessage="Teléfono solo debe contener números, espacios, guiones y el signo +." CssClass="text-danger" Display="Dynamic" ValidationExpression="^[\d\s-+]+$" />
                </div>
                <div class="col-md-4">
                    <label for="txtDireccionProveedor">Dirección</label>
                    <asp:TextBox ID="txtDireccionProveedor" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvDireccionProveedor" runat="server" ControlToValidate="txtDireccionProveedor" ErrorMessage="Dirección es requerida" CssClass="text-danger" Display="Dynamic" />
                </div>
            </div>
        </div>

        <div class="row mt-3">
            <div class="col-md-2">
                <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" CausesValidation="false" />
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
            </div>
        </div>
    </div>
</asp:Content>

