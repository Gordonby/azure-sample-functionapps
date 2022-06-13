using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using Microsoft.Extensions.Configuration;

namespace GordsSimpleApp
{
    public static class CheckAppSettings
    {
        [FunctionName("CheckAppSettings")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string funcRuntime=Environment.GetEnvironmentVariable("FUNCTIONS_WORKER_RUNTIME");
            string funcVersion=Environment.GetEnvironmentVariable("FUNCTIONS_EXTENSION_VERSION");
            string trafficId=Environment.GetEnvironmentVariable("TRAFFICID");

            return new ContentResult { Content = $"<html><body><h1>Info</h1><ul><li>Traffic Id: {trafficId}</li></ul><h1>AppSettings</h1><ul><li>Functions Runtime: {funcRuntime}</li><li>Function Version: {funcVersion}</li></ul></body></html>", ContentType = "text/html" };
        }
    }
}
