using RestaurantReservation.Db.Interface;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repository;

class OrderItemRepository : Repository<OrderItem>, IRepository<OrderItem>
{
    public OrderItemRepository(RestaurantReservationDbContext restaurantReservationDbContext) : base(restaurantReservationDbContext)
    {
    }
}

