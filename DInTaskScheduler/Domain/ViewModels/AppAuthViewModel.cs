namespace DInTaskScheduler.Domain.ViewModels
{
    public class AppAuthViewModel
    {
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public bool UseHeadQuarter { get; set; }

        public AppAuthViewModel()
        {
            this.UseHeadQuarter = false;
        }
    }
}
