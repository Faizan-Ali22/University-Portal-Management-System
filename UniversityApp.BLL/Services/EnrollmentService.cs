using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.BLL.Interfaces;
using UniversityApp.DAL.Repositories;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IUnitOfWork _unitOfWork;

    public EnrollmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Enrollment>> GetAllAsync()
    {
        var all = await _unitOfWork.Repository<Enrollment>().GetAllAsync();
        return all.ToList();
    }

    public async Task<List<Enrollment>> GetByStudentAsync(int studentId)
    {
        var all = await _unitOfWork.Repository<Enrollment>().GetAllAsync();
        return all.Where(e => e.StudentId == studentId).ToList();
    }

    public async Task<List<Enrollment>> GetByCourseAsync(int courseId)
    {
        var all = await _unitOfWork.Repository<Enrollment>().GetAllAsync();
        return all.Where(e => e.CourseId == courseId).ToList();
    }

    public async Task EnrollAsync(Enrollment enrollment)
    {
        await _unitOfWork.Repository<Enrollment>().AddAsync(enrollment);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DropAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Enrollment>().GetByIdAsync(id);
        if (entity != null)
        {
            _unitOfWork.Repository<Enrollment>().Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<int> GetEnrollmentCountAsync()
    {
        var all = await _unitOfWork.Repository<Enrollment>().GetAllAsync();
        return all.Count();
    }
}
