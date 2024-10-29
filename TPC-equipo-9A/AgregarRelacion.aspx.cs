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
    public partial class AgregarRelacion : System.Web.UI.Page
    {
        ProveedorServices serviceProveedor = new ProveedorServices();
        ClienteServices serviceCliente = new ClienteServices();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlTipoRelacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoRelacion.SelectedValue == "Cliente")
            {
                clienteFields.Attributes.Remove("class");
                proveedorFields.Attributes.Add("class", "hidden");

                ActivarValidadoresCliente();
                DesactivarValidadoresProveedor();
            }
            else if (ddlTipoRelacion.SelectedValue == "Proveedor")
            {
                proveedorFields.Attributes.Remove("class");
                clienteFields.Attributes.Add("class", "hidden");

                ActivarValidadoresProveedor();
                DesactivarValidadoresCliente();
            }
            else
            {
                clienteFields.Attributes.Add("class", "hidden");
                proveedorFields.Attributes.Add("class", "hidden");

                DesactivarValidadoresCliente();
                DesactivarValidadoresProveedor();
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ddlTipoRelacion.SelectedValue == "Cliente")
            {
                // Validar campos
                if (Page.IsValid)
                {
                    Cliente cliente = new Cliente
                    {
                        Nombre = txtNombreCliente.Text,
                        Apellido = txtApellidoCliente.Text,
                        Correo = txtCorreoCliente.Text,
                        Telefono = txtTelefonoCliente.Text,
                        Direccion = txtDireccionCliente.Text
                    };

                    serviceCliente.add(cliente);
                    Response.Redirect("RelacionesComerciales.aspx", false);
                }
            }
            else if (ddlTipoRelacion.SelectedValue == "Proveedor")
            {
                // Validar campos
                if (Page.IsValid)
                {
                    Proveedor proveedor = new Proveedor
                    {
                        Nombre = txtNombreProveedor.Text,
                        Correo = txtCorreoProveedor.Text,
                        Telefono = txtTelefonoProveedor.Text,
                        Direccion = txtDireccionProveedor.Text
                    };

                    serviceProveedor.add(proveedor);
                    Response.Redirect("RelacionesComerciales.aspx", false);
                }
            }
        }


        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("RelacionesComerciales.aspx", false);
        }

        private void ActivarValidadoresCliente()
        {
            rfvNombreCliente.Enabled = true;
            rfvCorreoCliente.Enabled = true;
            rfvTelefonoCliente.Enabled = true;
            rfvDireccionCliente.Enabled = true;
            revCorreoCliente.Enabled = true;
            revTelefonoCliente.Enabled = true;
        }

        private void DesactivarValidadoresCliente()
        {
            rfvNombreCliente.Enabled = false;
            rfvCorreoCliente.Enabled = false;
            rfvTelefonoCliente.Enabled = false;
            rfvDireccionCliente.Enabled = false;
            revCorreoCliente.Enabled = false;
            revTelefonoCliente.Enabled = false;
        }

        private void ActivarValidadoresProveedor()
        {
            rfvNombreProveedor.Enabled = true;
            rfvCorreoProveedor.Enabled = true;
            rfvTelefonoProveedor.Enabled = true;
            rfvDireccionProveedor.Enabled = true;
            revCorreoProveedor.Enabled = true;
            revTelefonoProveedor.Enabled = true;
        }

        private void DesactivarValidadoresProveedor()
        {
            rfvNombreProveedor.Enabled = false;
            rfvCorreoProveedor.Enabled = false;
            rfvTelefonoProveedor.Enabled = false;
            rfvDireccionProveedor.Enabled = false;
            revCorreoProveedor.Enabled = false;
            revTelefonoProveedor.Enabled = false;
        }
    }
}