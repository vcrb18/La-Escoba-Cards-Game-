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
}