using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.Facades;
using PL.Models;
using BL.DTOs;

namespace PL.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectFacade projectFacade;
        private readonly PersonFacade personFacade;
        private readonly CompanyFacade companyFacade;


        public ProjectController(ProjectFacade projectFacade, PersonFacade personFacade, CompanyFacade companyFacade)
        {
            this.projectFacade = projectFacade;
            this.personFacade = personFacade;
            this.companyFacade = companyFacade;

        }

        public ActionResult IndexByCustomer(int id)
        {
            var projectViewModel = new ProjectViewModel()
            {
                Projects = projectFacade.GetProjectsByCustomer(id),
                CustomerId = id
            };

            return View("Projects", projectViewModel);
        }

        public ActionResult Projects()
        {
            var projectViewModel = new ProjectViewModel()
            {
                Projects = projectFacade.GetAllProjects()
            };
            return View("Projects", projectViewModel);
        }

        public ActionResult Create(int id)
        {
            var projectCreateViewModel = new ProjectCreateViewModel()
            {
                SelectedCustomerId = id,
            };
            return View("Create", projectCreateViewModel);
        }

        [HttpPost]
        public ActionResult Create(ProjectCreateViewModel model)
        {
            projectFacade.CreateProject(model.Project, model.SelectedCustomerId);
            var projectViewModel = new ProjectViewModel()
            {
                Projects = projectFacade.GetProjectsByCustomer(model.SelectedCustomerId),
                CustomerId = model.SelectedCustomerId
            };
            return View("Projects", projectViewModel);
        }

        public ActionResult GetCustomers(int customerId)
        {
            if (personFacade.GetPersonsByIds(new[] {customerId}).Any())
            {
                return RedirectToAction("Persons", "Person");
            }
            if (companyFacade.GetCompaniesByIds(new[] { customerId }).Any())
            {
                return RedirectToAction("Companies", "Company");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}