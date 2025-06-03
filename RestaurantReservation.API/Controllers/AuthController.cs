using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Tokens;
using RestaurantReservation.API.Services;

namespace RestaurantReservation.API.Controllers;

public class AuthController : ControllerBase
{
    private readonly ITokenGenerator _tokenGenerator;

    public AuthController(ITokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }
    [HttpPost("login")]
    public IActionResult Login(User requestUser)
    {
        var token = _tokenGenerator.GenerateToken(requestUser);

        if (token == null)
            return Unauthorized("Invalid username or password");

        return Ok(new { token });
    }
}

