using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Interfaces;

public interface IExamService
{
    Task<List<Exam>> GetAllAsync();
    Task<Exam?> GetByIdAsync(int id);
    Task AddAsync(Exam exam);
    Task UpdateAsync(Exam exam);
    Task DeleteAsync(int id);
}
