using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Seeds;

public static class Seeder
{
    public static void SeedDatabase(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>().HasData(Data.GetRestaurants());
        modelBuilder.Entity<Customer>().HasData(Data.GetCustomers());
        modelBuilder.Entity<Employee>().HasData(Data.GetEmployees());
        modelBuilder.Entity<MenuItem>().HasData(Data.GetMenuItems());
        modelBuilder.Entity<Table>().HasData(Data.GetTables());
        modelBuilder.Entity<Reservation>().HasData(Data.GetReservations());
        modelBuilder.Entity<Order>().HasData(Data.GetOrders());
        modelBuilder.Entity<OrderItem>().HasData(Data.GetOrderItems());

    }
}

