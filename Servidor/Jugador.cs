namespace Servidor;

public class Jugador
{
    private List<Carta> _mano = new List<Carta>();
    private int _puntaje = 0;
    public int _id;

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
}