﻿using System;
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
        BasketRepository basketRepo = new BasketRepository();

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

        public string GetBasketHtml()
        {
            List<Basket> basket = basketRepo.GetItems();
            string ret = RenderPartialViewToString("~/Views/Home/BasketView.cshtml", basket);
            return ret;
        }

        public string RemoveItemFromBasket(int itemId)
        {
            basketRepo.RemoveItem(itemId);

            return GetBasketHtml();
        }

        public string RemoveItemsFromBasket()
        {
            basketRepo.RemoveItems();
            return GetBasketHtml();
        }

        public ActionResult AddTyreToBasket(int tyreId, string brand, string season, string article, double price )
        {
            bool tyreAdded = basketRepo.TyreAlreadyAdded(tyreId);

            if (!tyreAdded)
            {
                basketRepo.StoreTyre(tyreId, brand, season, article, price);
            }
            return Json(new { exists = tyreAdded });
        }

        public ActionResult GetBasketItems()
        {
            return Json(basketRepo.GetItems(), JsonRequestBehavior.AllowGet);
        }

        public string About()
        {
            string ret = RenderPartialViewToString("~/Views/Home/About.cshtml", false);
            return ret;
        }

        public string Contact()
        {
            string ret = RenderPartialViewToString("~/Views/Home/Contact.cshtml", false);
            return ret;
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