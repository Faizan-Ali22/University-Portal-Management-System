using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.BLL.Interfaces;
using UniversityApp.DAL.Repositories;
using UniversityApp.Entities;
using UniversityApp.Entities.DTOs;

namespace UniversityApp.BLL.Services;

public class GradeService : IGradeService
{
    private readonly IUnitOfWork _unitOfWork;

    public GradeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Grade>> GetAllAsync()
    {
        var all = await _unitOfWork.Repository<Grade>().GetAllAsync();
        return all.ToList();
    }

    public async Task AssignGradeAsync(Grade grade)
    {
        await _unitOfWork.Repository<Grade>().AddAsync(grade);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<GradeReportDto>> GetTranscriptAsync(int studentId)
    {
        var grades = await _unitOfWork.Repository<Grade>().GetAllAsync();
        var students = await _unitOfWork.Repository<Student>().GetAllAsync();
        var exams = await _unitOfWork.Repository<Exam>().GetAllAsync();
        var courses = await _unitOfWork.Repository<Course>().GetAllAsync();

        var query = from g in grades
                    where g.StudentId == studentId
                    join s in students on g.StudentId equals s.Id
                    join e in exams on g.ExamId equals e.Id
                    join c in courses on e.CourseId equals c.Id
                    select new GradeReportDto
                    {
                        StudentName = s.Name,
                        CourseName = c.Title,
                        ExamType = e.ExamType,
                        MarksObtained = g.MarksObtained,
                        TotalMarks = e.TotalMarks,
                        Percentage = (decimal)(e.TotalMarks > 0 ? (double)(g.MarksObtained / e.TotalMarks) * 100.0 : 0),
                        GradeValue = GetGradeValue(e.TotalMarks > 0 ? (double)(g.MarksObtained / e.TotalMarks) * 100.0 : 0)
                    };

        return query.ToList();
    }

    public async Task<List<Grade>> GetByExamAsync(int examId)
    {
        var all = await _unitOfWork.Repository<Grade>().GetAllAsync();
        return all.Where(g => g.ExamId == examId).ToList();
    }

    private string GetGradeValue(double percentage)
    {
        if (percentage >= 90) return "A";
        if (percentage >= 80) return "B";
        if (percentage >= 70) return "C";
        if (percentage >= 60) return "D";
        return "F";
    }
}
