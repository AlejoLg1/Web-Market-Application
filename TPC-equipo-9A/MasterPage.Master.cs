using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_9A
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["rol"] != null)
                    {
                        string userRole = Session["rol"].ToString();
                        if (!string.IsNullOrEmpty(userRole))
                        {
                            if (userRole == "Administrador")
                            {
                                liInicio.Visible = true;
                                liUsuarios.Visible = true;
                                liInventario.Visible = true;
                                liOperaciones.Visible = true;
                            }
                            else if (userRole == "Vendedor")
                            {
                                liInicio.Visible = true;
                                liInventario.Visible = true;
                                liOperaciones.Visible = true;
                            }
                        }
                        else
                        {
                            Session.Add("error", "Rol no especificado");
                            Response.Redirect("Error.aspx", false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

    }
}