using Models;
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
                Session.Add("listaMarcas", services.listar());
                dgvMarca.DataSource = Session["listaMarcas"];
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

        protected void dgvMarca_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMarca.PageIndex = e.NewPageIndex;
            MarcaServices services = new MarcaServices();
            dgvMarca.DataSource = services.listar();
            dgvMarca.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Marca> lista = (List<Marca>)Session["listaMarcas"];
            List<Marca> listaFiltrada = lista.FindAll(x => x.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()));
            dgvMarca.DataSource = listaFiltrada;
            dgvMarca.DataBind();
        }
    }
}