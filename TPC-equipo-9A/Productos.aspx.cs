using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using Models;

namespace TPC_equipo_9A
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoServices services = new ProductoServices();
            Session.Add("listaProductos", services.listar());
            dgvProductos.DataSource = Session["listaProductos"];
            dgvProductos.DataBind();
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
           var id = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormProducto.aspx?id=" + id);
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormProducto.aspx");
        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;
            ProductoServices services = new ProductoServices();
            dgvProductos.DataSource = services.listar();
            dgvProductos.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Producto> lista = (List<Producto>)Session["listaProductos"];
            List<Producto> listaFiltrada = lista.FindAll(x => RemoveAccents(x.Nombre.ToLower()).Contains(txtBuscar.Text.ToLower()) || RemoveAccents(x.Categoria.Nombre.ToLower()).Contains(txtBuscar.Text.ToLower()) || RemoveAccents(x.Marca.Nombre.ToLower()).Contains(txtBuscar.Text.ToLower()));
            dgvProductos.DataSource= listaFiltrada;
            dgvProductos.DataBind();
        }

        public static string RemoveAccents(string text)
        {
            var withAccents = "áéíóúüñ";
            var withoutAccents = "aeiouun"; // Debe incluir 'u' para la ü.

            for (int i = 0; i < withAccents.Length; i++)
            {
                text = text.Replace(withAccents[i], withoutAccents[i]);
            }

            return text;
        }
    }
}