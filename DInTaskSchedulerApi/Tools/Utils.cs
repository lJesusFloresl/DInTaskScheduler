using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using static DInTaskSchedulerApi.Tools.Enums;

namespace DInTaskSchedulerApi.Tools
{
    /// <summary>
    /// Util class
    /// </summary>
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

        #region Dates

        /// <summary>
        /// Get date with custom format
        /// </summary>
        public static string GetDateFormat(DateTime? date, string format = Constants.FORMAT_DATE_DDMMYYYY)
        {
            return date.HasValue ? date.Value.ToString(format) : null;
        }

        /// <summary>
        /// Get date from value with custom format
        /// </summary>
        public static DateTime? GetDateFormat(string date, string format = Constants.FORMAT_DATE_DDMMYYYY)
        {
            DateTime? result;
            try
            {
                result = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
            }
            catch
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Get day of the week from date with custom format
        /// </summary>
        public static string GetDayOfTheWeek(DateTime currentDate, DateTime? date, out DateTime? dateOfWeek)
        {
            string dayOfWeek = string.Empty;
            dateOfWeek = null;
            if (date.HasValue)
            {
                DateTime weekDate = FixLeapDate(currentDate.Year, date.Value.Month, date.Value.Day);
                dayOfWeek = GetDayOfWeekTranslate(weekDate.DayOfWeek);
                dateOfWeek = weekDate;
            }
            return dayOfWeek;
        }

        /// <summary>
        /// Get current datetime.
        /// </summary>
        public static DateTime GetCurrentDateTime()
        {
            DateTime utctime = DateTime.UtcNow;
            TimeZoneInfo mexicoTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
            DateTime mexicoLocalTime = TimeZoneInfo.ConvertTimeFromUtc(utctime, mexicoTimeZone);
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
        /// Check if year is leap year
        /// </summary>
        public static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }

        /// <summary>
        /// Check if current date is leap date and fix day in february (29 day)
        /// </summary>
        /// <param name="year">Evaluation leap year</param>
        /// <param name="evaluationDate">Evaluation date</param>
        public static DateTime FixLeapDate(int year, int month, int day)
        {
            if (!DateTime.IsLeapYear(year) && (Months)month == Months.FEB && day == 29)
                return new DateTime(year, month + 1, 1);
            else
                return new DateTime(year, month, day);
        }

        /// <summary>
        /// Check if current date is leap date and fix day in february (29 day)
        /// </summary>
        /// <param name="year">Evaluation leap year</param>
        /// <param name="evaluationDate">Evaluation date</param>
        public static bool IsFixedLeapDate(int year, int month, int day)
        {
            if (!DateTime.IsLeapYear(year) && (Months)month == Months.FEB && day == 29)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Determinates if birthday is on current week
        /// </summary>
        /// <param name="period">Daterange</param>
        /// <param name="currentDate">Current date</param>
        /// <param name="birthday">Birthday</param>
        /// <returns>True or false</returns>
        public static bool IsInWeek(DateTime StartDate, DateTime EndDate, DateTime currentDate, DateTime birthday)
        {
            DateTime weekDate = FixLeapDate(currentDate.Year, birthday.Month, birthday.Day);
            return weekDate >= StartDate && weekDate <= EndDate;
        }

        /// <summary>
        /// Get total weeks difference from period
        /// </summary>
        /// <param name="period">Start and End dates</param>
        /// <returns>Total week diference</returns>
        public static double GetWeekDifference(DateTime StartDate, DateTime EndDate)
        {
            var result = Math.Abs((EndDate - StartDate).TotalDays / 7);
            return result;
        }

        #endregion

        #region Encoders

        /// <summary>
        /// Encode text to Base64 string
        /// </summary>
        public static string EncodeBase64(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Decode Base64 string to text
        /// </summary>
        public static string DecodeBase64(string textBase64)
        {
            var bytes = Convert.FromBase64String(textBase64);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Generates a Random Password respecting the given strength requirements
        /// </summary>
        public static string GenerateRandomPassword()
        {
            var passwordOptions = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",
                "abcdefghijkmnopqrstuvwxyz",
                "0123456789",
                "!@$?_-"
            };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (passwordOptions.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (passwordOptions.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (passwordOptions.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (passwordOptions.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < passwordOptions.RequiredLength
                || chars.Distinct().Count() < passwordOptions.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        /// <summary>
        /// Generate api key string 
        /// </summary>
        /// <returns>Api Key</returns>
        public static string GenerateApiKey()
        {
            return Guid.NewGuid().ToString();
        }

        #endregion

        #region Nullable

        /// <summary>
        /// Get string from text. Get empty string if null
        /// </summary>
        public static string GetString(string text)
        {
            return !string.IsNullOrWhiteSpace(text) ? text.Trim() : string.Empty;
        }

        /// <summary>
        /// Check string value
        /// </summary>
        /// <returns>True if string is not empty</returns>
        public static bool CheckString(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }

        #endregion

        #region Calculations

        /// <summary>
        /// Get next due date for subscriptions
        /// </summary>
        /// <param name="startDate">Start date who is calculating</param>
        /// <param name="dueDay">Due day</param>
        /// <param name="isPayment">Indicates if due date calculation is for payment</param>
        /// <param name="excludeWeekend">Indicates if weekend days are excluded for due date calculation</param>
        /// <returns>Due date</returns>
        public static DateTime GetNextDueDate(DateTime startDate, int dueDay, bool isPayment = false, bool excludeWeekend = true)
        {
            DateTime result = FixLeapDate(startDate.Year, startDate.Month, dueDay);
            int startDay = startDate.Day;

            if (isPayment && !IsFixedLeapDate(startDate.Year, startDate.Month, dueDay))
                result = result.AddMonths(1);
            else if (startDay > dueDay)
                result = result.AddMonths(1);

            if (excludeWeekend)
            {
                DayOfWeek dueDayOfWeek = result.DayOfWeek;
                switch (dueDayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        result = result.AddDays(2);
                        break;
                    case DayOfWeek.Sunday:
                        result = result.AddDays(1);
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Get decimal value with 2 decimals
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Value with 2 decimals</returns>
        public static decimal GetDecimal(decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Get translate word for day of week
        /// </summary>
        private static string GetDayOfWeekTranslate(DayOfWeek day)
        {
            string translateDay;
            switch (day)
            {
                case DayOfWeek.Monday:
                    translateDay = "Lunes";
                    break;
                case DayOfWeek.Tuesday:
                    translateDay = "Martes";
                    break;
                case DayOfWeek.Wednesday:
                    translateDay = "Miércoles";
                    break;
                case DayOfWeek.Thursday:
                    translateDay = "Jueves";
                    break;
                case DayOfWeek.Friday:
                    translateDay = "Viernes";
                    break;
                case DayOfWeek.Saturday:
                    translateDay = "Sábado";
                    break;
                case DayOfWeek.Sunday:
                    translateDay = "Domingo";
                    break;
                default:
                    translateDay = string.Empty;
                    break;
            }

            return translateDay;
        }

        #endregion
    }
}
