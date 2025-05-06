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

}

