namespace DInTaskSchedulerApi.Tools
{
    /// <summary>
    /// Class with email server configurations
    /// </summary>
    public class ConfigEmail
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
    }
}
