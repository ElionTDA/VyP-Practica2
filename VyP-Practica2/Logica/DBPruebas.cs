using System;
using System.Collections.Generic;

namespace Logica
{
    public class DBPruebas : ICapaDatos
    {

        private List<Log> logList;

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
            Usuario u = new Usuario("JoseMari43", Utilidad.cifrar("1234567890a"), 
                "Jose María", "López", "Pérez", new DateTime(1974, 4, 21));
            u.editTipo(TipoUsuario.ADMINISTRADOR);
            listaUsers.Add(u);
            //------------------------------------------------
            logList = new List<Log>();
            logList.Add(new Log(u,u.Tipo, TipoSeccion.SIGN_IN, new DateTime(2015,12,18)));
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
            if (nick!=null && password!=null) {
                foreach (Usuario usuario in listaUsers)
                {
                    if (nick.Equals(usuario.Nick) && usuario.comparaPassword(password))
                    {
                        if(fechaNacimiento!=null) {
                            DateTime t = (DateTime)fechaNacimiento;
                            if (!Utilidad.compruebaFechaValida(t.Year,t.Month,t.Day))
                                return false;
                        }
                        usuario.Nombre = nombre; 
                        usuario.Apellido1 = apellido1; 
                        usuario.Apellido2 = apellido2; 
                        usuario.FechaNacimiento = fechaNacimiento;
                        return true;
                    }
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


        //-----------------------------------------------------------------------
        public void generaLog()
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"registro.txt"))
            {
                foreach (Log l in logList)
                {
                    file.WriteLine(l.stringInforme());
                }
            }
        }

        public bool borrarLog(String nick, String password)
        {
            Usuario u = getUsuarioPorNick(nick);
            if (u != null && u.comparaPassword(password))
            {
                if (u.Tipo == TipoUsuario.ADMINISTRADOR)
                {
                    foreach (Log l in logList)
                    {
                        logList.Remove(l);
                    }
                    return true;
                }
            }
            return false;
        }




    }
}