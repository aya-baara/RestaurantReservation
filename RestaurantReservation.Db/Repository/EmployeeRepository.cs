using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interface;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Models.Enums;

namespace RestaurantReservation.Db.Repository;

public class EmployeeRepository : Repository<Employee>, IRepository<Employee>
{
    private readonly RestaurantReservationDbContext _context;
    public EmployeeRepository(RestaurantReservationDbContext restaurantReservationDbContext) : base(restaurantReservationDbContext)
    {
        _context = restaurantReservationDbContext;
    }

    public async Task<List<Employee>> ListManagers()
    {
        return await
            _context.Employees.Where(e => e.Position.Equals(EmployeePosition.Manager)).ToListAsync();
    }
}

