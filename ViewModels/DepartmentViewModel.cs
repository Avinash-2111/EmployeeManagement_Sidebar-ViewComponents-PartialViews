using EmployeeManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class DepartmentViewModel
    {
        #region PropertiesOfDepartment
        [Key]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage ="DepartmentName Required")]
        public string DepartmentName { get; set; }
        #endregion

        #region RelationWithEmployee
        public ICollection<Employee> Employees { get; set; }
        #endregion
    }
}
