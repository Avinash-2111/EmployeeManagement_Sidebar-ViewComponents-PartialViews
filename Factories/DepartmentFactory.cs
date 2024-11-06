using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Factories
{
    public class DepartmentFactory : IDepartmentFactory
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentFactory(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<DepartmentViewModel> AddDepartment(DepartmentViewModel department)
        {
            return await _departmentRepository.AddDepartment(department);
        }

        public Task<DepartmentViewModel> DeleteDepartment(int id)
        {
           return _departmentRepository.DeleteDepartment(id);
        }

        public async Task<List<DepartmentViewModel>> GetAllDepartments()
        {
         return await _departmentRepository.GetAllDepartments();
        }

        public async Task<DepartmentViewModel> GetDepartmentByIdAsync(int id)
        {
        return await _departmentRepository.GetDepartmentByIdAsync(id);
        }

        public async Task<DepartmentViewModel> UpdateDepartment(DepartmentViewModel department)
        {
            return await _departmentRepository.UpdateDepartment(department);
        }
    }
}
