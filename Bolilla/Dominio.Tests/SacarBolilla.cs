using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xunit; //a tengo que agregar paquetes

public class SacarBolilla
{
    private Bolillero _bolillero;

    // Se ejecuta antes de cada test
    public SacarBolilla()
    {
        // 10 bolillas → del 0 al 9
        _bolillero = new Bolillero(9, new GeneradorFijo());
    }
    [Fact]
    public void SacarBolilla()
    {
        var bolilla = _bolillero.SacarBolilla();

        // Verifica que salió la bolilla 0
        Assert.Equal(0, bolilla.Numero);

        // Verifica que quedan 9 bolillas dentro
        Assert.Equal(9, _bolillero.CantidadEnBolillero());

        // Verifica que hay 1 afuera
        Assert.Equal(1, _bolillero.CantidadSacadas());
    }
}