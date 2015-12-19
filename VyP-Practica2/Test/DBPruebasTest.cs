using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        public DBPruebasTest()
        {
            usuario = new Usuario("Pepita33", "1234567890a", "Cantinflas", "Sánchez", "Rajoy", new DateTime(1950, 1, 10));
        }

        [TestInitialize]
        public void Inicializar()
        {
            dbpruebas = new DBPruebas();
        }

        [TestMethod]
        public void ComprobarAñadirEliminarUsuario()
        {
            //Añadimos el usuario
            Assert.IsTrue(dbpruebas.addUsuario(usuario));
            //Comprobamos que el usuario que añadimos sea el que obtenemos
            Assert.AreEqual(dbpruebas.getUsuarioPorNick(usuario.nick), usuario);
            //Comprobamos que el usuario se ha eliminado
            Assert.IsTrue(dbpruebas.deleteUsuarioPorNick(usuario.nick));
            //Comprobamos que no existe
            Assert.IsNull(dbpruebas.getUsuarioPorNick(usuario.nick));
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
            Assert.Equals(dbpruebas.getUsuarioPorNick(usuario.nick),usuario);
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
            Assert.IsTrue(dbpruebas.cambiarDatosUsuario(usuario.nick, usuario.password, "Iglesias", usuario.apellido1, usuario.apellido2, usuario.fechaNacimiento));

            //Cambiamos el nombre por null y no nos deja
            try
            {
                dbpruebas.cambiarDatosUsuario(usuario.nick, usuario.password, "null", usuario.apellido1, usuario.apellido2, usuario.fechaNacimiento);
                Assert.Fail("El nombre no debería ser nullable.");
            }
            catch (ArgumentNullException e) { }

            //Si el nick o el password son erróneos, tiene que fallar
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario("java33",usuario.password, "Pepito", usuario.apellido1, usuario.apellido2, usuario.fechaNacimiento));
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario(usuario.nick, "unpassworddiferente", "Pepito", usuario.apellido1, usuario.apellido2, usuario.fechaNacimiento));
        }

        [TestMethod]
        public void modificarPassword()
        {
            //Añadimos un usuario
            Assert.IsTrue(dbpruebas.addUsuario(usuario));
            //Y cambiamos su contraseña
            Assert.IsTrue(dbpruebas.cambiarPassword(usuario.nick, usuario.password, Utilidad.cifrar("nuevacontrasena33")));

            //Comprobamos que la contraseña no es nullable
            try
            {
                dbpruebas.cambiarPassword(usuario.nick, usuario.password, null);
                Assert.Fail("El password no debería ser nullable.");
            }
            //Capturamos que uno de los datos no tiene set definido
            catch (ArgumentNullException e) { }

            //Si el nick no existe, tampoco debería realizar ninguna operación
            Assert.IsFalse(dbpruebas.cambiarPassword("java33",usuario.password,Utilidad.cifrar("nuevacontrasena")));
        }

        [TestMethod]
        public void modificarApellido1()
        {
            //Añadimos un usuario
            Assert.IsTrue(dbpruebas.addUsuario(usuario));

            //Cambiamos el apellido1 y nos deja
            Assert.IsTrue(dbpruebas.cambiarDatosUsuario(usuario.nick, usuario.password, usuario.nombre, "reckles", usuario.apellido2, usuario.fechaNacimiento));

            //Cambiamos el apellido1 por null y no nos deja
            try
            {
                dbpruebas.cambiarDatosUsuario(usuario.nick, usuario.password, usuario.nombre, null, usuario.apellido2, usuario.fechaNacimiento);
                Assert.Fail("El nombre no debería ser nullable.");
            }
            catch (ArgumentNullException e) { }

            //Si el nick o el password son incorrectos, no se debe modificar nada
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario("java33", usuario.password, usuario.nombre, "Pepítez", usuario.apellido2, usuario.fechaNacimiento));
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario(usuario.nick, "unpassworddiferente", usuario.nombre, "Pepítez", usuario.apellido2, usuario.fechaNacimiento));
        }

        [TestMethod]
        public void modificarApellido2()
        {
            Assert.IsTrue(dbpruebas.addUsuario(usuario));

            //Cambiamos el apellido2 y nos deja
            Assert.IsTrue(dbpruebas.cambiarDatosUsuario(usuario.nick, usuario.password, usuario.nombre, usuario.apellido1, "Pepinillos", usuario.fechaNacimiento));

            //Cambiamos el apellido2 por null y no nos deja
            try
            {
                dbpruebas.cambiarDatosUsuario(usuario.nick, usuario.password, usuario.nombre, usuario.apellido1, null, usuario.fechaNacimiento);
                Assert.Fail("El nombre no debería ser nullable.");
            }
            catch (ArgumentNullException e) { }

            //Si el nick o el password son incorrectos, no se debe modificar nada
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario("java33", usuario.password, usuario.nombre, usuario.apellido1, "Pepinillos", usuario.fechaNacimiento));
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario(usuario.nick, "unpassworddiferente", usuario.nombre, usuario.apellido1, "Pepinillos", usuario.fechaNacimiento));
        }

        [TestMethod]
        public void modificarFechaNacimiento()
        {
            //Añadimos un usuario
            Assert.IsTrue(dbpruebas.addUsuario(usuario));

            //Cambiamos el nombre y nos deja
            Assert.IsTrue(dbpruebas.cambiarDatosUsuario(usuario.nick, usuario.password, usuario.nombre, usuario.apellido1, usuario.apellido2, new DateTime(1950,1,11)));

            //Cambiamos la fecha de nacimiento por null y no nos deja
            try
            {
                dbpruebas.cambiarDatosUsuario(usuario.nick, usuario.password, usuario.nombre, usuario.apellido1, usuario.apellido2, null);
                Assert.Fail("El nombre no debería ser nullable.");
            }
            catch (ArgumentNullException e) { }

            //Si el nick o el password son incorrectos, no se debe modificar nada
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario("java33", usuario.password, usuario.nombre, usuario.apellido1, usuario.apellido2, new DateTime(1950, 1, 11)));
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario(usuario.nick, "unpassworddiferente", usuario.nombre, usuario.apellido1, usuario.apellido2, new DateTime(1950, 1, 11)));

            //Si intentamos poner una fecha posterior a hoy, malo (como mucho, puedes nacer hoy).
            DateTime hoy = System.DateTime.Today;
            DateTime mañana = hoy.AddDays(1);
            DateTime ayer = hoy.AddDays(-1);
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario(usuario.nick, usuario.password, usuario.nombre, usuario.apellido1, usuario.apellido2, ayer));
            Assert.IsTrue(dbpruebas.cambiarDatosUsuario(usuario.nick, usuario.password, usuario.nombre, usuario.apellido1, usuario.apellido2, hoy));
            Assert.IsFalse(dbpruebas.cambiarDatosUsuario(usuario.nick, usuario.password, usuario.nombre, usuario.apellido1, usuario.apellido2, mañana));
        }
    }
}
