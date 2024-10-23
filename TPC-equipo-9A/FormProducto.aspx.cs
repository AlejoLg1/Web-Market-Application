using Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;
using Models;
using System.Globalization;

namespace TPC_equipo_9A
{
    public partial class FormProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    CategoriaServices categoriaServices = new CategoriaServices();
                    List<Categoria> categorias = categoriaServices.listar();

                    ddlCategoria.DataSource = categorias;
                    ddlCategoria.DataTextField = "Nombre"; // El nombre de la columna que quieres mostrar
                    ddlCategoria.DataValueField = "IdCategoria"; // El valor de la columna (ID)
                    ddlCategoria.DataBind();

                    MarcaServices marcaServices = new MarcaServices();
                    List<Marca> marcas = marcaServices.listar(); 

                    ddlMarca.DataSource = marcas;
                    ddlMarca.DataTextField = "Nombre"; // El nombre de la columna que quieres mostrar
                    ddlMarca.DataValueField = "IdMarca"; // El valor de la columna (ID)
                    ddlMarca.DataBind();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "")
                {
                    ProductoServices services = new ProductoServices();
                    List<Producto> lista = services.listar(id);
                    Producto seleccionado = lista[0];

                    //Precargar los datos
                    txtIdProducto.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtPorcentajeGanancia.Text = seleccionado.PorcentajeGanancia.ToString();
                    txtStockActual.Text = seleccionado.StockActual.ToString();
                    txtStockMinimo.Text = seleccionado.StockMinimo.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.IdCategoria.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.IdMarca.ToString();

                }
                else
                {
                    lblTitulo.Text = "Registrar Producto";

                    btnEliminar.Visible = false;
                    btnModificar.Visible = false;
                    btnGuardar.Visible = true;


                    txtIdProducto.Text = "";
                    txtNombre.Text = "";
                    txtPorcentajeGanancia.Text = "";
                    txtStockActual.Text = "";
                    txtStockMinimo.Text = "";
                    
                   
                    txtNombre.ReadOnly = false;
                    txtPorcentajeGanancia.ReadOnly = false;
                    txtStockActual.ReadOnly = false;
                    txtStockMinimo.ReadOnly = false;
                    ddlCategoria.Enabled = true;
                    ddlMarca.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
           
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoServices services = new ProductoServices();
                Producto nuevo = new Producto();
                nuevo.Nombre = txtNombre.Text;
                //decimal porcentajeGanancia;

                //if (!decimal.TryParse(txtPorcentajeGanancia.Text, NumberStyles.Any, new CultureInfo("es-AR"), out porcentajeGanancia))
                //{
                //    Session["error"] = "El porcentaje de ganancia es inválido.";
                //    Response.Redirect("Error.aspx", false);
                //    return; // Salir del método si la conversión falla
                //}
                //nuevo.PorcentajeGanancia = porcentajeGanancia;
                nuevo.PorcentajeGanancia = decimal.Parse(txtPorcentajeGanancia.Text);
                nuevo.StockMinimo = int.Parse(txtStockMinimo.Text);
                nuevo.StockActual = int.Parse(txtStockActual.Text);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Marca = new Marca();
                nuevo.Marca.IdMarca = int.Parse(ddlMarca.SelectedValue);

                services.add(nuevo);
                Response.Redirect("Productos.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}