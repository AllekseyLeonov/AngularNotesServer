using Domain.Core;
using Domain.Interfaces;

namespace Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _db;
    public IGenericRepository<Note> Notes => new GenericRepository<Note>(_db);

    public UnitOfWork(ApplicationContext db)
    {
        _db = db;
    }
}