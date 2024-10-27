using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Services
{
   public class ProveedorProductoServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public List<ProveedorProducto> listar()
        {
            List<ProveedorProducto> list = new List<ProveedorProducto>();
            try
            {
                DB.setQuery("Select IdProveedorProducto, IdProveedor, IdProducto, PrecioCompra, FechaCompra from ProveedorProducto");
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    ProveedorProducto proveedorProducto = new ProveedorProducto();
                    proveedorProducto.IdProveedorProducto = (int)DB.Reader["IdProveedorProducto"];
                    proveedorProducto.IdProveedor = (int)DB.Reader["IdProveedor"];
                    proveedorProducto.IdProducto = (int)DB.Reader["IdProducto"];
                    proveedorProducto.PrecioCompra = (decimal)DB.Reader["PrecioCompra"];
                    proveedorProducto.FechaCompra = (DateTime)DB.Reader["FechaCompra"];

                    list.Add(proveedorProducto);
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
