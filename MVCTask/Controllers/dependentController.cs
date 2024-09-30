using Microsoft.AspNetCore.Mvc;
using MVCTask.Models;

namespace MVCTask.Controllers
{
    public class dependentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        iticontext context=new iticontext();
        public IActionResult GetAll()
        {
            List<dependent> dependents = context.Dependents.ToList();
            return View(dependents);
        }
        public IActionResult GetById(string id)
        {
            dependent dependents = context.Dependents.SingleOrDefault(s => s.dependentName == id);
            return View(dependents);

        }
        public IActionResult GoToAdd(String name)
        {
            return View();
        }
        public IActionResult SaveAddedData(dependent dep)
        { 
            if(ModelState.IsValid==true)
            {
                context.Dependents.Add(dep);
                context.SaveChanges();
                return RedirectToAction("GetAll");
            }
            else
            {
                return View("GoToAdd");
            }

        }
        public IActionResult GoToEdit(string name)
        {
            dependent dependents=context.Dependents.SingleOrDefault(s=>s.dependentName== name);
            return View(dependents);
        }
        public IActionResult SaveEditedData(dependent dep)
        {
            context.Dependents.Update(dep);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }
    }
}
