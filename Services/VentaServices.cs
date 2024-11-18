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

        public List<Venta> listar(string filtro = "")
        {
            List<Venta> lista = new List<Venta>();

            try
            {
                string query = "SELECT V.IdVenta, C.Nombre AS NombreCliente, C.Apellido AS ApellidoCliente, " +
                               "C.Correo, V.FechaVenta, V.NumeroFactura, V.Estado " +
                               "FROM Venta V " +
                               "INNER JOIN Cliente C ON V.IdCliente = C.IdCliente";

                if (!string.IsNullOrEmpty(filtro))
                {
                    query += " WHERE C.Nombre LIKE @Filtro " +
                             "OR C.Apellido LIKE @Filtro " +
                             "OR C.Correo LIKE @Filtro " +
                             "OR CAST(V.IdVenta AS NVARCHAR) LIKE @Filtro " +
                             "OR CONVERT(VARCHAR, V.FechaVenta, 103) LIKE @Filtro " +
                             "OR V.NumeroFactura LIKE @Filtro";
                }

                DB.setQuery(query);
                if (!string.IsNullOrEmpty(filtro))
                    DB.setParameter("@Filtro", $"%{filtro}%");

                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    Venta aux = new Venta();
                    aux.IdVenta = (int)DB.Reader["IdVenta"];
                    aux.Cliente = new Cliente();
                    aux.Cliente.Nombre = (string)DB.Reader["NombreCliente"];
                    aux.Cliente.Apellido = (string)DB.Reader["ApellidoCliente"];
                    aux.Cliente.Correo = (string)DB.Reader["Correo"];
                    aux.FechaVenta = (DateTime)DB.Reader["FechaVenta"];
                    aux.NumeroFactura = (string)DB.Reader["NumeroFactura"];
                    aux.Estado = (bool)DB.Reader["Estado"];

                    lista.Add(aux);
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
