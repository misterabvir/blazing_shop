using Domain.Users;
using Domain.Users.ValueObjects;

namespace Application.Base.Repositories;

public interface IUserRepository
{
    Task Add(User user);
    Task<User?> GetByEmail(Email email);
    Task<User?> GetById(UserId userId);
    Task<bool> IsEmailNotUnique(Email email);
    Task<bool> IsPhoneNotUnique(Phone phone);
    Task<bool> IsUsernameNotUnique(Username username);
    Task<bool> IsUsersExist();
}
