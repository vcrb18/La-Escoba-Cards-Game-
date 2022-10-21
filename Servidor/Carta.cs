namespace Servidor;

public class Carta
{
    private string _pinta;
    public string _valor;

    public Carta(string pinta, string valor)
    {
        _pinta = pinta;
        _valor = valor;
    }

    public override string ToString()
    {
        string valorToString = _valor.ToString();
        string descripcionCarta = valorToString + "_" + _pinta;
        return descripcionCarta;
    }
}