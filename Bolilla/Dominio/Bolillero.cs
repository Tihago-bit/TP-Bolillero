using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio
{
    public class Bolillero
{
    private List<Bolilla> _bolillas;
    private List<Bolilla> _sacadas;
    private IGeneradorAleatorio _generador;
    private int _n;

    public Bolillero(int n, IGeneradorAleatorio generador)
    {
        _n = n;
        _generador = generador;
        InicializarBolillas();
    }

    private void InicializarBolillas() //Crea bolillas
    {
        _bolillas = new List<Bolilla>();
        _sacadas = new List<Bolilla>();
        for (int i = 0; i <= _n; i++)
        {
            _bolillas.Add(new Bolilla(i));
        }
    }


    public Bolilla SacarBolilla() /*Elige posicion aleatoria saca una bolilla
                                        la guarda en _sacadas y la devuelve*/
    {
        int index = _generador.Generar(_bolillas.Count);
        Bolilla bolilla = _bolillas[index];
        _bolillas.RemoveAt(index);
        _sacada.Add(bolilla);

        return Bolilla;
    }

}
}




