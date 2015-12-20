using System;
using System.Collections.Generic;

namespace Logica
{
    public class DBPruebas : ICapaDatos
    {
        /// <summary>
        /// Almacena la instancia única de la clase.
        /// </summary>
        private static DBPruebas instance = null;

        /// <summary>
        /// Almacena la lista de usuarios que posteriormente se manejará.
        /// </summary>
        private static List<Usuario> listaUsers = null;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        private DBPruebas()
        {
             listaUsers = new List<Usuario>();
        }

        /// <summary>
        /// Generador de singleton
        /// </summary>
        /// <returns>Instancia única de la clase.</returns>
        public static DBPruebas getInstance()
        {
            if (instance == null)
                instance = new DBPruebas();
            return instance;
        }

        /// <summary>
        /// Eliminar DBPruebas
        /// </summary>
        /// <returns>Borrar estado DBPruebas</returns>
        public static void removeDBPruebas()
        {
            if (instance != null)
            {
                instance = null;
            }
        }


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
        /// Método para obtener Usuario en el Login
        /// </summary>
        /// <param name="nick">Nombre identificativo de Usuario</param>
        /// <param name="password">Contraseña cifrada del usuario</param>
        public Usuario loginUsuario(String nick, String password)
        {
            Usuario user = getUsuarioPorNick(nick);
            if (user!=null && user.comparaPassword(password))
            {
                return user;
            }
            return null;

        }

        /// <summary>
        /// Método para obtener Usuario en el Login
        /// </summary>
        /// <param name="nick">Nombre identificativo de Usuario</param>
        /// <param name="password">Contraseña cifrada del usuario</param>
        public Usuario getUsuarioPorNick(String nick)
        {
            foreach (Usuario usuario in listaUsers)
            {
                if (nick.Equals(usuario.Nick))
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
                if (nick.Equals(usuario.Nick) && usuario.comparaPassword(password))
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
        /// <param name="nombre">Nombre de Usuario</param>
        /// <param name="apellido1">Apellido 1 de Usuario</param>
        /// <param name="apellido2">Apellido 2 de Usuario</param>
        /// <param name="fechaNacimiento">fecha de nacimiento</param>
        public bool cambiarDatosUsuario(String nick, String password, String nombre, String apellido1, 
            String apellido2, DateTime? fechaNacimiento)
        {
            bool flag = false;
            foreach (Usuario usuario in listaUsers)
            {
                if (nick.Equals(usuario.Nick) && usuario.comparaPassword(password))
                {
                    if (!nombre.Equals(usuario.Nombre)) { usuario.Nombre = nombre; flag = true; }
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
                if (nick.Equals(usuario.Nick) && usuario.comparaPassword(password))
                {
                    usuario.Password = p;
                    return true;
                }
            }
            return false;

        }
    }
}