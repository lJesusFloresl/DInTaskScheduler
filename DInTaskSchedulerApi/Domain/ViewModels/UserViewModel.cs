using DInTaskSchedulerApi.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Domain.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Lastname { get; set; }
        public string SecondLastname { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Get complete name
        /// </summary>
        /// <param name="startFromLastnames">Indicates if complete name start by lastname or name</param>
        /// <returns>Complete name</returns>
        public string GetCompleteName(bool startFromLastnames = false)
        {
            if (startFromLastnames)
                return string.Format(Constants.FORMAT_COMPLETE_NAME, Utils.GetString(Lastname), Utils.GetString(SecondLastname), Utils.GetString(Name)).Trim();
            else
                return string.Format(Constants.FORMAT_COMPLETE_NAME, Utils.GetString(Name), Utils.GetString(Lastname), Utils.GetString(SecondLastname)).Trim();
        }
    }
}
