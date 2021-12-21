using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using GuildCars.Models.ViewModels;
using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class AdminController : Controller
    {
        public List<VehicleDetail> vehicles { get; set; }
        private readonly RoleManager<IdentityRole> roleManager;

        private string GetUserID()
        {
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = userMgr.FindByName(User.Identity.Name);
            return user.Id;
        }

        //public AdminController(RoleManager<IdentityRole> roleManager)
        //{
        //    this.roleManager = roleManager;
        //}

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<VehicleDetail> vehicles = VehicleRepositoryFactory.GetRepository().GetByNewOrUsed(true);
            vehicles.AddRange(VehicleRepositoryFactory.GetRepository().GetByNewOrUsed(false));
            return View(vehicles);
        }

        [HttpGet]
        public ActionResult Vehicles()
        {
            vehicles = VehicleRepositoryFactory.GetRepository().GetByNewOrUsed(true);
            vehicles.AddRange(VehicleRepositoryFactory.GetRepository().GetByNewOrUsed(false));
            return View(vehicles);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddVehicle()
        {
            var model = new VehicleAddOrEditVM();

            var makeRepo = MakeRepositoryFactory.GetRepository();
            var modelRepo = ModelRepositoryFactory.GetRepository();
            var bodyTypeRepo = BodyTypeRepositoryFactory.GetRepository();
            var interiorColorRepo = InteriorColorRepositoryFactory.GetRepository();
            var exteriorColorRepo = ExteriorColorRepositoryFactory.GetRepository();

            model.Makes = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");
            model.Models = new SelectList(modelRepo.GetAll(), "ModelID", "ModelName");
            model.BodyTypes = new SelectList(bodyTypeRepo.GetAll(), "BodyTypeID", "BodyTypeName");
            model.InteriorColors = new SelectList(interiorColorRepo.GetAll(), "InteriorColorID", "InteriorColorName");
            model.ExteriorColors = new SelectList(exteriorColorRepo.GetAll(), "ExteriorColorID", "ExteriorColorName");
            model.Vehicle = new Vehicle();

            Select_YN_Rebind();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddVehicle(VehicleAddOrEditVM model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();

                try
                {
                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savePath = Server.MapPath("~/images");
                        string fileName = Path.GetFileName(model.ImageUpload.FileName);
                        var filePath = Path.Combine(savePath, fileName);
                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savePath, filePath + counter.ToString());
                            counter++;
                        }
                        model.ImageUpload.SaveAs(filePath);
                        model.Vehicle.ImageFileName = Path.GetFileName(filePath);
                    }
                    repo.Insert(model.Vehicle);
                    return RedirectToAction("EditVehicle", new { id = model.Vehicle.VIN });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var makeRepo = MakeRepositoryFactory.GetRepository();
                var modelRepo = ModelRepositoryFactory.GetRepository();
                var bodyTypeRepo = BodyTypeRepositoryFactory.GetRepository();
                var interiorColorRepo = InteriorColorRepositoryFactory.GetRepository();
                var exteriorColorRepo = ExteriorColorRepositoryFactory.GetRepository();
                model.Makes = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");
                model.Models = new SelectList(modelRepo.GetAll(), "ModelID", "ModelName");
                model.BodyTypes = new SelectList(bodyTypeRepo.GetAll(), "BodyTypeID", "BodyTypeName");
                model.InteriorColors = new SelectList(interiorColorRepo.GetAll(), "InteriorColorID", "InteriorColorName");
                model.ExteriorColors = new SelectList(exteriorColorRepo.GetAll(), "ExteriorColorID", "ExteriorColorName");

                Select_YN_Rebind();
                return View(model);
            }

        }


        [HttpGet]
        [Authorize]
        public ActionResult EditVehicle(string vin)
        {
            var model = new VehicleAddOrEditVM();

            var makeRepo = MakeRepositoryFactory.GetRepository();
            var modelRepo = ModelRepositoryFactory.GetRepository();
            var bodyTypeRepo = BodyTypeRepositoryFactory.GetRepository();
            var interiorColorRepo = InteriorColorRepositoryFactory.GetRepository();
            var exteriorColorRepo = ExteriorColorRepositoryFactory.GetRepository();
            var vehicleRepo = VehicleRepositoryFactory.GetRepository();

            model.Makes = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");
            model.Models = new SelectList(modelRepo.GetAll(), "ModelID", "ModelName");
            model.BodyTypes = new SelectList(bodyTypeRepo.GetAll(), "BodyTypeID", "BodyTypeName");
            model.InteriorColors = new SelectList(interiorColorRepo.GetAll(), "InteriorColorID", "InteriorColorName");
            model.ExteriorColors = new SelectList(exteriorColorRepo.GetAll(), "ExteriorColorID", "ExteriorColorName");
            model.Vehicle = vehicleRepo.GetByID(vin);

            Select_YN_Rebind();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditVehicle(VehicleAddOrEditVM model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();

                try
                {

                    var oldVehicle = repo.GetByID(model.Vehicle.VIN);
                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savePath = Server.MapPath("~/images");
                        string fileName = Path.GetFileName(model.ImageUpload.FileName);
                        var filePath = Path.Combine(savePath, fileName);
                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savePath, filePath + counter.ToString());
                            counter++;
                        }
                        model.ImageUpload.SaveAs(filePath);
                        model.Vehicle.ImageFileName = Path.GetFileName(filePath);
                        
                        //delete old file
                        var oldPath = Path.Combine(savePath, oldVehicle.ImageFileName);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    else
                    {
                        //old file not replaced, so keep the old file name
                        model.Vehicle.ImageFileName = oldVehicle.ImageFileName;
                    }
                    repo.Update(model.Vehicle);
                    return RedirectToAction("EditVehicle", new { vin = model.Vehicle.VIN });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var makeRepo = MakeRepositoryFactory.GetRepository();
                var modelRepo = ModelRepositoryFactory.GetRepository();
                var bodyTypeRepo = BodyTypeRepositoryFactory.GetRepository();
                var interiorColorRepo = InteriorColorRepositoryFactory.GetRepository();
                var exteriorColorRepo = ExteriorColorRepositoryFactory.GetRepository();
                model.Makes = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");
                model.Models = new SelectList(modelRepo.GetAll(), "ModelID", "ModelName");
                model.BodyTypes = new SelectList(bodyTypeRepo.GetAll(), "BodyTypeID", "BodyTypeName");
                model.InteriorColors = new SelectList(interiorColorRepo.GetAll(), "InteriorColorID", "InteriorColorName");
                model.ExteriorColors = new SelectList(exteriorColorRepo.GetAll(), "ExteriorColorID", "ExteriorColorName");

                Select_YN_Rebind();
                return View(model);
            }

        }
        [HttpGet]
        [Authorize]
        public ActionResult Delete(string vin)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            repo.Delete(vin);
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult Users()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserAddOrEditVM model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };


            using (var db = new ApplicationDbContext())
            {
                var store = new UserStore<ApplicationUser>(db);
                var manager = new UserManager<ApplicationUser, string>(store);

                var result = manager.Create(user, model.Password);
                if (!result.Succeeded)
                    throw new ApplicationException("Unable to create a user.");

                result = manager.AddToRole(user.Id, "Administrator");
                if (!result.Succeeded)
                    throw new ApplicationException("Unable to add user to a role.");
            }

            return View();
        }


        [HttpGet]
        public ActionResult EditUser(int userID)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Makes()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Models()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Specials()
        {
            return View();
        }


        private void Select_YN_Rebind()
        {
            List<SelectListItem> Select_YN = new List<SelectListItem>();
            Select_YN.Add(new SelectListItem
            {
                Text = "No",
                Value = false.ToString()
            });
            Select_YN.Add(new SelectListItem
            {
                Text = "Yes",
                Value = true.ToString()
            });
            ViewData["Select_YN"] = Select_YN;
        }
    }
}