using RestaurantReservation.Db;
using RestaurantReservation.Db.Repository;
using RestaurantReservation;



var repoTest = new RepositoryTests(new RestaurantReservationDbContext());

//await repoTest.TestAllRepositories();
await MethodsTest.TestListOrderedMenuItems(3, new OrderItemRepository(new RestaurantReservationDbContext()));