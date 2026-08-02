using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Entities;
using UniversityApp.Entities.DTOs;

namespace UniversityApp.BLL.Interfaces;

public interface IGradeService
{
    Task<List<Grade>> GetAllAsync();
    Task AssignGradeAsync(Grade grade);
    Task<List<GradeReportDto>> GetTranscriptAsync(int studentId);
    Task<List<Grade>> GetByExamAsync(int examId);
}
