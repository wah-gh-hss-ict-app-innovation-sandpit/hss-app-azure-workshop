using Azure.Storage;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Azure.Data;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Azure;

namespace demostoragequeue
{
    public class Program
    {
        private const string STORAGECONNSTRING = "{replace with your storage connection string}";
        private const string QUEUENAME = "message-queue";

        static void Main(string[] args)
        {
            WriteSomethingToQueue();

            ProcessQueue();

            ReadAllMessagesFromTable();
        }

        private static void ReadAllMessagesFromTable()
        {
            try{
                var tableServiceClient = new TableServiceClient(STORAGECONNSTRING);

                var tableClient = tableServiceClient.GetTableClient(tableName: "demomessageTable");

                Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: $"PartitionKey eq 'message-partition'");

                // Iterate the <see cref="Pageable"> to access all queried entities.
                foreach (TableEntity qEntity in queryResultsFilter)
                {
                    Console.WriteLine($"Message is {qEntity.GetString("TheMessage")}: {qEntity.GetString("Timestamp")}");
                }

                Console.WriteLine($"The query returned {queryResultsFilter.Count()} entities.");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void WriteSomethingToQueue()
        {
            try{
                QueueClient client = new QueueClient(STORAGECONNSTRING, QUEUENAME);
                client.CreateIfNotExists();

                client.SendMessage("Message 1 to the queue");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void ProcessQueue()
        {
            try{
                // Read from the queue and write it to the table storage
                QueueClient client = new QueueClient(STORAGECONNSTRING, QUEUENAME);

                foreach(var message in client.ReceiveMessages(maxMessages: 5).Value)
                {
                    Console.WriteLine($"Message: {message.Body}");

                    WriteMessageToTable(message);

                    // Remove message from queue after processing
                    client.DeleteMessage(message.MessageId, message.PopReceipt);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void WriteMessageToTable(QueueMessage message)
        {
            try{
                var tableServiceClient = new TableServiceClient(STORAGECONNSTRING);

                string partitionKey = "message-partition";
                string rowKey = Guid.NewGuid().ToString();

                TableItem table = tableServiceClient.CreateTableIfNotExists("demomessageTable");

                var tableClient = tableServiceClient.GetTableClient(tableName: "demomessageTable");
                tableClient.CreateIfNotExists();

                var entity = new TableEntity(partitionKey, rowKey){
                    {"TheMessage", message.Body.ToString()}
                };

                tableClient.AddEntity(entity);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}