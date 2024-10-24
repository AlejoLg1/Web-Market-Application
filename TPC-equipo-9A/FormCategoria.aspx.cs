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
    public partial class FromCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
              
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "")
                {
                    CategoriaServices services = new CategoriaServices();
                    List<Categoria> lista = services.listar(id);
                    Categoria seleccionado = lista[0];

                    //Precargar los datos
                    txtIdCategoria.Text = id;
                    txtNombreCategoria.Text = seleccionado.Nombre;

                    btnEliminar.OnClientClick = "return confirmarEliminacion('" + id + "', '" + seleccionado.Nombre + "');";
                }
                else
                {
                    btnEliminar.Visible = false;
                    btnModificar.Visible = false;
                    btnGuardar.Visible = true;


                    txtIdCategoria.Text = "";
                    txtNombreCategoria.Text = "";


                    txtNombreCategoria.ReadOnly = false;

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
            CategoriaServices services = new CategoriaServices();
            Categoria nuevo = new Categoria();
            nuevo.Nombre = txtNombreCategoria.Text;

            services.add(nuevo);
            Response.Redirect("Categorias.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            CategoriaServices services = new CategoriaServices();
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            services.delete(id);
            Response.Redirect("Categorias.aspx", false);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias.aspx", false);
        }
    }
}