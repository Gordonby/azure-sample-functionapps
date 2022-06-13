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
    public class ReturnObj
    {
        public string TrafficId { get; set; }
        public string Name { get; set; }
    }

    public static class Context
    {
        [FunctionName("Context")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "/api/context")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            // string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // dynamic data = JsonConvert.DeserializeObject(requestBody);
            // name = name ?? data?.name;

            return new JsonResult(new ReturnObj() { TrafficId = Environment.GetEnvironmentVariable("TRAFFICID"), Name=name });
        }
    }
}
