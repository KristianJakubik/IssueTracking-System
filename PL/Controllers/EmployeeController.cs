using System.Web.Mvc;
using BL.Facades;
using PL.Models;
using BL.DTOs;
using System.Linq;
using System;

namespace PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeFacade employeeFacade;

        public EmployeeController(EmployeeFacade employeeFacade)
        {
            this.employeeFacade = employeeFacade;
        }

        public ActionResult Employees()
        {
            var employeeViewModel = new EmployeeViewModel()
            {
                Employees = employeeFacade.GetAllEmployee()
            };
            return View("Employees", employeeViewModel);
        }

        public ActionResult Create()
        {
            return View("Create", new EmployeeViewModel());
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel model)
        {
            employeeFacade.CreateEmployee(model.Employee);
            return RedirectToAction("Employees");
        }

        public ActionResult Delete(int id)
        {
            employeeFacade.DeleteEmployee(id);
            return RedirectToAction("Employees");
        }
    }
}