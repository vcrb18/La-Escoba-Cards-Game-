namespace Servidor;

public class Jugador
{
    private List<Carta> _mano = new List<Carta>();
    private int _puntaje = 0;
    public int _id;
    private List<Jugada> _listaDeEscobas = new List<Jugada>();

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

    public void AgregarEscoba(Jugada jugada)
    {
        _listaDeEscobas.Add(jugada);
    }

    public void SacarCartaDeMano(Carta carta)
    {
        _mano.Remove(carta);
    }
}