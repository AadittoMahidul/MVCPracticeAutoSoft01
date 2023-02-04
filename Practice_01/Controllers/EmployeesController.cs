using Practice_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice_01.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeeDbContext db = new EmployeeDbContext();
        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.ToList();
            return View(employees);
        }
        public ActionResult Create()
        {
            ViewBag.emp = db.Employees.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emp = db.Employees.ToList();
            return View(emp);
        }
        public ActionResult Edit(int id)
        {
            return View(db.Employees.First(x => x.EmployeeId == id));
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");   
            }
            ViewBag.emp = db.Employees.ToList();
            return View();
        }
        public ActionResult Delete(int id)
        {
            return View(db.Employees.First(x=>x.EmployeeId ==id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Employee emp = new Employee { EmployeeId = id };
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}