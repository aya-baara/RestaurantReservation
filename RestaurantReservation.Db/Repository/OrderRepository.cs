using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interface;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repository;

public class OrderRepository : Repository<Order>, IRepository<Order>
{
    private readonly RestaurantReservationDbContext _context;
    public OrderRepository(RestaurantReservationDbContext restaurantReservationDbContext) : base(restaurantReservationDbContext)
    {
        _context = restaurantReservationDbContext;
    }

    public async Task<double> CalculateAverageOrderAmount(int employeeId)
    {
        var employeeOrdersCount = await _context.Orders
            .Where(o => o.EmployeeId == employeeId)
            .CountAsync();

        if (employeeOrdersCount == 0) return 0;

        var sum = await _context.Orders
            .Where(o => o.EmployeeId == employeeId)
            .SumAsync(o => o.TotalAmount);

        return sum / employeeOrdersCount;
    }
}

