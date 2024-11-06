using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using EmployeeManagement.Repositories;
using EmployeeManagement.Common.pdf;
using System.Collections.Generic;

namespace EmployeeManagement.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeFactory(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
       

        public async Task<EmployeeViewModel> AddEmployee(EmployeeViewModel employee)
        {
            return await _employeeRepository.AddEmployee(employee);
        }

        public Task<EmployeeViewModel> DeleteEmployee(int id)
        {
           return _employeeRepository.DeleteEmployee(id);
        }

        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
           return await _employeeRepository.GetAllEmployees();
        }

        public async Task<EmployeeViewModel> GetEmployeeByDepartmentId(int departmentid)
        {
        return await _employeeRepository.GetEmployeeByDepartmentId(departmentid);
        }

        public async Task<EmployeeViewModel> GetEmployeeById(int id)
        {
         return await _employeeRepository.GetEmployeeById(id);
        }

    
        public async Task<EmployeeViewModel> UpdateEmployee(EmployeeViewModel employee)
        {
           return await _employeeRepository.UpdateEmployee(employee);
        }
        public async Task PrintEmployeeslist(Stream stream,EmployeeViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            var Employees1 = await _employeeRepository.GetAllEmployees();

            var employeesource = new EmployeeSource
            {
                Employees = new List<EmployeeSource>()
            };

            foreach (var employee in Employees1)
            {
                employeesource.Employees.Add(new EmployeeSource
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateOfBirth = employee.DateOfBirth,
                    Gender = employee.Gender,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Address = employee.Address,
                });
            }
            await using var pdfStream = new MemoryStream();
            var document = new EmployeeDocument(employeesource);
            document.Genaratepdf(pdfStream);



        }

    }
}
