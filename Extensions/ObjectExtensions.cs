using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Converts a string to sentence case.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string ToSentenceCase(this object input, CultureInfo culture)
        {
            string str = input.ToString();
            string lowerCase = str.ToLower(culture);
            Regex r = new Regex(@"(^[a-zığüşöç])|\.\s+(.)", RegexOptions.ExplicitCapture);
            
            return r.Replace(lowerCase, s => s.Value.ToUpper(culture));
        }

        /// <summary>
        /// Converts a string to sentence case.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSentenceCase(this object input)
        {
            return input.ToSentenceCase(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns default value, if the object is null or conversion has failed
        /// </summary>
        /// <param name="value">object</param>
        /// <param name="defaultValue">DateTime</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTime(this object value, DateTime defaultValue)
        {
            try
            {
                return value == null ? defaultValue : Convert.ToDateTime(value);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Returns default value, if the object is null or conversion has failed
        /// </summary>
        /// <param name="value">object</param>
        /// <param name="defaultValue">int</param>
        /// <returns>int</returns>
        public static int ToInt32(this object value, int defaultValue = 0)
        {
            try
            {
                return value == null ? defaultValue : Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Returns default value, if the object is null or conversion has failed
        /// </summary>
        /// <param name="value">object</param>
        /// <param name="defaultValue">int?</param>
        /// <returns>int?</returns>
        public static int? ToNInt32(this object value, int? defaultValue = null)
        {
            try
            {
                return value == null ? defaultValue : Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Return display attribute of the field of the object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Display<T>(this T obj, Expression<Func<T, object>> value)
        {
            MemberExpression memberExpression = value.Body as MemberExpression;
            object[] attr = memberExpression.Member.GetCustomAttributes(typeof(DisplayAttribute), true);
            
            return ((DisplayAttribute)attr[0]).Name;
        }        
    }
}
