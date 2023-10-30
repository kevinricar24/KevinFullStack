namespace Kevin.API.Domain.Dtos
{
    public class EmployeeDto
    {
        public int IdEmployee { get; set; }

        public string? FullName { get; set; }

        public int? IdDeparment { get; set; }
        public string? NameDeparment { get; set; }

        public int? Salary { get; set; }

        public string? ContractDate { get; set; }
    }
}
