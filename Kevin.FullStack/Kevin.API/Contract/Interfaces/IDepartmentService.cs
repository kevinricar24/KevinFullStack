using Kevin.API.Domain.Dtos;

namespace Kevin.API.Contract.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllAsync();
    }
}
