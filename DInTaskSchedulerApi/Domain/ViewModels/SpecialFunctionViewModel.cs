namespace DInTaskSchedulerApi.Domain.ViewModels
{
    public class SpecialFunctionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CatalogViewModel PropertyType { get; set; }
    }
}
