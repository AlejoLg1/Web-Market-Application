using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_9A
{
    public partial class fVenta : System.Web.UI.Page
    {
        private VentaServices ventaServices = new VentaServices();
        private DetalleVentaServices detalleVentaServices = new DetalleVentaServices();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    VentaServices ventaServices = new VentaServices();
                    gvVentas.DataSource = ventaServices.list();
                    gvVentas.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showStaticModal", "$('#staticBackdrop').modal('show');", true);
        }

        protected void btnVerDetalleVenta_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int idVenta = int.Parse(btn.CommandArgument);

                DataTable detalles = detalleVentaServices.list(idVenta);

                if (detalles.Rows.Count == 0)
                {
                    LblError.Text = "No se encontraron detalles para esta compra.";
                    LblError.Visible = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#modalDetalleVenta').modal('show');", true);
                }
                else
                {
                    gvDetalleVenta.DataSource = detalles;
                    gvDetalleVenta.DataBind();
                    gvDetalleVenta.Visible = true;

                    // Mostrar el modal
                    ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#modalDetalleVenta').modal('show');", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGenerarVenta_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showStaticModal", "$('#staticBackdrop').modal('show');", true);
        }

        protected void btnAceptarGenerarVenta_ServerClick(object sender, EventArgs e)
        {

        }
    }
}