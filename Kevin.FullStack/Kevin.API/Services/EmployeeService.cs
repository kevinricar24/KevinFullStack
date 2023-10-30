using AutoMapper;
using Kevin.API.Contract.Interfaces;
using Kevin.API.Domain.Dtos;
using Kevin.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Kevin.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private DbemployeeContext _dbContext;
        private IMapper _mapper;
        public EmployeeService(DbemployeeContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            try
            {
                List<Employee> list = new List<Employee>();
                list = await _dbContext.Employees.Include(x => x.IdDepartmentNavigation).ToListAsync();

                var employees = _mapper.Map<List<EmployeeDto>>(list);

                return employees;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<EmployeeDto> GetById(int idEmployee)
        {
            try
            {
                Employee? employee = new Employee();
                employee = await _dbContext.Employees.Include(x => x.IdDepartmentNavigation).Where(x => x.IdEmployee == idEmployee).FirstOrDefaultAsync();

                var employeeResult = _mapper.Map<EmployeeDto>(employee);

                return employeeResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmployeeDto> Add(EmployeeDto employee)
        {
            try
            {
                var employeeEntity = _mapper.Map<Employee>(employee);

                _dbContext.Employees.Add(employeeEntity);
                await _dbContext.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(int idEmployee, EmployeeDto employee)
        {
            try
            {
                var employeeResult = await _dbContext.Employees.Include(x => x.IdDepartmentNavigation).Where(x => x.IdEmployee == idEmployee).FirstOrDefaultAsync();

                if (employeeResult is null)
                    return false;

                var employeeEntity = _mapper.Map<Employee>(employee);

                employeeResult.FullName = employeeEntity.FullName;
                employeeResult.IdDepartment = employeeEntity.IdDepartment;
                employeeResult.Salary = employeeEntity.Salary;
                employeeResult.ContractDate = employeeEntity.ContractDate;

                _dbContext.Employees.Update(employeeResult);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int idEmployee)
        {
            try
            {
                var employeeResult = await _dbContext.Employees.Include(x => x.IdDepartmentNavigation).Where(x => x.IdEmployee == idEmployee).FirstOrDefaultAsync();

                if (employeeResult is null)
                    return false;

                _dbContext.Employees.Remove(employeeResult);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
