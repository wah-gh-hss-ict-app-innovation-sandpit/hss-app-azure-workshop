using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Drawing;
using LazZiya.ImageResize;

namespace demostorageblob
{
    public class Program
    {
        private const string STORAGECONNSTRING = "{replace with your storage connection string}";
        private const string ORIGINALCONTAINERNAME = "original-image";

        private const string RESIZEDCONTAINERNAME = "small-image";
        
        static void Main(string[] args)
        {
            string blobName = "{the name of the blob you want to upload to}";
            string fullFilePath = @"{the path to the file and this should include the file}";
            string filePath = @"{the path to the file and this should only be the path and no file name}";

            // Upload original file
            UploadFile(ORIGINALCONTAINERNAME, fullFilePath);

            // Resize file
            string resizedFile = ResizeFile(fullFilePath, filePath, blobName);

            // Upload resized file
            UploadFile(RESIZEDCONTAINERNAME, resizedFile);
        }

        private static void UploadFile(string containerName, string fullFilePath)
        {
            try{
                // Get a reference to the container
                BlobContainerClient container = new BlobContainerClient(STORAGECONNSTRING, containerName);
                container.CreateIfNotExists();

                // Get a reference to a blob. The blob name can be anything but as a good practice, make it the same name as the object you want to upload
                BlobClient blob = container.GetBlobClient(blobName);

                // Upload local file
                blob.Upload(fullFilePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static string ResizeFile(string file, string filePath, string blobName)
        {
            string resizeFileName = "resized_" + blobName;
            string toSave = filePath + resizeFileName;

            using(var img = Image.FromFile(file))
            {
                img.ScaleByWidth(600)
                .SaveAs(toSave);
            }

            return toSave;
        }
    }
}