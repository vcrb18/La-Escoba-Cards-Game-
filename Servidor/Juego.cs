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
    private List<List<int>> _listaDeJugadas = new List<List<int>>();

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
        sum_up(_cartasEnMesa.ValoresDeLaMesa(), _target);
        
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
        
        List<int> valoresQuePuedenSumarQuince = ValoresQUePuedenSumarQuince(cartaAJugar);
        List<int> C = new List<int>();
        C.Add(3);
        C.Add(2);
        C.Add(5);
        C.Add(7);
        C.Add(8);
        // sum_up(C, target);
        sum_up(valoresQuePuedenSumarQuince, _target);
        
        // OBTENER CARTAS DE LAS LISTAS DE INTS QUE SUMAN 15
        // CREAR JUGADAS
        
        return jugadasPosibles;
    }

    private List<int> ValoresQUePuedenSumarQuince(Carta cartaAJugar)
    {
        int valorCartaAJugar = Convert.ToInt32(cartaAJugar.Valor);
        List<int> valoresQuePuedenSumarQuince = _cartasEnMesa.ValoresDeLaMesa();
        valoresQuePuedenSumarQuince.Add(valorCartaAJugar);
        return valoresQuePuedenSumarQuince;
    }

    private void sum_up(List<int> numbers, int target)
    {
        sum_up_recursive(numbers, target, new List<int>());
    }

    private void sum_up_recursive(List<int> numbers, int target, List<int> partial)
    {
        int s = 0;
        foreach (int x in partial) s += x;

        if (s == target)
            // Console.WriteLine(partial.ToArray());
            // Console.WriteLine("sum(" + string.Join(",", partial.ToArray()) + ")=" + target);
            // Console.WriteLine("sum(" + string.Join(",", partial) + ")=" + target);
            GuardaJugada(partial);

        if (s >= target)
            return;

        for (int i = 0; i < numbers.Count; i++)
        {
            List<int> remaining = new List<int>();
            int n = numbers[i];
            for (int j = i + 1; j < numbers.Count; j++) remaining.Add(numbers[j]);

            List<int> partial_rec = new List<int>(partial);
            partial_rec.Add(n);
            sum_up_recursive(remaining, target, partial_rec);
        }
    }

    private void GuardaJugada(List<int> valoresQueSumanQuince)
    {
        _listaDeJugadas.Add(valoresQueSumanQuince);
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