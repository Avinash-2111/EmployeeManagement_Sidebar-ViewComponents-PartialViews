using EmployeeManagement.Factories;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentFactory _departmentFactory;

        public DepartmentController(IDepartmentFactory departmentFactory)
        {
            _departmentFactory = departmentFactory;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _departmentFactory.GetAllDepartments();
            return View(list);
        }
        public async Task<IActionResult> AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentViewModel department)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            await _departmentFactory.AddDepartment(department);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (id == 0)
            {
                return View();
            }
            await _departmentFactory.DeleteDepartment(id);
            return RedirectToAction("Index");

        }
    }
}
