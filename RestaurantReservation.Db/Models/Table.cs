namespace RestaurantReservation.Db.Models;

class Table
{
    public int TableId { get; set; }
    public int Capacity { get; set; }

    public int ResturantId { get; set; }
    public Restaurant Restaurant { get; set; }
}

