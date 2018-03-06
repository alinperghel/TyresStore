using System;
using System.Collections.Generic;
using System.IO;
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
            List<Tyre> tyres = tyresRepo.GetTyres();

            return View(vehicles);
        }

        public string GetTyres(int vehicleId)
        {
            List<Tyre> tyres = tyresRepo.GetTyresByVehicleId(vehicleId);
            string ret = RenderPartialViewToString("~/Views/Home/TyresView.cshtml", tyres);

            return ret;
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

        public string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

    }
}