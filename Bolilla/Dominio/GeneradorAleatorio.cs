using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio
{
    public class GeneradorAleatorio : IGeneradorAleatorio
    {
        private readonly Random _random = new Random();

        public int Generar(int max)
        {
            if (max <= 0) throw new ArgumentOutOfRangeException(nameof(max), "max debe ser mayor que 0");
            return _random.Next(max); 
        }
    }
}
