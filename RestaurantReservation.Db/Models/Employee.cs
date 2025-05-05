namespace RestaurantReservation.Db.Models;

class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public int ResturantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();
}

