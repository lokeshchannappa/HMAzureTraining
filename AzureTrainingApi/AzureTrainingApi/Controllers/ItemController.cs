using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureTrainingApi.Models;
using AzureTrainingApi.Utility;
using Microsoft.AspNetCore.Mvc;

namespace AzureTrainingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ICosmosDbService _cosmosDbService;
        public ItemController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _cosmosDbService.GetItemsAsync("SELECT * FROM c"));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] Item item)
        {
            if (ModelState.IsValid)
            {
                item.Id = Guid.NewGuid().ToString();
                await _cosmosDbService.AddItemAsync(item);
                return Created(string.Empty, item);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditAsync(string id, [FromBody] Item item)
        {
            if (ModelState.IsValid)
            {
                await _cosmosDbService.UpdateItemAsync(id, item);
                return Created(string.Empty, item);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteConfirmedAsync(string id)
        {
            await _cosmosDbService.DeleteItemAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            return Ok(await _cosmosDbService.GetItemAsync(id));
        }
    }
}