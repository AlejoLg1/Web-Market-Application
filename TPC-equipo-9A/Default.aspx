<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_equipo_9A.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        <!-- Incluye el link de Google Fonts para Poppins y Roboto -->
        <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@600&family=Roboto:wght@400&display=swap" rel="stylesheet" >

        body {
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            color: #333;
            }

        .container {
            max-width: 100%;
            padding: 20px;
            box-sizing: border-box;
        }

        h1 {
            font-family:'Poppins', sans-serif;
            font-size: 2.5rem;
            font-weight: bold;
            color: #00796b;
            text-align: center;
            margin-bottom: 10px;
        }

        h3 {
            font-family: 'Roboto', sans-serif;
            font-size: 1.5rem;
            font-weight: normal;
            color: #555;
            text-align: center;
            margin-bottom: 20px;
            line-height: 1.6;
        }

        /* Añadir sombra y un fondo al contenedor */
        .container div {
            background-color: darkgrey;
            border-radius: 8px;
            padding: 20px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
            margin: auto;
            max-width: 90%; /* para que respete el ancho de la barra de navegación */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="container-content">
            <h1>
                <asp:Literal ID="litBienvenida" runat="server" /></h1>
            <%--Título dinámico--%>
            <h3>¡Bienvenido/a a la Plataforma de Gestión de Comercio!<br />
                Estamos listos para ayudarte a gestionar tus productos, pedidos y clientes de forma rápida y eficiente.
            ¿Listo para optimizar tu negocio? Explora nuestras herramientas y encuentra todo lo que necesitas para llevar tu comercio al siguiente nivel.
            </h3>
        </div>
    </div>
</asp:Content>
