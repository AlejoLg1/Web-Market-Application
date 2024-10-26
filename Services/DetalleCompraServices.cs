using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Utils;

namespace Services
{
   public class DetalleCompraService
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public List<DetalleCompra> listar()
        {
            List<DetalleCompra> list = new List<DetalleCompra>();
            try
            {
                DB.setQuery("Select IdDetalleCompra, IdCompra, IdProducto, Cantidad, PrecioUnitario from DetalleCompra");
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    DetalleCompra detalleCompra = new DetalleCompra();
                    detalleCompra.IdDetalleCompra = (int)DB.Reader["IdDetalleCompra"];
                    detalleCompra.IdCompra = (int)DB.Reader["IdCompra"];
                    detalleCompra.IdProducto = (int)DB.Reader["IdProducto"];
                    detalleCompra.Cantidad = (int)DB.Reader["Cantidad"];
                    detalleCompra.PrecioUnitario = (decimal)DB.Reader["PrecioUnitario"];

                    list.Add(detalleCompra);
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
