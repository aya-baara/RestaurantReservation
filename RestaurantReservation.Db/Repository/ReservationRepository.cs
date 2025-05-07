using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interface;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Models.Views;

namespace RestaurantReservation.Db.Repository;

public class ReservationRepository : Repository<Reservation>, IRepository<Reservation>
{
    private readonly RestaurantReservationDbContext _context;
    public ReservationRepository(RestaurantReservationDbContext restaurantReservationDbContext) : base(restaurantReservationDbContext)
    {
        _context = restaurantReservationDbContext;
    }
    public async Task<List<Reservation>> GetReservationsByCustomer(int csustomerId)
    {
        return await
            _context.Reservations.Where(r => r.CustomerId == csustomerId).ToListAsync();

    }
    public async Task<List<ReservationDetail>> ViewReservationDetails()
    {
        return await _context.ReservationDetails.ToListAsync();

    }

}

