using BuberDinner.Domain.Aggregates;

namespace BuberDinner.Application.Common.Interfaces.Persistence;
public interface IDinnerRepository : IRepository<Dinner, Guid>
{
     Task AddAsync(Dinner dinner);

    Task<Dinner?> GetByIdAsync(Guid id);

    IAsyncEnumerable<Dinner> ListUserDinnersAsync(Guid userId);

    Task<int> GetConfirmedDinnerGuestsCountAsync(Guid dinnerId);

    Task<int> GetPendingDinnerGuestsCountAsync(Guid dinnerId);

    Task<int> GetDeclinedDinnerGuestsCountAsync(Guid dinnerId);
}