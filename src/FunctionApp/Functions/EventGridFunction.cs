using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;

namespace Sample.FunctionApp.Functions
{
    public class EventGridFunction
    {
        [FunctionName(nameof(StorageHandler))]
        public async Task/*<IActionResult>*/ StorageHandler(
             [EventGridTrigger] EventGridEvent[] eventGridEvents,
            //[HttpTrigger]HttpRequest request,
            [EventGrid(TopicEndpointUri = @"SAMPLE_TOPIC_END_POINT", TopicKeySetting = @"SAMPLE_TOPIC_KEY")]IAsyncCollector<EventGridEvent> outputEvents,
            ILogger logger)
        {
            if (eventGridEvents == null)
            {
                throw new ArgumentNullException("Null request received");
            }

            foreach (var ege in eventGridEvents)
            {
                await outputEvents.AddAsync(ege);
            }

            //return new OkResult();
        }
    }
}