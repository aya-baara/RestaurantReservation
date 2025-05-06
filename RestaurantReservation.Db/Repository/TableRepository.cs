using RestaurantReservation.Db.Interface;
using RestaurantReservation.Db.Models;


namespace RestaurantReservation.Db.Repository;

class TableRepository : Repository<Table>, IRepository<Table>
{
    public TableRepository(RestaurantReservationDbContext restaurantReservationDbContext) : base(restaurantReservationDbContext)
    {
    }
}

