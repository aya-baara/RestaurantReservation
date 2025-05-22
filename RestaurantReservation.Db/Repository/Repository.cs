using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interface;

namespace RestaurantReservation.Db.Repository;

public class Repository<T> : IRepository<T> where T : class, IModel
{
    private readonly RestaurantReservationDbContext _retaurantContext;
    private readonly DbSet<T> _dbSet;

    public Repository(RestaurantReservationDbContext restaurantReservationDbContext)
    {
        _retaurantContext = restaurantReservationDbContext;
        _dbSet = _retaurantContext.Set<T>();

    }
    public async Task<T> Create(T model)
    {
        _dbSet.Add(model);
        await _retaurantContext.SaveChangesAsync();
        return model;
    }

    public async Task DeleteById(int id)
    {
        var model = await _dbSet.FindAsync(id);
        if (model != null)
        {
            _dbSet.Remove(model);
            await _retaurantContext.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException($"No record found with ID {id}");
        }
    }
    public async Task<T> GetById(int id)
    {
        var model = await _dbSet.FindAsync(id);
        if (model != null)
        {
            return model;
        }
        else
        {
            throw new InvalidOperationException($"No record found with ID {id}");
        }
    }

    public async Task Update(T model)
    {
        _dbSet.Update(model);
        await _retaurantContext.SaveChangesAsync();
    }
}

