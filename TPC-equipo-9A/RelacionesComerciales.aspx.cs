using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_9A
{
    public partial class RelacionesComerciales : System.Web.UI.Page
    {
        ProveedorServices serviceProveedor = new ProveedorServices();
        ClienteServices serviceCliente = new ClienteServices();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid(string filters = null)
        {
            try
            {
                List<Proveedor> proveedores = new List<Proveedor>();
                List<Cliente> clientes = new List<Cliente>();

                string tipoRelacion = ddlTipoRelacion.SelectedValue;

                if (!string.IsNullOrEmpty(tipoRelacion))
                {
                    if (tipoRelacion == "Proveedor")
                    {
                        proveedores = serviceProveedor.listar(filters);
                    }
                    else if (tipoRelacion == "Cliente")
                    {
                        clientes = serviceCliente.listar(filters);
                    }
                }
                else
                {
                    proveedores = serviceProveedor.listar(filters);
                    clientes = serviceCliente.listar(filters);
                }


                var relaciones = new List<object>();

                relaciones.AddRange(proveedores.Select(proveedor => new
                {
                    IdRelacion = proveedor.IdProveedor,
                    Nombre = proveedor.Nombre,
                    Apellido = proveedor.Apellido,
                    Correo = proveedor.Correo,
                    Telefono = proveedor.Telefono,
                    Direccion = proveedor.Direccion,
                    DNI = proveedor.DNI,
                    CUIT = proveedor.CUIT,
                    Relacion = "Proveedor"
                }));

                relaciones.AddRange(clientes.Select(cliente => new
                {
                    IdRelacion = cliente.IdCliente,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Correo = cliente.Correo,
                    Telefono = cliente.Telefono,
                    Direccion = cliente.Direccion,
                    DNI = cliente.DNI,
                    CUIT = cliente.CUIT,
                    Relacion = "Cliente"
                }));

                gvRelaciones.DataSource = relaciones;
                gvRelaciones.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreRelacion.Text;
                string dni_cuit = txtDNICUIT.Text;
                string tipoRelacion = ddlTipoRelacion.SelectedValue.ToString();

                string filters = "";

                if (nombre != "")
                {
                    filters += $"Nombre LIKE '%{nombre}%'";
                }

                if (dni_cuit != "")
                {
                    filters += $"(DNI LIKE '%{dni_cuit}%' OR CUIT LIKE '%{dni_cuit}%')";
                }

                BindGrid(filters);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAgregarRelacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarRelacion.aspx", false);
        }


        protected void gvRelaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            int IdRelacion = Convert.ToInt32(gvRelaciones.DataKeys[index].Value);

            GridViewRow row = gvRelaciones.Rows[index];
            Label lblRelacion = (Label)row.FindControl("lblRelacion");
            string relacionTipo = lblRelacion.Text;

            string page;
            object service;
            if (lblRelacion.Text == "Proveedor")
            {
                service = new ProveedorServices();

                page = "ProveedorPage";
            }
            else
            {
                service = new ClienteServices();
                page = "ClientePage";
            }

            switch (e.CommandName)
            {
                case "Editar":
                    Response.Redirect($"{page}.aspx?id={IdRelacion}", false);
                    break;

                case "Eliminar":

                    if (service is ProveedorServices proveedorService)
                    {
                        proveedorService.delete(IdRelacion);
                    }
                    else if (service is ClienteServices clienteService)
                    {
                        clienteService.delete(IdRelacion);
                    }
                    Response.Redirect("RelacionesComerciales.aspx", false);
                    break;

                default:
                    break;
            }
        }

    }
}