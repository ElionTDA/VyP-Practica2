using System;
using System.Collections.Generic;

namespace Logica
{
    public class DBPruebas : ICapaDatos
    {
        private static DBPruebas x = new DBPruebas();
        private static List<Usuario> listaUsers = new List<Usuario>();

        public DBPruebas() { }


        /// <summary>
        /// Método para añadir usuario
        /// </summary>
        /// <param name="usuario">Información del Usuario</param>
        public bool addUsuario(Usuario usuario)
        {
            if (!listaUsers.Contains(usuario))
            {
                listaUsers.Add(usuario);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Método para obtener Usuario
        /// </summary>
        /// <param name="nick">Nombre identificativo de Usuario</param>
        /// <param name="password">Contraseña cifrada del usuario</param>
        public Usuario loginUsuario(String nick, String password)
        {
            foreach (Usuario usuario in listaUsers)
            {
                if (nick.Equals(usuario.Nick) && password.Equals(usuario.Password))
                    return usuario;
            }
            return null;

        }

        /// <summary>
        /// Método parar eliminar el Usuario
        /// </summary>
        /// <param name="nick">Nombre identificativo de Usuario</param>
        /// <param name="password">Contraseña cifrada del usuario</param>
        public bool deleteUsuarioPorNick(String nick, String password)
        {
            foreach (Usuario usuario in listaUsers)
            {
                if (nick.Equals(usuario.Nick) && password.Equals(usuario.Password))
                {
                    listaUsers.Remove(usuario);
                    return true;
                }
            }
            return false;

        }

        /// <summary>
        /// Método para actualizar los datos de usuario
        /// </summary>
        /// <param name="nick">Nombre identificativo de Usuario</param>
        /// <param name="password">Contraseña de Usuario</param>
        /// <param name="v">Nombre de Usuario</param>
        /// <param name="apellido1">Apellido 1 de Usuario</param>
        /// <param name="apellido2">Apellido 2 de Usuario</param>
        /// <param name="fechaNacimiento">fecha de nacimiento</param>
        public bool cambiarDatosUsuario(String nick, String password, String v, String apellido1, String apellido2, DateTime fechaNacimiento)
        {
            bool flag = false;
            foreach (Usuario usuario in listaUsers)
            {
                if (nick.Equals(usuario.Nick) && password.Equals(usuario.Password))
                {
                    if (!apellido1.Equals(usuario.Apellido1)) { usuario.Apellido1 = apellido1; flag = true; }
                    if (!apellido2.Equals(usuario.Apellido2)) { usuario.Apellido2 = apellido2; flag = true; }
                    if (!fechaNacimiento.Equals(usuario.FechaNacimiento)) { usuario.FechaNacimiento = fechaNacimiento; flag = true; }
                    return flag;
                }
            }
            return false;
        }

        /// <summary>
        /// Método para cambiar el Password
        /// </summary>
        /// <param name="nick">Nombre identificativo de Usuario</param>
        /// <param name="password">Contraseña Antigua de Usuario</param>
        /// <param name="p">Contraseña Nueva de Usuario</param>
        public bool cambiarPassword(String nick, String password, String p)
        {
            foreach (Usuario usuario in listaUsers)
            {
                if (nick.Equals(usuario.Nick) && password.Equals(usuario.Password))
                {
                    usuario.Password = p;
                    return true;
                }
            }
            return false;

        }
    }
}