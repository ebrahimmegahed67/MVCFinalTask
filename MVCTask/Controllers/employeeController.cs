using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCTask.Models;

namespace MVCTask.Controllers
{
    public class employeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        iticontext context = new iticontext();
        public IActionResult GetAll()
        {
            List<employee> employees = context.Employees.Include(s=>s.department).ToList();
            return View(employees);
        }
        public IActionResult GetById(int id)
        {
            employee employees = context.Employees.SingleOrDefault(s => s.ssn == id);
            if (employees == null)
            {
                return NotFound(); 
            }
            return View(employees);
        }
        public IActionResult GoToAdd()
        {
            List<department> departments = context.Departments.ToList();
            ViewBag.dept_id = departments;
            return View();
        }
        public IActionResult SaveAddedData(employee emp)
        {
            if (ModelState.IsValid == true)
            {


                context.Employees.Add(emp);
                context.SaveChanges();
                return RedirectToAction("GetAll");
            }
            else
            {
                List<department> departments = context.Departments.ToList();
                ViewBag.dept_id = departments;
                return View("GoToAdd");
            }

        }
        public IActionResult GoToEdit(int id)
        {
            employee employees=context.Employees.SingleOrDefault(s=>s.ssn== id);
            List<department> departments = context.Departments.ToList();
            ViewBag.dept_id= departments;
            return View(employees);
        }
        public IActionResult SaveEditData(employee emp)
        {
            context.Employees.Update(emp);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }
        public IActionResult GoToDelete(int id)
        {
            employee emp = context.Employees.SingleOrDefault(s => s.ssn == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }

        // make salary range in client side

        public IActionResult CheckSalary(int salary)
        {
            if(salary>=10000 && salary<=20000)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
