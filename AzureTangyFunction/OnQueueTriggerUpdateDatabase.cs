using System;
using AzureTangyFunction.Data;
using AzureTangyFunction.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureTangyFunction
{
    public class OnQueueTriggerUpdateDatabase
    {
        private readonly AzureTangyDbContext _db;

        public OnQueueTriggerUpdateDatabase(AzureTangyDbContext db)
        {
            _db = db;
        }

        [FunctionName("OnQueueTriggerUpdateDatabase")]
        public void Run([QueueTrigger("SalesRequestInBound", Connection = "AzureWebJobsStorage")] SalesRequest myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            // change status of queue item
            myQueueItem.Status = "Submitted";

            // Add queue to db
            _db.SalesRequests.Add(myQueueItem);
            
            log.LogInformation($"Queue adding to sales request");

            // Save the changes in order to reflet on the database
            _db.SaveChanges();

            log.LogInformation($"Queue added to sales request");


        }
    }
}
