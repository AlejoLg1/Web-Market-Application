using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_9A
{
    public partial class ClientePage : System.Web.UI.Page
    {
        ClienteServices clienteService = new ClienteServices();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idCliente;
                if (int.TryParse(Request.QueryString["id"], out idCliente))
                {
                    CargarCliente(idCliente);
                }
            }
        }

        private void CargarCliente(int idCliente)
        {
            Cliente cliente = clienteService.getClient(idCliente);
            if (cliente != null)
            {
                hfIdCliente.Value = cliente.IdCliente.ToString();
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtCorreo.Text = cliente.Correo;
                txtTelefono.Text = cliente.Telefono;
                txtDireccion.Text = cliente.Direccion;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente
                {
                    IdCliente = int.Parse(hfIdCliente.Value),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Correo = txtCorreo.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                };

                clienteService.modify(cliente);

                Response.Redirect("RelacionesComerciales.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RelacionesComerciales.aspx", false);
        }
    }
}
