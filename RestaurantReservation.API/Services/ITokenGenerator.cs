using RestaurantReservation.API.Models.Tokens;

namespace RestaurantReservation.API.Services;

public interface ITokenGenerator
{
    public AuthToken GenerateToken(User user);
    public bool ValidateToken(AuthToken token);
}

