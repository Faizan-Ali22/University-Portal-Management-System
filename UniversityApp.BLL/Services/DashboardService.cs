using System.Linq;
using System.Threading.Tasks;
using UniversityApp.BLL.Interfaces;
using UniversityApp.DAL.Repositories;
using UniversityApp.Entities;
using UniversityApp.Entities.DTOs;

namespace UniversityApp.BLL.Services;

public class DashboardService : IDashboardService
{
    private readonly IUnitOfWork _unitOfWork;

    public DashboardService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DashboardStatsDto> GetStatsAsync()
    {
        var students = await _unitOfWork.Repository<Student>().GetAllAsync();
        var courses = await _unitOfWork.Repository<Course>().GetAllAsync();
        var faculties = await _unitOfWork.Repository<Faculty>().GetAllAsync();
        var announcements = await _unitOfWork.Repository<Announcement>().GetAllAsync();

        return new DashboardStatsDto
        {
            TotalStudents = students.Count(),
            TotalCourses = courses.Count(),
            TotalFaculty = faculties.Count(),
            RecentAnnouncements = announcements.OrderByDescending(a => a.CreatedAt).Take(5).ToList()
        };
    }
}
