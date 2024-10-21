using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Models;
using System.Data.SqlClient;

namespace Services
{
    public class ProductoServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public List<Producto> listar()
        {
            List<Producto> list = new List<Producto>();
            try
            {
                DB.setQuery("SELECT * FROM VW_productosGrid");
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    Producto producto = new Producto();

                    producto.IdProducto = (int)DB.Reader["IdProducto"];
                    producto.Nombre = (string)DB.Reader["Nombre"];
                    AsignarMarcaYCategoria(producto, DB.Reader);
                    producto.StockActual = (int)DB.Reader["StockActual"];
                    producto.StockMinimo = (int)DB.Reader["StockMinimo"];
                    producto.PorcentajeGanancia = (decimal)DB.Reader["PorcentajeGanancia"];


                    list.Add(producto);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        private void AsignarMarcaYCategoria(Producto producto, SqlDataReader reader)
        {
            producto.Categoria = new Categoria();
            if (!reader.IsDBNull(reader.GetOrdinal("IdCategoria")))
            {
                producto.Categoria.IdCategoria = (int)reader["IdCategoria"];
                producto.Categoria.Nombre = (string)reader["NombreCategoria"];
            }
            else
            {
                producto.Categoria.IdCategoria = 0;
                producto.Categoria.Nombre = string.Empty;
            }


            producto.Marca = new Marca();
            if (!reader.IsDBNull(reader.GetOrdinal("IdMarca")))
            {
                producto.Marca.IdMarca = (int)reader["IdMarca"];
                producto.Marca.Nombre = (string)reader["NombreMarca"];
            }
            else
            {
                producto.Marca.IdMarca = 0;
                producto.Marca.Nombre = string.Empty;
            }
        }
    }
}
