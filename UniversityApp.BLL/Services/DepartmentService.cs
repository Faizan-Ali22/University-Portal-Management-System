using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.BLL.Interfaces;
using UniversityApp.DAL.Repositories;
using UniversityApp.Entities.Models;

namespace UniversityApp.BLL.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Department>> GetAllAsync()
    {
        var all = await _unitOfWork.Repository<Department>().GetAllAsync();
        return all.ToList();
    }

    public async Task<Department?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Department>().GetByIdAsync(id);
    }

    public async Task AddAsync(Department department)
    {
        await _unitOfWork.Repository<Department>().AddAsync(department);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Department department)
    {
        _unitOfWork.Repository<Department>().Update(department);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Department>().GetByIdAsync(id);
        if (entity != null)
        {
            _unitOfWork.Repository<Department>().Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
