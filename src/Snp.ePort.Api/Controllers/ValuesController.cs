using Microsoft.AspNetCore.Mvc;
using Snp.ePort.Core.BaseDto;
using Snp.ePort.Service.RedisCaching;
using System;
using System.Threading.Tasks;

namespace Snp.ePort.Api.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRedisCacheService _redisService;

        public ValuesController(IRedisCacheService service)
        {
            _redisService = service;
        }

        [HttpGet]
        [Route("index")]
        public object index()
        {
            return new { code = "200" };
        }

        [HttpGet]
        [Route("get")]
        public async Task<object> Get()
        {
            await _redisService.SetAsync(new CacheDto
            {
                Key = "abc",
                Value = Guid.NewGuid().ToString(),
                ExpireTime = 1,
            });
            return _redisService.GetAsync("abc");
        }
    }
}
