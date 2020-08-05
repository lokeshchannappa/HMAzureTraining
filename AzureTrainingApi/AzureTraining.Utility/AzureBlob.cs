using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AzureTraining.Utility
{
    public class AzureBlob
    {
        //private readonly IConfiguration configuration;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="AzureBlob"/> class. 
        ///// </summary>
        ///// <param name="configuration">IConfiguration Object.</param>
        //public AzureBlob(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}

        public async Task SaveAsync(Stream file, string blobName, string containerName)
        {
            CloudBlockBlob blockBlob = await this.GetBlockBlobAsync(blobName, containerName);
            await blockBlob.UploadFromStreamAsync(file);
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
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(this.configuration["Azure:Blob:ConnectionString"]);
            //CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
            //if (await blobContainer.ExistsAsync(null, null))
            //{
            //    return blobContainer;
            //}
            //else
            //{
            //    await blobContainer.CreateIfNotExistsAsync();
            //    return blobContainer;
            //}
            return null;
        }
    }
}
