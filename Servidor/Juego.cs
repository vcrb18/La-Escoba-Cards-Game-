namespace Servidor;

public class Juego
{
    private const int NumJugadores = 2;
    // private const int NumCartasMesaInicial = 4;
    
    private Jugadores _jugadores;
    private int _idJugadorTurno = 0;
    private MazoCartas _mazoCartas;
    private CartasEnMesa _cartasEnMesa;
    private Vista _vista = new Vista();
    

    public Juego()
    {
        CrearJugadores();
        CrearMazo();
        // BarajarMazo();
        RepartirCartas();
        PonerMesa();
    }

    private void CrearJugadores() => _jugadores = new Jugadores(NumJugadores);
    private void CrearMazo() => _mazoCartas = new MazoCartas();
    private void BarajarMazo() => _mazoCartas.BarajarCartas();
    private void RepartirCartas() => _jugadores.RepartirCartas(_mazoCartas);
    private void PonerMesa() => _cartasEnMesa = new CartasEnMesa(_mazoCartas);

    public void Jugar()
    {
        while (!EsFinJuego())
        {
            _vista.MostrarInfoInicial();
            while (!EsFinMazo())
            {
                JugarTurno();
                break;
            }
            break;
        }
    }

    private bool EsFinJuego()
    {
        return false;
    }

    private bool EsFinMazo()
    {
        return false;
    }

    private void JugarTurno()
    {
        Jugador jugador = _jugadores.ObtenerJugador(_idJugadorTurno);
        _vista.MostrarQuienJuega(jugador);
        _vista.MostrarMesaActual(_cartasEnMesa);
        Carta cartaAJugar = _vista.MostrarManoJugador(jugador);
        JugarTurnoJugador(cartaAJugar);
    }

    private void JugarTurnoJugador(Carta cartaAJugar)
    {
        List<Jugada> jugadasPosibles = CalcularJugada(cartaAJugar);
        if (jugadasPosibles.Count == 0)
        {
            // No hay escoba
        }
        else
        {
            // Hay escoba
        }
    }

    private List<Jugada> CalcularJugada(Carta cartaAJugar)
    {
        List<Jugada> jugadasPosibles = new List<Jugada>();
        int valorCartaAJugar = Convert.ToInt32(cartaAJugar.Valor);
        int suma = valorCartaAJugar;
        List<int> valoresDeLaMesa = _cartasEnMesa.ValoresDeLaMesa();
        
        if (suma < 15)
        {
            
        }

        else
        {
            // Algoritmo para revisar combinaciones
            
        }
        return jugadasPosibles;
    }
}