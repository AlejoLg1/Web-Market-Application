<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClientePage.aspx.cs" Inherits="TPC_equipo_9A.ClientePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-header text-center">
                        <h3>Editar Cliente</h3>
                    </div>
                    <div class="card-body">
                        <asp:HiddenField ID="hfIdCliente" runat="server" />
                        <div class="form-group">
                            <label for="txtNombre">Nombre:</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator
                                ID="rfvNombre"
                                runat="server"
                                ControlToValidate="txtNombre"
                                ErrorMessage="El nombre es requerido."
                                CssClass="text-danger"
                                Display="Dynamic" />
                        </div>
                        <div class="form-group mt-3">
                            <label for="txtApellido">Apellido:</label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator
                                ID="rfvApellido"
                                runat="server"
                                ControlToValidate="txtApellido"
                                ErrorMessage="El apellido es requerido."
                                CssClass="text-danger"
                                Display="Dynamic" />
                        </div>
                        <div class="form-group mt-3">
                            <label for="txtCorreo">Correo:</label>
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator
                                ID="rfvCorreo"
                                runat="server"
                                ControlToValidate="txtCorreo"
                                ErrorMessage="El correo es requerido."
                                CssClass="text-danger"
                                Display="Dynamic" />
                            <asp:RegularExpressionValidator
                                ID="revCorreo"
                                runat="server"
                                ControlToValidate="txtCorreo"
                                ErrorMessage="El correo no es válido."
                                CssClass="text-danger"
                                Display="Dynamic"
                                ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" />

                        </div>
                        <div class="form-group mt-3">
                            <label for="txtTelefono">Teléfono:</label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group mt-3">
                            <label for="txtDireccion">Dirección:</label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
                        </div>
                        <div class="d-flex justify-content-between mt-4">
                            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar Cambios" OnClick="btnGuardar_Click" CausesValidation="true" />
                            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
