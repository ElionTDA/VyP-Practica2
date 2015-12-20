using System;

namespace Logica
{
    public interface ICapaDatos
    {
        /// <summary>
        /// Método para añadir usuario
        /// </summary>
        /// <param name="usuario">Información del Usuario</param>
        bool addUsuario(Usuario usuario);

        /// <summary>
        /// Método para obtener Usuario
        /// </summary>
        /// <param name="nick">Nombre identificativo de Usuario</param>
        Usuario getUsuarioPorNick(String nick);

        /// <summary>
        /// Método parar eliminar el Usuario
        /// </summary>
        /// <param name="nick">Nombre identificativo de Usuario</param>
        bool deleteUsuarioPorNick(String nick);

        /// <summary>
        /// Método para actualizar los datos de usuario
        /// </summary>
        /// <param name="nick">Nombre identificativo de Usuario</param>
        /// <param name="password">Contraseña de Usuario</param>
        /// <param name="v">Nombre de Usuario</param>
        /// <param name="apellido1">Apellido 1 de Usuario</param>
        /// <param name="apellido2">Apellido 2 de Usuario</param>
        /// <param name="fechaNacimiento">fecha de nacimiento</param>
        bool cambiarDatosUsuario(String nick, String password, String v, String apellido1, String apellido2, DateTime fechaNacimiento);


        /// <summary>
        /// Método para cambiar el Password
        /// </summary>
        /// <param name="nick">Nombre identificativo de Usuario</param>
        /// <param name="password">Contraseña Antigua de Usuario</param>
        /// <param name="p">Contraseña Nueva de Usuario</param>
        bool cambiarPassword(String nick, String password, String p);
    }
}