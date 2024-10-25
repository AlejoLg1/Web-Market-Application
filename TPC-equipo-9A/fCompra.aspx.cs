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
    public partial class fCompra : System.Web.UI.Page
    { 
        private CompraServices compraServices = new CompraServices();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    List<Compra> compra = compraServices.listar();
                    gvCompras.DataSource = compra;
                    gvCompras.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAgregarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                int idProveedor = int.Parse(txtIdProveedor.Value);

                string fechaInput = txtFechaCompra.Value;
                DateTime fechaCompra;

                if (!DateTime.TryParseExact(fechaInput, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaCompra))
                {
                    // Si no se pudo convertir la fecha correctamente, mostrar un mensaje de error
                    Response.Write("El formato de la fecha es incorrecto. Por favor ingrese una fecha válida.");
                    return;
                }

                compraServices.IngresarCompra(idProveedor, fechaCompra);

                Response.Write("Compra agregada con éxito.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
    
