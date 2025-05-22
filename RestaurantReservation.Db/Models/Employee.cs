using RestaurantReservation.Db.Interface;
using RestaurantReservation.Db.Models.Enums;

namespace RestaurantReservation.Db.Models;

public class Employee : IModel
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmployeePosition Position { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();
}

