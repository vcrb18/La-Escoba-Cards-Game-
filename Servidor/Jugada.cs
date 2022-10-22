namespace Servidor;

public class Jugada
{
    private List<Carta> _cartasQueFormanEscoba;

    public Jugada(List<Carta> cartasQueFormanEscoba)
    {
        _cartasQueFormanEscoba = cartasQueFormanEscoba;
    }

    public List<Carta> CartasQueFormanEscoba
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