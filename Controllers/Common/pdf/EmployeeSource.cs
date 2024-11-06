namespace EmployeeManagement.Common.pdf
{
    public class EmployeeSource
    {
        public EmployeeSource() 
        {
            Employees=new List<EmployeeSource>();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public List<EmployeeSource> Employees { get; set; }
    }
}
