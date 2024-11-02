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
    public class DetalleCompraService
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public DataTable list(int IdCompra)
        {
            DataTable table = new DataTable();
            try
            {
                DB.setQuery("SELECT m.Nombre AS NombreMarca, p.Nombre AS NombreProducto, c.Nombre AS NombreCategoria, dc.Cantidad, dc.PrecioUnitario FROM DetalleCompra dc JOIN Producto p ON dc.IdProducto = p.IdProducto JOIN Marca m ON p.IdMarca = m.IdMarca JOIN Categoria c ON p.IdTipoProducto = c.IdCategoria WHERE dc.IdCompra = @IdCompra;");
                DB.setParameter("@IdCompra", IdCompra);
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

        public void add(DetalleCompra detalleCompra)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("sp_InsertarDetalleCompra @IdCompra, @IdProducto, @Cantidad, @PrecioUnitario");

                DB.setParameter("@IdCompra", detalleCompra.IdCompra);
                DB.setParameter("@IdProducto", detalleCompra.IdProducto);
                DB.setParameter("@Cantidad", detalleCompra.Cantidad);
                DB.setParameter("@PrecioUnitario", detalleCompra.PrecioUnitario);

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



