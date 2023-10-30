using AutoMapper;
using Kevin.API.Contract.Interfaces;
using Kevin.API.Domain.Dtos;
using Kevin.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Kevin.API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private DbemployeeContext _dbContext;
        private IMapper _mapper;
        public DepartmentService(DbemployeeContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            try
            {
                List<Department> list = new List<Department>();
                list = await _dbContext.Departments.ToListAsync();

                var departments = _mapper.Map<List<DepartmentDto>>(list);

                return departments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
