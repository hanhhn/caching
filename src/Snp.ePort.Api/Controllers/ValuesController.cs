using Microsoft.AspNetCore.Mvc;

namespace Snp.ePort.Api.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("index")]
        public object Get()
        {
            return new { code = "200" };
        }
    }
}
