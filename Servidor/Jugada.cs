namespace Servidor;

public class Jugada
{
    private Carta _cartaAJugar;
    private List<Carta> _cartasCombinadas;

    public Carta CartaAJugar
    {
        get { return _cartaAJugar; }
    }

    public Jugada(Carta cartaAJugar)
    {
        _cartaAJugar = cartaAJugar;
    }

    public List<Carta> Escoba()
    {
        List<Carta> cartasEscoba = _cartasCombinadas;
        cartasEscoba.Add(_cartaAJugar);
        return cartasEscoba;
    }


}