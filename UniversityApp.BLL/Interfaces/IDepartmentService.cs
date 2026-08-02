using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Entities.Models;

namespace UniversityApp.BLL.Interfaces;

public interface IDepartmentService
{
    Task<List<Department>> GetAllAsync();
    Task<Department?> GetByIdAsync(int id);
    Task AddAsync(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(int id);
}
