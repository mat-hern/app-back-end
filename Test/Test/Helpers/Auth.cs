using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Test.Helpers;

public class Auth
{
    private readonly IConfiguration _configuration;
    
    public Auth(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    /*
     * Should add as a parameter for ClaimIdentity
     */
    public string GenerateToken(int expirationTime)
    {
        var jwtKey = _configuration["Jwt:Key"]!;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var audience = _configuration["Jwt:Audience"];
        var issuer = _configuration["Jwt:Issuer"];
        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(), 
            Expires = DateTime.UtcNow.AddMinutes(expirationTime),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials =  credentials
        };

        var handler = new JsonWebTokenHandler();
        return handler.CreateToken(tokenDescription);
    }
}