using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using GuildCars.Models.ViewModels;
using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class SalesController : Controller
    {

        public List<VehicleDetail> vehicles { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            //code to get user id from usermanager. Useful, but i really need the role moreso
            if (Request.IsAuthenticated)
            {
                var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = userMgr.FindByName(User.Identity.Name);
                ViewBag.UserId = user.Id;
            }

            vehicles = VehicleRepositoryFactory.GetRepository().GetByNewOrUsed(true);
            vehicles.AddRange(VehicleRepositoryFactory.GetRepository().GetByNewOrUsed(false));
            return View(vehicles);
        }

        [HttpGet]
        public ActionResult Purchase(string vin)
        {
            VehiclePurchaseDetailVM model = new VehiclePurchaseDetailVM();
            model.VehicleDetail = VehicleRepositoryFactory.GetRepository().GetDetailByID(vin);
            model.Vehicle = VehicleRepositoryFactory.GetRepository().GetByID(vin);
            return View(model);
        }

    }
}