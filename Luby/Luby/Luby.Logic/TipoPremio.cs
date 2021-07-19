using Luby.Logic.Enum;
using Luby.Logic.Helper;
using System;
using System.Collections.Generic;

namespace Luby.Logic
{
    public class TipoPremio : IDisposable
    {
        private Dictionary<TipoPremioEnum, decimal> FatoresMultiplicacao { get; set; }

        public TipoPremio()
        {
            FatoresMultiplicacao = new Dictionary<TipoPremioEnum, decimal>
            {
                { TipoPremioEnum.Basic, 1m },
                { TipoPremioEnum.Vip, 1.2m },
                { TipoPremioEnum.Premium, 1.5m },
                { TipoPremioEnum.Deluxe, 1.8m },
                { TipoPremioEnum.Special, 2m }
            };
        }

        public decimal GetValue(TipoPremioEnum tipoPremio)
        {
            if (!FatoresMultiplicacao.TryGetValue(tipoPremio, out decimal value))
                throw new ArgumentOutOfRangeException("Tipo prêmio não encontrado.");

            return value;
        }

        public decimal GetFator(string tipoFator, decimal? fatorProprio)
        {
            return fatorProprio == null ? GetValue(TipoPremioHelper.GetValue(tipoFator)) : fatorProprio.Value;
        }

        public void Dispose()
        {
            FatoresMultiplicacao = null;
        }
    }
}
