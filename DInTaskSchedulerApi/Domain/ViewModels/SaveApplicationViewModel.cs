using System.Collections.Generic;

namespace DInTaskSchedulerApi.Domain.ViewModels
{
    public class SaveApplicationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdStatus { get; set; }
        public IList<int> Environments { get; set; }

        public SaveApplicationViewModel()
        {
            this.Environments = new List<int>();
        }
    }
}
