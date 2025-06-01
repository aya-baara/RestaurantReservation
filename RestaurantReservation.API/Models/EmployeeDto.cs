using RestaurantReservation.Db.Models.Enums;

namespace RestaurantReservation.API.Models;

public class EmployeeDto
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmployeePosition Position { get; set; }
    public int RestaurantId { get; set; }
}

