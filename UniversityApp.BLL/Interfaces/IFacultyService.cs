using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Interfaces;

public interface IFacultyService
{
    Task<List<Faculty>> GetAllFacultiesAsync();
    Task<Faculty?> GetFacultyByIdAsync(int id);
    Task AddFacultyAsync(Faculty faculty);
    Task UpdateFacultyAsync(Faculty faculty);
    Task DeleteFacultyAsync(int id);
    Task<List<Faculty>> GetFacultyByDepartmentAsync(string department);
}
