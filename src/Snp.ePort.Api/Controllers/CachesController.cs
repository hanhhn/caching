using Microsoft.AspNetCore.Mvc;
using Snp.ePort.Core.BaseDto;
using Snp.ePort.Service.RedisCaching;
using System;
using System.Threading.Tasks;

namespace Snp.ePort.Api.Controllers
{
    [Route("api/caches")]
    [ApiController]
    public class CachesController : ControllerBase
    {
        private readonly IRedisCacheService _redisService;

        public CachesController(IRedisCacheService service)
        {
            _redisService = service;
        }

        [HttpGet]
        [Route("get/{key}")]
        public Task<string> Get(string key)
        {
            return _redisService.GetAsync(key);
        }

        [HttpPost]
        [Route("set")]
        public Task Set([FromBody] CacheDto cache)
        {
            return _redisService.SetAsync(cache);
        }

        [HttpDelete]
        [Route("remove/{key}")]
        public Task Remove(string key)
        {
            return _redisService.RemoveAsync(key);
        }

        [HttpPut]
        [Route("refresh/{key}")]
        public void Refresh(string key)
        {
            _redisService.Refresh(key);
        }
    }
}
