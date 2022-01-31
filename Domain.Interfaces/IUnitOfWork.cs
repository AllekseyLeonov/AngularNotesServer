using Domain.Core;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IGenericRepository<User> Users { get; }
    IGenericRepository<Note> Notes { get; }
}