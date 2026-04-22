

namespace Dominio
{
    public class GeneradorFijo : IGeneradorAleatorio
    {
        private int _valorActual = 0;

        public int Generar(int max)
        {
            return _valorActual++;
        }
    }
}
