using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repository;

namespace RestaurantReservation.Services;

public class OrderService
{
    private readonly OrderItemRepository _repo;

    public OrderService(OrderItemRepository repo)
    {
        _repo = repo;
    }

    public async Task ListOrderedMenuItems(int reservationId)
    {
        var menuItems = await _repo.ListOrderedMenuItems(reservationId);
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

    public async Task ListOrdersAndMenuItems(int reservationId)
    {
        var result = await _repo.ListOrdersAndMenuItems(reservationId);
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

}


