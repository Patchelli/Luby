using Luby.Logic.Enum;
using System;
using System.ComponentModel;

namespace Luby.Logic.Helper
{
    public static class TipoPremioHelper
    {
        public static string GetDescription(this TipoPremioEnum enumValue)
        {
            if (!typeof(TipoPremioEnum).IsEnum)
                return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }

        public static TipoPremioEnum GetValue(string description)
        {
            foreach (var field in typeof(TipoPremioEnum).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (TipoPremioEnum)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (TipoPremioEnum)field.GetValue(null);
                }
            }

            throw new ArgumentException("Não encontrado.", nameof(description));
        }
    }
}
