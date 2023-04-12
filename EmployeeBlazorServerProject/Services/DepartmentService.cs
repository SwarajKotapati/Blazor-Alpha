using EmployeeDetails.Model;

namespace EmployeeBlazorServerProject.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly HttpClient _httpClient;
        public DepartmentService(HttpClient httpClient) {
            
            _httpClient = httpClient;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Department>($"/api/Department/{id}");
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _httpClient.GetFromJsonAsync<Department[]>("/api/Department");
        }
    }
}
