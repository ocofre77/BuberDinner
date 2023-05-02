using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IRepository<T, Guid>
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}