using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_9A
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UsuarioServices service = new UsuarioServices();

            try
            {
                string username = HttpUtility.HtmlEncode(txtUsername.Text);
                string password = HttpUtility.HtmlEncode(txtPassword.Text);
                
                if (service.validUser(username, password))
                {
                    int IdUsuario = service.getUserId(username, password);
                    Session.Add("id", IdUsuario);
                    Session.Add("rol", service.getUserRol(IdUsuario));
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    lblError.Text = "Usuario o contraseña incorrectos";
                    lblError.Visible = true;
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

