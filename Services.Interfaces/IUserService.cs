using Domain.Core;

namespace Services.Interfaces;

public interface IUserService
{
    void Create(User user);
    User GetUserByEmail(string email);
    bool IsAuthorisationCorrect(string email, string password);
}