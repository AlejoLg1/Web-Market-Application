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

                if (service.ValidUser(username, password))
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    lblError.Text = "Usuario o contraseña incorrectos";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
        }
    }
}

