using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.BLL.Interfaces;
using UniversityApp.DAL.Repositories;
using UniversityApp.Entities;
using UniversityApp.Entities.DTOs;

namespace UniversityApp.BLL.Services;

public class AttendanceService : IAttendanceService
{
    private readonly IUnitOfWork _unitOfWork;

    public AttendanceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Attendance>> GetAllAsync()
    {
        var all = await _unitOfWork.Repository<Attendance>().GetAllAsync();
        return all.ToList();
    }

    public async Task MarkAttendanceAsync(Attendance attendance)
    {
        await _unitOfWork.Repository<Attendance>().AddAsync(attendance);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<AttendanceReportDto>> GetReportAsync(int courseId, DateTime? from, DateTime? to)
    {
        var attendances = await _unitOfWork.Repository<Attendance>().GetAllAsync();
        var students = await _unitOfWork.Repository<Student>().GetAllAsync();
        var courses = await _unitOfWork.Repository<Course>().GetAllAsync();

        var query = attendances.Where(a => a.CourseId == courseId);
        if (from.HasValue) query = query.Where(a => a.Date >= from.Value);
        if (to.HasValue) query = query.Where(a => a.Date <= to.Value);

        var report = from a in query
                     join s in students on a.StudentId equals s.Id
                     join c in courses on a.CourseId equals c.Id
                     group a by new { s.Name, c.Title } into g
                     select new AttendanceReportDto
                     {
                         StudentName = g.Key.Name,
                         CourseName = g.Key.Title,
                         TotalClasses = g.Count(),
                         Present = g.Count(x => x.Status == "Present"),
                         Absent = g.Count(x => x.Status == "Absent"),
                         Late = g.Count(x => x.Status == "Late"),
                         Percentage = (decimal)(g.Count() > 0 ? ((double)g.Count(x => x.Status == "Present" || x.Status == "Late") / g.Count()) * 100 : 0)
                     };

        return report.ToList();
    }

    public async Task<List<Attendance>> GetByStudentAsync(int studentId)
    {
        var all = await _unitOfWork.Repository<Attendance>().GetAllAsync();
        return all.Where(a => a.StudentId == studentId).ToList();
    }
}
