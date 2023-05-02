using BuberDinner.Domain.Aggregates;
using BuberDinner.Application.Common.Interfaces.Persistence;

namespace BuberDinner.Infrastructure.Persistence;

public class DinnerRepository : IDinnerRepository
{
    private readonly BuberDinnerDBContext _dbContext;

    public DinnerRepository(BuberDinnerDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Dinner dinner)
    {
       // await _dbContext.Dinners.AddAsync(dinner);
        await _dbContext.SaveChangesAsync(); 
    }

    public async Task<Dinner?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Dinners.SigleOrDefaultAsync(dinner => dinner.Id == id);
    }

    public Task<int> GetConfirmedDinnerGuestsCountAsync(Guid dinnerId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetDeclinedDinnerGuestsCountAsync(Guid dinnerId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetPendingDinnerGuestsCountAsync(Guid dinnerId)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<Dinner> ListUserDinnersAsync(Guid userId)
    {
        return _dbContext.Dinners
        .Where(dinner => dinner.Host.userId ==userId )
        .AsAsyncEnumerable();
    }
} 