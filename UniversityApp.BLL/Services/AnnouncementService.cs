using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.BLL.Interfaces;
using UniversityApp.DAL.Repositories;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Services;

public class AnnouncementService : IAnnouncementService
{
    private readonly IUnitOfWork _unitOfWork;

    public AnnouncementService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Announcement>> GetAllAsync()
    {
        var all = await _unitOfWork.Repository<Announcement>().GetAllAsync();
        return all.ToList();
    }

    public async Task<Announcement?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Announcement>().GetByIdAsync(id);
    }

    public async Task AddAsync(Announcement announcement)
    {
        await _unitOfWork.Repository<Announcement>().AddAsync(announcement);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Announcement announcement)
    {
        _unitOfWork.Repository<Announcement>().Update(announcement);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Announcement>().GetByIdAsync(id);
        if (entity != null)
        {
            _unitOfWork.Repository<Announcement>().Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<List<Announcement>> GetRecentAsync(int count)
    {
        var all = await _unitOfWork.Repository<Announcement>().GetAllAsync();
        return all.OrderByDescending(a => a.CreatedAt).Take(count).ToList();
    }
}
