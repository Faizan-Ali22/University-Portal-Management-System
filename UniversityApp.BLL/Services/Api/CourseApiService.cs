using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UniversityApp.Entities;

namespace UniversityApp.BLL.Services.Api;

public class CourseApiService
{
    private readonly HttpClient _httpClient;

    public CourseApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Course>?> GetCoursesAsync() => await _httpClient.GetFromJsonAsync<List<Course>>("api/courses");
    public async Task AddCourseAsync(Course course) => await _httpClient.PostAsJsonAsync("api/courses", course);
    public async Task UpdateCourseAsync(Course course) => await _httpClient.PutAsJsonAsync($"api/courses/{course.Id}", course);
    public async Task DeleteCourseAsync(int id) => await _httpClient.DeleteAsync($"api/courses/{id}");
}
