using Microsoft.AspNetCore.Mvc;
using Test.Helpers;
namespace Test.Controllers;

[ApiController]
[Route("[controller]")]

public class AuthentificationController: ControllerBase
{
    private readonly Auth _auth;

    public AuthentificationController(IConfiguration config)
    {
        _auth = new Auth(config);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        if (loginRequest.username == "admin")
        {
            return Ok(new  { Token = _auth.GenerateToken(60) });
        }

        return Unauthorized(new { Message = "Invalid username" });
    }
}

public record LoginRequest(string username, string password);