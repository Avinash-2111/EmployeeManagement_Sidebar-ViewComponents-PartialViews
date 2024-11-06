using EmployeeManagement.Context;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task<DepartmentViewModel> AddDepartment(DepartmentViewModel department)
        {
            try
            {
               var result= await _dbContext.Departments.AddAsync(department);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<DepartmentViewModel> DeleteDepartment(int id)
        {
            try
            {
                var model = await _dbContext.Departments.FindAsync(id);
                if (model != null)
                {
                  var result=  _dbContext.Departments.Remove(model);
                    _dbContext.SaveChanges();
                    return result.Entity;
                }
                else
                {
                    throw new NotImplementedException("The Request Cant be Processed");
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                _dbContext.SaveChanges();
            }
            
        }

        public async Task<List<DepartmentViewModel>> GetAllDepartments()
        {
            try
            {
                var List = await _dbContext.Departments.ToListAsync();
                return List;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<DepartmentViewModel> GetDepartmentByIdAsync(int id)
        {
            try
            {
                var department = await _dbContext.Departments.FindAsync(id);
                return department;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<DepartmentViewModel> UpdateDepartment(DepartmentViewModel department)
        {
            try
            {
                var result =  _dbContext.Departments.Update(department);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                _dbContext.SaveChanges();
            }

        }
    }
}
