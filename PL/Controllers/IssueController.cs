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
    public class IssueController : Controller
    {
        private readonly IssueFacade issueFacade;
        private readonly EmployeeFacade employeeFacade;
        private readonly ProjectFacade projectFacade;


        public IssueController(ProjectFacade projectFacade, IssueFacade issueFacade, EmployeeFacade employeeFacade)
        {
            this.projectFacade = projectFacade;
            this.issueFacade = issueFacade;
            this.employeeFacade = employeeFacade;

        }

        public ActionResult IndexByProject(int id)
        {
            var issueViewModel = new IssueViewModel()
            {
                Issues = issueFacade.GetIssuesByProject(id),
                ProjectId = id
            };

            return View("Issues", issueViewModel);
        }

        public ActionResult IndexByEmployee(int id)
        {
            var issueViewModel = new IssueViewModel()
            {
                Issues = issueFacade.GetIssuesByEmployee(id),
                EmployeeId = id
            };

            return View("Issues", issueViewModel);
        }

        public ActionResult Issues()
        {
            var issueViewModel = new IssueViewModel()
            {
                Issues = issueFacade.GetAllIssues()
            };
            return View("Issues", issueViewModel);
        }

        public ActionResult Create(int? projectId, int? employeeId)
        {
            var issueCreateViewModel = new IssueCreateViewModel()
            {
                SelectedProjectId = projectId,
                SelectedEmployeeId = employeeId,
                AvailableEmployees = new SelectList(employeeFacade.GetAllEmployee(), "Id", "GetFullName"),
                AvailableProjects = new SelectList(projectFacade.GetAllProjects(), "Id", "Name"),
            };

            return View("Create", issueCreateViewModel);
        }

        [HttpPost]
        public ActionResult Create(IssueCreateViewModel model)
        {
            if (model.SelectedProjectId == null && model.SelectedEmployeeId == null)
            {
                return RedirectToAction("Index", "Home");    
            }

            issueFacade.CreateIssue(model.Issue, model.NewProjectId, model.NewEmployeeId);

            return View("Issues", GetIssuesModel(model.SelectedProjectId, model.SelectedEmployeeId));
        }

        public ActionResult Delete(int id, int? projectId, int? employeeId)
        {
            issueFacade.DeleteIssue(id);
            return View("Issues", GetIssuesModel(projectId, employeeId));
        }

        public ActionResult GetProjectsEmployees(int? projectId, int? employeeId)
        {
            if (projectId != null)
            {
                return RedirectToAction("IndexByCustomer", "Project", new {id = projectFacade.GetCustomerId((int) projectId)});
            }
            if (employeeId != null)
            {
                return RedirectToAction("Employees", "Employee");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id, int? projectId, int? employeeId)
        {
            var issueModel = new IssueEditViewModel()
            {
               Issue = issueFacade.GetIssuesByIds(new []{id}).First(),
               SelectedProjectId = projectId,
               SelectedEmployeeId = employeeId,
               AvailableEmployees = new SelectList(employeeFacade.GetAllEmployee(), "Id", "GetFullName"),
            };
            return View("Edit", issueModel);
        }

        [HttpPost]
        public ActionResult Edit(IssueEditViewModel model)
        { 
            issueFacade.UpdateIssue(model.Issue, model.NewEmployeeId  ?? 0);
            
            return View("Issues", GetIssuesModel(model.SelectedProjectId, model.SelectedEmployeeId));
        }

        private IssueViewModel GetIssuesModel(int? projectId, int? employeeId)
        {
            var model = new IssueViewModel()
            {
                EmployeeId = employeeId,
                ProjectId = projectId,
            };

            if (projectId != null)
            {
                model.Issues = issueFacade.GetIssuesByProject((int) projectId);
            }
            if (employeeId != null)
            {
                model.Issues = issueFacade.GetIssuesByEmployee((int)employeeId);
            }

            return model;
        }
    }
}
