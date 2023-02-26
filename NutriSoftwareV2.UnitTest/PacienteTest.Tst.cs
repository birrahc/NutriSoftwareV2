using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutriSoftware.Negocio.Svc;

namespace NutriSoftwareV2.UnitTest
{
    [TestClass]
    public class PacienteTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var Pacientes = SvcPaciente.ListarPacientes();
        }
    }
}
