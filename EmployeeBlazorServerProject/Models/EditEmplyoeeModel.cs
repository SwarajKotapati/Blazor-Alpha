using EmployeeDetails.Model.Custom_Validators;
using EmployeeDetails.Model;
using System.ComponentModel.DataAnnotations;

namespace EmployeeBlazorServerProject.Models
{
    public class EditEmplyoeeModel
    {
        public int EmployeeId { get; set; }

        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [CustomEmailValidator(AttributeText = "gmail.com")]
        public string Email { get; set; }

        [EmailAddress]
        [CompareProperty("Email",ErrorMessage ="Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public int DepartmentId { get; set; }

        public string PhotoPath { get; set; }

        [ValidateComplexType]
        public Department Department { get; set; } = new Department();
    }
}
