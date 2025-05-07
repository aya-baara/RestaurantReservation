using RestaurantReservation.Db.Repository;

namespace RestaurantReservation.Services;

public class CustomerService
{
    private readonly CustomerRepository _repo;

    public CustomerService(CustomerRepository repo)
    {
        _repo = repo;
    }

    public async Task GetCustomersWithPartySize(int minPartySize)
    {
        var customers = await _repo.GetCustomersByPartySize(minPartySize);

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

