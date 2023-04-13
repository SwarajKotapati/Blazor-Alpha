using AutoMapper;
using EmployeeDetails.Model;

namespace EmployeeBlazorServerProject.Models
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper() {

            CreateMap<Employee, EditEmplyoeeModel>()
                .ForMember(edit=> edit.ConfirmEmail, opt => opt.MapFrom(src => src.Email));
            CreateMap<EditEmplyoeeModel, Employee>();

        }
    }
}
