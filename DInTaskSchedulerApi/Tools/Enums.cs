using System.ComponentModel;

namespace DInTaskSchedulerApi.Tools
{
    /// <summary>
    /// All enumerators used in this API must be write here
    /// </summary>
    public static class Enums
    {
        public enum EmailEmbeddedResourceType
        {
            IMAGE = 1
        }

        public enum PayForms
        {
            CASH = 1,
            CARD = 2,
            TRANSFER = 3
        }

        public enum Genders
        {
            [Description("M")]
            MALE = 1,
            [Description("F")]
            FEMALE = 2
        }

        public enum Months
        {
            JAN = 1,
            FEB = 2,
            MAR = 3,
            APR = 4,
            MAY = 5,
            JUN = 6,
            JUL = 7,
            AUG = 8,
            SEP = 9,
            OCT = 10,
            NOV = 11,
            DEC = 12
        }
    }
}
