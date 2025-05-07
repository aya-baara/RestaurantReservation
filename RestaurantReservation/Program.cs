using RestaurantReservation.Db;
using RestaurantReservation.Db.Repository;
using RestaurantReservation;
using RestaurantReservation.Services;


var contexct = new RestaurantReservationDbContext();
var repoCRUDTest = new RepositoriesCRUDTests(new RestaurantReservationDbContext());

var customerService = new CustomerService(new CustomerRepository(contexct));
var employeeService = new EmployeeService(new EmployeeRepository(contexct),new OrderRepository(contexct));
var orderService = new OrderService(new OrderItemRepository(contexct));
var reservationService = new ReservationService(new ReservationRepository(contexct));
var restaurantService = new RestaurantService(new RestaurantRepository(new RestaurantReservationDbContext()));

await repoCRUDTest.TestAllRepositories();

await customerService.GetCustomersWithPartySize(2);

await employeeService.TestCalculateAverageOrderAmount(4);
await employeeService.ListEmployeesDetails();

await orderService.ListOrderedMenuItems(4);
await orderService.ListOrdersAndMenuItems(4);

await reservationService.ViewReservationsDetails();

await restaurantService.TestTotalRevenue(1);
