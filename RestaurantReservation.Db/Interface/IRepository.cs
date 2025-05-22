namespace RestaurantReservation.Db.Interface;

public interface IRepository<T> where T : class, IModel
{
    public Task<T> Create(T model);
    public Task Update(T model);
    public Task DeleteById(int id);
    public Task<T> GetById(int id);
}

