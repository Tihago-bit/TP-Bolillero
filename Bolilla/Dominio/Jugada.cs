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
        Numeros = numeros ?? throw new ArgumentNullException(nameof(numeros));

        }
            public bool Jugar(Bolillero bolillero)
    {
        if (bolillero == null) throw new ArgumentNullException(nameof(bolillero));

        foreach (var numero in Numeros)
        {
            if (bolillero.CantidadDentro() == 0)
                return false;

            var bolilla = bolillero.SacarBolilla();

            if (bolilla != numero)
            {
                bolillero.ReingresarBolillas();
                return false;
            }
        }

        bolillero.ReingresarBolillas();
        return true;
        }

        public async Task<int> JugarNVecesAsync(Func<Bolillero> crearBolillero, int veces)
    {
        if (crearBolillero == null) throw new ArgumentNullException(nameof(crearBolillero));
        if (veces < 0) throw new ArgumentOutOfRangeException(nameof(veces));

        var tareas = new List<Task<bool>>(veces);
        for (int i = 0; i < veces; i++)
        {
            tareas.Add(Task.Run(() =>
            {
                var nuevoBolillero = crearBolillero();
                return Jugar(nuevoBolillero);
            }));
        }

        var resultados = await Task.WhenAll(tareas);
        return resultados.Count(r => r);
    }

    }

    public static class BolilleroExtensions
    {
        public static void ReingresarBolillas(this Bolillero bolillero)
        {
            if (bolillero == null) throw new ArgumentNullException(nameof(bolillero));
            
        }
    }
} 

