using Microsoft.AspNetCore.Mvc;
using MVCTask.Models;
using System.Threading.Tasks.Sources;

namespace MVCTask.Controllers
{
    public class projectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        iticontext contex=new iticontext();
        public IActionResult GetAll()
        {
            List<project> projects = contex.Projects.ToList();   
            return View(projects);
        }
        public IActionResult GetById(int id)
        {
            project projects=contex.Projects.SingleOrDefault(s=>s.Pnum==id);
            List<department> departments = contex.Departments.ToList();
            ViewBag.dept_id = departments;
            return View(projects);
        }
        public IActionResult GoToAdd()
        {
            List<department> departments = contex.Departments.ToList();
            ViewBag.dept_id = departments;
            return View();
        }
        public IActionResult SaveAddedData(project pro)
        {
            if(ModelState.IsValid==true)
            {
                contex.Projects.Add(pro);
                contex.SaveChanges();
                return RedirectToAction("GetAll");
            }
            else
            {
                List<department> departments = contex.Departments.ToList();
                ViewBag.dept_id = departments;
                return View("GoToAdd");
            }
           
        }
        public IActionResult GoToEdit(int id)
        {
            project projects = contex.Projects.SingleOrDefault(s=>s.Pnum==id);
            List<department> departments = contex.Departments.ToList();
            ViewBag.dept_id = departments;
            return View(projects);
        }
        public IActionResult SaveEditData(project pro)
        {
            contex.Projects.Update(pro);
            contex.SaveChanges();
            return RedirectToAction("GetAll");
        }
        public IActionResult GoToDelete(int id)
        {

            project projects=contex.Projects.SingleOrDefault(s=>s.Pnum==id);
            if (projects == null)
            {
                // Handle the case where the project is not found
                return NotFound();  // Or some other appropriate action
            }
            contex.Projects.Remove(projects);
            contex.SaveChanges();
            return RedirectToAction("GetAll");
        }
    }
}
