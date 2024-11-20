using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
                string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                int idCliente = int.Parse(ddlCliente.SelectedValue);
                DateTime fechaVenta = DateTime.Parse(txtFechaVenta.Value);
                bool estado = true;

                int idVenta = 0;
                string numeroFactura = string.Empty; 

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GenerarVenta", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                        cmd.Parameters.AddWithValue("@FechaVenta", fechaVenta);
                        cmd.Parameters.AddWithValue("@Estado", estado);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idVenta = Convert.ToInt32(reader["IdVenta"]);
                                numeroFactura = reader["NumeroFactura"].ToString();
                            }
                        }
                    }
                }

                if (idVenta > 0)
                {
                    int idProducto = int.Parse(ddlProducto.SelectedValue);
                    int cantidad = int.Parse(txtCantidad.Text);
                    decimal precioUnitario = decimal.Parse(txtPrecioUnitario.Text);

                    detalleVentaServices.add(idVenta, idProducto, cantidad, precioUnitario);

                    gvVentas.DataSource = ventaServices.listar();
                    gvVentas.DataBind();

                    ScriptManager.RegisterStartupScript(this, GetType(), "closeModal", "$('#staticBackdrop').modal('hide');", true);
                }
                else
                {
                    LblError.Text = "Error al generar la venta. Por favor, intente nuevamente.";
                    LblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                LblError.Text = "Ocurrió un error: " + ex.Message;
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
                string filtro = txtBuscar.Text.Trim();
                List<Venta> listaFiltrada = ventaServices.listar(filtro);
                gvVentas.DataSource = listaFiltrada;
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

        protected void gvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvVentas.PageIndex = e.NewPageIndex;
                if (Session["listaVenta"] != null)
                {
                    gvVentas.DataSource = Session["listaVenta"];
                    gvVentas.DataBind();
                }
            }
            catch (Exception ex)
            {
                LblError.Text = "Error al cambiar de página: " + ex.Message;
                LblError.Visible = true;
            }
        }
    }

}
