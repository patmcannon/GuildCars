using GuildCars.Data.ADO;
using GuildCars.Data.Factories;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using GuildCars.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //construct a view model (HomepageVehicleVM) because we need a list of FeaturedVehicles and a list of Specials
            HomepageVehiclesVM vehicles = new HomepageVehiclesVM();
            vehicles.FeaturedVehicles = VehicleRepositoryFactory.GetRepository().GetFeatured();
            vehicles.Specials = SpecialRepositoryFactory.GetRepository().GetAll();            
            return View(vehicles);
        }
        
        [HttpGet]
        public ActionResult Contact(string vin)
        {
            ViewBag.Message = "Your contact page.";
            Contact contact = new Contact();
            if (!string.IsNullOrEmpty(vin))
            {
                contact.ContactMessage = vin;
                return View(contact);
            } 
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Specials()
        {
            return View(SpecialRepositoryFactory.GetRepository().GetAll());
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            var repo = ContactRepositoryFactory.GetRepository();
            repo.Insert(contact);
            return RedirectToAction("Index");
        }

    }
}