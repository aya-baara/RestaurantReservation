using RestaurantReservation.Db.Models.Enums;

namespace RestaurantReservation.API.Models;

public class EmployeeCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmployeePosition Position { get; set; }
    public int RestaurantId { get; set; }
}

