using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooBookApp.Models;

namespace ZooBookApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DbConnection _dd;

        public EmployeeController(DbConnection dd)
        {
            _dd = dd;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Employees> employees = _dd.Employee.ToList();

            if (employees == null)
                return NotFound();

            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employees employee)
        {
            if(ModelState.IsValid)
            {
                _dd.Employee.Add(employee);
                int save = _dd.SaveChanges();

                if (save > 0)
                    return RedirectToAction("Index");
                return ViewBag.ErrorMessage = "Failed to Save New Employee Details";
            }
            return ViewBag.ErrorMessage = "Employee Details are Not Valid";
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return ViewBag.ErrorMessage = "Employee id is null";

            Employees employee =_dd.Employee.Find(id);
            _dd.Employee.Remove(employee);
            
            int save = _dd.SaveChanges();

            if (save > 0)
                return RedirectToAction("Index");

            return ViewBag.ErrorMessage = "Failed to delete Employee Data";
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return ViewBag.ErrorMessage = "Employee id is null";

            Employees employee = _dd.Employee.Find(id);

            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Employees employee)
        {
            if(ModelState.IsValid)
            {
                _dd.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                int save = _dd.SaveChanges();

                if (save > 0)
                    return RedirectToAction("Index");
            }
            return ViewBag.ErrorMessage = "New Employee Details are Not Valid";
        }
    }
}
