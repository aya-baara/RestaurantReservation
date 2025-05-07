namespace RestaurantReservation.Db.Models.Views;
public class ReservationDetail
{
    public int ReservationId { get; set; }
    public string FirstName { get; set; }        
    public string LastName { get; set; }
    public string Email { get; set; }
    public int CustomerPhoneNumber { get; set; }
    public string Name { get; set; }              
    public string Address { get; set; }
    public string OpeningHours { get; set; }
    public int RestaurantPhoneNumber { get; set; }
}


