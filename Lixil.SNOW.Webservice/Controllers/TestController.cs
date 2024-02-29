using Microsoft.AspNetCore.Mvc;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet(Name = "GetTest")]
        public IEnumerable<Test> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Test
            {
                TempNo = index,
                TempName= "TempName" + index
            }).ToArray();
        }
    }
}
