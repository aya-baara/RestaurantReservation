using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repository;

namespace RestaurantReservation;

public class MethodsTest
{
    public async static Task TestListOrderedMenuItems(int reservationId, OrderItemRepository repo)
    {
        var menuItems = await repo.ListOrderedMenuItems(reservationId);

        if (menuItems == null || !menuItems.Any())
        {
            Console.WriteLine("No menu items found for this reservation.");
            return;
        }

        Console.WriteLine($"Menu items ordered for Reservation ID {reservationId}:");
        foreach (var item in menuItems)
        {
            Console.WriteLine($"- {item.Name} (ID: {item.MenuItemId})");
        }
    }

    public async static Task TestListOrdersAndMenuItems(int reservationId, OrderItemRepository repo)
    {
        var result = await repo.ListOrdersAndMenuItems(reservationId);

        if (result == null || result.Count == 0)
        {
            Console.WriteLine($"No orders found for reservation ID: {reservationId}");
            return;
        }

        Console.WriteLine($"Orders and their menu items for reservation ID: {reservationId}");

        foreach (var kvp in result)
        {
            int orderId = kvp.Key;
            List<MenuItem> menuItems = kvp.Value;

            Console.WriteLine($"Order ID: {orderId}");

            if (menuItems.Count == 0)
            {
                Console.WriteLine("  No menu items in this order.");
            }
            else
            {
                foreach (var item in menuItems)
                {
                    Console.WriteLine($"  - {item.Name} (ID: {item.MenuItemId})");
                }
            }
        }
    }

    public async static Task TestCalculateAverageOrderAmount(int employeeId, OrderRepository repo)
    {
        double averageAmount = await repo.CalculateAverageOrderAmount(employeeId);

        if (averageAmount == 0)
        {
            Console.WriteLine($"No orders found for employee with ID {employeeId}.");
        }
        else
        {
            Console.WriteLine($"The average order amount for employee ID {employeeId} is: {averageAmount:C}");
        }
    }

    public async static Task TestViewReservationDetails(ReservationRepository repo)
    {
        var details = await repo.ViewReservationDetails();

        foreach (var d in details)
        {
            Console.WriteLine($"Reservation #{d.ReservationId} | Customer: {d.FirstName} {d.LastName} | Restaurant: {d.Name}");
        }
    }

    public async static Task TestEmplyeesDetails(EmployeeRepository repo)
    {
        var employees = await repo.ListEmployeesDetails();

        foreach (var e in employees)
        {
            Console.WriteLine($"Employee: {e.FirstName} {e.LastName} - {e.Position} | Restaurant: {e.Name}, {e.Address}");
        }
    }
    public async static Task TestTotalRevenue(int restaurantId , RestaurantRepository repo )
    {
        var revenue = await repo.GetTotalRevenueByRestaurant(restaurantId);
        Console.WriteLine($"Total Revenue for Restaurant {restaurantId}: {revenue} $");
    }


    public async static Task GetCustomersWithPartySize(int minPartySize, CustomerRepository repo)
    {
        var customers = await repo.GetCustomersByPartySize(minPartySize);

        Console.WriteLine("\nCustomers with party size greater than " + minPartySize + ":\n");

        foreach (var customer in customers)
        {
            Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Phone: {customer.PhoneNumber}");
            Console.WriteLine(new string('-', 30));
        }

        if (!customers.Any())
        {
            Console.WriteLine("No customers found.");
        }
    }
}
