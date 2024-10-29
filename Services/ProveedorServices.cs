using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Services
{
    public class ProveedorServices
    {
        
        private DataBaseAccess DB = new DataBaseAccess();

        public List<Proveedor> listar(string filters = null)
        {
            List<Proveedor> list = new List<Proveedor>();
            try
            {
                string sqlQuery = "SELECT * FROM Proveedor";
                if (!string.IsNullOrEmpty(filters))
                {
                    sqlQuery += $" WHERE {filters}";
                }

                DB.setQuery(sqlQuery);
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.IdProveedor = (int)DB.Reader["IdProveedor"];
                    proveedor.Nombre = (string)DB.Reader["Nombre"];
                    proveedor.Telefono = (string)DB.Reader["Correo"];
                    proveedor.Correo = (string)DB.Reader["Telefono"];
                    proveedor.Direccion = (string)DB.Reader["Direccion"];

                    list.Add(proveedor);
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

        public void add(Proveedor newProveedor)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("INSERT INTO Proveedor (Nombre, Correo, Telefono, Direccion) VALUES (@Nom, @Cor, @Tel, @Dir)");

                DB.setParameter("@Nom", newProveedor.Nombre);
                DB.setParameter("@Cor", newProveedor.Correo);
                DB.setParameter("@Tel", newProveedor.Telefono);
                DB.setParameter("@Dir", newProveedor.Direccion);

                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FATAL ERROR: Error al crear Proveedor. Comuníquese con el Soporte.\nDetalles: {ex.Message}");
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public void modify(Proveedor proveedor)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("UPDATE Proveedor SET Nombre = @Nom, Correo = @Cor, Telefono = @Tel, Direccion = @Dir WHERE IdProveedor = @Id");

                DB.setParameter("@Nom", proveedor.Nombre);
                DB.setParameter("@Cor", proveedor.Correo);
                DB.setParameter("@Tel", proveedor.Telefono);
                DB.setParameter("@Dir", proveedor.Direccion);
                DB.setParameter("@Id", proveedor.IdProveedor);

                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FATAL ERROR: Error al modificar Proveedor. Comuníquese con el Soporte.\nDetalles: {ex.Message}");
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
                DB.setQuery("DELETE FROM Proveedor WHERE IdProveedor = @Id");
                DB.setParameter("@Id", id);
                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FATAL ERROR: Error al eliminar Proveedor. Comuníquese con el Soporte.\nDetalles: {ex.Message}");
            }
            finally
            {
                DB.CloseConnection();
            }
        }

    }
}

