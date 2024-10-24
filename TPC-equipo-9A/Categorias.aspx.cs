using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace TPC_equipo_9A
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaServices services = new CategoriaServices();
                List<Categoria> categorias = services.listar();
                dgvCategoria.DataSource = categorias;
                dgvCategoria.DataBind();
            }
        }

        protected void dgvCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvCategoria.SelectedDataKey.Value.ToString();
            Response.Redirect("FormCategoria.aspx?id=" + id);
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormCategoria.aspx", false);
        }

        protected void dgvCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCategoria.PageIndex = e.NewPageIndex;
            CategoriaServices services = new CategoriaServices();
            dgvCategoria.DataSource = services.listar();
            dgvCategoria.DataBind();
        }
    }
}