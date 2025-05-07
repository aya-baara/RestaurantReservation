using RestaurantReservation.Db;
using RestaurantReservation.Db.Repository;
using RestaurantReservation;
using RestaurantReservation.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// Load config from appsettings.json
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = config.GetConnectionString("DefaultConnection");
var optionsBuilder = new DbContextOptionsBuilder<RestaurantReservationDbContext>();
optionsBuilder.UseSqlServer(connectionString);

using var context = new RestaurantReservationDbContext(optionsBuilder.Options);

var repoCRUDTest = new RepositoriesCRUDTests(context);

var customerService = new CustomerService(new CustomerRepository(context));
var employeeService = new EmployeeService(new EmployeeRepository(context), new OrderRepository(context));
var orderService = new OrderService(new OrderItemRepository(context));
var reservationService = new ReservationService(new ReservationRepository(context));
var restaurantService = new RestaurantService(new RestaurantRepository(context));

// Run the tests
await repoCRUDTest.TestAllRepositories();

await customerService.GetCustomersWithPartySize(2);
await employeeService.TestCalculateAverageOrderAmount(4);
await employeeService.ListEmployeesDetails();
await orderService.ListOrderedMenuItems(4);
await orderService.ListOrdersAndMenuItems(4);
await reservationService.ViewReservationsDetails();
await restaurantService.TestTotalRevenue(1);
