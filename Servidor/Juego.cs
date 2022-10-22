namespace Servidor;

public class Juego
{
    private const int NumJugadores = 2;
    // private const int NumCartasMesaInicial = 4;

    private int _target = 15;
    private Jugadores _jugadores;
    private int _idJugadorTurno = 0;
    private MazoCartas _mazoCartas;
    private CartasEnMesa _cartasEnMesa;
    private Vista _vista = new Vista();
    private List<Jugada> _listaDeJugadasPosibles = new List<Jugada>();

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
    private void PonerMesa() => _cartasEnMesa = new CartasEnMesa(_mazoCartas);

    public void Jugar()
    {
        while (!EsFinJuego())
        {
            // Caso Borde de Escoba en la Mesa
            // 
            _vista.MostrarInfoInicial();
            while (!EsFinMazo())
            {
                JugarTurno();
                CambiarTurno();
                break;
            }
            break;
        }
    }

    private void ChequeaCasoBorde()
    {
        
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
        ResetearJugadas();
    }


    private void JugarTurnoJugador(Carta cartaAJugar)
    {
        CalcularJugadas(cartaAJugar);
        if (_listaDeJugadasPosibles.Count == 0)
        {
            // No hay escoba
            BajarCarta(cartaAJugar);
            _vista.NoHayEscoba();
        }
        else if (_listaDeJugadasPosibles.Count == 1)
        {
            BajarCarta(cartaAJugar);
            JugarEscoba(_listaDeJugadasPosibles[0]);
        }
        else
        {
            BajarCarta(cartaAJugar);
            int idJugada = _vista.PedirJugada(_listaDeJugadasPosibles);
            JugarEscoba(_listaDeJugadasPosibles[idJugada]);
        }
    }

    private void BajarCarta(Carta carta)
    {
        Jugador jugador = _jugadores.ObtenerJugador(_idJugadorTurno);
        jugador.SacarCartaDeMano(carta);
        _cartasEnMesa.AgregarCarta(carta);
    }


    // SACAR CARTAS DE LA MESA
    private void JugarEscoba(Jugada jugada)
    {
        Jugador jugador = _jugadores.ObtenerJugador(_idJugadorTurno);
        _cartasEnMesa.SacarCartas(jugada.CartasQueFormanEscoba);
        jugador.AgregarEscoba(jugada);
        _vista.JugadorSeLlevaLasCartas(jugador, jugada);
        _vista.MostrarEscoba(jugador);
    }

    private void CalcularJugadas(Carta cartaAJugar)
    {
        List<Jugada> jugadasPosibles = new List<Jugada>();
        sum_up(CartasQuePuedenSumarQuince(cartaAJugar), _target);
        
        // List<Carta> cartasQuePuedenSumarQuince = CartasQuePuedenSumarQuince(cartaAJugar);
        // List<int> C = new List<int>();
        // C.Add(3);
        // C.Add(2);
        // C.Add(5);
        // C.Add(7);
        // C.Add(8);
        // // sum_up(C, target);
        // // OBTENER CARTAS DE LAS LISTAS DE INTS QUE SUMAN 15
        // // CREAR JUGADAS
        
        // return jugadasPosibles;
    }

    private List<Carta> CartasQuePuedenSumarQuince(Carta cartaAJugar)
    {
        // int valorCartaAJugar = Convert.ToInt32(cartaAJugar.Valor);
        List<Carta> cartasQuePuedenSumarQuince = _cartasEnMesa.CartasDeLaMesa;
        cartasQuePuedenSumarQuince.Add(cartaAJugar);
        return cartasQuePuedenSumarQuince;
    }

    private void sum_up(List<Carta> numbers, int target)
    {
        sum_up_recursive(numbers, target, new List<Carta>());
    }

    private void sum_up_recursive(List<Carta> numbers, int target, List<Carta> partial)
    {
        int s = 0;
        foreach (Carta x in partial) s += x.ConvierteValorAInt();

        if (s == target)
            // Console.WriteLine(partial.ToArray());
            // Console.WriteLine("sum(" + string.Join(",", partial.ToArray()) + ")=" + target);
            // Console.WriteLine("sum(" + string.Join(",", partial) + ")=" + target);
            GuardaJugada(partial);

        if (s >= target)
            return;

        for (int i = 0; i < numbers.Count; i++)
        {
            List<Carta> remaining = new List<Carta>();
            Carta n = numbers[i];
            for (int j = i + 1; j < numbers.Count; j++) remaining.Add(numbers[j]);

            List<Carta> partial_rec = new List<Carta>(partial);
            partial_rec.Add(n);
            sum_up_recursive(remaining, target, partial_rec);
        }
    }

    private void GuardaJugada(List<Carta> cartasQueSumanQuince)
    {
        Jugada jugadaPosible = new Jugada(cartasQueSumanQuince);
        _listaDeJugadasPosibles.Add(jugadaPosible);
    }
    
    private void ResetearJugadas()
    {
        _listaDeJugadasPosibles = new List<Jugada>();
    }
    
    private void CambiarTurno()
    {
        if (_idJugadorTurno == 0)
        {
            _idJugadorTurno = 1;
        }
        else
        {
            _idJugadorTurno = 0;
        }
    }
  
    
}