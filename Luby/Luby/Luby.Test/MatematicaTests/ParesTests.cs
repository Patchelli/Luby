using Luby.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Luby.Test.MatematicaTests
{
    public class ParesTests
    {
        private readonly Matematica _matematica;
        public ParesTests()
        {
            _matematica = new Matematica();
        }

        [Theory]
        [InlineData(new int[] { })]
        public void ObterElementosPares_should_returns_empty(int [] vetor)
        {
            int [] resultado = _matematica.ObterElementosPares(vetor);
            Assert.Equal(new int[] {}, resultado);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 })]
        public void ObterElementosPares_should_returns_pares_2_4(int[] vetor)
        {
            int[] resultado = _matematica.ObterElementosPares(vetor);
            Assert.Equal(new int[] { 2, 4 }, resultado);
        }

        [Theory]
        [InlineData(new int[] { 0 })]
        public void ObterElementosPares_should_returns_0(int[] vetor)
        {
            int[] resultado = _matematica.ObterElementosPares(vetor);
            Assert.Equal(new int[] { 0 }, resultado);
        }

        [Theory]
        [InlineData(new int[] { -2 })]
        public void ObterElementosPares_should_returns_negative(int[] vetor)
        {
            int[] resultado = _matematica.ObterElementosPares(vetor);
            Assert.Equal(new int[] { -2 }, resultado);
        }
    }
}
