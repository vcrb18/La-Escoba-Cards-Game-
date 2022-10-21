namespace Servidor;

public class CartasEnMesa
{
    private List<Carta> _fichasEnMesa = new List<Carta>();

    public void AgregarCartasALaMesa(int numeroDeCartas, MazoCartas mazoCartas)
    {
        for (int i = 0; i < numeroDeCartas; i++)
        {
            _fichasEnMesa.Add(mazoCartas.SacarCartaDeArriba());
        }
    }
}