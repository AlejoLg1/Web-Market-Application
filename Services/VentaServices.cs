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

        public List<dynamic> listar()
        {
            var lista = new List<dynamic>();

            try
            {
                DB.setQuery("SELECT V.IdVenta, C.Nombre, C.Apellido, C.Correo, V.FechaVenta, V.NumeroFactura, V.Estado FROM Venta V JOIN Cliente C ON V.IdCliente = C.IdCliente;");
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    lista.Add(new
                    {
                        IdVenta = (int)DB.Reader["IdVenta"],
                        Nombre = (string)DB.Reader["Nombre"],
                        Apellido = (string)DB.Reader["Apellido"],
                        Correo = (string)DB.Reader["Correo"],
                        FechaVenta = (DateTime)DB.Reader["FechaVenta"],
                        NumeroFactura = (string)DB.Reader["NumeroFactura"],
                        Estado = (bool)DB.Reader["Estado"]
                    });
                }

                return lista;
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

                DB.excecuteQuery();

                int IdVenta = 0;
                if (DB.Reader.Read())
                {
                    IdVenta = Convert.ToInt32(DB.Reader["IdVenta"]);
                }
                return IdVenta;
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
