using System.Globalization;
using AutoMapper;
using Kevin.API.Domain.Dtos;
using Kevin.API.Models;

namespace Kevin.API.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>()
                .ForMember(x => x.NameDepartment, opt => opt.MapFrom(s => s.IdDepartmentNavigation.Name))
                .ForMember(x => x.ContractDate, opt => opt.MapFrom(s => s.ContractDate.HasValue ? s.ContractDate.Value.ToString("dd/MM/yyyy") : string.Empty));

            CreateMap<EmployeeDto, Employee>()
                .ForMember(x => x.IdDepartmentNavigation, opt => opt.Ignore())
                .ForMember(x => x.ContractDate, opt => opt.MapFrom(s => !string.IsNullOrEmpty(s.ContractDate) ? DateTime.ParseExact(s.ContractDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Now));
        }
    }
}
