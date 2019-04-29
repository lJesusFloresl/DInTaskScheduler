using System.Collections.Generic;
using System.IO;

namespace DInTaskSchedulerApi.Tools
{
    /// <summary>
    /// Helper for html templates
    /// </summary>
    public static class HtmlTemplateHelper
    {
        /// <summary>
        /// Put dictionary values in html template with name from htmlTemplateName
        /// </summary>
        public static string GetHtmlWithValuesFromTemplate(string htmlTemplateName, Dictionary<string, string> values)
        {
            var path = Path.Combine("Templates", htmlTemplateName);
            var template = File.ReadAllText(path);
            return GetHtmlWithValues(template, values);
        }

        /// <summary>
        /// Put dictionary values in html template
        /// </summary>
        public static string GetHtmlWithValues(string html, Dictionary<string, string> values)
        {
            string templateHtml = html;
            foreach (var value in values)
            {
                templateHtml = templateHtml.Replace(value.Key, value.Value);
            }
            return templateHtml;
        }

        /// <summary>
        /// Get template stream
        /// </summary>
        /// <param name="htmlTemplateName"></param>
        /// <returns></returns>
        public static Stream GetTemplateBytes(string htmlTemplateName)
        {
            var path = Path.Combine("Templates", htmlTemplateName);
            var template = File.ReadAllBytes(path);
            return new MemoryStream(template);
        }
    }
}
