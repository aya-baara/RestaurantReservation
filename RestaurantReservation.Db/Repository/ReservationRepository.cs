using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interface;
using RestaurantReservation.Db.Models;

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
}

