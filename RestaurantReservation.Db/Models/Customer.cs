namespace RestaurantReservation.Db.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
}

