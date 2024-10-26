using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Utils;

namespace Services
{
   public class DetalleVentaServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public List<DetalleVenta> listar()
        {
            List<DetalleVenta> list = new List<DetalleVenta>();
            try
            {
                DB.setQuery("Select IdDetalleVenta, IdVenta, IdProducto, Cantidad, PrecioUnitario, PrecioTotal from DetalleVenta");
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    DetalleVenta detalleVenta = new DetalleVenta();
                    detalleVenta.IdDetalleVenta = (int)DB.Reader["IdDetalleVenta"];
                    detalleVenta.IdVenta = (int)DB.Reader["IdVenta"];
                    detalleVenta.IdProducto = (int)DB.Reader["IdProducto"];
                    detalleVenta.Cantidad = (int)DB.Reader["Cantidad"];
                    detalleVenta.PrecioUnitario = (decimal)DB.Reader["PrecioUnitario"];
                    detalleVenta.PrecioTotal = (decimal)DB.Reader["PrecioTotal"];

                    list.Add(detalleVenta);
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
    }
}
