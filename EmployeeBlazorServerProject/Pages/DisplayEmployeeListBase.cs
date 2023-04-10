using EmployeeDetails.Model;
using Microsoft.AspNetCore.Components;

namespace EmployeeBlazorServerProject.Pages
{
    public class DisplayEmployeeListBase : ComponentBase
    {
        [Parameter]
        public Employee Employee {get;set;}

        [Parameter]
        public bool ShowOptions { get; set; } = true;
    }
}
