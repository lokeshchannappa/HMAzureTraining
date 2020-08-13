using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AzureTrainingApi.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace AzureTrainingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        private IDistributedCache _cache;
        public RedisController(IDistributedCache cache, IConfiguration Configuration)
        {
            this._cache = cache;
            this.Configuration = Configuration;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetByKey(string key)
        {
            return Ok(this._cache.GetString(key) ?? "");
        }

        [HttpPost]
        public async Task<IActionResult> SetByKey(CustomCache request)
        {
            await _cache.SetStringAsync(request.Key, request.Value);
            return Ok(new KeyValuePair<string, string>(request.Key, _cache.GetString(request.Key)));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            ConfigurationOptions options = ConfigurationOptions.Parse(Configuration.GetConnectionString("RedisConnection"));
            using (ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(options))
            {
                EndPoint endPoint = connection.GetEndPoints().First();
                var server = connection.GetServer(endPoint);
                foreach (var key in server.Keys(pattern: "*"))
                {
                    result.Add(new KeyValuePair<string, string>(key, _cache.GetString(key)));
                }
            }
            return Ok(result);
        }
        [HttpDelete("{key}")]
        public async Task<IActionResult> DeleteByKey(string key)
        {
            this._cache.Remove(key);
            return Ok();
        }
    }
}
