using System;

namespace FantasySoccerApp.MobileAppService.Utilities
{
    public static class TextMethods
    {
        public static string NoNull(this string value)
        {
            return (value == null) ? "" : value.Trim();
        }

        public static string ToNullIfWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        public static DateTime? ToNullableDateTime(this string date)
        {
            if (DateTime.TryParse(date, out var d)) { return d; }
            return null;
        }
        public static decimal? ToNullableDecimal(this string decimalN)
        {
            decimal number;
            if (Decimal.TryParse(decimalN, out number))
            {
                return number;
            }
            return null;
        }

        public static bool? ToNullableBool(this string text)
        {
            var val = ToNullIfWhiteSpace(text);

            if (val == null)
            {
                return null;
            }
            else if (val.ToLower() == "true" || val.ToLower() == "on" || val.ToLower() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double? ToNullableDouble(this string doubleN)
        {
            double number;
            if (double.TryParse(doubleN, out number))
            {
                return number;
            }
            return null;
        }

        public static int? ToNullableInt(this string intN)
        {
            int number;
            if (int.TryParse(intN, out number))
            {
                return number;
            }
            return null;
        }

        public static long? ToNullableLong(this string longN)
        {
            long number;
            if (long.TryParse(longN, out number))
            {
                return number;
            }
            return null;
        }

        public static string ToPasswordHash(this string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }
    }
}
