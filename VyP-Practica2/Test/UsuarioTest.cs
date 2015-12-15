using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UsuarioTest
    {
        Usuario usuario1;
        Usuario usuario2;

        public UsuarioTest()
        {
            usuario1 = new Usuario("Juanito", "123456789aA", "Juan", "Perez", "Lopez", new DateTime(1992, 2, 29));
            usuario2 = new Usuario("Pedrito", "123456789aA", "Pedro", "Gonzalez", "Ruiz", new DateTime(1992, 2, 29));
        }

        [TestMethod]
        public void creaUsuario()
        {
            // Crear los Usuarios validos
            try {
                new Usuario("JJ8", "123456789aA", "Juan", "Perez","Lopez",new DateTime(1992, 2, 29));
                new Usuario("JJ9", "123456789aA", null, null, null, null);
            }
            catch(Exception e)
            {
                Assert.Fail("No debería haber fallado");
            }

                ////////////////
                ////  NICK  ////
                ////////////////
            // Nick demasiado corto < 2
            // Nick demasiado largo > 21
            // Nick que empieza por numero.
            // Nick que empiece por caracter especial.

            // Nick demasiado corto < 2
            try
            {
                new Usuario("J", "123456789aA", "Juan", "Perez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Nick demasiado corto");
            }
            catch (Exception e)
            { }

            // Nick demasiado largo > 21
            try
            {
                new Usuario("JuanitoitoitoMolaMuch", "123456789aA", "Juan", "Perez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Nick demasiado largo");
            }
            catch (Exception e)
            { }

            // Nick que empieza por numero.
            try
            {
                new Usuario("1Juanito", "123456789aA", "Juan", "Perez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Nick empieza por número");
            }
            catch (Exception e)
            { }

            // Nick que empiece por caracter especial.
            try
            {
                new Usuario("_Juanito", "123456789aA", "Juan", "Perez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Nick empieza por caracter especial");
            }
            catch (Exception e)
            { }

                //////////////////////
                ////  CONTRASEÑA  ////
                //////////////////////
            // Contraseña demasiado corta. < 8
            // Contraseña demasiado larga. > 25
            // Contraseña sin Mayusculas.
            // Contraseña sin Minusculas.
            // Contraseña sin Números.

            // Contraseña demasiado corta. < 8
            try
            {
                new Usuario("Juanito", "1234567", "Juan", "Perez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Contraseña demasiado corta");
            }
            catch (Exception e)
            { }

            // Contraseña demasiado larga. > 25
            try
            {
                new Usuario("Juanito", "123456789012345678901234aA", "Juan", "Perez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Contraseña demasiado larga");
            }
            catch (Exception e)
            { }

            // Contraseña sin Mayusculas.
            try
            {
                new Usuario("Juanito", "1234567890a", "Juan", "Perez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Contraseña sin mayusculas");
            }
            catch (Exception e)
            { }

            // Contraseña sin Minusculas.
            try
            {
                new Usuario("Juanito", "1234567890A", "Juan", "Perez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Contraseña sin minusculas");
            }
            catch (Exception e)
            { }

            // Contraseña sin Números.
            try
            {
                new Usuario("Juanito", "aAbBcCdDeE", "Juan", "Perez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Contraseña sin numeros");
            }
            catch (Exception e)
            { }

                ///////////////////
                ////  NOMBRE   ////
                ///////////////////
            // Nombre demasiado corto. < 2
            // Nombre demasiado largo > 20
            // Nombre con numeros
            // Nombre con caracteres especiales

            // Nombre demasiado corto. < 2
            try
            {
                new Usuario("Juanito", "1234567890a", "J", "Perez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Nombre demasiado corto");
            }
            catch (Exception e)
            { }

            // Nombre demasiado largo > 20
            try
            {
                new Usuario("Juanito", "1234567890a", "JuanJuanJuanJuanJuanJ", "Perez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Nombre demasiado largo");
            }
            catch (Exception e)
            { }

            // Nombre con numeros.
            try
            {
                new Usuario("Juanito", "1234567890a", "J1uan", "Perez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Nombre empieza por número");
            }
            catch (Exception e)
            { }

            // Nombre con caracteres especiales.
            try
            {
                new Usuario("Juanito", "1234567890a", "_Juan", "Perez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Nombre empieza por número");
            }
            catch (Exception e)
            { }

                /////////////////////
                ////  APELLIDO1  ////
                /////////////////////
            // apellido1 demasiado corto. < 2
            // apellido1 demasiado largo > 20
            // apellido1 con números.
            // apellido1 con caracter especial.

            // apellido1 demasiado corto. < 2
            try
            {
                new Usuario("Juanito", "1234567890a", "Juan", "P", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Apellido1 demasido corto.");
            }
            catch (Exception e)
            { }

            // apellido1 demasiado largo > 20
            try
            {
                new Usuario("Juanito", "1234567890a", "Juan", "PérezPérezPérezPérezP", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Apellido1 demasido largo.");
            }
            catch (Exception e)
            { }

            // apellido1 con número.
            try
            {
                new Usuario("Juanito", "1234567890a", "Juan", "P1érez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Apellido1 empieza por número.");
            }
            catch (Exception e)
            { }

            // apellido1 con caracter especial.
            try
            {
                new Usuario("Juanito", "1234567890a", "Juan", "_Pérez", "Lopez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Apellido1 empieza por caracter especial.");
            }
            catch (Exception e)
            { }


                /////////////////////
                ////  APELLIDO2  ////
                /////////////////////
            // apellido2 demasiado corto
            // apellido2 demasiado largo
            // apellido2 empieza por numero
            // apellido2 que empieza por caracter especial.

            // apellido2 demasiado corto
            try
            {
                new Usuario("Juanito", "1234567890a", "Juan", "Pérez", "L", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Apellido2 demasiado corto.");
            }
            catch (Exception e)
            { }

            // apellido2 demasiado largo
            try
            {
                new Usuario("Juanito", "1234567890a", "Juan", "Pérez", "LópezLópezLópezLópezL", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Apellido2 demasiado largo.");
            }
            catch (Exception e)
            { }

            // apellido2 empieza por numero.
            try
            {
                new Usuario("Juanito", "1234567890a", "Juan", "Pérez", "L1ópez", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Apellido2 con número.");
            }
            catch (Exception e)
            { }

            // apellido2 que empieza por caracter especial.
            try
            {
                new Usuario("Juanito", "1234567890a", "Juan", "Pérez", "_López", new DateTime(1992, 2, 29));
                Assert.Fail("Fallo, Apellido2 con caracter especial.");
            }
            catch (Exception e)
            { }

                ///////////////////////////////
                ////  FECHA DE NACIMIENTO  ////
                ///////////////////////////////
            // Formato de fecha no valida
            // Fecha invalida año
            // Fecha invalida febrero
            // Fecha invalida dia

            // Formato de fecha no valida
            try
            {
                new Usuario("Juanito", "1234567890a", "Juan", "Pérez", "López", 29-2-2001);
                Assert.Fail("Fallo, Formato de fecha no valida.");
            }
            catch (Exception e)
            { }

            // Fecha invalida año
            try
            {
                new Usuario("Juanito", "1234567890a", "Juan", "Pérez", "López", new DateTime(2020, 1, 10));
                Assert.Fail("Fallo, Apellido2 con caracter especial.");
            }
            catch (Exception e)
            { }

            // Fecha invalida febrero
            try
            {
                new Usuario("Juanito", "1234567890a", "Juan", "Pérez", "López", new DateTime(2001, 2, 29));
                Assert.Fail("Fallo, Apellido2 con caracter especial.");
            }
            catch (Exception e)
            { }

            // Fecha invalida dia
            try
            {
                new Usuario("Juanito", "1234567890a", "Juan", "Pérez", "López", new DateTime(2000, 1, 32));
                Assert.Fail("Fallo, Apellido2 con caracter especial.");
            }
            catch (Exception e)
            { }

        } // fin metodo crea usuario

        [TestMethod]
        public void bloqueaUsuarioTest()
        {
            bool flag;
            flag = usuario1.bloqueaUsuario();

            Assert.IsTrue(flag);
            Assert.IsTrue(usuario1.bloqueado);
        }

        [TestMethod]
        public void desbloqueaUsuarioTest()
        {
            bool flag;
            flag = usuario1.desbloqueaUsuario();

            Assert.IsTrue(flag);
            Assert.IsFalse(usuario1.bloqueado);
        }


    }// fin clase usuario
}
