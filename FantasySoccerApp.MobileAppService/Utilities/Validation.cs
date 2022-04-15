using System;
using System.Text.RegularExpressions;
using FantasySoccerApp.MobileAppService.Models;

namespace FantasySoccerApp.MobileAppService.Utilities
{
    public static class Validation
    {
        public static bool Item(ValidationTypes type, string value, bool isOptional = false)
        {
            if (isOptional && String.IsNullOrEmpty(value)) return true;

            switch (type)
            {
                case ValidationTypes.ZipUS:
                    return ZipUS(value);
                case ValidationTypes.ZipCanada:
                    return ZipCanada(value);
                case ValidationTypes.Password:
                    return Password(value);
                case ValidationTypes.PhoneUS:
                    return PhoneUS(value);
                case ValidationTypes.Date:
                    return Date(value);
                case ValidationTypes.FutureDate:
                    return FutureDate(value);
                case ValidationTypes.FirstAndLastName:
                    return FirstAndLastName(value);
                case ValidationTypes.Email:
                    return Email(value);
                case ValidationTypes.Double:
                    return IsDouble(value);
                case ValidationTypes.Integer:
                    return IsInteger(value);
                case ValidationTypes.AnyValue:
                    return !String.IsNullOrEmpty(value);
                case ValidationTypes.Blank:
                    return String.IsNullOrEmpty(value);
                case ValidationTypes.CreditCard:
                    return CreditCard(value);
                case ValidationTypes.CVV:
                    return CVV(value);
                default:
                    return false;
            }
        }

        private static bool ZipUS(string subject)
        {
            return IsMatch("^\\d{5}$", subject);
        }

        private static bool ZipCanada(string subject)
        {
            return IsMatch(@"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}((\d[ABCEGHJKLMNPRSTVWXYZ]\d)|)$", subject.ToUpper());
        }

        private static bool Password(string subject)
        {
            return IsMatch("^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$", subject);
        }

        private static bool PhoneUS(string subject)
        {
            return IsMatch("^(\\([2-9]\\d{2}\\)|[2-9]\\d{2})[- .]?\\d{3}[- .]?\\d{4}$", subject);
        }

        private static bool Email(string subject)
        {
            return IsMatch("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z0-9]{2,})(\\]?)$", subject);
        }

        private static bool IsDouble(string subject)
        {
            double val;
            return Double.TryParse(subject, out val);
        }

        private static bool IsInteger(string subject)
        {
            int val;
            return Int32.TryParse(subject, out val);
        }

        private static bool Date(string subject)
        {
            try
            {
                DateTime d = DateTime.Parse(subject);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool FutureDate(string subject)
        {
            try
            {
                DateTime d = DateTime.Parse(subject);
                if (d > DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private static bool FirstAndLastName(string subject)
        {
            if (string.IsNullOrEmpty(subject))
            {
                return false;
            }
            else
            {
                var s = subject.Trim();
                var sa = s.Split(' ');
                if (s.Contains(" ") & !s.Contains("&"))
                {
                    if (!string.IsNullOrEmpty(sa[0]) & !string.IsNullOrEmpty(sa[sa.Length - 1]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool CreditCard(string t)
        {
            return IsMatch("\\A(?:^(?:^((4\\d{3})|(5[1-5]\\d{2})|(6011))\\d{4}\\d{4}\\d{4}|3[4,7]\\d{13}$)$)\\Z", t);
        }

        public static bool CreditCardExpiration(int? month, int? year)
        {
            try
            {
                long ExDateInt;
                long TodayInt = DateTime.Now.Ticks;
                DateTime ExDateDate = new DateTime(year.GetValueOrDefault(), month.GetValueOrDefault(), 1);
                ExDateDate = ExDateDate.AddMonths(1);
                ExDateDate = ExDateDate.AddDays(-1);
                ExDateInt = ExDateDate.Ticks;
                if (ExDateInt - TodayInt < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool CVV(string number)
        {
            try
            {
                return IsMatch("[0-9]{3,4}", number);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool IsMatch(string regex, string subject)
        {
            if (string.IsNullOrEmpty(subject)) return false;
            var re = new Regex(regex, RegexOptions.IgnoreCase);
            return re.IsMatch(subject);
        }
    }
}