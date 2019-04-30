using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DInTaskScheduler.Tools
{
    public static class UtilsExtensions
    {
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
    }
}
