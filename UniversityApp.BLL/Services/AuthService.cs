using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UniversityApp.BLL.Interfaces;
using UniversityApp.DAL.Repositories;
using UniversityApp.Entities;
using UniversityApp.Entities.DTOs;
using BC = BCrypt.Net.BCrypt;

namespace UniversityApp.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _config;

    public AuthService(IUnitOfWork unitOfWork, IConfiguration config)
    {
        _unitOfWork = unitOfWork;
        _config = config;
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
    {
        var users = await _unitOfWork.Repository<AppUser>().GetAllAsync();
        var user = users.FirstOrDefault(u => u.Email == request.Email);

        if (user == null)
            return null;

        if (!BC.Verify(request.Password, user.PasswordHash))
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var keyStr = _config["Jwt:Key"];
        var key = Encoding.UTF8.GetBytes(keyStr ?? "default_secret_key_needs_to_be_long");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddHours(24),
            Issuer = _config["Jwt:Issuer"],
            Audience = _config["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwt = tokenHandler.WriteToken(token);

        return new LoginResponseDto
        {
            Token = jwt,
            Email = user.Email,
            FullName = user.FullName,
            Role = user.Role
        };
    }
}
