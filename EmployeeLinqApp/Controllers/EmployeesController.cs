using EmployeeLinqApp.Data;
using EmployeeLinqApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EmployeeLinqApp.Controllers
{
    public class EmployeesController : Controller
    {
        // Show all employees + optional search
        public IActionResult Index(string search)
        {
            var employees = EmployeeRepository.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                // LINQ query to filter by name or department
                employees = employees
                    .Where(e => e.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
                             || e.Department.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(employees);
        }

        // Show create form
        public IActionResult Create()
        {
            return View();
        }

        // Handle create POST
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Show edit form
        public IActionResult Edit(int id)
        {
            var emp = EmployeeRepository.GetById(id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // Handle edit POST
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository.Update(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Show delete confirmation
        public IActionResult Delete(int id)
        {
            var emp = EmployeeRepository.GetById(id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // Handle delete POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            EmployeeRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
