using RestaurantReservation.Db.Repository;

public class ReservationService
{
    private readonly ReservationRepository _repo;

    public ReservationService(ReservationRepository repo)
    {
        _repo = repo;
    }

    public async Task ViewReservationsDetails()
    {
        var details = await _repo.ViewReservationDetails();
        foreach (var d in details)
        {
            Console.WriteLine($"Reservation #{d.ReservationId} | Customer: {d.FirstName} {d.LastName} | Restaurant: {d.Name}");
        }
    }
}
