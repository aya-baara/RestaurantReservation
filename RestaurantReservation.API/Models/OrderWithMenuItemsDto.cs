using RestaurantReservation.Db.Models;

namespace RestaurantReservation.API.Models;

public class OrderWithMenuItemsDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int TotalAmount { get; set; }
    public int EmployeeId { get; set; }
    public List<MenuItemDto> MenuItems { get; set; } = new List<MenuItemDto>();
    public int ReservationId { get; set; }
}

