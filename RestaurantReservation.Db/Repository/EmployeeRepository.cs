using RestaurantReservation.Db.Interface;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repository;

class EmployeeRepository : Repository<Employee>, IRepository<Employee>
{
    public EmployeeRepository(RestaurantReservationDbContext restaurantReservationDbContext) : base(restaurantReservationDbContext)
    {
    }
}

