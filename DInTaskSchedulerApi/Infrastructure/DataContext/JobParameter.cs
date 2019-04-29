using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class JobParameter
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public int IdPropertyType { get; set; }
        public int IdJob { get; set; }
        public int? IdSpecialFunction { get; set; }
        public int IdParameterType { get; set; }
        public int? IdJobParameter { get; set; }
        public string Value { get; set; }

        public Job IdJobNavigation { get; set; }
        public ParameterType IdParameterTypeNavigation { get; set; }
        public PropertyType IdPropertyTypeNavigation { get; set; }
        public SpecialFunction IdSpecialFunctionNavigation { get; set; }
    }
}
