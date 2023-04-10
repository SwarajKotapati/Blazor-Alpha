using EmployeeBlazorServerProject.Services;
using EmployeeDetails.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBlazorServerProject.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        private IEmployeeService _IemployeeService {get; set;}

        protected Employee Employee { get; set; } = new Employee();

        protected string FontFamily = "Verdana";

        protected override async Task OnInitializedAsync()
        {
            Employee = await _IemployeeService.GetEmployee(int.Parse(Id));
        }
    }
}
