using System.ComponentModel;

namespace Luby.Logic.Enum
{
    public enum TipoPremioEnum
    {
        [Description("basic")]
        Basic,
        [Description("vip")]
        Vip,
        [Description("premium")]
        Premium,
        [Description("deluxe")]
        Deluxe,
        [Description("special")]
        Special
    }
}
