using System;

namespace utils
{
    public static class EnumUtils
    {
        public static bool IsValidEnumOfType(string text, Type enumType)
        {
            foreach (var enumValue in Enum.GetValues(enumType))
            {
                if (string.Equals(text.Trim(), $"{enumValue}", StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}