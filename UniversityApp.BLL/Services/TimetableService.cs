using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.BLL.Interfaces;
using UniversityApp.DAL.Repositories;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Services;

public class TimetableService : ITimetableService
{
    private readonly IUnitOfWork _unitOfWork;

    public TimetableService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Timetable>> GetAllAsync()
    {
        var all = await _unitOfWork.Repository<Timetable>().GetAllAsync();
        return all.ToList();
    }

    public async Task<Timetable?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Timetable>().GetByIdAsync(id);
    }

    public async Task AddAsync(Timetable timetable)
    {
        await _unitOfWork.Repository<Timetable>().AddAsync(timetable);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Timetable timetable)
    {
        _unitOfWork.Repository<Timetable>().Update(timetable);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Timetable>().GetByIdAsync(id);
        if (entity != null)
        {
            _unitOfWork.Repository<Timetable>().Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<List<Timetable>> GetByDayAsync(string day)
    {
        var all = await _unitOfWork.Repository<Timetable>().GetAllAsync();
        return all.Where(t => t.DayOfWeek == day).ToList();
    }

    public async Task<List<Timetable>> GetByCourseAsync(int courseId)
    {
        var all = await _unitOfWork.Repository<Timetable>().GetAllAsync();
        return all.Where(t => t.CourseId == courseId).ToList();
    }
}
