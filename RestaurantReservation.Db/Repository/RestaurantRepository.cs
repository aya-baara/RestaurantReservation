using RestaurantReservation.Db.Interface;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repository
{
    class RestaurantRepository : Repository<Restaurant>, IRepository<Restaurant>
    {
        public RestaurantRepository(RestaurantReservationDbContext restaurantReservationDbContext) : base(restaurantReservationDbContext)
        {
        }
    }
}
