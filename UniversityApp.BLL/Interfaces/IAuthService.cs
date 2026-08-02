using System.Threading.Tasks;
using UniversityApp.Entities.DTOs;

namespace UniversityApp.BLL.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);
}
