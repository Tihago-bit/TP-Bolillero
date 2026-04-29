using System;
using System.Threading.Tasks;

namespace Dominio
{
    public class Simulacion
    {
        private readonly Func<Bolillero> _crearBolillero;
        private readonly Jugada _jugada;

        public Simulacion(Func<Bolillero> crearBolillero, Jugada jugada)
        {
            _crearBolillero = crearBolillero ?? throw new ArgumentNullException(nameof(crearBolillero));
            _jugada = jugada ?? throw new ArgumentNullException(nameof(jugada));
        }

        public int Ejecutar(int veces)
        {
            if (veces < 0) throw new ArgumentOutOfRangeException(nameof(veces), "veces debe ser mayor o igual a 0");

            var ganadas = 0;
            for (var i = 0; i < veces; i++)
            {
                var bolillero = _crearBolillero();
                if (_jugada.Jugar(bolillero))
                {
                    ganadas++;
                }
            }

            return ganadas;
        }

        public async Task<int> EjecutarAsync(int veces)
        {
            if (veces < 0) throw new ArgumentOutOfRangeException(nameof(veces), "veces debe ser mayor o igual a 0");

            return await _jugada.JugarNVecesAsync(_crearBolillero, veces);
        }

        public double ProbabilidadGanada(int veces)
        {
            if (veces <= 0) return 0d;

            var ganadas = Ejecutar(veces);
            return (double)ganadas / veces;
        }
    }
}
