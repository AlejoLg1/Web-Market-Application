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
                DB.setQuery("SELECT Compra.IdCompra, Compra.IdProveedor, Proveedor.Nombre AS NombreProveedor, Compra.FechaCompra FROM Compra JOIN Proveedor ON Compra.IdProveedor = Proveedor.IdProveedor");
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
        public void IngresarCompra(int IdProveedor, DateTime FechaCompra)
        {
            try
            {
                DB.setQuery("INSERT INTO vw_IngresarCompra (IdProveedor, FechaCompra) VALUES (@IdProveedor, @FechaCompra)");

                DB.setParameter("@IdProveedor", IdProveedor);
                DB.setParameter("@FechaCompra", FechaCompra);

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
