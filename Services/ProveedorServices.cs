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

        public List<Proveedor> listar()
        {
            List<Proveedor> list = new List<Proveedor>();
            try
            {
                DB.setQuery("Select IdProveedor, Nombre, Correo, Telefono, Direccion from Proveedor");
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
    }
}

