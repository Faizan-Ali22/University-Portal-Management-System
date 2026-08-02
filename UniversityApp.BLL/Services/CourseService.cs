using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.BLL.Interfaces;
using UniversityApp.DAL.Repositories;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Services;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Course>> GetAllCoursesAsync()
    {
        var all = await _unitOfWork.Repository<Course>().GetAllAsync();
        return all.ToList();
    }

    public async Task<Course?> GetCourseByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Course>().GetByIdAsync(id);
    }

    public async Task AddCourseAsync(Course course)
    {
        await _unitOfWork.Repository<Course>().AddAsync(course);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateCourseAsync(Course course)
    {
        _unitOfWork.Repository<Course>().Update(course);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteCourseAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Course>().GetByIdAsync(id);
        if (entity != null)
        {
            _unitOfWork.Repository<Course>().Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<List<Course>> GetCoursesByFacultyAsync(int facultyId)
    {
        var all = await _unitOfWork.Repository<Course>().GetAllAsync();
        return all.Where(c => c.FacultyId == facultyId).ToList();
    }

    public async Task<List<Course>> GetCoursesBySemesterAsync(string semester)
    {
        var all = await _unitOfWork.Repository<Course>().GetAllAsync();
        return all.Where(c => c.Semester == semester).ToList();
    }
}
