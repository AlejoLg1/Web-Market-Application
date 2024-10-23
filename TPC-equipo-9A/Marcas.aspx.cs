using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_9A
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MarcaServices services = new MarcaServices();
                dgvMarca.DataSource = services.listar();
                dgvMarca.DataBind();
            }
        }

        protected void dgvMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvMarca.SelectedDataKey.Value.ToString();
            Response.Redirect("FormMarca.aspx?id=" + id);
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormMarca.aspx", false);
        }
    }
}