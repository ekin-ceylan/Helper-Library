using System;
using System.Text.RegularExpressions;

namespace Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmail(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                       + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                       + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

                return regex.IsMatch(value);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tcKimlikNo"></param>
        /// <returns></returns>
        public static bool IsTcNo(this string tcKimlikNo)
        {
            bool returnvalue = false;

            if (tcKimlikNo.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                try
                {
                    TcNo = Int64.Parse(tcKimlikNo);

                    ATCNO = TcNo / 100;
                    BTCNO = TcNo / 100;

                    C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                    Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                    Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                    returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return returnvalue;
        }

        public static int ToInt32(this string value)
        {
            if (value.Length > 1)
            {
                value = value.TrimStart('0');
            }

            int req = 0;

            if (!int.TryParse(value, out req))
            {
                throw new ArgumentException("Can not convert value to int");
            }

            return req;
        }

        public static int ToInt32(this string value, int defaultValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            if (value.Length > 1)
            {
                value = value.TrimStart('0');
            }

            int req = 0;

            if (!int.TryParse(value, out req))
            {
                return defaultValue;
            }

            return req;
        }
    }
}
