using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_9A
{
    public partial class ControlAcceso : System.Web.UI.Page
    {
        UsuarioServices service = new UsuarioServices();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            try
            {
                List<Usuario> list = service.listar();
                if (list != null)
                {
                    gvUsuarios.DataSource = list;
                    gvUsuarios.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvUsuarios.Rows[rowIndex];
            int IdUsuario = Convert.ToInt32(gvUsuarios.DataKeys[rowIndex].Value.ToString());

            if (e.CommandName == "Editar")
            {
                // Lógica para editar el usuario
                //Response.Redirect($"EditarUsuario.aspx?id={idUsuario}");
            }
            else if (e.CommandName == "Eliminar")
            {
                service.delete(IdUsuario);
                Response.Redirect("ControlAcceso.aspx", false);
            }
            else if (e.CommandName == "VerPerfil")
            {
                // Lógica para ver el perfil del usuario
                //Response.Redirect($"Perfil.aspx?id={idUsuario}");
            }
        }
    }
}