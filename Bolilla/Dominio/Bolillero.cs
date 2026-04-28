using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Dominio 
{
    public class Bolillero
    {
        private List<int> _bolillas;
        private List<int> _sacadas;
        private IGeneradorAleatorio _generador;
        private int _n;
        
        public List<int> Jugada { get; set; }

        public Bolillero(int n, IGeneradorAleatorio generador)
        {
            if (n < 1) throw new ArgumentException("n debe ser mayor o igual a 1", nameof(n));
            _n = n;
            _generador = generador ?? throw new ArgumentNullException(nameof(generador));
            InicializarBolillas();
        }

        private void InicializarBolillas()
        {
            _bolillas = new List<int>();
    _sacadas = new List<int>();
    
    // ¡AQUÍ ESTÁ EL CAMBIO! Empezamos en 0 y ponemos i < _n
    for (int i = 0; i < _n; i++) 
    {
        _bolillas.Add(i);
    }
        }

        public int SacarBolilla()
        {
            if (_bolillas == null || _bolillas.Count == 0)
                throw new InvalidOperationException("No quedan bolillas para sacar.");

            int index = _generador.Generar(_bolillas.Count);
            if (index < 0 || index >= _bolillas.Count)
                throw new InvalidOperationException("Índice generado fuera de rango.");
            int bolilla = _bolillas[index];
            _bolillas.RemoveAt(index);
            _sacadas.Add(bolilla);

            return bolilla;
        }
                public int CantidadDentro()
        {
            return _bolillas?.Count ?? 0;
        }

        public int CantidadSacadas()
        {
            return _sacadas?.Count ?? 0;
        }

        public bool Jugar(List<int> numeros)
        {
            foreach (int numeroApostado in numeros)
    {
        // Sacamos una bolilla del bolillero
        int bolillaSacada = SacarBolilla();

        // Si la bolilla que salió no es igual al número que el jugador esperaba, pierde
        if (bolillaSacada != numeroApostado)
        {
            return false;
        }
    }

    // Si terminó de revisar toda la lista y todas las bolillas coincidieron, ¡gana!
    return true;
        }
    }
}




