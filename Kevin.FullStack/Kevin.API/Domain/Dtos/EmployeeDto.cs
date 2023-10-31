namespace Kevin.API.Domain.Dtos
{
    public class EmployeeDto
    {
        public int IdEmployee { get; set; }

        public string? FullName { get; set; }

        public int? IdDepartment { get; set; }
        public string? NameDepartment { get; set; }

        public int? Salary { get; set; }

        public string? ContractDate { get; set; }
    }
}
