using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Models;

namespace Services
{
    public class CompraServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public void IngresarCompra(int IdProveedor, DateTime FechaCompra)
        {
            try
            {
                dbAccess.setQuery("INSERT INTO vw_IngresarCompra (IdProveedor, FechaCompra) VALUES (@IdProveedor, @FechaCompra)");

                dbAccess.setParameter("@IdProveedor", IdProveedor);
                dbAccess.setParameter("@FechaCompra", FechaCompra);

                dbAccess.excecuteAction();
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
