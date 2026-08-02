using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Interfaces;

public interface IEnrollmentService
{
    Task<List<Enrollment>> GetAllAsync();
    Task<List<Enrollment>> GetByStudentAsync(int studentId);
    Task<List<Enrollment>> GetByCourseAsync(int courseId);
    Task EnrollAsync(Enrollment enrollment);
    Task DropAsync(int id);
    Task<int> GetEnrollmentCountAsync();
}
