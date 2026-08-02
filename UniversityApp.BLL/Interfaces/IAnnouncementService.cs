using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Interfaces;

public interface IAnnouncementService
{
    Task<List<Announcement>> GetAllAsync();
    Task<Announcement?> GetByIdAsync(int id);
    Task AddAsync(Announcement announcement);
    Task UpdateAsync(Announcement announcement);
    Task DeleteAsync(int id);
    Task<List<Announcement>> GetRecentAsync(int count);
}
