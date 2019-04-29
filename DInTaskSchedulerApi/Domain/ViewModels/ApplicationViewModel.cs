using System;

namespace DInTaskSchedulerApi.Domain.ViewModels
{
    public class ApplicationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public CatalogViewModel Status { get; set; }
    }
}
