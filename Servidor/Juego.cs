namespace Servidor;

public class Juego
{
    private const int NumJugadores = 2;
    private const int NumCartasMesaInicial = 4;
    
    private Jugadores _jugadores;
    private int _idJugadorTurno;
    private MazoCartas _mazoCartas;
    private CartasEnMesa _cartasEnMesa;
    private Vista _vista = new Vista();

    public Juego()
    {
        CrearJugadores();
        CrearMazo();
        BarajarMazo();
        RepartirCartas();
        PonerMesa();
    }

    private void CrearJugadores() => _jugadores = new Jugadores(NumJugadores);
    private void CrearMazo() => _mazoCartas = new MazoCartas();
    private void BarajarMazo() => _mazoCartas.BarajarCartas();
    private void RepartirCartas() => _jugadores.RepartirCartas(_mazoCartas);
    private void PonerMesa() => _cartasEnMesa.AgregarCartasALaMesa(NumCartasMesaInicial, _mazoCartas);

    public void Jugar()
    {
        while (!EsFinJuego())
        {
            
        }
    }

    private bool EsFinJuego()
    {
        return false;
    }
}