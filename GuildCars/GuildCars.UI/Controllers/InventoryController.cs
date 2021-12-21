using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        public List<VehicleDetail> vehicles { get; set; }

        public ActionResult New()
        {
            vehicles = VehicleRepositoryFactory.GetRepository().GetByNewOrUsed(true);
            return View(vehicles);
        }

        public ActionResult Used()
        {
            vehicles = VehicleRepositoryFactory.GetRepository().GetByNewOrUsed(false);
            return View(vehicles);
        }

        [HttpGet]
        public ActionResult Details(string vin)
        {
            return View(VehicleRepositoryFactory.GetRepository().GetDetailByID(vin));
        }
    }
}