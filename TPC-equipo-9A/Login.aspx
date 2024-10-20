<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_equipo_9A.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-header text-center">
                        <h3>Login</h3>
                    </div>
                    <div class="card-body">
                        <asp:Panel ID="LoginPanel" runat="server">
                            <div class="form-group">
                                <label for="username">Nombre de Usuario</label>
                                <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" placeholder="Usuario" />
                                <asp:RequiredFieldValidator 
                                    ID="rfvUsername" 
                                    runat="server" 
                                    ControlToValidate="txtUsername" 
                                    ErrorMessage="El nombre de usuario es requerido" 
                                    CssClass="text-danger" 
                                    Display="Dynamic" />
                            </div>
                            <div class="form-group mt-3">
                                <label for="password">Contraseña</label>
                                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" placeholder="Contraseña" />
                                <asp:RequiredFieldValidator 
                                    ID="rfvPassword" 
                                    runat="server" 
                                    ControlToValidate="txtPassword" 
                                    ErrorMessage="La contraseña es requerida" 
                                    CssClass="text-danger" 
                                    Display="Dynamic" />
                            </div>
                            <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="False" />
                            <div class="d-grid gap-2 mt-4">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary btn-block" Text="Iniciar sesión" OnClick="btnSubmit_Click"/>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
