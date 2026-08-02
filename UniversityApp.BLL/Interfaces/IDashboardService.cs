using System.Threading.Tasks;
using UniversityApp.Entities.DTOs;

namespace UniversityApp.BLL.Interfaces;

public interface IDashboardService
{
    Task<DashboardStatsDto> GetStatsAsync();
}
