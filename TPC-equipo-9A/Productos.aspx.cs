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
    }
}