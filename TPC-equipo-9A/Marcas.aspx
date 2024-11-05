<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TPC_equipo_9A.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilo para la tabla */
        .table {
            width: 50%;
            max-width: 600px;
            margin: 20px auto !important;
            border-collapse: collapse;
            font-size: 18px;
            background-color: #f9f9f9;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px; /* Bordes redondeados */
            overflow: hidden; /* Para asegurar que los bordes redondeados se vean correctamente */
        }

            /* Bordes de las celdas */
            .table th, .table td {
                padding: 12px 15px;
                border: 1px solid #dddddd;
                text-align: center; /* Centrado de texto */
            }

            /* Estilo para el encabezado */
            .table th {
                background-color: #4CAF50;
                color: white;
                font-weight: bold;
                width: 50%;
            }

            /* Estilo para el cuerpo de la tabla */
            .table td {
                width: 50%;
            }

            /* Cambiar color de las filas alternas */
            .table tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            /* Efecto hover */
            .table tr:hover {
                background-color: #f1f1f1;
            }

        /* Estilo para el título */
        h1 {
            font-family: 'Arial', sans-serif;
            text-align: center;
            font-size: 2em;
            color: #333;
        }

        .btn:hover {
            transform: translateY(-2px); /* Efecto de elevar el botón */
        }

        /* Estilo para el botón Agregar */
        .btn-success {
            background-color: #28a745;
            color: white;
            font-size: 16px;
            padding: 10px 20px;
            border-radius: 5px;
            transition: background-color 0.3s ease;
        }

            .btn-success:hover {
                background-color: #218838;
            }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h1>Listado de Marcas</h1>
    <!-- Caja de búsqueda -->
    <div class="row mb-3 justify-content-center">
        <div class="col-md-6">
            <div class="input-group">
                <asp:TextBox ID="txtBuscar" CssClass="form-control" runat="server" Placeholder="Buscar marca..."></asp:TextBox>
                <asp:Button ID="btnBuscar" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" runat="server" />
            </div>
        </div>
    </div>
    <asp:GridView ID="dgvMarca" runat="server" OnSelectedIndexChanged="dgvMarca_SelectedIndexChanged" DataKeyNames="IdMarca" CssClass="table" AutoGenerateColumns="false" AllowPaging="True" PageSize="5" OnPageIndexChanging="dgvMarca_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="50%" />
            <asp:TemplateField HeaderText="Ver detalle" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnVerDetalle" runat="server" CommandName="Select" CommandArgument='<%# Eval("IdMarca") %>'>
                        <i class="fa fa-eye"></i> <!-- Ícono de ojo -->
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div style="text-align: center; margin-top: 20px;">
        <asp:Button ID="btnAgregarMarca" runat="server" CssClass="btn btn-success mt-3" Text="Agregar" OnClick="btnAgregarMarca_Click" />
    </div>
</asp:Content>
