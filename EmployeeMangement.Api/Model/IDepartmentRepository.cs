using EmployeeDetails.Model;

namespace EmployeeMangement.Api.Model
{
    public interface IDepartmentRepository
    {

        Task<IEnumerable<Department>> GetDepartments();

        Task<Department> GetDepartmentById(int id);

        Task<Department> DeleteDepartmentById(int id);

    }
}
