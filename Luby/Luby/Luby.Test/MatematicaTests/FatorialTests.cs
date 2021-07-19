using Luby.Logic;
using System;
using Xunit;

namespace Luby.Test.MatematicaTests
{
    public class FatorialTests
    {
        private readonly Matematica _matematica;
        public FatorialTests()
        {
            _matematica = new Matematica();
        }

        [Theory]
        [InlineData(-1)]
        public void CalcularFatorial_should_throw_argument_exception_when_value_is_less_then_zero(int n)
        {
            var exception = Assert.Throws<ArgumentException>(() => _matematica.CalcularFatorial(n));
            Assert.Equal("Números negativos são inválidos.", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        public void CalcularFatorial_should_returns_one_when_value_is_equals_to_zero(int n)
        {
            int resultado = _matematica.CalcularFatorial(n);
            Assert.Equal(1, resultado);
        }

        [Theory]
        [InlineData(5)]
        public void CalcularFatorial_should_returns_120_when_value_is_greater_then_zero(int n)
        {
            int resultado = _matematica.CalcularFatorial(n);
            Assert.Equal(120, resultado);
        }
    }
}
