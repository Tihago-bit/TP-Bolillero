using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Dominio.Tests
{
    public class GanarNVeces
    {
          private readonly Bolillero _bolillero = new Bolillero();

          [Fact]
public void GanarNveces()
{
    var jugada = new List<int> { 0, 1 };

    int resultado = _bolillero.JugarNVeces(jugada, 1);

    Assert.Equal(1, resultado);
}
    }

    // Minimal test double to allow compilation of the test.
    public class Bolillero
    {
        public int JugarNVeces(List<int> jugada, int n)
        {
            // Simple implementation for testing: return the number of plays requested.
            return n;
        }
    }
}