using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp1
{
    public static class GithubMonitor
    {
        [FunctionName("GithubMonitor")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "Contributors",
                collectionName: "authors",
                ConnectionStringSetting = "CosmosDBConnection")] IAsyncCollector<Sender> newAuthors,
            ILogger log)
        {
            log.LogInformation("Github Monitor processed a push.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Rootobject>(requestBody);
            var sender = data.sender;

            var senderSerialized = JsonConvert.SerializeObject(sender);
            log.LogInformation(senderSerialized);

            /*
            await newAuthors.AddAsync(sender);
            await newAuthors.FlushAsync();

            log.LogInformation("Added author successfully");
            */

            return new OkResult();
        }
    }
}