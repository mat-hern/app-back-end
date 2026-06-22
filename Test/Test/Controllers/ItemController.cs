using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ItemController : ControllerBase
  {
      [Authorize]
      [HttpGet]
      public IActionResult Get()
      {
          var users = new[] { "allo" };
          return Ok(users);
      }
  }  
}
