using EmployeeBlazorServerProject.Services;
using EmployeeDetails.Model;
using Microsoft.AspNetCore.Components;

namespace EmployeeBlazorServerProject.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        private IEmployeeService EmployeeService { get; set; }

        public IEnumerable<Employee> EmployeeList { get; set; }

        protected string headerFontFamily = "Ariel";

        public bool ShowOptions { get; set; } = true;

        protected int SelectedProfiles { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            System.Threading.Thread.Sleep(2000);
            EmployeeList = (await EmployeeService.GetEmployees()).ToList();
            //await Task.Run(PopulateEmployeeList);
        }

        public void IncrementCount(bool b)
        {
            if (b)
            {
                SelectedProfiles++;
            }
            else
            {
                SelectedProfiles--;
            }
        }

        public void PopulateEmployeeList()
        {

            Thread.Sleep(6000);
            Employee e1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "Venkata",
                LastName = "Swaraj",
                Email = "Venkatawaraj@gmail.com",
                DateOfBirth = new DateTime(2001, 08, 06),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/Male2.png"
            };

            Employee e2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Sathya",
                LastName = "Damera",
                Email = "Sathyadamera@yahoo.com",
                DateOfBirth = new DateTime(2001, 08, 08),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/Male1.jpg"
            };

            Employee e3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Shreya",
                LastName = "Guptha",
                Email = "shreyagupta@linkedin.com",
                DateOfBirth = new DateTime(2003, 11, 10),
                Gender = Gender.Female,
                DepartmentId = 3,
                PhotoPath = "images/Female1.png"
            };

            Employee e4 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Vaishnavi",
                LastName = "Reddy",
                Email = "vaishnavireddy@gmail.com",
                DateOfBirth = new DateTime(2001, 10, 13),
                Gender = Gender.Female,
                DepartmentId = 4,
                PhotoPath = "images/Female2.jpg"
            };

            EmployeeList = new List<Employee>
            {
                e1,
                e2,
                e3,
                e4
            };

        }

    }
}
