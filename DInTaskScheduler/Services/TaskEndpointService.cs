using DInTaskScheduler.Api;
using DInTaskScheduler.Models;
using DInTaskScheduler.Tools;
using System;
using System.Threading.Tasks;

namespace DInTaskScheduler.Services
{
    public static class TaskEndpointService
    {
        private static DInServicesApi api = new DInServicesApi();

        public static Action ExecuteEndpointTaskAction(EndpointTaskViewModel model)
        {
            return new Action(() => 
            {
                Utils.PrintConsole(string.Format("Execution for endpoint {0} -->", model.EndpointSufix));
                Utils.PrintConsole(string.Format("Body: {0}", model.Body.ToJson()));
                var result = api.ExecuteEndpointTask(model).GetAwaiter().GetResult();
                Utils.PrintConsole(string.Format("Result: {0}", result.ToJson()));
                Utils.PrintConsole(result.ToJson());
                Utils.PrintConsole(string.Format("Execution for endpoint {0} //>", model.EndpointSufix));
            });
        }

        public static void ExecuteEndpointTaskAsync(EndpointTaskViewModel model)
        {
            Task.Run(() => 
            {
                Utils.PrintConsole(string.Format("Execution for endpoint {0} -->", model.EndpointSufix));
                Utils.PrintConsole(string.Format("Body: {0}", model.Body.ToJson()));
                var result = api.ExecuteEndpointTask(model).GetAwaiter().GetResult();
                Utils.PrintConsole(string.Format("Result: {0}", result.ToJson()));
                Utils.PrintConsole(result.ToJson());
                Utils.PrintConsole(string.Format("Execution for endpoint {0} //>", model.EndpointSufix));
            });
        }
    }
}
