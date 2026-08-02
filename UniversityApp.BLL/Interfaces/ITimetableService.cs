using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Interfaces;

public interface ITimetableService
{
    Task<List<Timetable>> GetAllAsync();
    Task<Timetable?> GetByIdAsync(int id);
    Task AddAsync(Timetable timetable);
    Task UpdateAsync(Timetable timetable);
    Task DeleteAsync(int id);
    Task<List<Timetable>> GetByDayAsync(string day);
    Task<List<Timetable>> GetByCourseAsync(int courseId);
}
