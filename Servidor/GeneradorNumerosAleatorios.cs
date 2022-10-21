namespace Servidor;

//CAMBIADA! Revisar
public class GeneradorNumerosAleatorios
{
    private const int RandomSeed = 0;
    private static Random rng = new Random(RandomSeed);

    public int Generar() => rng.Next();
}