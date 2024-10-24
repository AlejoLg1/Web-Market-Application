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
        private DataBaseAccess dbAccess = new DataBaseAccess();

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
               dbAccess.CloseConnection();
            }
        }
    }
}
