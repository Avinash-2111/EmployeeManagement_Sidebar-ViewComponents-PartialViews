using EmployeeManagement.Factories;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MimeKit;
using PdfSharp.Snippets.Drawing;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeFactory _employeeFactory;
        private readonly IDepartmentFactory _departmentFactory;

        public EmployeeController(IEmployeeFactory employeeFactory,IDepartmentFactory departmentFactory)
        {
            _employeeFactory = employeeFactory;
            _departmentFactory= departmentFactory;
        }
        public async Task<IActionResult> Index(string searchString,string sortOrder)
        {
            var employees = await _employeeFactory.GetAllEmployees();

            //Search Functionality
            if(!string.IsNullOrEmpty(searchString))
            {
                var lowerSearchString = searchString.ToLower();
                employees = employees
                    .Where(x =>
                        x.FirstName.ToLower().Contains(lowerSearchString) ||
                        x.LastName.ToLower().Contains(lowerSearchString))
                    .ToList();
            }
            ViewBag.fnamesortparam = sortOrder== "fname_asc" ? "fname_desc" : "fname_asc";
            ViewBag.lnamesortparam = sortOrder == "lname_asc" ? "lname_desc" : "lname_asc";
            ViewBag.dobsortparam = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            ViewBag.isactivesortparam = sortOrder == "isactive_asc" ? "isactive_desc" : "isactive_asc";
            ViewBag.gendersortparam = sortOrder == "gender_asc" ? "gender_desc" : "gender_asc";
            ViewBag.emailsortparam = sortOrder == "email_asc" ? "email_desc" : "email_asc";
            ViewBag.phonesortparam = sortOrder == "phone_asc" ? "phone_desc" : "phone_asc";
            ViewBag.addresssortparam = sortOrder == "address_asc" ? "address_desc" : "address_asc";

            //Sort Functionality
            switch(sortOrder)
            {
                case "fname_desc":
                    employees = employees.OrderByDescending(x => x.FirstName).ToList();
                    break;
                case "fname_asc":
                    employees = employees.OrderBy(x => x.FirstName).ToList();
                    break;
                case "lname_asc":
                    employees = employees.OrderBy(x => x.LastName).ToList();
                    break;
                case "lname_desc":
                    employees = employees.OrderByDescending(x => x.LastName).ToList();
                    break;
                case "date_asc":
                    employees=employees.OrderBy(x=>x.DateOfBirth).ToList();
                    break;
                case "date_desc":
                    employees = employees.OrderByDescending(x => x.DateOfBirth).ToList();
                    break;
                case "isactive_desc":
                    employees=employees.OrderByDescending(x=>x.IsActive).ToList();
                    break;
                case "isactive_asc":
                    employees = employees.OrderBy(x => x.IsActive).ToList();
                    break;
                case "gender_asc":
                    employees = employees.OrderBy(x => x.Gender).ToList();
                    break;
                case "gender_desc":
                    employees = employees.OrderByDescending(x => x.Gender).ToList();
                    break;
                case "email_asc":
                    employees = employees.OrderBy(x => x.Email).ToList();
                    break;
                case "email_desc":
                    employees = employees.OrderByDescending(x => x.Email).ToList();
                    break;
                case "phone_asc":
                    employees = employees.OrderBy(x => x.Phone).ToList();
                    break;
                case "phone_desc":
                    employees = employees.OrderByDescending(x => x.Phone).ToList();
                    break;
                case "address_asc":
                    employees = employees.OrderBy(x => x.Address).ToList();
                    break;
                case "address_desc":
                    employees = employees.OrderByDescending(x => x.Address).ToList();
                    break;

                default:
                    employees=employees.ToList();
                    break;

            }
            return View(employees);
        }
        public async Task<IActionResult> AddEmployee()
        {
            var departments = await _departmentFactory.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> AddEmployee(EmployeeViewModel employee)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            await _employeeFactory.AddEmployee(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int itemid)
        {
            var employee=await _employeeFactory.GetEmployeeById(itemid);
            var departments = await _departmentFactory.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeViewModel updatedemployee)
        {
            if (updatedemployee == null)
            {
               return View("Error");
            }
            await _employeeFactory.UpdateEmployee(updatedemployee);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteEmployee(int itemid)
        {
            if (itemid == 0)
            {
                return View("Employee id cannot be zero");
            }
            await _employeeFactory.DeleteEmployee(itemid);
            return RedirectToAction("Index");
        }
        //public async Task<IActionResult> GetEmployeePdf()
        //{
        //    try
        //    {
                
        //        byte[] bytes;
        //        await using var stream=new MemoryStream();
        //        var model = new EmployeeViewModel();
        //        //await _employeeFactory.PrintEmployeeslist(stream,model);
        //        //return File(stream, MimeTypes.Applicationpdf, "Employee.pdf");
        //    }
        //    catch (Exception ex)
        //    {
        //       // return View("Error", ex.Message);
        //        throw new NotImplementedException(ex.Message);
        //    }
        //}
    }
}
