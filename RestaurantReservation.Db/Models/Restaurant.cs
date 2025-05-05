namespace RestaurantReservation.Db.Models;

public class Restaurant
{
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int PhoneNumber { get; set; }
    public string OpeningHours { get; set; }
}

