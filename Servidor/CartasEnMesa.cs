namespace Servidor;

public class CartasEnMesa
{
    private const int NumCartasMesaInicial = 4;
    private List<Carta> _cartasEnMesa = new List<Carta>();

    public CartasEnMesa(MazoCartas mazoCartas)
    {
        for (int i = 0; i < NumCartasMesaInicial; i++)
        {
            _cartasEnMesa.Add(mazoCartas.SacarCartaDeArriba());
        }
    }

    public List<Carta> CartasDeLaMesa
    {
        get { return _cartasEnMesa; }
    }

    public List<int> ValoresDeLaMesa()
    {
        List<int> listaDeValores = new List<int>();
        foreach (var carta in _cartasEnMesa)
        {
            int valor = Convert.ToInt32(carta.Valor);
            listaDeValores.Add(valor);
        }
        return listaDeValores;
    }
    
}