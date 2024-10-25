<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="fVenta.aspx.cs" Inherits="TPC_equipo_9A.fVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="ID Venta" />
        <asp:BoundField DataField="IdCliente" HeaderText="ID Cliente" />
        <asp:BoundField DataField="FechaVenta" HeaderText="Fecha de Venta" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="NumeroFactura" HeaderText="Número de Factura" />
    </Columns>
</asp:GridView>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
</asp:UpdatePanel>

</asp:Content>
