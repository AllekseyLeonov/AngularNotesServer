using Domain.Core;
using Domain.Interfaces;
using Services.Interfaces;

namespace Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(User user)
    {
        _unitOfWork.Users.CreateAsync(user);
    }

    public User GetUserByEmail(string email)
    {
        return _unitOfWork.Users
            .FilterAsync(c => c.Email == email)
            .Result.First();
    }

    public bool IsAuthorisationCorrect(string email, string password)
    {
        return _unitOfWork.Users.GetAllAsync().Result.FirstOrDefault(
            user =>
                user.Email == email &&
                user.Password == password
        ) != null;
    }
}