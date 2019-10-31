using Microsoft.AspNetCore.Mvc;
using Snp.Core.BaseDto;
using Snp.Service.RedisCaching;
using System;
using System.Threading.Tasks;

namespace Snp.Api.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("index")]
        public object index()
        {
            return new { code = "200" };
        }

        [HttpGet]
        [Route("error")]
        public string Error()
        {
            return "Xảy ra lỗi, xin vui lòng thử lại sau!";
        }
    }
}
