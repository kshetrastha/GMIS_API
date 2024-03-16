using gmis.Shared.Enumerations.Extension.Models;
using System.ComponentModel;
using System.Reflection;

namespace gmis.Shared.Enumerations.Extension
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        public static List<EnumDropdownModel> ToDropdownList<TEnum>(this TEnum obj) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new EnumDropdownModel
            {
                Id = (Convert.ToInt32(x)),
                Text = Enum.GetName(typeof(TEnum), x).ToString()
            }).ToList();
        }
    }
}
