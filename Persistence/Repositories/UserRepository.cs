using Application.Base.Repositories;
using Domain.Users;
using Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

internal class UserRepository(BlazingShopContext context) : IUserRepository
{
    private readonly BlazingShopContext _context = context;

    public Task<User?> GetByEmail(Email email)
        => _context.Users.FirstOrDefaultAsync(user => user.Contact.Email == email);

    public Task<User?> GetById(UserId userId)
        => _context.Users.FirstOrDefaultAsync(user => user.Id == userId);

    public Task<bool> IsEmailNotUnique(Email email)
        => _context.Users.AnyAsync(user => user.Contact.Email == email);

    public Task<bool> IsPhoneNotUnique(Phone phone)
        => _context.Users.AnyAsync(user => user.Contact.Phone == phone);

    public Task<bool> IsUsernameNotUnique(Username username)
         => _context.Users.AnyAsync(user => user.Profile.Username == username);

    public Task<bool> IsUsersExist()
        => _context.Users.AnyAsync();

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
