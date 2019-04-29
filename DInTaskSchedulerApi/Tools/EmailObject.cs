using System.Collections.Generic;

namespace DInTaskSchedulerApi.Tools
{
    /// <summary>
    /// Email properties
    /// </summary>
    public class EmailObject
    {
        public IList<string> Destinataries { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public Dictionary<string, string> Values { get; set; }
        public IList<EmailEmbeddedResource> EmbeddedResources { get; set; }

        public EmailObject()
        {
            this.Destinataries = new List<string>();
            this.Values = new Dictionary<string, string>();
            this.EmbeddedResources = new List<EmailEmbeddedResource>();
        }
    }
}
