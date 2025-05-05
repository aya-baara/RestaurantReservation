namespace RestaurantReservation.Db.Models;

class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int TotalAmount { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}

