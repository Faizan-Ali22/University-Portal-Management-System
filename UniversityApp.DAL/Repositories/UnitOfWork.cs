using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.DAL;

namespace UniversityApp.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly UniversityDbContext _context;
    private readonly Dictionary<Type, object> _repositories;

    public UnitOfWork(UniversityDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    public IRepository<T> Repository<T>() where T : class
    {
        if (_repositories.ContainsKey(typeof(T)))
        {
            return (IRepository<T>)_repositories[typeof(T)];
        }

        var repository = new Repository<T>(_context);
        _repositories.Add(typeof(T), repository);
        return repository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
