using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interface;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Models.DTOs;

namespace RestaurantReservation.Db.Repository;

public class CustomerRepository : Repository<Customer>, IRepository<Customer>
{
    private readonly RestaurantReservationDbContext _context;
    public CustomerRepository(RestaurantReservationDbContext restaurantReservationDbContext) : base(restaurantReservationDbContext)
    {
        _context = restaurantReservationDbContext;
    }
    public async Task<List<CustomerInfoDto>> GetCustomersByPartySize(int partySize)
    {
        return await _context.CustomerInfoResults
            .FromSqlRaw("EXEC GetCustomersByPartySize @PartySize",
                        new SqlParameter("@PartySize", partySize))
            .ToListAsync();
    }
}

