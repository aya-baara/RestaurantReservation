using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interface;
using RestaurantReservation.Db.Models;
using System.Data;

namespace RestaurantReservation.Db.Repository;

public class RestaurantRepository : Repository<Restaurant>, IRepository<Restaurant>
{
    private readonly RestaurantReservationDbContext _context;
    public RestaurantRepository(RestaurantReservationDbContext restaurantReservationDbContext) : base(restaurantReservationDbContext)
    {
        _context = restaurantReservationDbContext;
    }
    public async Task<int> GetTotalRevenueByRestaurant(int restaurantId)
    {
        using var connection = _context.Database.GetDbConnection();
        await connection.OpenAsync();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT dbo.TotalRevenue(@RestaurantId)";
        command.CommandType = CommandType.Text;

        var parameter = command.CreateParameter();
        parameter.ParameterName = "@RestaurantId";
        parameter.Value = restaurantId;
        command.Parameters.Add(parameter);

        var result = await command.ExecuteScalarAsync();
        return result == DBNull.Value ? 0 : Convert.ToInt32(result);
    }



}

