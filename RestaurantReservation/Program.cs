
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repository;



var context = new RestaurantReservationDbContext();
var customerRepo = new CustomerRepository(context);

var newCustomer = new Customer { FirstName = "Ahmad", LastName = "Mahmoud", Email = "Ahmad@gmail.com", PhoneNumber = 85456464 };
await customerRepo.Create(newCustomer);

Customer customer = customerRepo.GetById(3).Result;

customer.Email = "ayabaara4@gmail.com";
await customerRepo.Update(customer);

await customerRepo.DeleteById(6);

Console.WriteLine( customerRepo.GetById(6));