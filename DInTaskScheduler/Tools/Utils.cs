using Newtonsoft.Json;
using System;
using System.Configuration;

namespace DInTaskScheduler.Tools
{
    public static class Utils
    {
        #region Server Response

        /// <summary>
        /// Get success response
        /// </summary>
        public static ServerResponse SuccessResponse(object id = null, string message = Constants.OK)
        {
            return new ServerResponse(true, message, id);
        }

        /// <summary>
        /// Get error response
        /// </summary>
        public static ServerResponse ErrorResponse(string messageComplement, object id = null)
        {
            return new ServerResponse(false, string.Format(Constants.ERROR, messageComplement), id);
        }

        #endregion

        /// <summary>
        /// Get appsetting value from app.config
        /// </summary>
        public static string GetAppSetting(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get current datetime.
        /// </summary>
        public static DateTime GetCurrentDateTime(bool withSeconds = true)
        {
            DateTime utctime = DateTime.UtcNow;
            TimeZoneInfo mexicoTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
            DateTime mexicoLocalTime = TimeZoneInfo.ConvertTimeFromUtc(utctime, mexicoTimeZone);
            if (!withSeconds)
                mexicoLocalTime = new DateTime(mexicoLocalTime.Year, mexicoLocalTime.Month, mexicoLocalTime.Day, mexicoLocalTime.Hour, mexicoLocalTime.Minute, 0);
            return mexicoLocalTime;
        }

        /// <summary>
        /// Get current date
        /// </summary>
        public static DateTime GetCurrentDate()
        {
            return GetCurrentDateTime().Date;
        }

        /// <summary>
        /// Round datetime from timespan
        /// </summary>
        /// <param name="dateTime">Datetime to round</param>
        /// <param name="interval">Interval to round</param>
        /// <returns>DateTime</returns>
        public static DateTime RoundUp(DateTime dateTime, TimeSpan interval)
        {
            return new DateTime((dateTime.Ticks + interval.Ticks - 1) / interval.Ticks * interval.Ticks, dateTime.Kind);
        }

        /// <summary>
        /// Print data in console with log format
        /// </summary>
        /// <param name="data">Data to print</param>
        public static void PrintConsole(string data)
        {
            Console.WriteLine(Constants.FORMAT_LOG_OUTPUT, GetCurrentDateTime(), data);
        }

        /// <summary>
        /// Print data in console with log format
        /// </summary>
        /// <param name="data">Data to print</param>
        public static void PrintConsole(string formatString, params object[] data)
        {
            Console.WriteLine(Constants.FORMAT_LOG_OUTPUT, GetCurrentDateTime(), string.Format(formatString, data));
        }

        /// <summary>
        /// Deserialize json string object to object
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="json">String json</param>
        /// <returns>T object</returns>
        public static T DeserializeJson<T>(this string json)
        {
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        /// <summary>
        /// Serialize object to json string
        /// </summary>
        /// <param name="data">Object data</param>
        /// <returns>Json</returns>
        public static string SerializeJson(object data)
        {
            var result = JsonConvert.SerializeObject(data);
            return result;
        }

        #region Extension Methods

        /// <summary>
        /// Get string considerating null and whitespace values
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Text</returns>
        public static string Format(this string text)
        {
            return !string.IsNullOrWhiteSpace(text) ? text.Trim() : string.Empty;
        }

        /// <summary>
        /// Serialize object to json string
        /// </summary>
        /// <param name="data">Object data</param>
        /// <returns>Json</returns>
        public static string ToJson<T>(this T data) 
        {
            return SerializeJson(data);
        }

        #endregion
    }
}
