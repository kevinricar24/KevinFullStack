using Kevin.API.Domain.Dtos;

namespace Kevin.API.Contract.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> GetById(int idEmployee);
        Task<EmployeeDto> Add(EmployeeDto employee);
        Task<bool> Update(int idEmployee, EmployeeDto employee);
        Task<bool> Delete(int idEmployee);
    }
}
