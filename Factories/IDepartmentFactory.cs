﻿using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Factories
{
    public interface IDepartmentFactory
    {
        public Task<DepartmentViewModel> GetDepartmentByIdAsync(int id);
        public Task<DepartmentViewModel> AddDepartment(DepartmentViewModel department);

        public Task<DepartmentViewModel> UpdateDepartment(DepartmentViewModel department);
        public Task<DepartmentViewModel> DeleteDepartment(int id);
        public Task<List<DepartmentViewModel>> GetAllDepartments();
    }
}
