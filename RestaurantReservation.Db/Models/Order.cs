using RestaurantReservation.Db.Interface;

namespace RestaurantReservation.Db.Models;

public class Order : IModel
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int TotalAmount { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public Reservation Reservation { get; set; }
    public int ReservationId { get; set; }
}

