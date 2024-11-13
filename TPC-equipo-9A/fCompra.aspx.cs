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
                    Session["listaCompra"] = compraServices.listar(); // Inicializar la lista de compras
                    gvCompras.DataSource = Session["listaCompra"];
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
                int idCompra = int.Parse(btn.CommandArgument);

                DataTable detalles = detalleCompraService.list(idCompra);

                if (detalles.Rows.Count == 0)
                {
                    LblError.Text = "No se encontraron detalles para esta compra.";
                    LblError.Visible = true;
                    gvDetalleCompra.Visible = false;
                }
                else
                {
                    gvDetalleCompra.DataSource = detalles;
                    gvDetalleCompra.DataBind();
                    gvDetalleCompra.Visible = true; 
                    LblError.Visible = false;
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#modalDetalleCompra').modal('show');", true);
            }
            catch (Exception ex)
            {
                LblError.Text = "Error al cargar detalles: " + ex.Message;
                LblError.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#modalDetalleCompra').modal('show');", true);
            }
        }

        protected void btnGenerarCompra_Click(object sender, EventArgs e)
        {
            cargarDropDownLists();
            ScriptManager.RegisterStartupScript(this, GetType(), "showStaticModal", "$('#staticBackdrop').modal('show');", true);
        }

        protected void btnAceptarGenerarCompra_ServerClick(object sender, EventArgs e)
        {
            try
            {
                bool Estado = true;
                int IdProveedor = int.Parse(ddlProveedor.SelectedValue);
                string fechaInput = txtFechaCompra.Value;

                DateTime fechaCompra;
                if (!DateTime.TryParseExact(fechaInput, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaCompra))
                {
                    Response.Write("El formato de la fecha es incorrecto. Por favor ingrese una fecha válida.");
                    return;
                }

                int IdCompra = compraServices.add(IdProveedor, fechaCompra, Estado);

                int IdProducto = int.Parse(ddlProducto.SelectedValue);
                int Cantidad = int.Parse(txtCantidad.Text);
                decimal PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);

                detalleCompraService.add(IdCompra, IdProducto, Cantidad, PrecioUnitario);

                gvCompras.DataSource = compraServices.listar();
                gvCompras.DataBind();

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
            ddlProveedor.DataSource = proveedorServices.listar();
            ddlProveedor.DataTextField = "Nombre";
            ddlProveedor.DataValueField = "IdProveedor";
            ddlProveedor.DataBind();

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
                int idCompra = Convert.ToInt32(gvCompras.DataKeys[row.RowIndex].Value);

                // Cambia el estado en la base de datos  (Pruebaaaa)
                bool nuevoEstado = chk.Checked;
                compraServices.ActualizarEstadoCompra(idCompra, nuevoEstado ? 1 : 0);

                Label lblEstado = (Label)row.FindControl("lblEstado");
                lblEstado.Text = nuevoEstado ? "Confirmada" : "Anulada";
            }
            catch (Exception ex)
            {
                LblError.Text = "Error al actualizar el estado de la compra: " + ex.Message;
                LblError.Visible = true;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el texto de búsqueda y eliminar acentos
                string searchText = RemoveAccents(txtBuscar.Text.ToLower());
                var listaCompras = Session["listaCompra"] as List<Compra>;

                if (listaCompras == null || listaCompras.Count == 0)
                {
                    LblError.Text = "No se encontraron datos en la lista de compras.";
                    LblError.Visible = true;
                    return;
                }

                // Filtrar por nombre de proveedor, ID de compra o fecha de compra
                var filteredList = listaCompras.Where(c =>
                   // RemoveAccents(c.NombreProveedor.ToLower()).Contains(searchText) || // Filtra por nombre de proveedor
                    c.IdCompra.ToString().Contains(searchText) || // Filtra por ID de compra
                    c.FechaCompra.ToString("dd/MM/yyyy").Contains(searchText) // Filtra por fecha de compra en formato dd/MM/yyyy
                ).ToList();

                // Actualizar gvCompras con la lista filtrada
                gvCompras.DataSource = filteredList;
                gvCompras.DataBind();
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

