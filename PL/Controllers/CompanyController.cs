using System.Web.Mvc;
using BL.Facades;
using BL.DTOs;
using PL.Models;
using System.Linq;

namespace PL.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyFacade companyFacade;

        public CompanyController(CompanyFacade companyFacade)
        {
            this.companyFacade = companyFacade;
        }

        public ActionResult Companies()
        {
            var companyViewModel = new CompanyViewModel()
            {
                Companies = companyFacade.GetAllCompanies()
            };
            return View("Companies", companyViewModel);
        }

        public ActionResult Create()
        {
            var companyViewModel = new CompanyViewModel()
            {
                Company = null,
                Companies = companyFacade.GetAllCompanies()
            };
            return View("Create", companyViewModel);
        }

        [HttpPost]
        public ActionResult Create(CompanyViewModel model)
        {
            companyFacade.CreateCompany(model.Company);
            return RedirectToAction("Companies");
        }
    }

}