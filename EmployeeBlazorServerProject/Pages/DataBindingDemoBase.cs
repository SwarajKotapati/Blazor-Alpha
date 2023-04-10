using Microsoft.AspNetCore.Components;

namespace EmployeeBlazorServerProject.Pages
{
    public class DataBindingDemoBase : ComponentBase
    {
        protected String Name { get; set; } = "Sathya Damera";
        protected String Gender { get; set; } = "Male";

        protected String Color { get; set; } = "background-color: white";
    }
}
