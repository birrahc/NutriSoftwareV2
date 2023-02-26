using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutriSoftware.Negocio.Svc;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriSoftwareV2.UnitTest
{
    [TestClass]
    public class Testes
    {
        [TestMethod]
        public void teste() 
        {
            var teste = SvcPaciente.testes();
        }
    }
}
