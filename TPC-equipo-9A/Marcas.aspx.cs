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
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaServices services = new MarcaServices();
            dgvMarca.DataSource = services.listar();
            dgvMarca.DataBind();
        }
    }
}