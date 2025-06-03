namespace RestaurantReservation.API.Models;

public class OrderWithItemsResponseDto
{
    public List<OrderWithMenuItemsDto> Orders { get; set; } = new List<OrderWithMenuItemsDto>();
}

