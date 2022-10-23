namespace Servidor;

public class Jugadores
{
    private List<Jugador> _jugadores;

    public Jugadores(int numJugadores)
    {
        _jugadores= new List<Jugador>();
        for (int i = 0; i < numJugadores; i++)
        {
            _jugadores.Add(new Jugador(i));
        }
    }

    public bool ManosVacias()
    {
        if (_jugadores[0].ManoVacia() && _jugadores[1].ManoVacia())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public Jugador ObtenerJugador(int idJugador) => _jugadores[idJugador];

    public void RepartirCartas(MazoCartas mazoCartas)
    {
        foreach (var jugador in _jugadores)
        {
            mazoCartas.DarCartasIniciales(jugador);
        }   
    }

    public void MostrarCartasGanadas()
    {
        foreach (var jugador in _jugadores)
        {
            Console.WriteLine($"    Jugador {jugador._id}:");
            jugador.MostrarCartasGanadas();
        }
    }

    public List<Jugador> ObtenerJugadores
    {
        get { return _jugadores; }
    }

    public void CalcularPuntajes()
    {
        foreach (var jugador in _jugadores)
        {
            jugador.CalcularPuntaje();
        }
    }
    
}