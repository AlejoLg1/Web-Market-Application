using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Utils;


namespace Services
{
    public class UsuarioServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public void add(Usuario newUsuario)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("INSERT INTO Usuario (NombreUsuario, Contrasena, Rol, FotoPerfil) VALUES (@NombreUsuario, @Contrasena, @Rol, @FotoPerfil)");

                DB.setParameter("@NombreUsuario", newUsuario.NombreUsuario);
                DB.setParameter("@Contrasena", newUsuario.Contrasena);
                DB.setParameter("@Rol", newUsuario.Rol);
                DB.setParameter("@FotoPerfil", newUsuario.FotoPerfil);

                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FATAL ERROR: Error al crear Usuario. Comuníquese con el Soporte.\nDetalles: {ex.Message}");
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public void modify(Usuario usuario)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("UPDATE Usuario SET NombreUsuario = @Nombre, Contrasena = @Cont, Rol = @R, FotoPerfil = @Foto WHERE IdUsuario = @Id");

                DB.setParameter("@Nombre", usuario.NombreUsuario);
                DB.setParameter("@Cont", usuario.Contrasena);
                DB.setParameter("@R", usuario.Rol);
                DB.setParameter("@Foto", usuario.FotoPerfil);
                DB.setParameter("@Id", usuario.IdUsuario);

                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FATAL ERROR: Error al modificar Usuario. Comuníquese con el Soporte.\nDetalles: {ex.Message}");
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
                DB.setQuery("DELETE FROM Usuario WHERE IdUsuario = @IdUsuario");
                DB.setParameter("@IdUsuario", id);
                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FATAL ERROR: Error al modificar Usuario. Comuníquese con el Soporte.\nDetalles: {ex.Message}");
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public bool validUser(string username, string password)
        {
            try
            {
                bool response = false;
                DB.clearParameters();
                DB.setQuery("Select IdUsuario from Usuario where NombreUsuario = @username and Contrasena = @password");
                DB.setParameter("@username", username);
                DB.setParameter("@password", password);
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    response = true;
                }

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Credenciales inválidas. Acceso denegado.");
                return false;
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public int getUserId(string username, string password)
        {
            try
            {
                int id = 0;
                DB.clearParameters();
                DB.setQuery("Select IdUsuario from Usuario where NombreUsuario = @username and Contrasena = @password");
                DB.setParameter("@username", username);
                DB.setParameter("@password", password);
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    id = Convert.ToInt32(DB.Reader["IdUsuario"]);
                }

                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Credenciales inválidas. Acceso denegado.");
                return 0;
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public string getUserRol(int Id)
        {
            try
            {
                string rol = "";
                DB.clearParameters();
                DB.setQuery("Select Rol from Usuario where IdUsuario = @id");
                DB.setParameter("@id", Id);
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    rol = DB.Reader["Rol"].ToString();
                }

                return rol;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Credenciales inválidas. Acceso denegado.");
                return "";
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public Usuario getUser(int Id)
        {
            try
            {
                Usuario user = new Usuario();
                DB.clearParameters();
                DB.setQuery("SELECT IdUsuario, NombreUsuario, Contrasena, Rol, FotoPerfil FROM Usuario WHERE IdUsuario = @id");
                DB.setParameter("@id", Id);
                DB.excecuteQuery();

                if (DB.Reader.Read())
                {
                    user.IdUsuario = DB.Reader["IdUsuario"] != DBNull.Value ? Convert.ToInt32(DB.Reader["IdUsuario"]) : 0;
                    user.NombreUsuario = DB.Reader["NombreUsuario"] != DBNull.Value ? DB.Reader["NombreUsuario"].ToString() : null;
                    user.Contrasena = DB.Reader["Contrasena"] != DBNull.Value ? DB.Reader["Contrasena"].ToString() : null;
                    user.Rol = DB.Reader["Rol"] != DBNull.Value ? DB.Reader["Rol"].ToString() : null;
                    user.FotoPerfil = DB.Reader["FotoPerfil"] != DBNull.Value ? DB.Reader["FotoPerfil"].ToString() : "/images/user.png";
                }

                if (user.IdUsuario == 0)
                {
                    return null;
                }

                return user;
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.CloseConnection();
            }
        }

    }

}
