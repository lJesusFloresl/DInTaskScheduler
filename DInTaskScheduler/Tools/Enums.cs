using System.ComponentModel.DataAnnotations;

namespace DInTaskScheduler.Tools
{
    public static class Enums
    {
        public enum HttpMethods
        {
            [Display(Name = "GET")]
            GET = 1,
            [Display(Name = "POST")]
            POST = 2,
            [Display(Name = "PUT")]
            PUT = 3,
            [Display(Name = "DELETE")]
            DELETE = 4,
            [Display(Name = "OPTIONS")]
            OPTIONS = 5
        }
    }
}
