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
            if (!IsPostBack)
            {
                
                txtDNI.Text = ""; 
                txtCUIT.Text = "";
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoRelacion = ddlTipoRelacion.SelectedValue;
            string tipoPersona = ddlTipoPersona.SelectedValue;

            txtDNI.Enabled = false;
            lblDNI.Visible = true; 
            rfvDNI.Enabled = false;

            txtCUIT.Enabled = false;
            lblCUIT.Visible = true;
            rfvCUIT.Enabled = false;
            
            if (tipoRelacion != "" && tipoPersona != "")
            {
                PersonFields.Attributes.Remove("class");
                DatosPersonales.Attributes.Remove("class");

                if (tipoPersona == "Fisica")
                {
                    txtDNI.Enabled = true;
                    txtCUIT.Text = "";
                    rfvDNI.Enabled = true;
                }
                else
                {
                    txtCUIT.Enabled = true;
                    txtDNI.Text = "";
                    rfvCUIT.Enabled = true;
                }
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if (ddlTipoRelacion.SelectedValue == "Cliente")
            {
                if (Page.IsValid)
                {
                    Cliente cliente = new Cliente
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Correo = txtCorreo.Text,
                        Telefono = txtTelefono.Text,
                        Direccion = txtDireccion.Text,
                        TipoPersona = ddlTipoPersona.SelectedValue,
                        DNI = txtDNI.Text,
                        CUIT = txtCUIT.Text
                    };

                    serviceCliente.add(cliente);
                    Response.Redirect("RelacionesComerciales.aspx", false);
                }
            }
            else if (ddlTipoRelacion.SelectedValue == "Proveedor")
            {
                if (Page.IsValid)
                {
                    Proveedor proveedor = new Proveedor
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Correo = txtCorreo.Text,
                        Telefono = txtTelefono.Text,
                        Direccion = txtDireccion.Text,
                        TipoPersona = ddlTipoPersona.SelectedValue.ToString(),
                        DNI = txtDNI.Text,
                        CUIT = txtCUIT.Text
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


    }
}