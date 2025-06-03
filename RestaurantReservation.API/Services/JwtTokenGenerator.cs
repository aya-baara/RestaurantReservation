using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.API.Models.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantReservation.API.Services;

public class JwtTokenGenerator : ITokenGenerator
{
    private readonly IConfiguration _configuration;

public JwtTokenGenerator(IConfiguration configuration)
{
    _configuration = configuration;
}

public AuthToken GenerateToken(User user)
{
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.UTF8.GetBytes(_configuration["JWTToken:Key"]);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new[]
        {
                new Claim(ClaimTypes.Name, user.FirstName + user.LastName),
                new Claim("UserId", user.Id.ToString())
            }),
        Expires = DateTime.UtcNow.AddMinutes(5),
        Issuer = _configuration["JWTToken:Issuer"],
        Audience = _configuration["JWTToken:Audience"],
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);

    return new AuthToken { Token = tokenHandler.WriteToken(token) };
}

public bool ValidateToken(AuthToken token)
{
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.UTF8.GetBytes(_configuration["JWTToken:Key"]);

    var validationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = _configuration["JWTToken:Issuer"],
        ValidateAudience = true,
        ValidAudience = _configuration["JWTToken:Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

    try
    {
        tokenHandler.ValidateToken(token.Token, validationParameters, out SecurityToken validatedToken); 
            return true;
    }
    catch
    {
        return false;
    }
}
}

