using Day4_MVC.Context;
using Microsoft.AspNetCore.Mvc;
using MVC_DAY2.Models;

namespace Day4_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        MyContext db = new MyContext();

        [HttpGet]
        public IActionResult Index()
        {
            var departments = db.Departments;

            return View(departments);
        }
        public IActionResult Details(int id)
        {
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return RedirectToAction("Index");
            }
            return View(department);
        }
     
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult Create(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dept = db.Departments.Find(id);
            if (dept == null)
            {
                return RedirectToAction("Index");
            }
            return View(dept);
        }
       
        
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            
            var dept = db.Departments.Find(department.DeptId);
            if (dept == null)
            {
                return RedirectToAction("Index");
            }
            dept.DeptName = department.DeptName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public IActionResult Delete(int id)
        {
            var dept = db.Departments.Find(id);
            if (dept == null)
            {
                return RedirectToAction("Index");
            }
            db.Departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
