using RestaurantReservation.Db.Interface;

namespace RestaurantReservation.Db.Models;

public class OrderItem : IModel
{
    public int OrderItemId { get; set; }
    public int Quantity { get; set; }
    public Order Order { get; set; }
    public int OrderId { get; set; }
    public MenuItem MenuItem { get; set; }
    public int MenuItemId { get; set; }
}

