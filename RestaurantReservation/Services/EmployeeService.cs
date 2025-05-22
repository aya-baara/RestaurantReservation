using RestaurantReservation.Db.Repository;

namespace RestaurantReservation.Services;
public class EmployeeService
{
    private readonly EmployeeRepository _Employeerepo;
    private readonly OrderRepository _orderRepo;

    public EmployeeService(EmployeeRepository eRepo,OrderRepository oRepo)
    {
        _Employeerepo = eRepo;
        _orderRepo = oRepo;
    }

    public async Task ListEmployeesDetails()
    {
        var employees = await _Employeerepo.ListEmployeesDetails();
        foreach (var e in employees)
        {
            Console.WriteLine($"Employee: {e.FirstName} {e.LastName} - {e.Position} | Restaurant: {e.Name}, {e.Address}");
        }
    }

    public async  Task TestCalculateAverageOrderAmount(int employeeId)
    {
        double averageAmount = await _orderRepo.CalculateAverageOrderAmount(employeeId);

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

