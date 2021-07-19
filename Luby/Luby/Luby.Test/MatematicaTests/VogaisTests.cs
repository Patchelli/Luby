using Luby.Logic;
using System;
using Xunit;

namespace Luby.Test.MatematicaTests
{
    public class VogaisTests
    {
        private readonly Matematica _matematica;
        public VogaisTests()
        {
            _matematica = new Matematica();
        }

        [Theory]
        [InlineData("Luby Software")]
        public void CalcularVogais_should_returns_4(string text)
        {
            decimal resultado = _matematica.CalcularVogais(text);
            Assert.Equal(4, resultado);
        }

        [Theory]
        [InlineData("áéíóú")]
        public void CalcularVogais_should_returns_5(string text)
        {
            decimal resultado = _matematica.CalcularVogais(text);
            Assert.Equal(5, resultado);
        }

        [Theory]
        [InlineData("")]
        public void CalcularVogais_should_returns_0(string text)
        {
            decimal resultado = _matematica.CalcularVogais(text);
            Assert.Equal(0, resultado);
        }
    }
}
