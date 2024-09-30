using Microsoft.AspNetCore.Mvc;
using MVCTask.Models;

namespace MVCTask.Controllers
{
    public class departmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        iticontext context=new iticontext();
        public IActionResult GetAll()
        {
            List<department> departments=context.Departments.ToList();
            return View(departments);
        }
        public IActionResult GetById(int id)
        {
            department departments=context.Departments.SingleOrDefault(s=>s.DNum==id);
            return View(departments);
        }
        public IActionResult GoToAdd()
        {
            return View();
        }
        public IActionResult SaveAddedData(department dept)
        {
            if(ModelState.IsValid==true)
            {
                context.Departments.Add(dept);
                context.SaveChanges();
                return RedirectToAction("GetAll");
            }
            else
            {
                return View("GoToAdd");
            }
           
        }
        public IActionResult GoToEdit(int id)
        {
            department departments=context.Departments.SingleOrDefault(s=>s.DNum== id);
            return View(departments);
        }
        public IActionResult SaveEditData(department dept)
        {
            context.Departments.Update(dept);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }
        public IActionResult GoToDelete(int id)
        {
            department departments = context.Departments.SingleOrDefault(s => s.DNum == id);
            return View(departments);
        }
        public IActionResult SaveDeleteData(department dept)
        {
            context.Departments.Remove(dept);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }
    }
}
