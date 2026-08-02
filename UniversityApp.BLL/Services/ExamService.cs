using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.BLL.Interfaces;
using UniversityApp.DAL.Repositories;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Services;

public class ExamService : IExamService
{
    private readonly IUnitOfWork _unitOfWork;

    public ExamService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Exam>> GetAllAsync()
    {
        var all = await _unitOfWork.Repository<Exam>().GetAllAsync();
        return all.ToList();
    }

    public async Task<Exam?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Exam>().GetByIdAsync(id);
    }

    public async Task AddAsync(Exam exam)
    {
        await _unitOfWork.Repository<Exam>().AddAsync(exam);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Exam exam)
    {
        _unitOfWork.Repository<Exam>().Update(exam);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Exam>().GetByIdAsync(id);
        if (entity != null)
        {
            _unitOfWork.Repository<Exam>().Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
