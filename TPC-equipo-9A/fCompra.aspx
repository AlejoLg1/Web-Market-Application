<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="fCompra.aspx.cs" Inherits="TPC_equipo_9A.fCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="width: 100%; display: flex; justify-content: center;">
<asp:GridView ID="gvCompras" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="IdCompra" HeaderText="ID Compra" />
        <asp:BoundField DataField="IdProveedor" HeaderText="ID Proveedor" />
        <asp:BoundField DataField="FechaCompra" HeaderText="Fecha de Compra" DataFormatString="{0:dd/MM/yyyy}" />
    </Columns>
</asp:GridView>
</div>


<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div>
            <label for="txtIdProveedor">ID Proveedor:</label>
            <input type="text" id="txtIdProveedor" runat="server" class="form-control" />

            <label for="txtFechaCompra">Fecha de Compra:</label>
            <input type="date" id="txtFechaCompra" runat="server" class="form-control" />

            <button type="button" class="btn btn-primary" id="btnAgregarCompra" runat="server" onserverclick="btnAgregarCompra_Click">
                Agregar Compra
            </button>

        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAgregarCompra" EventName="ServerClick" />
    </Triggers>
</asp:UpdatePanel>

</asp:Content>
