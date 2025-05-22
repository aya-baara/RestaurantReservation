using RestaurantReservation.Db.Interface;
namespace RestaurantReservation.Db.Models;

public class Customer : IModel
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
}

