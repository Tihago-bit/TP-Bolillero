using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xunit; //a tengo que agregar paquetes

public class SacarBolilla
{
    private Bolillero _bolillero;

    public SacarBolilla()
    {
        _bolillero = new Bolillero(10, new GeneradorFijo());
    }

    [Fact]
    public void sacarbolilla()
    {
        var bolilla = _bolillero.SacarBolilla();
        Assert.Equal(0, bolilla);
        Assert.Equal(9, _bolillero.CantidadDentro());
        Assert.Equal(1, _bolillero.CantidadSacadas());
    }
}