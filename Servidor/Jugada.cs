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

    public bool EsEscoba
    {
        get { return _esEscoba; }
    }
    
    public int NumeroDeCartasDeJugada
    {
        get { return _cartasQueFormanEscoba.Count; }
    }

    public bool TieneSieteDeOro()
    {
        bool tieneSieteDeOro = false;
        foreach (var carta in _cartasQueFormanEscoba)
        {
            if (carta.Pinta == "Oro" && carta.Valor == "7")
            {
                tieneSieteDeOro = true;
            }
        }

        return tieneSieteDeOro;
    }

    public bool TieneMayoriaDeSietes()
    {
        bool tieneMayoriaDeSietes = false;
        int numeroDeSietes = 0;
        foreach (var carta in _cartasQueFormanEscoba)
        {
            if (carta.Valor == "7")
            {
                numeroDeSietes += 1;
            }
        }

        if (numeroDeSietes >= 2)
        {
            tieneMayoriaDeSietes = true;
        }

        return tieneMayoriaDeSietes;
    }

    public int NumeroDeOrosEnJugada()
    {
        int numeroDeOros = 0;
        foreach (var carta in _cartasQueFormanEscoba)
        {
            if (carta.Pinta == "Oro")
            {
                numeroDeOros += 1;
            }
        }

        return numeroDeOros;
    }
    
    
    
}