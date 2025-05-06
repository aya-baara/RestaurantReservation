using RestaurantReservation.Db.Interface;

namespace RestaurantReservation.Db.Models;

public class Table : IModel
{
    public int TableId { get; set; }
    public int Capacity { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public List<Reservation> Reservations { get; set; }
}

