using Luby.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Luby.Test.MatematicaTests
{
    public class DatasTests
    {
        private readonly Matematica _matematica;
        public DatasTests()
        {
            _matematica = new Matematica();
        }

        [Theory]
        [InlineData("10122020", "25122020")]
        public void CalcularDiferencaData_should_returns_days_15(string dataInicial, string dataFinal)
        {
            int resultado = _matematica.CalcularDiferencaData(dataInicial, dataFinal);
            Assert.Equal(15, resultado);
        }

        [Theory]
        [InlineData("10122020", "25122020")]
        public void CalcularDiferencaData_should_throw_argument_exception_when_number_is_less_then_zero(string dataInicial, string dataFinal)
        {
            var exception = Assert.Throws<ArgumentException>(() => _matematica.CalcularDiferencaData(dataInicial,dataFinal));
            Assert.Equal("Números negativos são inválidos.", exception.Message);
        }
        

    }
}
