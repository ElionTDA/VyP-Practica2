using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;

namespace Test
{
    [TestClass]
    public class LogTest
    {
        private Log log1;
        private Usuario u1;

        [TestInitialize]
        public void inicializar()
        {
            u1 = new Usuario("Pepita33", "1234567890a", "Cantinflas", "Sánchez", "Rajoy", new DateTime(1950, 1, 10));
            log1 = new Log(u1, TipoUsuario.ADMINISTRADOR, TipoSeccion.SIGN_IN, new DateTime(2015, 1, 1, 10, 10, 15));
        }


        [TestMethod]
        public void stringInforme()
        {
            String cadena = "ADMINISTRADOR Pepita33 realizó SIGN_IN a las 10:10:15 el 1/1/2015";
            String cadena2 = "Pepita33 realizó SIGN_IN a las 10:10:15 el 1/1/2015";
            Assert.AreEqual(cadena, log1.stringInforme());
            Assert.AreNotEqual(cadena2, log1.stringInforme());
            //return log.User.Nombre+": "+log.User.Apellido1+" "+ log.User.Apellido2
        }


    }
}

