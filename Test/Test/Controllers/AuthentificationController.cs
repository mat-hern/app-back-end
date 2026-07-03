using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Test.DataAdapters;
using Test.Helpers;
using Test.Models;

namespace Test.Controllers;

[ApiController]
[Route("[controller]")]

public class AuthentificationController: ControllerBase
{
    private readonly Auth _auth;
    private UserAdapter adapter;

    public AuthentificationController(IConfiguration config)
    {
        _auth = new Auth(config);
        this.adapter = new UserAdapter(config);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        User user =  adapter.GetUser(loginRequest.username);
        
        if (PasswordHasher.IsGoodPassword(loginRequest.password, user.Password))
        {
            return Ok(new  { Token = _auth.GenerateToken(60) });
        }

        return Unauthorized(new { Message = "Invalid username" });
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest registerRequest)
    {
        User user = this.adapter.AddData(new User{Username =  registerRequest.username, Password= registerRequest.password});
        return Ok(user);
        
    }
}

public record LoginRequest(string username, string password);
public record RegisterRequest(string username, string password);