using EmployeeDetails.Model;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeBlazorServerProject.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<Employee[]>("api/Employee");
                return res;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"/api/Employee/{id}");
        }

        public async Task UpdateEmployee(Employee UpdatedEmployee)
        {
            await _httpClient.PutAsJsonAsync<Employee>("/api/Employee", UpdatedEmployee);
        }
    }
}
