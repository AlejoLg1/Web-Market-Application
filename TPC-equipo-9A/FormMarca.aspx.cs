﻿using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_9A
{
    public partial class FormMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "")
                {
                    MarcaServices services = new MarcaServices();
                    List<Marca> lista = services.listar(id);
                    Marca seleccionado = lista[0];

                    //Precargar los datos
                    txtIdMarca.Text = id;
                    txtNombreMarca.Text = seleccionado.Nombre;

                    //Pregunta de confirmacion al eliminar
                    btnEliminar.OnClientClick = "return confirmarEliminacion('" + id + "', '" + seleccionado.Nombre + "');";

                }
                else
                {
                    btnEliminar.Visible = false;
                    btnModificar.Visible = false;
                    btnGuardar.Visible = true;


                    txtIdMarca.Text = "";
                    txtNombreMarca.Text = "";


                    txtNombreMarca.ReadOnly = false;

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
            MarcaServices services = new MarcaServices();
            Marca nuevo = new Marca();
            nuevo.Nombre = txtNombreMarca.Text;

            services.add(nuevo);
            Response.Redirect("Marcas.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            MarcaServices services = new MarcaServices();
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            services.delete(id);
            Response.Redirect("Marcas.aspx", false);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marcas.aspx", false);
        }
    }
}