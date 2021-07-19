using Luby.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Luby.Test.MatematicaTests
{
    public class PrimoTests
    {
        private readonly Matematica _matematica;
        public PrimoTests()
        {
            _matematica = new Matematica();
        }

        [Theory]
        [InlineData(-1)]
        public void ContarNumerosPrimos_should_throw_argument_exception_when_number_is_less_then_zero(int numero)
        {
            var exception = Assert.Throws<ArgumentException>(() => _matematica.ContarNumerosPrimos(numero));
            Assert.Equal("Números negativos são inválidos.", exception.Message);
        }

        [Theory]
        [InlineData(10)]
        public void ContarNumerosPrimos_should_returns_4(int numero)
        {
            decimal resultado = _matematica.ContarNumerosPrimos(numero);
            Assert.Equal(4, resultado);
        }

        [Theory]
        [InlineData(2)]
        public void ContarNumerosPrimos_should_returns_1(int numero)
        {
            decimal resultado = _matematica.ContarNumerosPrimos(numero);
            Assert.Equal(1, resultado);
        }

        [Theory]
        [InlineData(0)]
        public void ContarNumerosPrimos_should_returns_0(int numero)
        {
            decimal resultado = _matematica.ContarNumerosPrimos(numero);
            Assert.Equal(0, resultado);
        }

     
    }
}
