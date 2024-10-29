using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                    Apellido = "-",
                    Correo = proveedor.Correo,
                    Telefono = proveedor.Telefono,
                    Direccion = proveedor.Direccion,
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
}