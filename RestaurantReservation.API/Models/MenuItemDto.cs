namespace RestaurantReservation.API.Models;

public class MenuItemDto
{
    public int MenuItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int RestaurantId { get; set; }
}

