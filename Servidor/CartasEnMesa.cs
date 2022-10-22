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
            int valor = ConvierteValorAInt(carta.Valor);
            listaDeValores.Add(valor);
        }
        return listaDeValores;
    }

    public int ConvierteValorAInt(string valor)
    {
        Dictionary<string, int> dictionaryStringToInt = hashValorCarta();
        return dictionaryStringToInt[valor];
    }

    public Dictionary<string, int> hashValorCarta()
    {
        Dictionary<string, int> dictionaryStringToInt = new Dictionary<string, int>();
        dictionaryStringToInt.Add("1", 1);
        dictionaryStringToInt.Add("2", 2);
        dictionaryStringToInt.Add("3", 3);
        dictionaryStringToInt.Add("4", 4);
        dictionaryStringToInt.Add("5", 5);
        dictionaryStringToInt.Add("6", 6);
        dictionaryStringToInt.Add("7", 7);
        dictionaryStringToInt.Add("Sota", 8);
        dictionaryStringToInt.Add("Caballo", 9);
        dictionaryStringToInt.Add("Rey", 10);
        return dictionaryStringToInt;
    }

    public void AgregarCarta(Carta carta)
    {
        _cartasEnMesa.Add(carta);
    }

    public void SacarCartas(List<Carta> cartas)
    {
        foreach (var carta in cartas)
        {
            _cartasEnMesa.Remove(carta);
        }
    }

}