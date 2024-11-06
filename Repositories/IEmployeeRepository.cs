using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<EmployeeViewModel> GetEmployeeById(int id);
        public Task<EmployeeViewModel> AddEmployee(EmployeeViewModel employee);
        public Task<EmployeeViewModel> UpdateEmployee(EmployeeViewModel employee);
        public Task<EmployeeViewModel> DeleteEmployee(int id);
        public Task<List<EmployeeViewModel>> GetAllEmployees();
        public Task<EmployeeViewModel> GetEmployeeByDepartmentId(int departmentid);
    }
}
