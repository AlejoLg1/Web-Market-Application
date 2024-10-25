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

        public List<Venta> listar()
        {
            List<Venta> list = new List<Venta>();
            try
            {
                DB.setQuery("Select IdVenta, IdCliente as Cliente, FechaVenta, NumeroFactura from Venta");
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    Venta venta = new Venta();
                    venta.Id = (int)DB.Reader["IdVenta"];
                    venta.IdCliente = (int)DB.Reader["Cliente"];
                    venta.FechaVenta = (DateTime)DB.Reader["FechaVenta"];
                    venta.NumeroFactura = (string)DB.Reader["NumeroFactura"];

                    list.Add(venta);
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
