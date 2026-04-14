using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio
{
    public class Jugada
    {
        public List<int> Numeros { get; }
        public Jugada(List<int> numeros)
        {
        Numeros = numeros;
        }
            public bool Jugar(List<int> jugada)
        {
            foreach (var numero in jugada)
            {
                if (_bolillas.Count == 0)
                    return false;

                var bolilla = SacarBolilla();

                if (bolilla.Numero != numero)
                {
                    ReingresarBolillas();
                    return false;
                }
            }

            ReingresarBolillas();
            return true;
        }

        public async Task <int> JugarNVecesAsync(List<int>jugada, int veces)
        {
            var tareas = new List<Task<bool>>();
            for (int i = 0; i <veces; i++)
            {
                tareas.Add(Task.Run(() =>
                {
                    var nuevoBolillero = new Bolillero(_n,_generador);
                    return nuevoBolillero.Jugar(jugada);
                }));
            }

        }

    }
} 

