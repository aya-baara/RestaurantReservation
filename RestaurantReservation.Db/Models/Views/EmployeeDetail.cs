using RestaurantReservation.Db.Models.Enums;

namespace RestaurantReservation.Db.Models.Views;

public class EmployeeDetail
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmployeePosition Position { get; set; }
    public string Name { get; set; }  
    public string Address { get; set; } 
}
