using EmployeeDetails.Model;

namespace EmployeeMangement.Api.Model
{
    public interface IEmployeeRepository
    {

        Task<IEnumerable<Employee>> GetEmployees();

        Task<IEnumerable<Employee>> SearchEmployees(string name,Gender? gender);

        Task <Employee> GetEmployee(int id);

        Task<Employee> GetEmail(string  email);

        Task <Employee> UpdateEmployee(Employee employee);

        Task <Employee> AddEmployee(Employee employee);

        Task <Employee> DeleteEmployee(Employee employee);

    }
}
