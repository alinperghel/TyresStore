using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TyresStore.Repository;
using TyresStore.Repository.Models;

namespace TyresStore.Controllers
{
    public class HomeController : Controller
    {
        VehiclesRepository vehiclesRepo = new VehiclesRepository();
        TyresRepository tyresRepo = new TyresRepository();

        public ActionResult Index()
        {
            List<Vehicle> vehicles = vehiclesRepo.GetVehicles();

            return View(vehicles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}