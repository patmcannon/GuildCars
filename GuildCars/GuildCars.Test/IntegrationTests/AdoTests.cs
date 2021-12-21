using GuildCars.Data.ADO;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Test.IntegrationTests
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DBReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //State Tests
        [Test]
        public void CanLoadStates()
        {
            var repo = new StateRepositoryADO();
            var states = repo.GetAll();

            Assert.AreEqual(3, states.Count);
            Assert.AreEqual("KY", states[0].StateAbbr);
            Assert.AreEqual("Kentucky", states[0].StateName);
        }
        [Test]
        public void CanLoadStateByID()
        {
            var repo = new StateRepositoryADO();
            var state = repo.GetByID("MN");


            Assert.IsNotNull(state);
            Assert.AreEqual("Minnesota", state.StateName);
            Assert.AreEqual("MN", state.StateAbbr);
        }

        [Test]
        public void NotFoundStateReturnsNull()
        {
            var repo = new StateRepositoryADO();
            var state = repo.GetByID("ZZ");

            Assert.IsNull(state);
        }

        [Test]
        public void CanAddState()
        {
            State state = new State();
            var repo = new StateRepositoryADO();

            state.StateAbbr = "WA";
            state.StateName = "Washington";
            repo.Insert(state);

            Assert.AreEqual(4, repo.GetAll().Count);
        }

        [Test]
        public void CanUpdateState()
        {
            State state = new State();
            var repo = new StateRepositoryADO();

            state.StateAbbr = "WA";
            state.StateName = "Wershingfon";
            repo.Insert(state);

            state.StateName = "Washington";
            repo.Update(state);

            var updatedState = repo.GetByID("WA");
            Assert.AreEqual("Washington", updatedState.StateName);
        }

        [Test]
        public void CanDeleteState()
        {
            State state = new State();
            var repo = new StateRepositoryADO();

            state.StateAbbr = "WA";
            state.StateName = "Washington";
            repo.Insert(state);

            var loaded = repo.GetByID("WA");
            Assert.IsNotNull(loaded);

            repo.Delete("WA");
            loaded = repo.GetByID("WA");
            Assert.IsNull(loaded);
        }


        //BodyType Tests
        [Test]
        public void CanLoadBodyType()
        {
            var repo = new BodyTypeRepositoryADO();
            var bodyTypes = repo.GetAll();

            Assert.AreEqual(4, bodyTypes.Count);
            Assert.AreEqual(1, bodyTypes[0].BodyTypeID);
            Assert.AreEqual("Car", bodyTypes[0].BodyTypeName);
        }

        [Test]
        public void CanLoadBodyTypeByID()
        {
            var repo = new BodyTypeRepositoryADO();
            var bodyType = repo.GetByID(1);


            Assert.IsNotNull(bodyType);
            Assert.AreEqual(bodyType.BodyTypeID, 1);
            Assert.AreEqual(bodyType.BodyTypeName, "Car");
        }

        [Test]
        public void NotFoundBodyTypeReturnsNull()
        {
            var repo = new BodyTypeRepositoryADO();
            var bodyType = repo.GetByID(675);

            Assert.IsNull(bodyType);
        }

        [Test]
        public void CanAddBodyType()
        {
            BodyType bodyType = new BodyType();
            var repo = new BodyTypeRepositoryADO();

            bodyType.BodyTypeName = "Hatchback";
            repo.Insert(bodyType);

            Assert.AreEqual(5, bodyType.BodyTypeID);
        }

        [Test]
        public void CanUpdateBodyType()
        {
            BodyType bodyType = new BodyType();
            var repo = new BodyTypeRepositoryADO();

            bodyType.BodyTypeName = "Hatchback";
            repo.Insert(bodyType);

            bodyType.BodyTypeName = "Coupe";
            repo.Update(bodyType);

            var updatedBodyType = repo.GetByID(5);
            Assert.AreEqual("Coupe", updatedBodyType.BodyTypeName);
        }

        [Test]
        public void CanDeleteBodyType()
        {
            BodyType bodyType = new BodyType();
            var repo = new BodyTypeRepositoryADO();

            bodyType.BodyTypeName = "Coupe";
            repo.Insert(bodyType);
            var loaded = repo.GetByID(5);
            Assert.IsNotNull(loaded);

            repo.Delete(5);
            loaded = repo.GetByID(5);
            Assert.IsNull(loaded);
        }


        //ExteriorColor
        [Test]
        public void CanLoadExteriorColor()
        {
            var repo = new ExteriorColorRepositoryADO();
            var exteriorColors = repo.GetAll();

            Assert.AreEqual(2, exteriorColors.Count);
            Assert.AreEqual(1, exteriorColors[0].ExteriorColorID);
            Assert.AreEqual("White", exteriorColors[0].ExteriorColorName);
            Assert.AreEqual("FFFFFF", exteriorColors[0].ExteriorColorHex);
            Assert.AreEqual(2, exteriorColors[1].ExteriorColorID);
            Assert.AreEqual("Black", exteriorColors[1].ExteriorColorName);
            Assert.AreEqual("000000", exteriorColors[1].ExteriorColorHex);
        }

        [Test]
        public void CanLoadExteriorColorByID()
        {
            var repo = new ExteriorColorRepositoryADO();
            var exteriorColor = repo.GetByID(1);


            Assert.IsNotNull(exteriorColor);
            Assert.IsNotNull(exteriorColor);
            Assert.AreEqual(1, exteriorColor.ExteriorColorID);
            Assert.AreEqual("White", exteriorColor.ExteriorColorName);
            Assert.AreEqual("FFFFFF", exteriorColor.ExteriorColorHex);
        }

        [Test]
        public void NotFoundExteriorColorReturnsNull()
        {
            var repo = new ExteriorColorRepositoryADO();
            var exteriorColor = repo.GetByID(44);

            Assert.IsNull(exteriorColor);
        }

        [Test]
        public void CanAddExteriorColor()
        {
            ExteriorColor exteriorColor = new ExteriorColor();
            var repo = new ExteriorColorRepositoryADO();

            exteriorColor.ExteriorColorName = "Red";
            exteriorColor.ExteriorColorHex = "FF0000";
            repo.Insert(exteriorColor);

            Assert.AreEqual(3, exteriorColor.ExteriorColorID);
        }

        [Test]
        public void CanUpdateExteriorColor()
        {
            ExteriorColor exteriorColor = new ExteriorColor();
            var repo = new ExteriorColorRepositoryADO();

            exteriorColor.ExteriorColorName = "Red";
            exteriorColor.ExteriorColorHex = "FF0000";
            repo.Insert(exteriorColor);

            exteriorColor.ExteriorColorName = "Blue";
            exteriorColor.ExteriorColorHex = "0000FF";
            repo.Update(exteriorColor);

            var updatedExteriorColor = repo.GetByID(3);
            Assert.AreEqual("Blue", updatedExteriorColor.ExteriorColorName);
            Assert.AreEqual("0000FF", updatedExteriorColor.ExteriorColorHex);
        }

        [Test]
        public void CanDeleteExteriorColor()
        {
            ExteriorColor exteriorColor = new ExteriorColor();
            var repo = new ExteriorColorRepositoryADO();

            exteriorColor.ExteriorColorName = "Red";
            exteriorColor.ExteriorColorHex = "FF0000";
            repo.Insert(exteriorColor);

            var loaded = repo.GetByID(3);
            Assert.IsNotNull(loaded);

            repo.Delete(3);
            loaded = repo.GetByID(3);
            Assert.IsNull(loaded);
        }


        //Interior Color tests
        //InteriorColor
        [Test]
        public void CanLoadInteriorColor()
        {
            var repo = new InteriorColorRepositoryADO();
            var interiorColors = repo.GetAll();

            Assert.AreEqual(2, interiorColors.Count);
            Assert.AreEqual(1, interiorColors[0].InteriorColorID);
            Assert.AreEqual("White", interiorColors[0].InteriorColorName);
            Assert.AreEqual("FFFFFF", interiorColors[0].InteriorColorHex);
            Assert.AreEqual(2, interiorColors[1].InteriorColorID);
            Assert.AreEqual("Black", interiorColors[1].InteriorColorName);
            Assert.AreEqual("000000", interiorColors[1].InteriorColorHex);
        }

        [Test]
        public void CanLoadInteriorColorByID()
        {
            var repo = new InteriorColorRepositoryADO();
            var interiorColor = repo.GetByID(1);


            Assert.IsNotNull(interiorColor);
            Assert.IsNotNull(interiorColor);
            Assert.AreEqual(1, interiorColor.InteriorColorID);
            Assert.AreEqual("White", interiorColor.InteriorColorName);
            Assert.AreEqual("FFFFFF", interiorColor.InteriorColorHex);
        }

        [Test]
        public void NotFoundInteriorColorReturnsNull()
        {
            var repo = new InteriorColorRepositoryADO();
            var interiorColor = repo.GetByID(44);

            Assert.IsNull(interiorColor);
        }

        [Test]
        public void CanAddInteriorColor()
        {
            InteriorColor interiorColor = new InteriorColor();
            var repo = new InteriorColorRepositoryADO();

            interiorColor.InteriorColorName = "Red";
            interiorColor.InteriorColorHex = "FF0000";
            repo.Insert(interiorColor);

            Assert.AreEqual(3, interiorColor.InteriorColorID);
        }

        [Test]
        public void CanUpdateInteriorColor()
        {
            InteriorColor interiorColor = new InteriorColor();
            var repo = new InteriorColorRepositoryADO();

            interiorColor.InteriorColorName = "Red";
            interiorColor.InteriorColorHex = "FF0000";
            repo.Insert(interiorColor);

            interiorColor.InteriorColorName = "Blue";
            interiorColor.InteriorColorHex = "0000FF";
            repo.Update(interiorColor);

            var updatedInteriorColor = repo.GetByID(3);
            Assert.AreEqual("Blue", updatedInteriorColor.InteriorColorName);
            Assert.AreEqual("0000FF", updatedInteriorColor.InteriorColorHex);
        }

        [Test]
        public void CanDeleteInteriorColor()
        {
            InteriorColor interiorColor = new InteriorColor();
            var repo = new InteriorColorRepositoryADO();

            interiorColor.InteriorColorName = "Red";
            interiorColor.InteriorColorHex = "FF0000";
            repo.Insert(interiorColor);

            var loaded = repo.GetByID(3);
            Assert.IsNotNull(loaded);

            repo.Delete(3);
            loaded = repo.GetByID(3);
            Assert.IsNull(loaded);
        }


        //Make Tests
        [Test]
        public void CanLoadMake()
        {
            var repo = new MakeRepositoryADO();
            var makes = repo.GetAll();

            Assert.AreEqual(2, makes.Count);
            Assert.AreEqual(1, makes[0].MakeID);
            Assert.AreEqual("Honda", makes[0].MakeName);
        }

        [Test]
        public void CanLoadMakeByID()
        {
            var repo = new MakeRepositoryADO();
            var make = repo.GetByID(1);


            Assert.IsNotNull(make);
            Assert.AreEqual(make.MakeID, 1);
            Assert.AreEqual(make.MakeName, "Honda");
        }

        [Test]
        public void NotFoundMakeReturnsNull()
        {
            var repo = new MakeRepositoryADO();
            var make = repo.GetByID(4635);

            Assert.IsNull(make);
        }

        [Test]
        public void CanAddMake()
        {
            Make make = new Make();
            var repo = new MakeRepositoryADO();

            make.MakeName = "Toyota";
            repo.Insert(make);

            Assert.AreEqual(3, make.MakeID);
        }

        [Test]
        public void CanUpdateMake()
        {
            Make make = new Make();
            var repo = new MakeRepositoryADO();

            make.MakeName = "Toyota";
            repo.Insert(make);

            make.MakeName = "Nissan";
            repo.Update(make);

            var updatedMake = repo.GetByID(3);
            Assert.AreEqual("Nissan", updatedMake.MakeName);
        }

        [Test]
        public void CanDeleteMake()
        {
            Make make = new Make();
            var repo = new MakeRepositoryADO();

            make.MakeName = "Nissan";
            repo.Insert(make);
            var loaded = repo.GetByID(3);
            Assert.IsNotNull(loaded);

            repo.Delete(3);
            loaded = repo.GetByID(3);
            Assert.IsNull(loaded);
        }



        //Model Tests
        [Test]
        public void CanLoadModel()
        {
            var repo = new ModelRepositoryADO();
            var models = repo.GetAll();

            Assert.AreEqual(3, models.Count);
            Assert.AreEqual(1, models[0].ModelID);
            Assert.AreEqual(1, models[0].MakeID);
            Assert.AreEqual("Civic", models[0].ModelName);
        }

        [Test]
        public void CanLoadModelByID()
        {
            var repo = new ModelRepositoryADO();
            var model = repo.GetByID(1);


            Assert.IsNotNull(model);
            Assert.AreEqual(model.ModelID, 1);
            Assert.AreEqual(model.MakeID, 1);
            Assert.AreEqual(model.ModelName, "Civic");
        }

        [Test]
        public void NotFoundModelReturnsNull()
        {
            var repo = new ModelRepositoryADO();
            var model = repo.GetByID(675);

            Assert.IsNull(model);
        }

        [Test]
        public void CanAddModel()
        {
            Model model = new Model();
            var repo = new ModelRepositoryADO();

            model.ModelName = "Explorer";
            model.MakeID = 2;
            repo.Insert(model);

            Assert.AreEqual(4, model.ModelID);
        }

        [Test]
        public void CanUpdateModel()
        {
            Model model = new Model();
            var repo = new ModelRepositoryADO();

            model.ModelName = "Explorer";
            model.MakeID = 2;
            repo.Insert(model);

            model.ModelName = "Mustang";
            repo.Update(model);

            var updatedModel = repo.GetByID(4);
            Assert.AreEqual("Mustang", updatedModel.ModelName);
        }

        [Test]
        public void CanDeleteModel()
        {
            Model model = new Model();
            var repo = new ModelRepositoryADO();

            model.ModelName = "Explorer";
            model.MakeID = 2;
            repo.Insert(model);
            var loaded = repo.GetByID(4);
            Assert.IsNotNull(loaded);

            repo.Delete(4);
            loaded = repo.GetByID(4);
            Assert.IsNull(loaded);
        }



        //Vehicle Tests
        [Test]
        public void CanLoadVehicles()
        {
            var repo = new VehicleRepositoryADO();
            var vehicles = repo.GetAll();

            Assert.AreEqual(5, vehicles.Count);
        }

        [Test]
        public void CanLoadVehicleByID()
        {
            var repo = new VehicleRepositoryADO();
            var vehicle = repo.GetByID("1G4HP54K62U137426");


            Assert.IsNotNull(vehicle);
            Assert.AreEqual("1G4HP54K62U137426", vehicle.VIN);
            Assert.AreEqual(1, vehicle.BodyTypeID);
            Assert.AreEqual(1, vehicle.ModelID);
            Assert.AreEqual(1, vehicle.InteriorColorID);
            Assert.AreEqual(1, vehicle.InteriorColorID);
            Assert.AreEqual(2001, vehicle.ModelYear);
            Assert.AreEqual(false, vehicle.IsNew);
            Assert.AreEqual(true, vehicle.IsManual);
            Assert.AreEqual(true, vehicle.IsFeatured);
            Assert.AreEqual(false, vehicle.IsSold);
            Assert.AreEqual(400000, vehicle.Mileage);
            Assert.AreEqual(100.00, vehicle.RetailPrice);
            Assert.AreEqual(90.00, vehicle.SalePrice);
            Assert.AreEqual(90.00, vehicle.PurchasePrice);
        }

        [Test]
        public void NotFoundVehicleReturnsNull()
        {
            var repo = new VehicleRepositoryADO();
            var vehicle = repo.GetByID("1D7HA16K04J132907");

            Assert.IsNull(vehicle);
        }

        [Test]
        public void CanAddVehicle()
        {
            Vehicle vehicle = new Vehicle();
            var repo = new VehicleRepositoryADO();

            vehicle.VIN = "1FMEU72E16UB64267"; 
            vehicle.BodyTypeID = 2;
            vehicle.ModelID = 1;
            vehicle.InteriorColorID = 1;
            vehicle.ExteriorColorID = 2;
            vehicle.ModelYear = 2004;
            vehicle.IsNew = true;
            vehicle.IsManual = true;
            vehicle.IsFeatured = true;
            vehicle.IsSold = true;
            vehicle.Mileage = 100;
            vehicle.RetailPrice = 50000;
            vehicle.SalePrice = 45000;
            vehicle.PurchasePrice = 42000;
            vehicle.VehicleDesc = "Sold test vehicle.";
            vehicle.ImageFileName = "test34.png";
            repo.Insert(vehicle);

            Assert.AreEqual(6, repo.GetAll().Count);

            vehicle.VIN = "JHLRE38547C045173";
            vehicle.BodyTypeID = 2;
            vehicle.ModelID = 1;
            vehicle.InteriorColorID = 1;
            vehicle.ExteriorColorID = 2;
            vehicle.ModelYear = 2004;
            vehicle.IsNew = true;
            vehicle.IsManual = true;
            vehicle.IsFeatured = true;
            vehicle.IsSold = false;
            vehicle.Mileage = 100;
            vehicle.RetailPrice = 50000;
            vehicle.VehicleDesc = "Sold test vehicle.";
            vehicle.ImageFileName = "test34.png";
            repo.Insert(vehicle);

            Assert.AreEqual(7, repo.GetAll().Count);
        }

        [Test]
        public void CanUpdateVehicle()
        {
            Vehicle vehicle = new Vehicle();
            var repo = new VehicleRepositoryADO();

            vehicle.VIN = "1FMEU72E16UB64267";
            vehicle.BodyTypeID = 2;
            vehicle.ModelID = 1;
            vehicle.InteriorColorID = 1;
            vehicle.ExteriorColorID = 2;
            vehicle.ModelYear = 2004;
            vehicle.IsNew = true;
            vehicle.IsManual = true;
            vehicle.IsFeatured = true;
            vehicle.IsSold = false;
            vehicle.Mileage = 100;
            vehicle.RetailPrice = 50000;
            vehicle.VehicleDesc = "Sold test vehicle.";
            vehicle.ImageFileName = "test34.png";
            repo.Insert(vehicle);

            vehicle.IsNew = false;
            vehicle.IsFeatured = false;
            vehicle.IsSold = true;
            vehicle.Mileage = 40000;
            vehicle.PurchasePrice = (decimal)30000.00;
            repo.Update(vehicle);

            var updatedVehicle = repo.GetByID("1FMEU72E16UB64267");
            Assert.AreEqual(false, updatedVehicle.IsNew);
            Assert.AreEqual(true, updatedVehicle.IsSold);
            Assert.AreEqual(false, updatedVehicle.IsFeatured);
            Assert.AreEqual(40000, updatedVehicle.Mileage);
            Assert.AreEqual(30000.00, updatedVehicle.PurchasePrice);

        }

        [Test]
        public void CanDeleteVehicle()
        {
            Vehicle vehicle = new Vehicle();
            var repo = new VehicleRepositoryADO();


            vehicle.VIN = "1FMEU72E16UB64267";
            vehicle.BodyTypeID = 2;
            vehicle.ModelID = 1;
            vehicle.InteriorColorID = 1;
            vehicle.ExteriorColorID = 2;
            vehicle.ModelYear = 2004;
            vehicle.IsNew = true;
            vehicle.IsManual = true;
            vehicle.IsFeatured = true;
            vehicle.IsSold = true;
            vehicle.Mileage = 100;
            vehicle.RetailPrice = 50000;
            vehicle.SalePrice = 45000;
            vehicle.PurchasePrice = 42000;
            vehicle.VehicleDesc = "Sold test vehicle.";
            vehicle.ImageFileName = "test34.png";
            repo.Insert(vehicle);

            var loaded = repo.GetByID("1FMEU72E16UB64267");
            Assert.IsNotNull(loaded);

            repo.Delete("1FMEU72E16UB64267");
            loaded = repo.GetByID("1FMEU72E16UB64267");
            Assert.IsNull(loaded);
        }

        //PurchaseType Tests
        [Test]
        public void CanLoadPurchaseType()
        {
            var repo = new PurchaseTypeRepositoryADO();
            var purchaseTypes = repo.GetAll();

            Assert.AreEqual(3, purchaseTypes.Count);
            Assert.AreEqual(1, purchaseTypes[0].PurchaseTypeID);
            Assert.AreEqual("Bank Finance", purchaseTypes[0].PurchaseTypeName);
        }

        [Test]
        public void CanLoadPurchaseTypeByID()
        {
            var repo = new PurchaseTypeRepositoryADO();
            var purchaseType = repo.GetByID(1);


            Assert.IsNotNull(purchaseType);
            Assert.AreEqual(purchaseType.PurchaseTypeID, 1);
            Assert.AreEqual(purchaseType.PurchaseTypeName, "Bank Finance");
        }

        [Test]
        public void NotFoundPurchaseTypeReturnsNull()
        {
            var repo = new PurchaseTypeRepositoryADO();
            var purchaseType = repo.GetByID(675);

            Assert.IsNull(purchaseType);
        }

        [Test]
        public void CanAddPurchaseType()
        {
            PurchaseType purchaseType = new PurchaseType();
            var repo = new PurchaseTypeRepositoryADO();

            purchaseType.PurchaseTypeName = "Donation";
            repo.Insert(purchaseType);

            Assert.AreEqual(4, purchaseType.PurchaseTypeID);
        }

        [Test]
        public void CanUpdatePurchaseType()
        {
            PurchaseType purchaseType = new PurchaseType();
            var repo = new PurchaseTypeRepositoryADO();

            purchaseType.PurchaseTypeName = "Donation";
            repo.Insert(purchaseType);

            purchaseType.PurchaseTypeName = "Giveaway";
            repo.Update(purchaseType);

            var updatedPurchaseType = repo.GetByID(4);
            Assert.AreEqual("Giveaway", updatedPurchaseType.PurchaseTypeName);
        }

        [Test]
        public void CanDeletePurchaseType()
        {
            PurchaseType purchaseType = new PurchaseType();
            var repo = new PurchaseTypeRepositoryADO();

            purchaseType.PurchaseTypeName = "Donation";
            repo.Insert(purchaseType);
            var loaded = repo.GetByID(4);
            Assert.IsNotNull(loaded);

            repo.Delete(4);
            loaded = repo.GetByID(4);
            Assert.IsNull(loaded);
        }

        //Purchase Tests
        [Test]
        public void CanLoadPurchase()
        {
            var repo = new PurchaseRepositoryADO();
            var purchases = repo.GetAll();

            Assert.AreEqual(1, purchases.Count);
            Assert.AreEqual(1, purchases[0].PurchaseID);
            Assert.AreEqual("5TFBV54178X070365", purchases[0].VIN);
            Assert.AreEqual(3, purchases[0].PurchaseTypeID);
            Assert.AreEqual(DateTime.Parse("1/1/2020"), Convert.ToDateTime(purchases[0].PurchaseDate));
            Assert.AreEqual("John", purchases[0].CustomerFirstName);
            Assert.AreEqual("Smith", purchases[0].CustomerLastName);
            Assert.AreEqual("1234 Main Street", purchases[0].StreetAddress);
            Assert.AreEqual("Minneapolis", purchases[0].City);
            Assert.AreEqual("MN", purchases[0].StateAbbr);
            Assert.AreEqual("55425", purchases[0].Zipcode);
        }

        [Test]
        public void CanLoadPurchaseByID()
        {
            var repo = new PurchaseRepositoryADO();
            var purchase = repo.GetByID(1);


            Assert.IsNotNull(purchase);
            Assert.AreEqual(1, purchase.PurchaseID);
            Assert.AreEqual("5TFBV54178X070365", purchase.VIN);
            Assert.AreEqual(3, purchase.PurchaseTypeID);
            Assert.AreEqual(DateTime.Parse("1/1/2020"), Convert.ToDateTime(purchase.PurchaseDate));
            Assert.AreEqual("John", purchase.CustomerFirstName);
            Assert.AreEqual("Smith", purchase.CustomerLastName);
            Assert.AreEqual("1234 Main Street", purchase.StreetAddress);
            Assert.AreEqual("Minneapolis", purchase.City);
            Assert.AreEqual("MN", purchase.StateAbbr);
            Assert.AreEqual("55425", purchase.Zipcode);
        }

        [Test]
        public void NotFoundPurchaseReturnsNull()
        {
            var repo = new PurchaseRepositoryADO();
            var purchase = repo.GetByID(675);

            Assert.IsNull(purchase);
        }

        [Test]
        public void CanAddPurchase()
        {
            Purchase purchase = new Purchase();
            var repo = new PurchaseRepositoryADO();

            purchase.VIN = "5TFBV54178X070365";
            purchase.PurchaseTypeID = 2;
            purchase.PurchaseDate = DateTime.Today;
            purchase.CustomerFirstName = "Jane";
            purchase.CustomerLastName = "Doe";
            purchase.StreetAddress = "123 Abc Ave";
            purchase.City = "St Paul";
            purchase.StateAbbr = "MN";
            purchase.Zipcode = "12345";
            repo.Insert(purchase);

            Assert.AreEqual(2, purchase.PurchaseID);
        }

        [Test]
        public void CanUpdatePurchase()
        {
            Purchase purchase = new Purchase();
            var repo = new PurchaseRepositoryADO();

            purchase.VIN = "5TFBV54178X070365";
            purchase.PurchaseTypeID = 2;
            purchase.PurchaseDate = DateTime.Today;
            purchase.CustomerFirstName = "Jane";
            purchase.CustomerLastName = "Doe";
            purchase.StreetAddress = "123 Abc Ave";
            purchase.City = "St Paul";
            purchase.StateAbbr = "MN";
            purchase.Zipcode = "12345";
            repo.Insert(purchase);

            purchase.CustomerFirstName = "Susan";
            purchase.CustomerLastName = "Smith";
            repo.Update(purchase);

            var updatedPurchase = repo.GetByID(2);
            Assert.AreEqual("Susan", updatedPurchase.CustomerFirstName);
            Assert.AreEqual("Smith", updatedPurchase.CustomerLastName);
        }

        [Test]
        public void CanDeletePurchase()
        {
            Purchase purchase = new Purchase();
            var repo = new PurchaseRepositoryADO();

            purchase.VIN = "5TFBV54178X070365";
            purchase.PurchaseTypeID = 2;
            purchase.PurchaseDate = DateTime.Today;
            purchase.CustomerFirstName = "Jane";
            purchase.CustomerLastName = "Doe";
            purchase.StreetAddress = "123 Abc Ave";
            purchase.City = "St Paul";
            purchase.StateAbbr = "MN";
            purchase.Zipcode = "12345";
            repo.Insert(purchase);
            var loaded = repo.GetByID(2);
            Assert.IsNotNull(loaded);

            repo.Delete(2);
            loaded = repo.GetByID(2);
            Assert.IsNull(loaded);
        }

        //Special Tests
        [Test]
        public void CanLoadSpecial()
        {
            var repo = new SpecialRepositoryADO();
            var specials = repo.GetAll();

            Assert.AreEqual(2, specials.Count);
            Assert.AreEqual(1, specials[0].SpecialID);
            Assert.AreEqual("1FAFP42X62F177164", specials[0].VIN);
            Assert.AreEqual("FIRST SPECIAL!", specials[0].SpecialTitle);
            Assert.AreEqual("This is a test special, and the first ever for Guild Cards.", specials[0].SpecialDescription);
        }

        [Test]
        public void CanLoadSpecialByID()
        {
            var repo = new SpecialRepositoryADO();
            var special = repo.GetByID(1);

            Assert.IsNotNull(special);
            Assert.AreEqual(1, special.SpecialID);
            Assert.AreEqual("1FAFP42X62F177164", special.VIN);
            Assert.AreEqual("FIRST SPECIAL!", special.SpecialTitle);
            Assert.AreEqual("This is a test special, and the first ever for Guild Cards.", special.SpecialDescription);
        }

        [Test]
        public void NotFoundSpecialReturnsNull()
        {
            var repo = new SpecialRepositoryADO();
            var special = repo.GetByID(675);

            Assert.IsNull(special);
        }

        [Test]
        public void CanAddSpecial()
        {
            Special special = new Special();
            var repo = new SpecialRepositoryADO();

            special.VIN = "5TFBV54178X070365";
            special.SpecialTitle = "Addin";
            special.SpecialDescription = "new desc";
            repo.Insert(special);

            Assert.AreEqual(3, special.SpecialID);
        }

        [Test]
        public void CanUpdateSpecial()
        {
            Special special = new Special();
            var repo = new SpecialRepositoryADO();

            special.VIN = "5TFBV54178X070365";
            special.SpecialTitle = "Addin";
            special.SpecialDescription = "new desc";
            repo.Insert(special);

            special.VIN = "1G4HP54K62U137426";
            special.SpecialTitle = "Addin 2";
            special.SpecialDescription = "new desc updated";
            repo.Update(special);

            var updatedSpecial = repo.GetByID(3);
            Assert.AreEqual("1G4HP54K62U137426", updatedSpecial.VIN);
            Assert.AreEqual("Addin 2", updatedSpecial.SpecialTitle);
            Assert.AreEqual("new desc updated", updatedSpecial.SpecialDescription);
        }

        [Test]
        public void CanDeleteSpecial()
        {
            Special special = new Special();
            var repo = new SpecialRepositoryADO();

            special.VIN = "5TFBV54178X070365";
            special.SpecialTitle = "Addin";
            special.SpecialDescription = "new desc";
            repo.Insert(special);
            var loaded = repo.GetByID(2);
            Assert.IsNotNull(loaded);

            repo.Delete(2);
            loaded = repo.GetByID(2);
            Assert.IsNull(loaded);
        }

        [Test]
        public void CanLoadFeaturedVehicles()
        {
            var repo = new VehicleRepositoryADO();
            List<FeaturedVehicle> featuredVehicles = repo.GetFeatured().ToList();

            Assert.AreEqual(5, featuredVehicles.Count());
            Assert.AreEqual("5TFBV54178X070365", featuredVehicles[0].VIN);
            Assert.AreEqual(2020, featuredVehicles[0].ModelYear);
            Assert.AreEqual("Honda", featuredVehicles[0].MakeName);
            Assert.AreEqual("Accord", featuredVehicles[0].ModelName);
            Assert.AreEqual(65000.00, featuredVehicles[0].RetailPrice);
            Assert.AreEqual(60000.00, featuredVehicles[0].SalePrice);
            Assert.AreEqual("placeholder.png", featuredVehicles[0].ImageFileName);
        }


        //Contact Tests
        [Test]
        public void CanLoadContacts()
        {
            var repo = new ContactRepositoryADO();
            var contacts = repo.GetAll();

            Assert.AreEqual(2, contacts.Count);
            Assert.AreEqual(1, contacts[0].ContactID);
            Assert.AreEqual("Johnny Test", contacts[0].ContactName);
            Assert.AreEqual("jt@messages.com", contacts[0].ContactEmail);
            Assert.AreEqual("7635551234", contacts[0].ContactPhone);
            Assert.AreEqual("Please call me.", contacts[0].ContactMessage);
        }

        [Test]
        public void CanLoadContactByID()
        {
            var repo = new ContactRepositoryADO();
            var contact = repo.GetByID(1);

            Assert.IsNotNull(contact);
            Assert.AreEqual(1, contact.ContactID);
            Assert.AreEqual("Johnny Test", contact.ContactName);
            Assert.AreEqual("jt@messages.com", contact.ContactEmail);
            Assert.AreEqual("7635551234", contact.ContactPhone);
            Assert.AreEqual("Please call me.", contact.ContactMessage);
        }

        [Test]
        public void NotFoundContactReturnsNull()
        {
            var repo = new ContactRepositoryADO();
            var contact = repo.GetByID(675);

            Assert.IsNull(contact);
        }

        [Test]
        public void CanAddContact()
        {
            Contact contact = new Contact();
            var repo = new ContactRepositoryADO();

            contact.ContactName = "Alpha Bravo";
            contact.ContactEmail = "alphabravo@mail.com";
            contact.ContactPhone = "5551234";
            contact.ContactMessage = "email me";
            repo.Insert(contact);

            Assert.AreEqual(3, contact.ContactID);
        }

        [Test]
        public void CanDeleteContact()
        {
            Contact contact = new Contact();
            var repo = new ContactRepositoryADO();

            contact.ContactName = "Alpha Bravo";
            contact.ContactEmail = "alphabravo@mail.com";
            contact.ContactPhone = "5551234";
            contact.ContactMessage = "email me";
            repo.Insert(contact);
            var loaded = repo.GetByID(3);
            Assert.IsNotNull(loaded);

            repo.Delete(3);
            loaded = repo.GetByID(3);
            Assert.IsNull(loaded);
        }

        [Test]
        public void CanSearchOnMinPrice()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new VehicleSearchParameters { MinPrice = 110M });

            Assert.AreEqual(4, found.Count());
        }

        [Test]
        public void CanSearchOnMaxPrice()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new VehicleSearchParameters { MaxPrice = 200M });

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanSearchOnMaxYear()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new VehicleSearchParameters { MaxYear = 2014 });

            Assert.AreEqual(3, found.Count());
        }

        [Test]
        public void CanSearchOnMinYear()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new VehicleSearchParameters { MinYear = 2014 });

            Assert.AreEqual(2, found.Count());
        }

        [Test]
        [TestCase("Ford", 1)]
        [TestCase("Honda", 4)]
        [TestCase("Civic", 3)]
        [TestCase("2001", 1)]
        public void CanQuickSearch(string text, int count)
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new VehicleSearchParameters { QuickSearch = text });

            Assert.AreEqual(count, found.Count());
        }
    }
}
