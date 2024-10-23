using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Models;

namespace Services
{
    public class VentaServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public void IngresarCompra(DateTime FechaVenta, String NumeroFactura, int IdCliente)
        {
            try
            {
                DB.setQuery("INSERT INTO vw_IngresarVenta (IdCliente, FechaVenta, NumeroFactura) VALUES (@IdCliente, @FechaVenta, @NumeroFactura)");

                DB.setParameter("@IdCliente", IdCliente);
                DB.setParameter("@FechaVenta", FechaVenta);
                DB.setParameter("@NumeroFactura", NumeroFactura);

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
