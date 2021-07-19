using Luby.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Luby.Test.MatematicaTests
{
    public class PremioTests
    {
        private readonly Matematica _matematica;
        public PremioTests()
        {
            _matematica = new Matematica();
        }

        [Theory]
        [InlineData(0, "vip")]
        public void CalcularPremio_should_throw_argument_exception_when_premio_is_equals_to_zero(decimal premio, string tipoFator)
        {
            var exception = Assert.Throws<ArgumentException>(() => _matematica.CalcularPremio(premio, tipoFator, null));
            Assert.Equal("Valor prêmio é inválido.", exception.Message);
        }

        [Theory]
        [InlineData(-3, "special")]
        public void CalcularPremio_should_throw_argument_exception_when_premio_is_less_then_zero(decimal premio, string tipoFator)
        {
            var exception = Assert.Throws<ArgumentException>(() => _matematica.CalcularPremio(premio, tipoFator, null));
            Assert.Equal("Valor prêmio é inválido.", exception.Message);
        }

        [Theory]
        [InlineData(100, "vip")]
        public void CalcularPremio_should_returns_120(decimal premio, string tipoFator)
        {
            decimal resultado = _matematica.CalcularPremio(premio, tipoFator, null);
            Assert.Equal(120, resultado);
        }

        [Theory]
        [InlineData(100, "basic", 3)]
        public void CalcularPremio_should_returns_300(decimal premio, string tipoFator, decimal fatorProprio)
        {
            decimal resultado = _matematica.CalcularPremio(premio, tipoFator, fatorProprio);
            Assert.Equal(300, resultado);
        }

        [Theory]
        [InlineData(900, "deluxe")]
        public void CalcularPremio_should_returns_900(decimal premio, string tipoFator)
        {
            decimal resultado = _matematica.CalcularPremio(premio, tipoFator, null);
            Assert.Equal(1620, resultado);
        }
    }
}
