using EmployeeManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeViewModel
    {
        #region PropertiesOfEmployee
        [Key]
      
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "FirstName Required")]
        [StringLength(50,ErrorMessage ="Length Should not Exceed 50 Characters")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "LastName Required")]
        [StringLength(50, ErrorMessage = "Length Should not Exceed 50 Characters")]
        public string? LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage ="Please Choose Gender")]

        public string? Gender { get; set; }
        [EmailAddress(ErrorMessage ="Invalid Email")]
        [Required]
        public string? Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        #endregion

        #region OneToMany RelationShip With Department
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        #endregion
    }
}
