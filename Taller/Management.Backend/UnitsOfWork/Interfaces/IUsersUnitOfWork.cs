using Microsoft.AspNetCore.Identity;
using Management.Shared.DTOs;
using Management.Shared.Entities;

namespace Management.Backend.UnitsOfWork.Interfaces;

public interface IUsersUnitOfWork
{
    Task<User> GetUserAsync(string email);

    Task<IdentityResult> AddUserAsync(User user, string password);

    Task CheckRoleAsync(string roleName);

    Task AddUserToRoleAsync(User user, string roleName);

    Task<SignInResult> LoginAsync(LoginDTO model);

    Task LogoutAsync();

    Task<bool> IsUserInRoleAsync(User user, string roleName);
}
