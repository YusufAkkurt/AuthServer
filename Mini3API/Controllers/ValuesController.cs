using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mini3.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetValue()
        {
            var value = "Login olmadan bağlanıldı";
            return Ok($"Value işlemleri => değer: {value}");
        }
    }
}
