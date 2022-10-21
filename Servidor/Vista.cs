namespace Servidor;

public class Vista
{
    public void MostrarInfoInicial()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("El jugador 1 comienza repartiendo cartas y el 0 parte jugando.");
    }

    public void MostrarQuienJuega(Jugador jugador)
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"Juega Jugador {jugador._id}");
    }

    public void MostrarMesaActual(CartasEnMesa cartasEnMesa)
    {
        List<Carta> listaDeCartasEnLaMesa = cartasEnMesa.CartasDeLaMesa; 
        Console.WriteLine("Mesa actual:");
        for (int i = 1; i < listaDeCartasEnLaMesa.Count + 1; i++)
        {
            Carta carta = listaDeCartasEnLaMesa[i - 1];
            Console.WriteLine($"({i}) {carta.Valor}_{carta.Pinta}");
        }
    }

    // Arreglar!
    public Carta MostrarManoJugador(Jugador jugador)
    {
        List<Carta> manoJugador = jugador.Mano;
        for (int i = 1; i < manoJugador.Count + 1; i++)
        {
            Carta carta = manoJugador[i - 1];
            Console.WriteLine($"({i}) {carta.Valor}_{carta.Pinta}");
        }
        Console.WriteLine("¿Qué carta quieres bajar?");
        Console.WriteLine($"(Ingresa un número entre 1 y {manoJugador.Count}");
        int nrCartaEscogida = PedirJugada(1, manoJugador.Count);
        return manoJugador[nrCartaEscogida];
    }

    public int PedirJugada(int minValue, int maxValue)
    {
        int nrCartaEscogida = PedirNumeroValido(minValue, maxValue);
        return nrCartaEscogida;
    }

    private int PedirNumeroValido(int minValue, int maxValue)
    {
        int numero;
        bool fuePosibleTransformarElString;
        do
        {
            string? inputUsuario = Console.ReadLine();
            fuePosibleTransformarElString = int.TryParse(inputUsuario, out numero);
        } while (!fuePosibleTransformarElString || numero < minValue || numero > maxValue);

        return numero;
    }

    private void JugadorSeLlevaLasCartas(Jugador jugador ,Jugada jugada)
    {
        Console.WriteLine($"Jugador {jugador._id} se lleva las siguientes cartas: {MostrarEscoba(jugada.Escoba())}");
        Console.WriteLine($"Jugador {jugador._id} se lleva las siguientes cartas: {jugada.Escoba()}");
    }

    private void MostrarEscoba(List<Carta> cartasEscoba)
    {
        foreach (var carta in cartasEscoba)
        {
            Console.WriteLine($"{carta.Valor}_{carta.Pinta}");
        }
    }
}