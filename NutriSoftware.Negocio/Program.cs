using NutriSoftware.Negocio.Svc;
using System;

namespace NutriSoftware.Negocio
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = SvcPaciente.ListarPacientes();
        }
    }
}
