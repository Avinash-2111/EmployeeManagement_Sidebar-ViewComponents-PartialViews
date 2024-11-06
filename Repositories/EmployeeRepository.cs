using EmployeeManagement.Context;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<EmployeeViewModel> AddEmployee(EmployeeViewModel employee)
        {
            if (employee != null)
            {
                try
                {
                    var result = _appDbContext.Employees.Add(employee);
                    _appDbContext.SaveChanges();
                    return result.Entity;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(ex.Message);
                }
            }
            else
            {
                throw new NotImplementedException("employee cannot be null");
            }

        }

        public async Task<EmployeeViewModel> DeleteEmployee(int id)
        {
            try
            {
                if (id != 0)
                {
                    var employee = await _appDbContext.Employees.FindAsync(id);
                    if (employee != null)
                    {
                        var result = _appDbContext.Employees.Remove(employee);
                        _appDbContext.SaveChanges();
                        return result.Entity;
                    }
                    else
                    {
                        throw new NotImplementedException("Employee Details not Found");
                    }
                }
                else
                {
                    throw new NotImplementedException("Employee not found");
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            try
            {
                var list = await _appDbContext.Employees.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<EmployeeViewModel> GetEmployeeByDepartmentId(int departmentid)
        {
            try
            {
                if (departmentid != 0)
                {
                    var employee = await _appDbContext.Employees.Where(x => x.DepartmentId == departmentid).FirstOrDefaultAsync();
                    if (employee == null)
                    {
                        return null;
                    }
                    return employee;
                }
                else
                {
                    throw new NotImplementedException("DepartmentId Cannot be Zero");
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("An error occurred while fetching the employee.", ex);
            }
        }

        public async Task<EmployeeViewModel> GetEmployeeById(int id)
        {
            try
            {
                if (id != 0)
                {
                    var employee = await _appDbContext.Employees.FindAsync(id);
                    return employee;
                }
                else
                {
                    throw new NotImplementedException("Employee not found");
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<EmployeeViewModel> UpdateEmployee(EmployeeViewModel employee)
        {
            try
            {
                if (employee != null)
                {
                    var result = _appDbContext.Employees.Update(employee);
                    _appDbContext.SaveChanges();
                    return result.Entity;
                }
                else
                {
                    throw new NotImplementedException("Employee Cannot be Updated");
                }

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

        }
    }
}
