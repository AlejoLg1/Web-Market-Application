﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="fVenta.aspx.cs" Inherits="TPC_equipo_9A.fVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID Venta" />
            <asp:BoundField DataField="IdCliente" HeaderText="ID Cliente" />
            <asp:BoundField DataField="FechaVenta" HeaderText="Fecha de Venta" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="NumeroFactura" HeaderText="Número de Factura" />
            <asp:TemplateField HeaderText="Ver Detalle" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Button ID="btnVerDetalle" runat="server" Text="Ver Detalle" CommandName="VerDetalle" CommandArgument='<%# Eval("Id") %>' OnClick="btnVerDetalleVenta_Click" CssClass="btn btn-link" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <!--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div>
            <label for="txtIdCliente">ID Cliente:</label>
            <input type="text" id="txtIdCliente" runat="server" class="form-control" />

            <label for="txtFechaVenta">Fecha de Venta:</label>
            <input type="date" id="txtFechaVenta" runat="server" class="form-control" />

            <label for="txtNumeroFactura">Numero Factura:</label>
            <input type="text" id="txtNumeroFactura" runat="server" class="form-control" />

            <button type="button" class="btn btn-primary" id="btnAgregarVenta" runat="server" onserverclick="btnAgregarVenta_Click">
                Agregar Venta
            </button>

        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAgregarVenta" EventName="ServerClick" />
    </Triggers>
</asp:UpdatePanel>-->

    <div class="modal fade" id="modalDetalleVenta" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalLabel">Detalles de la Venta</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:GridView ID="gvDetalleVenta" runat="server" AutoGenerateColumns="false" Visible="false">
                        <Columns>
                            <asp:BoundField DataField="IdDetalleVenta" HeaderText="ID Detalle Venta" />
                            <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
                            <asp:BoundField DataField="PrecioTotal" HeaderText="Precio Total" DataFormatString="{0:C}" />
                        </Columns>
                    </asp:GridView>
                </div>
                <!--<asp:Label ID="LblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>-->
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
