using System;
using System.IO;
using static DInTaskSchedulerApi.Tools.Enums;

namespace DInTaskSchedulerApi.Tools
{
    /// <summary>
    /// Embedded resources for mails
    /// </summary>
    public class EmailEmbeddedResource
    {
        public string GuidId { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public Stream Content { get; set; }
        public EmailEmbeddedResourceType Type { get; set; }

        public EmailEmbeddedResource()
        {
            this.GuidId = Guid.NewGuid().ToString();
        }
    }
}
