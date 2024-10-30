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
            try
            {
                int idCliente = int.Parse(txtIdCliente.Value);

                string fechaInput = txtFechaVenta.Value;
                DateTime fechaVenta;

                string NumeroFactura = txtNumeroFactura.Value;

                if (!DateTime.TryParseExact(fechaInput, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaVenta))
                {
                    // Si no se pudo convertir la fecha correctamente, mostrar un mensaje de error
                    Response.Write("El formato de la fecha es incorrecto. Por favor ingrese una fecha válida.");
                    return;
                }

               ventaServices.IngresarCompra(fechaVenta, NumeroFactura, idCliente);

                Response.Write("Compra agregada con éxito.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
    }
}