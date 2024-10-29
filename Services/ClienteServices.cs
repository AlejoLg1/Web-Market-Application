using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Utils;

namespace Services
{
    public class ClienteServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public List<Cliente> listar(string filters = null)
        {
            List<Cliente> list = new List<Cliente>();
            try
            {
                string sqlQuery = "SELECT * FROM Cliente";
                if (!string.IsNullOrEmpty(filters))
                {
                    sqlQuery += $" WHERE {filters}";
                }

                DB.setQuery(sqlQuery);
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.IdCliente = (int)DB.Reader["IdCliente"];
                    cliente.Nombre = (string)DB.Reader["Nombre"];
                    cliente.Apellido = (string)DB.Reader["Apellido"];
                    cliente.Correo = (string)DB.Reader["Correo"];
                    cliente.Telefono = (string)DB.Reader["Telefono"];
                    cliente.Direccion = (string)DB.Reader["Direccion"];

                    list.Add(cliente);
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

        public void add(Cliente newCliente)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("INSERT INTO Cliente (Nombre, Apellido, Correo, Telefono, Direccion) VALUES (@Nom, @Apel, @Cor, @Tel, @Dir)");

                DB.setParameter("@Nom", newCliente.Nombre);
                DB.setParameter("@Apel", newCliente.Apellido);
                DB.setParameter("@Cor", newCliente.Correo);
                DB.setParameter("@Tel", newCliente.Telefono);
                DB.setParameter("@Dir", newCliente.Direccion);

                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FATAL ERROR: Error al crear Cliente. Comuníquese con el Soporte.\nDetalles: {ex.Message}");
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public void modify(Cliente cliente)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("UPDATE Cliente SET Nombre = @Nom, Apellido = @Apel, Correo = @Cor, Telefono = @Tel, Direccion = @Dir WHERE IdCliente = @Id");

                DB.setParameter("@Nom", cliente.Nombre);
                DB.setParameter("@Apel", cliente.Apellido);
                DB.setParameter("@Cor", cliente.Correo);
                DB.setParameter("@Tel", cliente.Telefono);
                DB.setParameter("@Dir", cliente.Direccion);
                DB.setParameter("@Id", cliente.IdCliente);

                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FATAL ERROR: Error al modificar Cliente. Comuníquese con el Soporte.\nDetalles: {ex.Message}");
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public void delete(int id)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("DELETE FROM Cliente WHERE IdCliente = @Id");
                DB.setParameter("@Id", id);
                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FATAL ERROR: Error al eliminar Cliente. Comuníquese con el Soporte.\nDetalles: {ex.Message}");
            }
            finally
            {
                DB.CloseConnection();
            }
        }

    }
}
