using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using WhereIsPatient.DB;
using WhereIsPatient.DB.Models;

namespace WhereIsPatient.ProcessQueueFunction
{
    public class FunctionProcessQueue
    {
        private readonly WhereIsPatientContext _context;

        public FunctionProcessQueue(WhereIsPatientContext context)
        {
            _context = context;
        }

        [FunctionName("FunctionProcessQueue")]
        public void Run([QueueTrigger("patient-message-queue", Connection = "MessageQueueConnString")]string myQueueItem, ILogger log)
        {
            try
            {
                Patient? patient = JsonSerializer.Deserialize<Patient>(myQueueItem);

                _context.Patients.Add(patient);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                log.LogError("Error saving data: ", ex);
            }

            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }

        
    }
}
