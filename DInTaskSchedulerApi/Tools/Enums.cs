using System.ComponentModel;

namespace DInTaskSchedulerApi.Tools
{
    /// <summary>
    /// All enumerators used in this API must be write here
    /// </summary>
    public static class Enums
    {
        public enum ApiEnvironment
        {
            [Description("Local")]
            LOCAL = 1,
            [Description("QA")]
            QA = 2,
            [Description("Production")]
            PRODUCTION = 3
        }

        public enum EmailEmbeddedResourceType
        {
            IMAGE = 1
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

        public enum StatusCatalog
        {
            ACTIVE = 1,
            INACTIVE = 2
        }
    }
}
