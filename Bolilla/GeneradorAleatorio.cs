using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolilla
{
    public class GeneradorAleatorio : IGeneradorAleatorio
    {
        private Random _random = new Random();

        public int Generar(int max)
        {
            return _random.Next(0, max);
        }
    }
}
