using System;
using System.ComponentModel;
using System.Reflection;

namespace Dota2ApiWrapper.Helpers
{
    public static class EnumHelper
    {
        public static string GetEunumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[]) fi.GetCustomAttributes(typeof (DescriptionAttribute),
                    false);

            if (attributes.Length > 0)
                return attributes[0].Description;

            return value.ToString();
        }
    }
}