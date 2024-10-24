using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;

namespace TPC_equipo_9A
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoServices services = new ProductoServices();
            dgvProductos.DataSource = services.listar();
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
    }
}