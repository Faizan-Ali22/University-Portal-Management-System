using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Interfaces;

public interface ICourseService
{
    Task<List<Course>> GetAllCoursesAsync();
    Task<Course?> GetCourseByIdAsync(int id);
    Task AddCourseAsync(Course course);
    Task UpdateCourseAsync(Course course);
    Task DeleteCourseAsync(int id);
    Task<List<Course>> GetCoursesByFacultyAsync(int facultyId);
    Task<List<Course>> GetCoursesBySemesterAsync(string semester);
}
