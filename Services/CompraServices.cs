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
        public void add(Compra compra)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("sp_InsertarCompra @IdProveedor, @FechaCompra");

                DB.setParameter("@Nombre", compra.IdProveedor);
                DB.setParameter("@IdMarca", compra.FechaCompra);

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
