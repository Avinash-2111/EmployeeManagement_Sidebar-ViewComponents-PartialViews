using EmployeeManagement.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Department
    {
        #region PropertiesOfDepartment
        [Key]
        public int DepartmentId {  get; set; }
        [Required]
        public string DepartmentName { get; set; }
        #endregion

        #region RelationWithEmployee
        public ICollection<EmployeeViewModel> Employees { get; set; }
        #endregion

    }
}
