using System;
using System.Collections.Specialized;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Xenhey.BPM.Core.Net6;
using Xenhey.BPM.Core.Net6.Implementation;

namespace DataIngestionIntoAzureTable
{
    public class FileShareChecker
    {
        private NameValueCollection nvc = new NameValueCollection();

        [FunctionName("FileShareChecker")]
        public void Run([TimerTrigger("%TimerInterval%")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string ApiKeyName = "x-api-key";
            //Ge file and update database information.
            nvc.Add(ApiKeyName, "3FB620B0E0FD4E8F93C9E4D839D00E1E");
            string requestBody = "{\"ProcessStarted\" : \"Yes\" }";
            var uploadFile = orchrestatorService.Run(requestBody);
            log.LogInformation(uploadFile);
        }

        private IOrchestrationService orchrestatorService
        {
            get
            {
                return new ManagedOrchestratorService(nvc);
            }
        }
    }
}
