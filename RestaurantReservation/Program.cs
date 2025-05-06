using RestaurantReservation.Db;
using RestaurantReservation;



var repoTest = new RepositoryTests(new RestaurantReservationDbContext());

await repoTest.TestAllRepositories();