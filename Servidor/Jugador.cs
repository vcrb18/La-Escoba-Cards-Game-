namespace Servidor;

public class Jugador
{
    private List<Carta> _mano = new List<Carta>();
    private int _puntaje = 0;
    public int _id; // ARREGLAR
    private List<Jugada> _listaDeJugadas = new List<Jugada>();

    public Jugador(int id)
    {
        _id = id;
    }

    public void AgregarCartaAMano(Carta carta)
    {
        _mano.Add(carta);
    }

    public int Puntaje
    {
        get { return _puntaje;  }
    }

    public List<Carta> Mano
    {
        get { return _mano; }
    }

    public void AgregarJugada(Jugada jugada)
    {
        _listaDeJugadas.Add(jugada);
    }

    public void SacarCartaDeMano(Carta carta)
    {
        _mano.Remove(carta);
    }

    public bool ManoVacia()
    {
        if (_mano.Count == 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void MostrarCartasGanadas()
    {
        foreach (var jugada in _listaDeJugadas)
        {
            Console.WriteLine(jugada);
        }
    }

    public void CalcularPuntaje()
    {
        PuntajePorEscoba();
        PuntajePorMayoriaDeOros();
        PuntajePorMayoriaDeSietes();
        PuntajePorMayoriaDeCartas();
        PuntajePorMayoriaDeOros();
    }

    private void PuntajePorEscoba()
    {
        _puntaje += NumeroDeEscobas();
    }

    private void PuntajePorSieteDeOro()
    {
        if (TieneSieteDeOro())
        {
            _puntaje++;
        }
    }

    private void PuntajePorMayoriaDeSietes()
    {
        if (TieneMayoriaDeSietes())
        {
            _puntaje++;
        }
    }

    private void PuntajePorMayoriaDeCartas()
    {
        if (TieneMayoriaDeCartas())
        {
            _puntaje++;
        }
    }

    private void PuntajePorMayoriaDeOros()
    {
        if (TieneMayoriaDeOros())
        {
            _puntaje++;
        }
    }

    public int NumeroDeEscobas()
    {
        int numeroDeEscobas = 0;
        foreach (var jugada in _listaDeJugadas)
        {
            if (jugada.EsEscoba)
            {
                numeroDeEscobas++;
            }
        }

        return numeroDeEscobas;
    }

    public bool TieneSieteDeOro()
    {
        bool tieneSieteDeOro = false;
        foreach (var jugada in _listaDeJugadas)
        {
            if (jugada.TieneSieteDeOro())
            {
                tieneSieteDeOro = true;
            }
        }

        return tieneSieteDeOro;
    }

    public bool TieneMayoriaDeSietes()
    {
        bool tieneMayoriaDeSietes = false;
        foreach (var jugada in _listaDeJugadas)
        {
            if (jugada.TieneMayoriaDeSietes())
            {
                tieneMayoriaDeSietes = true;
            }
        }

        return tieneMayoriaDeSietes;
    }

    public bool TieneMayoriaDeCartas()
    {
        bool tieneMayoriaDeCartas = false;
        foreach (var jugada in _listaDeJugadas)
        {
            if (jugada.TieneMayoriaDeCartas())
            {
                tieneMayoriaDeCartas = true;
            }
        }

        return tieneMayoriaDeCartas;
    }

    public bool TieneMayoriaDeOros()
    {
        bool tieneMayoriaDeOros = false;
        foreach (var jugada in _listaDeJugadas)
        {
            if (jugada.TieneMayoriaDeOros())
            {
                tieneMayoriaDeOros = true;
            }
        }

        return tieneMayoriaDeOros;
    }
}