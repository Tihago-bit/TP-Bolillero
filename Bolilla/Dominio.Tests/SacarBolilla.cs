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