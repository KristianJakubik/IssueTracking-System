using System.Web.Mvc;
using BL.Facades;
using PL.Models;

namespace PL.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonFacade personFacade;

        public PersonController(PersonFacade personFacade)
        {
            this.personFacade = personFacade;
        }

        public ActionResult Persons()
        {
            var personViewModel = new PersonViewModel()
            {
                Persons = personFacade.GetAllPerson()
            };
            return View("Persons", personViewModel);
        }

        public ActionResult Create()
        {
            var personViewModel = new PersonViewModel()
            {
                Persons = personFacade.GetAllPerson()
            };
            return View("Create", personViewModel);
        }

        [HttpPost]
        public ActionResult Create(PersonViewModel model)
        {
            personFacade.CreatePerson(model.Person);
            return RedirectToAction("Persons");
        }
    }
}