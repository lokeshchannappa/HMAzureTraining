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
    public interface IAzureBlob
    {
         Task SaveAsync(Stream file, string fileName);
        Task<List<FileResponse>> GetAllFiles();


        /// <summary>
        /// Get Block Blob.
        /// </summary>
        /// <param name="blobName">Blob Name.</param>
        /// <param name="containerName">Container Name.</param>
        /// <returns>CloudBlockBlob Object.</returns>
        Task<CloudBlockBlob> GetBlockBlobAsync(string blobName, string containerName);

        /// <summary>
        /// Get Container.
        /// </summary>
        /// <param name="containerName">Container Name.</param>
        /// <returns>CloudBlobContainer Object.</returns>
        Task<CloudBlobContainer> GetContainerAsync(string containerName);
    }
}
