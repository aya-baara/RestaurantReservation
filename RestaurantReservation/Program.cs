using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Db;
using Microsoft.EntityFrameworkCore;

//var host = Host.CreateDefaultBuilder()
//    .ConfigureAppConfiguration((context, config) =>
//    {
//        config.AddJsonFile("appsettings.json");
//    })
//    .ConfigureServices((context, services) =>
//    {
//        services.AddDbContext<RestaurantReservationDbContext>(options =>
//            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));
//    })
//    .Build();

//using (var scope = host.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<RestaurantReservationDbContext>();
//    Console.WriteLine("DB Context is ready.");
//}
