using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace DInTaskSchedulerApi.Tools
{
    /// <summary>
    /// Util extensions class
    /// </summary>
    public static class UtilsExtensions
    {
        /// <summary>
        /// Get money format for decimal
        /// </summary>
        /// <param name="value">Decimal value</param>
        /// <param name="format">Format string</param>
        public static string ToMoney(this decimal value, string format = Constants.FORMAT_MONEY)
        {
            return string.Format(format, value);
        }

        /// <summary>
        /// Get "Name" property value from enumerator
        /// </summary>
        /// <param name="enumerator">Enumerator to check</param>
        /// <returns>String "Name" property</returns>
        public static string GetName(this Enum enumerator)
        {
            string displayName = string.Empty;
            MemberInfo info = enumerator.GetType().GetMember(enumerator.ToString()).First();

            if (info != null && info.CustomAttributes.Any())
            {
                DisplayAttribute nameAttr = info.GetCustomAttribute<DisplayAttribute>();
                displayName = nameAttr != null ? nameAttr.Name : enumerator.ToString();
            }
            else
            {
                displayName = enumerator.ToString();
            }

            return displayName;
        }

        /// <summary>
        /// Get enumerator value
        /// </summary>
        /// <param name="enumerator">Enumerator to check</param>
        /// <returns>Int del valor del enumerador</returns>
        public static int GetValue(this Enum enumerator)
        {
            int result = 0;
            if (enumerator != null)
            {
                try
                {
                    result = Convert.ToInt32(enumerator);
                }
                catch
                {
                    result = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// Get "Description" property value from enumerator
        /// </summary>
        /// <param name="enumerator">Enumerator to check</param>
        /// <returns>String "Description" property</returns>
        public static string GetDescription(this Enum enumerator)
        {
            MemberInfo[] memberInfo = enumerator.GetType().GetMember(enumerator.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return string.Empty;
        }

        /// <summary>
        /// Get enumerator value from description attribute
        /// </summary>
        /// <typeparam name="T">Enumerator type</typeparam>
        /// <param name="description">Description attribute value</param>
        /// <returns>Enumerator</returns>
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);

            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var enumeratorValue in type.GetFields())
            {
                var atributo = Attribute.GetCustomAttribute(enumeratorValue, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (atributo != null)
                {
                    if (atributo.Description == description)
                        return (T)enumeratorValue.GetValue(null);
                }
                else if (enumeratorValue.Name == description)
                    return (T)enumeratorValue.GetValue(null);
            }

            return default(T);
        }

        /// <summary>
        /// Get a variable value from configuration
        /// </summary>
        /// <param name="configuration">Api configuration</param>
        /// <param name="key">Variable to find</param>
        /// <returns>String value</returns>
        public static string GetString(this IConfiguration configuration, string key)
        {
            return configuration[key];
        }

        /// <summary>
        /// Get a variable value from configuration
        /// </summary>
        /// <param name="configuration">Api configuration</param>
        /// <param name="key">Variable to find</param>
        /// <returns>Int value</returns>
        public static int GetInt(this IConfiguration configuration, string key)
        {
            return Convert.ToInt32(configuration[key]);
        }

        /// <summary>
        /// Get a variable value from configuration
        /// </summary>
        /// <param name="configuration">Api configuration</param>
        /// <param name="key">Variable to find</param>
        /// <returns>Boolean value</returns>
        public static bool GetBoolean(this IConfiguration configuration, string key)
        {
            return Convert.ToBoolean(configuration[key]);
        }
    }
}
