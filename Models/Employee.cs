using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        #region PropertiesOfEmployee
        [Key]
        public int EmployeeId { get; set; }
        public string?  FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public bool? IsActive { get; set; }
        #endregion

        #region OneToMany RelationShip With Department
        [ForeignKey("Department")]
        public int DepartmentId {  get; set; }
        public Department? Department { get; set; }
        #endregion
    }
}
