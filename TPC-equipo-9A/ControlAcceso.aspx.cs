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

        private void BindGrid(string filters = null)
        {
            try
            {
                List<Usuario> list = service.listar(filters);
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
            try
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvUsuarios.Rows[rowIndex];
                int IdUsuario = Convert.ToInt32(gvUsuarios.DataKeys[rowIndex].Value.ToString());

                switch (e.CommandName)
                {
                    case "Editar":
                        Response.Redirect($"Perfil.aspx?id={IdUsuario}&edit={true}");
                        break;

                    case "Eliminar":
                        service.delete(IdUsuario);
                        Response.Redirect("ControlAcceso.aspx", false);
                        break;

                    case "VerPerfil":
                        Response.Redirect($"Perfil.aspx?id={IdUsuario}&edit={false}");
                        break;

                    case "Activar":
                        service.updateEstado(IdUsuario, true);
                        Response.Redirect("ControlAcceso.aspx", false);
                        break;

                    case "Desactivar":

                        if (service.getUser(IdUsuario).Rol == "Administrador")
                        {
                            int admins = service.countActiveAdmins();
                            if (Convert.ToInt32(admins) == 1)
                            {
                                string script = "alert('No es posible Desactivar al único administrador de la plataforma.');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", script, true);
                                return;
                            }
                        }
                        service.updateEstado(IdUsuario, false);
                    
                        if (IdUsuario == Convert.ToInt32(Session["id"]))
                        {
                            Session.Abandon();
                            Response.Redirect("Login.aspx", false);
                            return;
                        }
                        Response.Redirect("ControlAcceso.aspx", false);

                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = txtNombreUsuario.Text;
                string rolSeleccionado = ddlRol.SelectedValue.ToString();
                string estadoSeleccionado = ddlEstado.SelectedValue.ToString();

                string filters = "";

                if (nombreUsuario != "")
                {
                    filters += $"NombreUsuario = '{nombreUsuario}'";
                }

                if (rolSeleccionado != "")
                {
                    if (filters != "")
                    {
                        filters += " and ";
                    }
                    filters += $"Rol = '{rolSeleccionado}'";
                }

                if (estadoSeleccionado != "")
                {
                    if (filters != "")
                    {
                        filters += " and ";
                    }
                    filters += $"Estado = '{estadoSeleccionado}'";
                }

                BindGrid(filters);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}