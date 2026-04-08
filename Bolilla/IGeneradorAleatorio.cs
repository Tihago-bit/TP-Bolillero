using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios
{
    public class IGeneradorAleatorio
    {
        public interface IGeneradorAleatorio
        {
            int Generar(int max);
        }
    }
}