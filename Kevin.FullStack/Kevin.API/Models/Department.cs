namespace Kevin.API.Models;

public partial class Department
{
    public int IdDeparment { get; set; }

    public string? Name { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
