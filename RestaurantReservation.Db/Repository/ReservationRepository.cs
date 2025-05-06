using RestaurantReservation.Db.Interface;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repository;

class ReservationRepository : Repository<Reservation>, IRepository<Reservation>
{
    public ReservationRepository(RestaurantReservationDbContext restaurantReservationDbContext) : base(restaurantReservationDbContext)
    {
    }
}

