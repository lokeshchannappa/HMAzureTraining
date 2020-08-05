using AzureTrainingApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AzureTraining.Utility
{
    public class AzureBlob : IAzureBlob
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureBlob"/> class. 
        /// </summary>
        /// <param name="configuration">IConfiguration Object.</param>
        public AzureBlob(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SaveAsync(Stream file, string fileName)
        {
            CloudBlockBlob blockBlob = await this.GetBlockBlobAsync(fileName, this.configuration["Azure:Blob:Container"]);
            await blockBlob.UploadFromStreamAsync(file);
        }

        public async Task<List<FileResponse>> GetAllFiles()
        {
            List<FileResponse> urls = new List<FileResponse>();
            CloudBlobContainer blobContainer = await this.GetContainerAsync(this.configuration["Azure:Blob:Container"]);
            try
            {
                //root directory
                CloudBlobDirectory dira = blobContainer.GetDirectoryReference(string.Empty);
                //true for all sub directories else false 
                var rootDirFolders = await dira.ListBlobsSegmentedAsync(true, BlobListingDetails.Metadata, null, null, null, null);

                foreach (var blob in rootDirFolders.Results)
                {
                    urls.Add(new FileResponse{
                        Name = System.IO.Path.GetFileName(blob.Uri.OriginalString),
                        URL = blob?.Uri?.OriginalString
                    });
                }

            }
            catch (Exception e)
            {
                //  Block of code to handle errors
            }
            return urls;
        }


        /// <summary>
        /// Get Block Blob.
        /// </summary>
        /// <param name="blobName">Blob Name.</param>
        /// <param name="containerName">Container Name.</param>
        /// <returns>CloudBlockBlob Object.</returns>
        public async Task<CloudBlockBlob> GetBlockBlobAsync(string blobName, string containerName)
        {
            CloudBlobContainer blobContainer = await this.GetContainerAsync(containerName);
            return blobContainer.GetBlockBlobReference(blobName);
        }

        /// <summary>
        /// Get Container.
        /// </summary>
        /// <param name="containerName">Container Name.</param>
        /// <returns>CloudBlobContainer Object.</returns>
        public async Task<CloudBlobContainer> GetContainerAsync(string containerName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(this.configuration["Azure:Blob:ConnectionString"]);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
            if (await blobContainer.ExistsAsync(null, null))
            {
                return blobContainer;
            }
            else
            {
                await blobContainer.CreateIfNotExistsAsync();
                return blobContainer;
            }
        }
    }
}
