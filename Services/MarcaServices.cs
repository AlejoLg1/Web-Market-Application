using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Models;

namespace Services
{
    public class MarcaServices
    {
        private DataBaseAccess DB = new DataBaseAccess();
        public List<Marca> listar()
        {
            List<Marca> list = new List<Marca>();
            try
            {
                DB.setQuery("SELECT * FROM VW_MarcasGrid");
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    Marca marca = new Marca();

                    marca.IdMarca = (int)DB.Reader["IdMarca"];
                    marca.Nombre = (string)DB.Reader["Nombre"];

                    list.Add(marca);
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
