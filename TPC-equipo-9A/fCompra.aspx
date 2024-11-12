<%@ Page Title="Operaciones" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="fCompra.aspx.cs" Inherits="TPC_equipo_9A.fCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <style>
        .centered-gridview {
            text-align: center; /* Centra el contenido de cada celda */
        }
    </style>

    <script type="text/javascript">
        function toggleSwitchLabel(checkbox) {
            var label = checkbox.nextElementSibling;
            if (checkbox.checked) {
                label.textContent = "Confirmada";
            } else {
                label.textContent = "Anulada";
            }
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div style="width: 100%; display: flex; justify-content: center;">
        <asp:GridView ID="gvCompras" runat="server" AutoGenerateColumns="false" CssClass="centered-gridview" DataKeyNames="IdCompra">
            <Columns>
                <asp:BoundField DataField="IdCompra" HeaderText="ID Compra" />
                <asp:BoundField DataField="NombreProveedor" HeaderText="Proveedor" />
                <asp:BoundField DataField="FechaCompra" HeaderText="Fecha de Compra" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:TemplateField HeaderText="Verificación">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkVerificacion" runat="server"
                            AutoPostBack="true"
                            Checked='<%# Convert.ToInt32(Eval("Estado")) == 1 %>'
                            OnCheckedChanged="chkVerificacion_CheckedChanged" />
                        <asp:Label ID="lblEstado" runat="server"
                            Text='<%# Convert.ToInt32(Eval("Estado")) == 1 ? "Confirmada" : "Anulada" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ver Detalle" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Button ID="btnVerDetalle" runat="server" Text="Ver Detalle" CommandName="VerDetalle" CommandArgument='<%# Eval("IdCompra") %>' OnClick="btnVerDetalle_Click" CssClass="btn btn-link" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <div class="modal fade" id="modalDetalleCompra" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalLabel">Detalles de la Compra</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div style="width: 100%; display: flex; justify-content: center;">
                        <asp:GridView ID="gvDetalleCompra" runat="server" AutoGenerateColumns="false" CssClass="centered-gridview" Visible="false">
                            <Columns>
                                <asp:BoundField DataField="NombreMarca" HeaderText="Marca" />
                                <asp:BoundField DataField="NombreProducto" HeaderText="Producto" />
                                <asp:BoundField DataField="NombreCategoria" HeaderText="Categoria" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <!--<asp:Label ID="LblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>-->
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <asp:Button ID="btnGenerarCompra" runat="server" Text="Generar Compra" CssClass="btn btn-success" OnClick="btnGenerarCompra_Click" />

    <div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="staticBackdropLabel">Generar Compra</h1>
                    <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <!-- Columna 1 -->
                        <div class="col-6">
                            <div class="mb-3">
                                <label for="ddlProveedor" class="form-label">Proveedor: </label>
                                <asp:DropDownList ID="ddlProveedor" CssClass="form-select" runat="server"></asp:DropDownList>
                            </div>

                            <div class="mb-3">
                                <label for="txtFechaCompra">Fecha de Compra: </label>
                                <input type="date" id="txtFechaCompra" runat="server" class="form-control" />
                            </div>

                            <div class="mb-3">
                                <label for="ddlProducto" class="form-label">Producto: </label>
                                <asp:DropDownList ID="ddlProducto" CssClass="form-select" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <!-- Columna 2 -->
                        <div class="col-6">
                            <div class="mb-3">
                                <label for="txtCantidad" class="form-label">Cantidad: </label>
                                <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" />
                            </div>

                            <div class="mb-3">
                                <label for="txtPrecioUnitario" class="form-label">Precio Unitario: </label>
                                <asp:TextBox runat="server" ID="txtPrecioUnitario" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary" id="btnAceptarGenerarCompra" runat="server" onserverclick="btnAceptarGenerarCompra_ServerClick">
                        Generar Compra
                    </button>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
