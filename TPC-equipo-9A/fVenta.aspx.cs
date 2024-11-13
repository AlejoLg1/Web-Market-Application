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
        private ClienteServices clienteServices = new ClienteServices();
        private ProductoServices productoServices = new ProductoServices();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session.Add("listaVenta", ventaServices.listar());
                    gvVentas.DataSource = Session["listaVenta"];
                    gvVentas.DataBind();
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
                int idVenta = int.Parse(btn.CommandArgument);

                DataTable detalles = detalleVentaServices.list(idVenta);

                if (detalles.Rows.Count == 0)
                {
                    LblError.Text = "No se encontraron detalles para esta compra.";
                    LblError.Visible = true;
                    gvDetalleVenta.Visible = false;
                }
                else
                {
                    gvDetalleVenta.DataSource = detalles;
                    gvDetalleVenta.DataBind();
                    gvDetalleVenta.Visible = true;
                    LblError.Visible = false;
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#modalDetalleVenta').modal('show');", true);
            }
            catch (Exception ex)
            {
                LblError.Text = "Error al cargar detalles: " + ex.Message;
                LblError.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#modalDetalleVenta').modal('show');", true);
            }
        }

        protected void btnGenerarVenta_Click(object sender, EventArgs e)
        {
            cargarDropDownLists();
            ScriptManager.RegisterStartupScript(this, GetType(), "showStaticModal", "$('#staticBackdrop').modal('show');", true);
        }

        protected void btnAceptarGenerarVenta_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int IdProveedor = int.Parse(ddlCliente.SelectedValue);
                string fechaInput = txtFechaVenta.Value;
                string NumeroFactura = txtNumeroFactura.Text;
                bool Estado = true;

                DateTime fechaVenta;
                if (!DateTime.TryParseExact(fechaInput, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaVenta))
                {
                    Response.Write("El formato de la fecha es incorrecto. Por favor ingrese una fecha válida.");
                    return;
                }

                int IdVenta = ventaServices.add(IdProveedor, fechaVenta, NumeroFactura,Estado);

                int IdProducto = int.Parse(ddlProducto.SelectedValue);
                int Cantidad = int.Parse(txtCantidad.Text);
                decimal PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);

                detalleVentaServices.add(IdVenta, IdProducto, Cantidad, PrecioUnitario);

                gvVentas.DataSource = ventaServices.listar();
                gvVentas.DataBind();

                ScriptManager.RegisterStartupScript(this, GetType(), "closeModal", "$('#staticBackdrop').modal('hide');", true);
            }
            catch (Exception ex)
            {
                LblError.Text = "Error al agregar la compra: " + ex.Message;
                LblError.Visible = true;
            }
        }

        private void cargarDropDownLists()
        {
            ddlCliente.DataSource = clienteServices.listar();
            ddlCliente.DataTextField = "Nombre";
            ddlCliente.DataValueField = "IdCliente";
            ddlCliente.DataBind();

            ddlProducto.DataSource = productoServices.listar();
            ddlProducto.DataTextField = "Nombre";
            ddlProducto.DataValueField = "IdProducto";
            ddlProducto.DataBind();

        }

        protected void chkVerificacion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chk = (CheckBox)sender;
                GridViewRow row = (GridViewRow)chk.NamingContainer;
                int idVenta = Convert.ToInt32(gvVentas.DataKeys[row.RowIndex].Value);

                bool nuevoEstado = chk.Checked;
                ventaServices.ActualizarEstadoVenta(idVenta, nuevoEstado ? 1 : 0);

                Label lblEstado = (Label)row.FindControl("lblEstado");
                lblEstado.Text = nuevoEstado ? "Confirmada" : "Anulada";
            }
            catch (Exception ex)
            {
                LblError.Text = "Error al actualizar el estado de la Venta: " + ex.Message;
                LblError.Visible = true;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                // Actualizar gvCompras con la lista filtrada
                gvVentas.DataBind();
            }
            catch (Exception ex)
            {
                LblError.Text = "Error al realizar la búsqueda: " + ex.Message;
                LblError.Visible = true;
            }
        }

        public static string RemoveAccents(string text)
        {
            var withAccents = "áéíóúÁÉÍÓÚüÜñÑ";
            var withoutAccents = "aeiouAEIOUuUnN";

            for (int i = 0; i < withAccents.Length; i++)
            {
                text = text.Replace(withAccents[i], withoutAccents[i]);
            }

            return text;
        }
        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e); // Llama al método de búsqueda
        }

    }

}
