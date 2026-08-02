using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.BLL.Interfaces;
using UniversityApp.DAL.Repositories;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        var all = await _unitOfWork.Repository<Student>().GetAllAsync();
        return all.ToList();
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Student>().GetByIdAsync(id);
    }

    public async Task AddStudentAsync(Student student)
    {
        await _unitOfWork.Repository<Student>().AddAsync(student);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateStudentAsync(Student student)
    {
        _unitOfWork.Repository<Student>().Update(student);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Student>().GetByIdAsync(id);
        if (entity != null)
        {
            _unitOfWork.Repository<Student>().Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<List<Student>> SearchStudentsAsync(string term)
    {
        if (string.IsNullOrWhiteSpace(term))
            return await GetAllStudentsAsync();

        var lowerTerm = term.ToLower();
        var all = await _unitOfWork.Repository<Student>().GetAllAsync();
        return all.Where(s => 
            (s.Name != null && s.Name.ToLower().Contains(lowerTerm)) ||
            (s.Email != null && s.Email.ToLower().Contains(lowerTerm)) ||
            (s.Department != null && s.Department.ToLower().Contains(lowerTerm))
        ).ToList();
    }
}
