using RestaurantReservation.Db.Interface;

namespace RestaurantReservation.Db.Models;

public class MenuItem : IModel
{
    public int MenuItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public Restaurant Restaurant { get; set; }
    public int RestaurantId { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

