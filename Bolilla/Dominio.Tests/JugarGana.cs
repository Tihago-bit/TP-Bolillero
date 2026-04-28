using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Dominio; 

namespace Dominio.Tests
{
    public class JugarGana
    {
        [Fact]
        public void VerificarGanada()
        {
            var bolillero = new Bolillero(10, new GeneradorFijo());
            
            var numeros = new List<int> { 0, 1, 2, 3 };

            var resultado = bolillero.Jugar(numeros);

            Assert.False(resultado);
        }
    }
}