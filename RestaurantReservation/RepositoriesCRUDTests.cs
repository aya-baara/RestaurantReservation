
namespace RestaurantReservation;

using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repository;
using RestaurantReservation.Db;
using System;
using System.Threading.Tasks;

public class RepositoriesCRUDTests
{
    private readonly RestaurantReservationDbContext _context;

    public RepositoriesCRUDTests(RestaurantReservationDbContext restaurantReservationDbContext)
    {
        _context = restaurantReservationDbContext;
    }

    private async Task TestCustomerCrud()
    {
        var repo = new CustomerRepository(_context);

        var customer = new Customer
        {
            FirstName = "John",
            LastName = "Doe",
            PhoneNumber = 123456,
            Email = "john@example.com"
        };

        // Create
        var created = await repo.Create(customer);

        // Read
        var fetched = await repo.GetById(created.CustomerId);
        Console.WriteLine($"Fetched Customer: {fetched.FirstName}");

        // Update
        fetched.FirstName = "Jane";
        await repo.Update(fetched);

        // Delete
        await repo.DeleteById(fetched.CustomerId);
    }

    private async Task TestEmployeeCrud()
    {
        var restaurant = new Restaurant { Name = "Pizza Place", Address = "Main St", PhoneNumber = 1234, OpeningHours = "10-10" };
        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();

        var repo = new EmployeeRepository(_context);

        var employee = new Employee
        {
            FirstName = "Alice",
            LastName = "Smith",
            Position = Db.Models.Enums.EmployeePosition.Waiter,
            RestaurantId = restaurant.RestaurantId
        };

        var created = await repo.Create(employee);
        var fetched = await repo.GetById(created.EmployeeId);
        Console.WriteLine($"Fetched Employee: {fetched.FirstName}");

        fetched.LastName = "Johnson";
        await repo.Update(fetched);

        await repo.DeleteById(fetched.EmployeeId);
    }

    private async Task TestMenuItemCrud()
    {
        var restaurant = new Restaurant { Name = "Burger House", Address = "Second St", PhoneNumber = 5678, OpeningHours = "11-11" };
        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();

        var repo = new Repository<MenuItem>(_context);

        var item = new MenuItem
        {
            Name = "Burger",
            Description = "Beef burger",
            Price = 50,
            RestaurantId = restaurant.RestaurantId
        };

        var created = await repo.Create(item);
        var fetched = await repo.GetById(created.MenuItemId);
        Console.WriteLine($"Fetched Menu Item: {fetched.Name}");

        fetched.Price = 55;
        await repo.Update(fetched);

        await repo.DeleteById(fetched.MenuItemId);
    }

    private async Task TestReservationCrud()
    {
        var restaurant = new Restaurant { Name = "Grill Spot", Address = "Third St", PhoneNumber = 1010, OpeningHours = "9-9" };
        var customer = new Customer { FirstName = "Tom", LastName = "Jerry", PhoneNumber = 4444, Email = "tom@example.com" };
        var table = new Table { Capacity = 4, Restaurant = restaurant };

        _context.Restaurants.Add(restaurant);
        _context.Customers.Add(customer);
        _context.Tables.Add(table);
        await _context.SaveChangesAsync();

        var repo = new Repository<Reservation>(_context);

        var reservation = new Reservation
        {
            ReservationDate = DateTime.Now,
            PartySize = 2,
            CustomerId = customer.CustomerId,
            RestaurantId = restaurant.RestaurantId,
            TableId = table.TableId
        };

        var created = await repo.Create(reservation);
        var fetched = await repo.GetById(created.ReservationId);
        Console.WriteLine($"Fetched Reservation for CustomerId: {fetched.CustomerId}");

        fetched.PartySize = 3;
        await repo.Update(fetched);

        await repo.DeleteById(fetched.ReservationId);
    }

    private async Task TestOrderCrud()
    {
        var restaurant = new Restaurant { Name = "Testaurant", Address = "123 Test St", PhoneNumber = 9999, OpeningHours = "10-10" };
        var customer = new Customer { FirstName = "Sara", LastName = "Lee", PhoneNumber = 123123, Email = "sara@example.com" };
        var employee = new Employee { FirstName = "Mike", LastName = "Tyson", Position = Db.Models.Enums.EmployeePosition.Chef, Restaurant = restaurant };
        var table = new Table { Capacity = 4, Restaurant = restaurant };

        _context.Restaurants.Add(restaurant);
        _context.Customers.Add(customer);
        _context.Employees.Add(employee);
        _context.Tables.Add(table);
         await _context.SaveChangesAsync();

        var reservation = new Reservation
        {
            ReservationDate = DateTime.Now,
            PartySize = 2,
            CustomerId = customer.CustomerId,
            RestaurantId = restaurant.RestaurantId,
            TableId = table.TableId
        };

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        var repo = new Repository<Order>(_context);

        var order = new Order
        {
            OrderDate = DateTime.Now,
            TotalAmount = 100,
            EmployeeId = employee.EmployeeId,
            ReservationId = reservation.ReservationId
        };

        var created = await repo.Create(order);
        var fetched = await repo.GetById(created.OrderId);
        Console.WriteLine($"Fetched Order: {fetched.OrderId}, Total: {fetched.TotalAmount}");

        fetched.TotalAmount = 120;
        await repo.Update(fetched);

        await repo.DeleteById(fetched.OrderId);
    }

    private async Task TestTableCrud()
    {
        var restaurant = new Restaurant { Name = "Sky Lounge", Address = "Top Floor", PhoneNumber = 2222, OpeningHours = "6PM - 2AM" };
        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();

        var repo = new Repository<Table>(_context);

        var table = new Table
        {
            Capacity = 6,
            RestaurantId = restaurant.RestaurantId
        };

        var created = await repo.Create(table);
        var fetched = await repo.GetById(created.TableId);
        Console.WriteLine($"Fetched Table Capacity: {fetched.Capacity}");

        fetched.Capacity = 8;
        await repo.Update(fetched);

        await repo.DeleteById(fetched.TableId);
    }

    public async Task TestAllRepositories()
    {
        await TestCustomerCrud();
        await TestEmployeeCrud();
        await TestMenuItemCrud();
        await TestReservationCrud();
        await TestOrderCrud();
        await TestTableCrud();
    }
}



