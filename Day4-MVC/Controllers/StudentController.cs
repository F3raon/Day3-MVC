using Day4_MVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_DAY2.Models;

namespace Day4_MVC.Controllers
{
    public class StudentController : Controller
    {
        MyContext db = new MyContext();

        [HttpGet]
        public IActionResult Index()
        {
            var students = db.Students.Include(e => e.Department);

            return View(students);
        }
        public IActionResult Details(int id)
        {
            var students = db.Students.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            if (students == null)
            {
                return RedirectToAction("Index");
            }
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag._Depts = new SelectList(db.Departments, "DeptId", "DeptName");
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var students = db.Students.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            if (students == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag._Depts = new SelectList(db.Departments, "DeptId", "DeptName");
            return View(students);
        }
      
        [HttpPost]
        public IActionResult Edit(Student students)
        {
            var oldstudent = db.Students.Find(students.Id);
            if (oldstudent == null)
            {
                return RedirectToAction("Index");
            }
            oldstudent.Name = students.Name;
            oldstudent.Age = students.Age;
            oldstudent.Address = students.Address;
            oldstudent.DeptId = students.DeptId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var students = db.Students.Find(id);
            if (students == null)
            {
                return RedirectToAction("Index");
            }
            db.Students.Remove(students);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
