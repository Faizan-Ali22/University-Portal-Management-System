using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.BLL.Interfaces;
using UniversityApp.DAL.Repositories;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Services;

public class FacultyService : IFacultyService
{
    private readonly IUnitOfWork _unitOfWork;

    public FacultyService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Faculty>> GetAllFacultiesAsync()
    {
        var all = await _unitOfWork.Repository<Faculty>().GetAllAsync();
        return all.ToList();
    }

    public async Task<Faculty?> GetFacultyByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Faculty>().GetByIdAsync(id);
    }

    public async Task AddFacultyAsync(Faculty faculty)
    {
        await _unitOfWork.Repository<Faculty>().AddAsync(faculty);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateFacultyAsync(Faculty faculty)
    {
        _unitOfWork.Repository<Faculty>().Update(faculty);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteFacultyAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Faculty>().GetByIdAsync(id);
        if (entity != null)
        {
            _unitOfWork.Repository<Faculty>().Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<List<Faculty>> GetFacultyByDepartmentAsync(string department)
    {
        var all = await _unitOfWork.Repository<Faculty>().GetAllAsync();
        return all.Where(f => f.Department == department).ToList();
    }
}
