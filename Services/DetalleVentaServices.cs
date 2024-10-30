using System;
using System.Collections.Generic;
using System.Data;
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

        public DataTable list(int IdVenta)
        {
            DataTable table = new DataTable();
            try
            {
                DB.setQuery("SELECT p.Nombre AS NombreProducto, m.Nombre AS NombreMarca, c.Nombre AS NombreCategoria, dv.Cantidad, dv.PrecioUnitario, dv.PrecioTotal FROM DetalleVenta dv JOIN Producto p ON dv.IdProducto = p.IdProducto JOIN Marca m ON p.IdMarca = m.IdMarca JOIN Categoria c ON p.IdTipoProducto = c.IdCategoria WHERE dv.IdVenta = @IdVenta;");
                DB.setParameter("@IdVenta", IdVenta);
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
    }
}
