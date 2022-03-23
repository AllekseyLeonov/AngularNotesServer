using Domain.Core;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IGenericRepository<Note> Notes { get; }
}