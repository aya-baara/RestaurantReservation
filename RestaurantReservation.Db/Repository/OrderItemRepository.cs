using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interface;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repository;

public class OrderItemRepository : Repository<OrderItem>, IRepository<OrderItem>
{
    private readonly RestaurantReservationDbContext _context;
    public OrderItemRepository(RestaurantReservationDbContext restaurantReservationDbContext) : base(restaurantReservationDbContext)
    {
        _context = restaurantReservationDbContext;
    }

    public async Task<List<MenuItem>> ListOrderedMenuItems(int reservationId)
    {
        return await _context.OrderItems
        .Include(o => o.Order)
        .Include(oI => oI.MenuItem)
         .Where(o => o.Order.ReservationId == reservationId)
         .Select(o => o.MenuItem)
         .Distinct()
         .ToListAsync();

    }

    public async Task<Dictionary<int, List<MenuItem>>> ListOrdersAndMenuItems(int reservationId)
    {
        return await _context.Orders
            .Where(o => o.Reservation.ReservationId == reservationId)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
            .ToDictionaryAsync(
                o => o.OrderId,
                o => o.OrderItems.Select(oi => oi.MenuItem).ToList()
            );
    }
}

