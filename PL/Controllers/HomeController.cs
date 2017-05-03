using System.Linq;
using System.Web.Mvc;
using BL.DTOs;
using BL.Facades;
using PL.Models;

namespace PL.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    };
}