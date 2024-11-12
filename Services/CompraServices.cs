using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Models;
using System.Data;

namespace Services
{
    public class CompraServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public DataTable list()
        {
            DataTable table = new DataTable();
            try
            {
                DB.setQuery("SELECT Compra.IdCompra, Compra.IdProveedor, Proveedor.Nombre AS NombreProveedor, Compra.FechaCompra, Compra.Estado FROM Compra JOIN Proveedor ON Compra.IdProveedor = Proveedor.IdProveedor");
                DB.excecuteQuery();

                table.Load(DB.Reader);
                return table;
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
                DB.setQuery("EXEC sp_InsertarCompra @IdProveedor, @FechaCompra, @Estado");
                DB.setParameter("@IdProveedor", IdProveedor);
                DB.setParameter("@FechaCompra", FechaCompra);
                DB.setParameter("@Estado", Estado);

                DataTable table = new DataTable();
                table.Load(DB.excecuteQueryWithResult());

                int NewID = Convert.ToInt32(table.Rows[0]["IdCompra"]);

                return NewID;
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