using RestaurantReservation.Db.Repository;

namespace RestaurantReservation.Services;

class RestaurantService
{
    private readonly RestaurantRepository _repo;
    
    public RestaurantService(RestaurantRepository repo)
    {
        _repo = repo;
    }

    public async  Task TestTotalRevenue(int restaurantId)
    {
        var revenue = await _repo.GetTotalRevenueByRestaurant(restaurantId);
        Console.WriteLine($"Total Revenue for Restaurant {restaurantId}: {revenue} $");
    }

}

