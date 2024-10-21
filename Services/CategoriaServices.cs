using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Models;

namespace Services
{
    public class CategoriaServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public List<Categoria> listar()
        {
            List<Categoria> list = new List<Categoria>();
            try
            {
                DB.setQuery("SELECT * FROM VW_CategoriasGrid");
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    Categoria categoria = new Categoria();

                    categoria.IdCategoria = (int)DB.Reader["IdCategoria"];
                    categoria.Nombre = (string)DB.Reader["Nombre"];

                    list.Add(categoria);
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
