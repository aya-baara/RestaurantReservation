using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Models.Enums;

namespace RestaurantReservation.Db.Seeds;
class Data
{
    public static List<Restaurant> GetRestaurants()
    {
        return new List<Restaurant>
            {
                new Restaurant { RestaurantId = 1, Name = "Restaurant A", Address = "Address A", PhoneNumber = 123456789, OpeningHours = "9 AM - 9 PM" },
                new Restaurant { RestaurantId = 2, Name = "Restaurant B", Address = "Address B", PhoneNumber = 987654321, OpeningHours = "10 AM - 10 PM" },
                new Restaurant { RestaurantId = 3, Name = "Restaurant C", Address = "Address C", PhoneNumber = 555555555, OpeningHours = "8 AM - 8 PM" },
                new Restaurant { RestaurantId = 4, Name = "Restaurant D", Address = "Address D", PhoneNumber = 666666666, OpeningHours = "7 AM - 7 PM" },
                new Restaurant { RestaurantId = 5, Name = "Restaurant E", Address = "Address E", PhoneNumber = 777777777, OpeningHours = "6 AM - 6 PM" }
            };
    }

    public static List<Customer> GetCustomers()
    {
        return new List<Customer>
            {
                new Customer { CustomerId = 1, FirstName = "John", LastName = "Doe" ,Email="John@gmail",PhoneNumber=6262325 },
                new Customer { CustomerId = 2, FirstName = "Jane", LastName = "Doe",Email="Jane@gmail",PhoneNumber=6262325  },
                new Customer { CustomerId = 3, FirstName = "Alice", LastName = "Smith" ,Email="Alice@gmail",PhoneNumber=6262325 },
                new Customer { CustomerId = 4, FirstName = "Bob", LastName = "Johnson" ,Email="Bob@gmail",PhoneNumber=6262325 },
                new Customer { CustomerId = 5, FirstName = "Charlie", LastName = "Brown",Email="Charlie@gmail",PhoneNumber=6262325  }
            };
    }

    public static List<Employee> GetEmployees()
    {
        return new List<Employee>
            {
                new Employee { EmployeeId = 1, FirstName = "Mike", LastName = "Davis", Position = EmployeePosition.Manager, RestaurantId = 1 },
                new Employee { EmployeeId = 2, FirstName = "Sarah", LastName = "Williams", Position =EmployeePosition.Chef, RestaurantId = 2 },
                new Employee { EmployeeId = 3, FirstName = "David", LastName = "Martinez", Position = EmployeePosition.Waiter, RestaurantId = 3 },
                new Employee { EmployeeId = 4, FirstName = "Anna", LastName = "Garcia", Position = EmployeePosition.Cashier, RestaurantId = 4 },
                new Employee { EmployeeId = 5, FirstName = "Luis", LastName = "Rodriguez", Position = EmployeePosition.Host, RestaurantId = 5 }
            };
    }

    public static List<MenuItem> GetMenuItems()
    {
        return new List<MenuItem>
            {
                new MenuItem { MenuItemId = 1, Name = "Burger", Description = "Beef Burger", Price = 12, RestaurantId = 1 },
                new MenuItem { MenuItemId = 2, Name = "Pizza", Description = "Cheese Pizza", Price = 15, RestaurantId = 2 },
                new MenuItem { MenuItemId = 3, Name = "Pasta", Description = "Penne Pasta", Price = 10, RestaurantId = 3 },
                new MenuItem { MenuItemId = 4, Name = "Steak", Description = "Grilled Steak", Price = 20, RestaurantId = 4 },
                new MenuItem { MenuItemId = 5, Name = "Sushi", Description = "Sushi Rolls", Price = 18, RestaurantId = 5 }
            };
    }

    public static List<Table> GetTables()
    {
        return new List<Table>
            {
                new Table { TableId = 1, Capacity = 4, RestaurantId = 1 },
                new Table { TableId = 2, Capacity = 2, RestaurantId = 2 },
                new Table { TableId = 3, Capacity = 6, RestaurantId = 3 },
                new Table { TableId = 4, Capacity = 8, RestaurantId = 4 },
                new Table { TableId = 5, Capacity = 10, RestaurantId = 5 }
            };
    }

    public static List<Reservation> GetReservations()
    {
        return new List<Reservation>
            {
                new Reservation { ReservationId = 1, ReservationDate = new DateTime(2025, 1, 1) , PartySize = 4, CustomerId = 1, RestaurantId = 1, TableId = 1 },
                new Reservation { ReservationId = 2, ReservationDate = new DateTime(2025, 8, 10), PartySize = 2, CustomerId = 2, RestaurantId = 2, TableId = 2 },
                new Reservation { ReservationId = 3, ReservationDate = new DateTime(2025, 11, 17), PartySize = 6, CustomerId = 3, RestaurantId = 3, TableId = 3 },
                new Reservation { ReservationId = 4, ReservationDate = new DateTime(2025, 10, 2), PartySize = 8, CustomerId = 4, RestaurantId = 4, TableId = 4 },
                new Reservation { ReservationId = 5, ReservationDate = new DateTime(2025, 5, 21), PartySize = 10, CustomerId = 5, RestaurantId = 5, TableId = 5 }
            };
    }

    public static List<Order> GetOrders()
    {
        return new List<Order>
            {
                new Order { OrderId = 1, OrderDate = new DateTime(2025, 5, 21), TotalAmount = 50, EmployeeId = 1, ReservationId = 1 },
                new Order { OrderId = 2, OrderDate = new DateTime(2025, 5, 21), TotalAmount = 30, EmployeeId = 2, ReservationId = 2 },
                new Order { OrderId = 3, OrderDate = new DateTime(2025, 5, 21), TotalAmount = 40, EmployeeId = 3, ReservationId = 3 },
                new Order { OrderId = 4, OrderDate = new DateTime(2025, 5, 21), TotalAmount = 60, EmployeeId = 4, ReservationId = 4 },
                new Order { OrderId = 5, OrderDate = new DateTime(2025, 5, 21), TotalAmount = 100, EmployeeId = 5, ReservationId = 5 }
            };
    }

    public static List<OrderItem> GetOrderItems()
    {
        return new List<OrderItem>
            {
                new OrderItem { OrderItemId = 1, Quantity = 2, OrderId = 1, MenuItemId = 1 },
                new OrderItem { OrderItemId = 2, Quantity = 1, OrderId = 2, MenuItemId = 2 },
                new OrderItem { OrderItemId = 3, Quantity = 3, OrderId = 3, MenuItemId = 3 },
                new OrderItem { OrderItemId = 4, Quantity = 2, OrderId = 4, MenuItemId = 4 },
                new OrderItem { OrderItemId = 5, Quantity = 5, OrderId = 5, MenuItemId = 5 }
            };
    }
}

