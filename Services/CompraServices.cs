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

        public List<Compra> listar()
        {
            List<Compra> list = new List<Compra>();
            try
            {
                DB.setQuery("Select IdCompra, IdProveedor, FechaCompra from Compra");
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    Compra compra = new Compra();
                    compra.IdCompra = (int)DB.Reader["IdCompra"];
                    compra.IdProveedor = (int)DB.Reader["IdProveedor"];
                    compra.FechaCompra = (DateTime)DB.Reader["FechaCompra"];

                    list.Add(compra);
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
