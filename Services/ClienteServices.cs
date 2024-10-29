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
    }
}
