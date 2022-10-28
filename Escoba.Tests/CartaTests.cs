using System.Collections.Generic;
using Servidor;
using Xunit;

namespace Escoba.Tests;

public class CartaTests
{
    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("3", 3)]
    [InlineData("4", 4)]
    [InlineData("5", 5)]
    [InlineData("6", 6)]
    [InlineData("7", 7)]
    [InlineData("Sota", 8)]
    [InlineData("Caballo", 9)]
    [InlineData("Rey", 10)]
    public void ConvierteValorAInt_StringDelValorDebeConvertirse(string valor, int expected)
    {
        // Arrange
        Carta carta = new Carta("oro", valor);
        int valorEsperado = expected;
        // Act
        int valorNuevo = carta.ConvierteValorAInt();
        // Assert
        Assert.Equal(valorNuevo, valorEsperado);
    }
}