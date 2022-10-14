using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace demostorageblob
{
    public class Program
    {
        private const string STORAGECONNSTRING = "{replace with your storage connection string}";
        private const string CONTAINERNAME = "original-image";
        
        static void Main(string[] args)
        {
            UploadFile();
        }

        private static void UploadFile()
        {
            string blobName = "{the name of the blob you want to upload to}";
            string filePath = @"{the path to the file and this should include the file}";

            try{
                // Get a reference to the container
                BlobContainerClient container = new BlobContainerClient(STORAGECONNSTRING, CONTAINERNAME);
                container.CreateIfNotExists();

                // Get a reference to a blob. The blob name can be anything but as a good practice, make it the same name as the object you want to upload
                BlobClient blob = container.GetBlobClient(blobName);

                // Upload local file
                blob.Upload(filePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}