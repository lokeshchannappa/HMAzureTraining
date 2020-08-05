using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AzureTraining.Utility;
using Microsoft.AspNetCore.Mvc;

namespace AzureTrainingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {

        private readonly IAzureBlob blob;
        public BlobController(IAzureBlob blob)
        {
            this.blob = blob;
        }
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        await blob.SaveAsync(ms, fileName);
                    }
                    var list = await blob.GetAllFiles();
                    return Ok(list);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFiles()
        {
            var list = await blob.GetAllFiles();
            if (list != null && list.Count > 0)
            {
                return Ok(list);
            }
            return NoContent();
        }
    }
}
