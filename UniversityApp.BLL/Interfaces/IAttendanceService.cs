using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Entities;
using UniversityApp.Entities.DTOs;

namespace UniversityApp.BLL.Interfaces;

public interface IAttendanceService
{
    Task<List<Attendance>> GetAllAsync();
    Task MarkAttendanceAsync(Attendance attendance);
    Task<List<AttendanceReportDto>> GetReportAsync(int courseId, DateTime? from, DateTime? to);
    Task<List<Attendance>> GetByStudentAsync(int studentId);
}
