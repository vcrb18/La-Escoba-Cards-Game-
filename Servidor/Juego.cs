namespace Servidor;

public class Juego
{
    private const int NumJugadores = 2;
    // private const int NumCartasMesaInicial = 4;

    private int _target = 15;
    private Jugadores _jugadores;
    private int _idJugadorTurno = 0;
    private int _idUltimoJugadorEnLlevarseLasCartas;
    private int _idJugadorRepartidor = 0;
    private int _idJugadorPartidor = 1;
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
            if (_mazoCartas.SeAcabaronLasCartas() && _jugadores.ManosVacias())
            {
                NuevoJuego();
            }
            
            /////////////////////////////////////
            // Caso Borde de Escoba en la Mesa //
            /////////////////////////////////////
            _vista.MostrarInfoInicial(_idJugadorRepartidor, _idJugadorPartidor);
            while (!EsFinMazoYManos())
            {
                _mazoCartas.CuantasCartasQuedan();
                JugarTurno();
                CambiarTurno();
            }
            // break;
        }
    }

    private void ChequeaCasoBorde()
    {
        
    }

    private bool EsFinJuego()
    {
        return false;
    }

    private bool EsFinMazoYManos()
    {
        if (_mazoCartas.SeAcabaronLasCartas())
        {
            if (_jugadores.ManosVacias())
            {
                UltimaJugadaDelMazo();
                // NuevoJuego();
                _vista.CartasGanadasEnEstaRonda(_jugadores);
                _vista.TotalPuntosGanadosJugadores(_jugadores);
                return true;
            }
            else
            {
                return false;
            }

        }
        else
        {
            return false;
        }
    }

    public void NuevoJuego()
    {
        CambiarRepartidorYJugador();
        CrearMazo();
        BarajarMazo();
        RepartirCartas();
        PonerMesa();
    }

    public void CambiarRepartidorYJugador()
    {
        CambiarRepartidor();
        CambiarJugador();
    }

    public void CambiarRepartidor()
    {
        if (_idJugadorRepartidor == 0)
        {
            _idJugadorRepartidor = 1;
        }
        else
        {
            _idJugadorRepartidor = 0;
        }
    }

    public void CambiarJugador()
    {
        if (_idJugadorPartidor == 0)
        {
            _idJugadorPartidor = 1;
            _idJugadorTurno = 1;
        }
        else
        {
            _idJugadorPartidor = 0;
            _idJugadorTurno = 0;
        }
    }
    
    
    private void JugarTurno()
    {
        SiNoTienenCartasSeReparte();
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
            JugarJugada(_listaDeJugadasPosibles[0]);
        }
        else
        {
            BajarCarta(cartaAJugar);
            int idJugada = _vista.PedirJugada(_listaDeJugadasPosibles);
            JugarJugada(_listaDeJugadasPosibles[idJugada]);
        }
    }

    private void BajarCarta(Carta carta)
    {
        Jugador jugador = _jugadores.ObtenerJugador(_idJugadorTurno);
        jugador.SacarCartaDeMano(carta);
        _cartasEnMesa.AgregarCarta(carta);
    }

    private void JugarJugada(Jugada jugada)
    {
        Jugador jugador = _jugadores.ObtenerJugador(_idJugadorTurno);
        GuardarUltimoJugadorEnLlevarseCartas(jugador);
        jugador.AgregarJugada(jugada);
        _cartasEnMesa.SacarCartas(jugada.CartasQueFormanJugada);
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
        List<Carta> cartasQuePuedenSumarQuince = new List<Carta>();
        cartasQuePuedenSumarQuince.Add(cartaAJugar);
        foreach (var carta in _cartasEnMesa.CartasDeLaMesa)
        {
            cartasQuePuedenSumarQuince.Add(carta);
        }
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
        Jugada jugadaPosible = new Jugada(cartasQueSumanQuince, true);
        _listaDeJugadasPosibles.Add(jugadaPosible);
    }
    
    private void ResetearJugadas()
    {
        _listaDeJugadasPosibles = new List<Jugada>();
    }

    private void SiNoTienenCartasSeReparte()
    {
        if (_jugadores.ManosVacias())
        {
            if (_mazoCartas.SeAcabaronLasCartas())
            {
                // NUNCA VA A ENTRAR ACA
                UltimaJugadaDelMazo();
                // NuevoJuego();
            }
            else
            {
                RepartirCartas();
                _vista.SeVuelvenARepartirCartas();
            }
        }
    }

    private void UltimaJugadaDelMazo()
    {
        List<Carta> cartasMesa = _cartasEnMesa.CartasDeLaMesa;
        
        
        _cartasEnMesa.CuantasCartasHayEnLaMesa();
        Jugada cartasSobrantes = new Jugada(cartasMesa, false);
        

        Jugador jugadorEnLlevarseLasCartas = _jugadores.ObtenerJugador(_idUltimoJugadorEnLlevarseLasCartas);
        jugadorEnLlevarseLasCartas.AgregarJugada(cartasSobrantes);
        _vista.SeLlevaLasUltimasCartas(jugadorEnLlevarseLasCartas, cartasSobrantes);
        _cartasEnMesa.SacarCartas(cartasSobrantes.CartasQueFormanJugada);
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

    private void GuardarUltimoJugadorEnLlevarseCartas(Jugador jugador)
    {
        _idUltimoJugadorEnLlevarseLasCartas = jugador._id;
    }
  
    
}