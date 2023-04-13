using EmployeeBlazorServerProject.Models;
using EmployeeBlazorServerProject.Services;
using EmployeeDetails.Model;
using Microsoft.AspNetCore.Components;

namespace EmployeeBlazorServerProject.Pages
{
    public class EditEmplyoeeBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]

        public IDepartmentService DepartmentService { get; set; }   

        private Employee Employee { get; set; } = new Employee();

        public EditEmplyoeeModel editEmployee { get; set; } = new EditEmplyoeeModel();

        public List<Department> departments { get; set; } = new List<Department>();

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(Id);
            departments = (await DepartmentService.GetDepartments()).ToList();

            populateEditEmployee();
        }

        private void populateEditEmployee()
        {
            editEmployee.EmployeeId = Employee.EmployeeId;
            editEmployee.FirstName = Employee.FirstName;
            editEmployee.LastName = Employee.LastName;
            editEmployee.Email  = Employee.Email;
            editEmployee.ConfirmEmail = Employee.Email;
            editEmployee.DateOfBirth = Employee.DateOfBirth;
            editEmployee.Gender = Employee.Gender;
            editEmployee.PhotoPath = Employee.PhotoPath;
            editEmployee.DepartmentId = Employee.DepartmentId;
            editEmployee.Department = Employee.Department;
        }

        public void SaveForm()
        {

        }
    }
}
