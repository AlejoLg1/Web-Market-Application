using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Models;
using System.Data;

namespace Services
{
    public class VentaServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public DataTable list()
        {
            DataTable table = new DataTable();
            try
            {
                DB.setQuery("SELECT V.IdVenta, C.Nombre, C.Apellido, C.Correo, V.FechaVenta, V.NumeroFactura, V.Estado FROM Venta V JOIN Cliente C ON V.IdCliente = C.IdCliente");
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

        public int add(int IdCliente, DateTime FechaVenta, string NumeroFactura, bool Estado)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("EXEC sp_GenerarVenta @IdCliente, @FechaVenta, @NumeroFactura, @Estado");
                DB.setParameter("@IdCliente", IdCliente);
                DB.setParameter("@FechaVenta", FechaVenta);
                DB.setParameter("@NumeroFactura", NumeroFactura);
                DB.setParameter("Estado", Estado);

                DataTable table = new DataTable();
                table.Load(DB.excecuteQueryWithResult());

                int NewID = Convert.ToInt32(table.Rows[0]["IdVenta"]);

                return NewID;
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

        public void ActualizarEstadoVenta(int IdVenta, int nuevoEstado)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("UPDATE Venta SET Estado = @Estado WHERE IdVenta = @IdVenta");
                DB.setParameter("@Estado", nuevoEstado);
                DB.setParameter("@IdVenta", IdVenta);
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
