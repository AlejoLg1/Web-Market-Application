using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Models;
using System.Data;
using System.Xml.Linq;

namespace Services
{
    public class CompraServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public List<dynamic> listar()
        {
            var lista = new List<dynamic>();

            try
            {
                DB.setQuery("SELECT Compra.IdCompra, Proveedor.Nombre AS NombreProveedor, Compra.FechaCompra, Compra.Estado FROM Compra INNER JOIN Proveedor ON Compra.IdProveedor = Proveedor.IdProveedor;");
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    lista.Add(new
                    {
                        IdCompra = (int)DB.Reader["IdCompra"],
                        NombreProveedor = (string)DB.Reader["NombreProveedor"],
                        FechaCompra = (DateTime)DB.Reader["FechaCompra"],
                        Estado = (bool)DB.Reader["Estado"]
                    });
                }

                return lista;
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
        public int add(int IdProveedor, DateTime FechaCompra, bool Estado)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("EXEC sp_InsertarCompra @IdProveedor, @FechaCompra, @Estado; SELECT SCOPE_IDENTITY() AS IdCompra;");
                DB.setParameter("@IdProveedor", IdProveedor);
                DB.setParameter("@FechaCompra", FechaCompra);
                DB.setParameter("@Estado", Estado);

                DB.excecuteQuery();

                int IdCompra = 0;
                if (DB.Reader.Read())
                {
                    IdCompra = Convert.ToInt32(DB.Reader["IdCompra"]);
                }
                return IdCompra;
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

        /*public void delete(int IdCompra)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("EXEC sp_AnularCompra @IdCompra");
                DB.setParameter("@IdCompra", IdCompra);
                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DB.CloseConnection();
            }
        }*/

        public void ActualizarEstadoCompra(int IdCompra, int nuevoEstado)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("UPDATE Compra SET Estado = @Estado WHERE IdCompra = @IdCompra");
                DB.setParameter("@Estado", nuevoEstado);
                DB.setParameter("@IdCompra", IdCompra);
                DB.excecuteAction();
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

    }
}