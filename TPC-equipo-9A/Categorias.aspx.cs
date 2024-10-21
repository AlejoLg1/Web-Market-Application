using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;

namespace TPC_equipo_9A
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaServices services = new CategoriaServices ();
            dgvCategoria.DataSource = services.listar();
            dgvCategoria.DataBind();
        }
    }
}