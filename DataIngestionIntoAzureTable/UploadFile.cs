using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using System.Linq;
using Xenhey.BPM.Core.Net6;
using System.IO;
using Xenhey.BPM.Core.Net6.Implementation;

namespace DataIngestionIntoAzureTable
{
    public class UploadFile
    {
        private HttpRequest _req;
        private NameValueCollection nvc = new NameValueCollection();
        [FunctionName("UploadFile")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
            HttpRequest req, ILogger log)
        {
            _req = req;

            log.LogInformation("C# HTTP trigger function processed a request.");
            _req.Headers.ToList().ForEach(item => { nvc.Add(item.Key, item.Value.FirstOrDefault()); });
            var results = orchrestatorService.Run(_req.Body);
            return resultSet(results);

        }

        private ActionResult resultSet(string reponsePayload)
        {
            var returnContent = new ContentResult();
            var mediaSelectedtype = nvc.Get("Content-Type");
            returnContent.Content = reponsePayload;
            returnContent.ContentType = mediaSelectedtype;
            return returnContent;
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
