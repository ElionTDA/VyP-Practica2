using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;

namespace Test
{
    /// <summary>
    /// Summary description for DBPruebasTest
    /// </summary>
    [TestClass]
    public class DBPruebasTest
    {
        private static DBPruebas dbpruebas = null;
        private Usuario usuario = null;
        private String password = "1234567890a";

        public DBPruebasTest()
        {
            usuario = new Usuario("Pepita33", "1234567890a", "Cantinflas", "Sánchez", "Rajoy", new DateTime(1950, 1, 10));
        }

        [TestInitialize]
        public void Inicializar()
        {
            dbpruebas = DBPruebas.getInstance();
        }

        [TestMethod]
        public void ComprobarAñadirEliminarUsuario()
        {
            //Añadimos el usuario
            Assert.IsTrue(dbpruebas.addUsuario(usuario));
            //Comprobamos que el usuario que añadimos sea el que obtenemos
            Assert.AreEqual(dbpruebas.getUsuarioPorNick(usuario.Nick), usuario);
            //Comprobamos que el usuario se ha eliminado
            Assert.IsTrue(dbpruebas.deleteUsuarioPorNick(usuario.Nick, password));
            //Comprobamos que no existe
            Assert.IsNull(dbpruebas.getUsuarioPorNick(usuario.Nick));
        }

        [TestMethod]
        public void AñadirUsuariosRepetidos()
        {
            //Añadimos el usuario
            Assert.IsTrue(dbpruebas.addUsuario(usuario));
            //Comprobamos que no nos permite añadir el mismo usuario
            Assert.IsFalse(dbpruebas.addUsuario(usuario));
        }

        [TestMethod]
        public void obtenerUsuarioExistente()
        {
            //Añadimos el usuario
            Assert.IsTrue(dbpruebas.addUsuario(usuario));
            //Probamos a pedir un usuario que si existe
            Assert.Equals(dbpruebas.getUsuarioPorNick(usuario.Nick),usuario);
        }

        [TestMethod]
        public void obtenerUsuarioNoExistente()
        {
            //Pedimos un usuario que no existe
            Assert.IsNull(dbpruebas.getUsuarioPorNick("java33"));
        }

        [TestMethod]
        public void modificarNombreUsuario()
        {
            Assert.IsTrue(dbpruebas.addUsuario(usuario));

            //Cambiamos el nombre y nos deja
            Assert.IsTrue(dbpruebas.cambiarDatosUsuario(usuario.Nick, password, "Iglesias", usuario.Apellido1, usuario.Apellido2, usuario.FechaNacimiento));

            //Cambiamos el nombre por null y no nos deja
            try
            {
                dbpruebas.cambiarDatosUsuario(usuario.Nick, password, "null", usuario.Apellido1, usuario.Apellido2, usuario.FechaNacimiento);
                Assert.Fail("El nombre no debería ser nullable.");
            }
            catch (ArgumentNullException e) { }

            //Si el nick o el password son erróneos, tiene que fallar
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario("java33",password, "Pepito", usuario.Apellido1, usuario.Apellido2, usuario.FechaNacimiento));
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario(usuario.Nick, "unpassworddiferente", "Pepito", usuario.Apellido1, usuario.Apellido2, usuario.FechaNacimiento));
        }

        [TestMethod]
        public void modificarPassword()
        {
            //Añadimos un usuario
            Assert.IsTrue(dbpruebas.addUsuario(usuario));
            //Y cambiamos su contraseña
            Assert.IsTrue(dbpruebas.cambiarPassword(usuario.Nick, password, Utilidad.cifrar("nuevacontrasena33")));

            //Comprobamos que la contraseña no es nullable
            try
            {
                dbpruebas.cambiarPassword(usuario.Nick, password, null);
                Assert.Fail("El password no debería ser nullable.");
            }
            //Capturamos que uno de los datos no tiene set definido
            catch (ArgumentNullException e) { }

            //Si el nick no existe, tampoco debería realizar ninguna operación
            Assert.IsFalse(dbpruebas.cambiarPassword("java33",password,Utilidad.cifrar("nuevacontrasena")));
        }

        [TestMethod]
        public void modificarApellido1()
        {
            //Añadimos un usuario
            Assert.IsTrue(dbpruebas.addUsuario(usuario));

            //Cambiamos el apellido1 y nos deja
            Assert.IsTrue(dbpruebas.cambiarDatosUsuario(usuario.Nick, password, usuario.Nombre, "reckles", usuario.Apellido2, usuario.FechaNacimiento));

            //Cambiamos el apellido1 por null y no nos deja
            try
            {
                dbpruebas.cambiarDatosUsuario(usuario.Nick, password, usuario.Nombre, null, usuario.Apellido2, usuario.FechaNacimiento);
                Assert.Fail("El nombre no debería ser nullable.");
            }
            catch (ArgumentNullException e) { }

            //Si el nick o el password son incorrectos, no se debe modificar nada
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario("java33", password, usuario.Nombre, "Pepítez", usuario.Apellido2, usuario.FechaNacimiento));
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario(usuario.Nick, "unpassworddiferente", usuario.Nombre, "Pepítez", usuario.Apellido2, usuario.FechaNacimiento));
        }

        [TestMethod]
        public void modificarApellido2()
        {
            Assert.IsTrue(dbpruebas.addUsuario(usuario));

            //Cambiamos el apellido2 y nos deja
            Assert.IsTrue(dbpruebas.cambiarDatosUsuario(usuario.Nick, password, usuario.Nombre, usuario.Apellido1, "Pepinillos", usuario.FechaNacimiento));

            //Cambiamos el apellido2 por null y no nos deja
            try
            {
                dbpruebas.cambiarDatosUsuario(usuario.Nick, password, usuario.Nombre, usuario.Apellido1, null, usuario.FechaNacimiento);
                Assert.Fail("El nombre no debería ser nullable.");
            }
            catch (ArgumentNullException e) { }

            //Si el nick o el password son incorrectos, no se debe modificar nada
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario("java33", password, usuario.Nombre, usuario.Apellido1, "Pepinillos", usuario.FechaNacimiento));
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario(usuario.Nick, "unpassworddiferente", usuario.Nombre, usuario.Apellido1, "Pepinillos", usuario.FechaNacimiento));
        }

        [TestMethod]
        public void modificarFechaNacimiento()
        {
            //Añadimos un usuario
            Assert.IsTrue(dbpruebas.addUsuario(usuario));

            //Cambiamos el nombre y nos deja
            Assert.IsTrue(dbpruebas.cambiarDatosUsuario(usuario.Nick, password, usuario.Nombre, usuario.Apellido1, usuario.Apellido2, new DateTime(1950,1,11)));

            //Cambiamos la fecha de nacimiento por null y no nos deja
            try
            {
                dbpruebas.cambiarDatosUsuario(usuario.Nick, password, usuario.Nombre, usuario.Apellido1, usuario.Apellido2, null);
                Assert.Fail("El nombre no debería ser nullable.");
            }
            catch (ArgumentNullException e) { }

            //Si el nick o el password son incorrectos, no se debe modificar nada
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario("java33", password, usuario.Nombre, usuario.Apellido1, usuario.Apellido2, new DateTime(1950, 1, 11)));
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario(usuario.Nick, "unpassworddiferente", usuario.Nombre, usuario.Apellido1, usuario.Apellido2, new DateTime(1950, 1, 11)));

            //Si intentamos poner una fecha posterior a hoy, malo (como mucho, puedes nacer hoy).
            DateTime hoy = System.DateTime.Today;
            DateTime mañana = hoy.AddDays(1);
            DateTime ayer = hoy.AddDays(-1);
            Assert.IsTrue(dbpruebas.cambiarDatosUsuario(usuario.Nick, password, usuario.Nombre, usuario.Apellido1, usuario.Apellido2, ayer));
            Assert.IsTrue(dbpruebas.cambiarDatosUsuario(usuario.Nick, password, usuario.Nombre, usuario.Apellido1, usuario.Apellido2, hoy));
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario(usuario.Nick, password, usuario.Nombre, usuario.Apellido1, usuario.Apellido2, mañana));
        }
    }
}
