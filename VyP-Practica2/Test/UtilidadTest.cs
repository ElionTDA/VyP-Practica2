using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UtilidadTest
    {


        [TestMethod]
        public void compruebaNickTest()
        {
            Assert.IsFalse(Utilidad.compruebaNick("P"));
            Assert.IsTrue(Utilidad.compruebaNick("Jose Francisco"));
            Assert.IsFalse(Utilidad.compruebaNick("DiegoDiegoDiegoDiegoD"));
            Assert.IsTrue(Utilidad.compruebaNick("Iñaki"));
            Assert.IsFalse(Utilidad.compruebaNick("-Pepe"));
            Assert.IsTrue(Utilidad.compruebaNick("Pe-pe"));
            Assert.IsFalse(Utilidad.compruebaNick("1Pepe"));
            Assert.IsTrue(Utilidad.compruebaNick("Pepe23"));
            Assert.IsFalse(Utilidad.compruebaNick(null));
        }


        [TestMethod]
        public void compruebaNombreTest()
        {
            Assert.IsFalse(Utilidad.compruebaNombre("P"));
            Assert.IsTrue(Utilidad.compruebaNombre("Jose Francisco"));
            Assert.IsFalse(Utilidad.compruebaNombre("DiegoDiegoDiegoDiegoD"));
            Assert.IsTrue(Utilidad.compruebaNombre("Iñaki"));
            Assert.IsFalse(Utilidad.compruebaNombre("-Pepe"));
            Assert.IsFalse(Utilidad.compruebaNombre("P1epe"));
            Assert.IsFalse(Utilidad.compruebaNombre(null));
        }

        [TestMethod()]
        public void compruebaFechaValidaTest()
        {
            Assert.IsFalse(Utilidad.compruebaFechaValida(2001, 08, 32));   //Miramos los máximos y mínimos de día
            Assert.IsFalse(Utilidad.compruebaFechaValida(2001, 08, 0));
            Assert.IsFalse(Utilidad.compruebaFechaValida(2001, 08, -1));

            Assert.IsFalse(Utilidad.compruebaFechaValida(2000, 13, 05)); //Miramos los máximos y mínimos de mes
            Assert.IsFalse(Utilidad.compruebaFechaValida(2000, 0, 05));
            Assert.IsFalse(Utilidad.compruebaFechaValida(2000, -1, 05));

            Assert.IsFalse(Utilidad.compruebaFechaValida(2016, 10, 06));  //Miramos los máximos y mínimos de año
            Assert.IsFalse(Utilidad.compruebaFechaValida(0, 06, 06));
            Assert.IsFalse(Utilidad.compruebaFechaValida(-1, 0, 05));


            Assert.IsFalse(Utilidad.compruebaFechaValida(2005, 04, 31)); //tiene 30 dias
            Assert.IsTrue(Utilidad.compruebaFechaValida(2005, 04, 30)); //tiene 30 dias

            Assert.IsFalse(Utilidad.compruebaFechaValida(2005, 05, 32)); //tiene 31 dias
            Assert.IsTrue(Utilidad.compruebaFechaValida(2005, 05, 31)); //tiene 31 dias

            Assert.IsFalse(Utilidad.compruebaFechaValida(2000, 02, 30)); //tiene 29 dias
            Assert.IsTrue(Utilidad.compruebaFechaValida(2000, 02, 29)); //tiene 29 dias

            Assert.IsFalse(Utilidad.compruebaFechaValida(2001, 02, 29)); //tiene 28 dias
            Assert.IsTrue(Utilidad.compruebaFechaValida(2001, 02, 28)); //tiene 28 dias
        }


    } // fin clase
}
