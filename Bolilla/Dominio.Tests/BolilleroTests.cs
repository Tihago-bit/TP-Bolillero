using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BolilleroTests
{
    private Bolillero _bolillero;

    // Se ejecuta antes de cada test
    public BolilleroTests()
    {
        // 10 bolillas → del 0 al 9
        _bolillero = new Bolillero(9, new GeneradorFijo());
        //Casimiro arregla todo esto//
    }
}