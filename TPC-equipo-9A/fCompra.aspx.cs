using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_9A
{
    public partial class fCompra : System.Web.UI.Page
    {
        private CompraServices compraServices = new CompraServices();
        private DetalleCompraService detalleCompraService = new DetalleCompraService();
        private ProveedorServices proveedorServices = new ProveedorServices();
        private MarcaServices marcaServices = new MarcaServices();
        private CategoriaServices categoriaServices = new CategoriaServices();
        private ProductoServices productoServices = new ProductoServices();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    CompraServices compraService = new CompraServices();
                    gvCompras.DataSource = compraService.list();
                    gvCompras.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int idCompra = int.Parse(btn.CommandArgument); // ID de la compra

                DataTable detalles = detalleCompraService.list(idCompra);

                if (detalles.Rows.Count == 0)
                {
                    LblError.Text = "No se encontraron detalles para esta compra.";
                    LblError.Visible = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#modalDetalleCompra').modal('show');", true);
                }
                else
                {
                    gvDetalleCompra.DataSource = detalles;
                    gvDetalleCompra.DataBind();
                    gvDetalleCompra.Visible = true;

                    // Mostrar el modal
                    ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#modalDetalleCompra').modal('show');", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGenerarCompra_Click(object sender, EventArgs e)
        {
            cargarDropDownLists();
            ScriptManager.RegisterStartupScript(this, GetType(), "showStaticModal", "$('#staticBackdrop').modal('show');", true);
        }

        protected void btnAceptarGenerarCompra_ServerClick(object sender, EventArgs e)
        {

        }

        private void cargarDropDownLists()
        {
            ddlProveedor.DataSource = proveedorServices.listar();
            ddlProveedor.DataTextField = "Nombre";
            ddlProveedor.DataValueField = "IdProveedor";
            ddlProveedor.DataBind();

            ddlMarca.DataSource = marcaServices.listar();
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();

            ddlProducto.DataSource = productoServices.listar();
            ddlProducto.DataTextField = "Nombre";
            ddlProducto.DataValueField = "IdProducto";
            ddlProducto.DataBind();
        }
    }
}
