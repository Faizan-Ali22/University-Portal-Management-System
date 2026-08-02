using System;
using System.Threading.Tasks;

namespace UniversityApp.DAL.Repositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : class;
    Task<int> SaveChangesAsync();
}
