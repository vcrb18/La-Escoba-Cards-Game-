namespace Servidor;

public class Jugada
{
    private List<Carta> _cartasQueFormanEscoba;
    private bool _esEscoba;

    public Jugada(List<Carta> cartasQueFormanEscoba, bool esEscoba)
    {
        _cartasQueFormanEscoba = cartasQueFormanEscoba;
        _esEscoba = esEscoba;
    }

    public List<Carta> CartasQueFormanJugada
    {
        get { return _cartasQueFormanEscoba; }
    }

    public override string ToString()
    {
        string s = "";
        foreach (var carta in _cartasQueFormanEscoba)
        {
            s += $"{carta.ToString()}, ";
        }

        return s;
    }
}