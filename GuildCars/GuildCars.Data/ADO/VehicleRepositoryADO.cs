using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class VehicleRepositoryADO : IVehicleRepository
    {

        public List<Vehicle> GetAll()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.BodyTypeID = (int)dr["BodyTypeID"];
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.InteriorColorID = (int)dr["InteriorColorID"];
                        currentRow.ExteriorColorID = (int)dr["ExteriorColorID"];
                        currentRow.ModelYear = (int)dr["ModelYear"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.IsManual = (bool)dr["IsManual"];
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsSold = (bool)dr["IsSold"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.RetailPrice = (decimal)dr["RetailPrice"];
                        if (dr["SalePrice"] != DBNull.Value) { currentRow.SalePrice = (decimal)dr["SalePrice"]; }
                        if (dr["PurchasePrice"] != DBNull.Value) { currentRow.PurchasePrice = (decimal)dr["PurchasePrice"]; }
                        if (dr["VehicleDesc"] != DBNull.Value) { currentRow.VehicleDesc = dr["VehicleDesc"].ToString(); }
                        if (dr["ImageFileName"] != DBNull.Value) { currentRow.ImageFileName = dr["ImageFileName"].ToString(); }
                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public Vehicle GetByID(string vin)
        {
            Vehicle vehicle = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VIN", vin);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new Vehicle();
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.BodyTypeID = (int)dr["BodyTypeID"];
                        vehicle.ModelID = (int)dr["ModelID"];
                        vehicle.InteriorColorID = (int)dr["InteriorColorID"];
                        vehicle.ExteriorColorID = (int)dr["ExteriorColorID"];
                        vehicle.ModelYear = (int)dr["ModelYear"];
                        vehicle.IsNew = (bool)dr["IsNew"];
                        vehicle.IsManual = (bool)dr["IsManual"];
                        vehicle.IsFeatured = (bool)dr["IsFeatured"];
                        vehicle.IsSold = (bool)dr["IsSold"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.RetailPrice = (decimal)dr["RetailPrice"];
                        if (dr["SalePrice"] != DBNull.Value) { vehicle.SalePrice = (decimal)dr["SalePrice"]; }
                        if (dr["PurchasePrice"] != DBNull.Value) { vehicle.PurchasePrice = (decimal)dr["PurchasePrice"]; }
                        vehicle.VehicleDesc = dr["VehicleDesc"].ToString();
                        vehicle.ImageFileName = dr["ImageFileName"].ToString();
                    }
                }
            }
            return vehicle;
        }

        public void Insert(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@BodyTypeID", vehicle.BodyTypeID);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@InteriorColorID", vehicle.InteriorColorID);
                cmd.Parameters.AddWithValue("@ExteriorColorID", vehicle.ExteriorColorID);
                cmd.Parameters.AddWithValue("@ModelYear", vehicle.ModelYear);
                cmd.Parameters.AddWithValue("@IsNew", vehicle.IsNew);
                cmd.Parameters.AddWithValue("@IsManual", vehicle.IsManual);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);
                cmd.Parameters.AddWithValue("@IsSold", vehicle.IsSold);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@RetailPrice", vehicle.RetailPrice);
                cmd.Parameters.AddWithValue("@SalePrice", ((object)vehicle.SalePrice ?? DBNull.Value));
                cmd.Parameters.AddWithValue("@PurchasePrice", ((object)vehicle.PurchasePrice ?? DBNull.Value));
                cmd.Parameters.AddWithValue("@VehicleDesc", ((object)vehicle.VehicleDesc ?? DBNull.Value));
                cmd.Parameters.AddWithValue("@ImageFileName", ((object)vehicle.ImageFileName ?? DBNull.Value));
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@BodyTypeID", vehicle.BodyTypeID);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@InteriorColorID", vehicle.InteriorColorID);
                cmd.Parameters.AddWithValue("@ExteriorColorID", vehicle.ExteriorColorID);
                cmd.Parameters.AddWithValue("@ModelYear", vehicle.ModelYear);
                cmd.Parameters.AddWithValue("@IsNew", vehicle.IsNew);
                cmd.Parameters.AddWithValue("@IsManual", vehicle.IsManual);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);
                cmd.Parameters.AddWithValue("@IsSold", vehicle.IsSold);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@RetailPrice", vehicle.RetailPrice);
                cmd.Parameters.AddWithValue("@SalePrice", ((object)vehicle.SalePrice ?? DBNull.Value));
                cmd.Parameters.AddWithValue("@PurchasePrice", ((object)vehicle.PurchasePrice ?? DBNull.Value));
                cmd.Parameters.AddWithValue("@VehicleDesc", ((object)vehicle.VehicleDesc ?? DBNull.Value));
                cmd.Parameters.AddWithValue("@ImageFileName", ((object)vehicle.ImageFileName ?? DBNull.Value));
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string vin)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VIN", vin);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<FeaturedVehicle> GetFeatured()
        {
            List<FeaturedVehicle> featuredVehicles = new List<FeaturedVehicle>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectFeatured", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FeaturedVehicle currentRow = new FeaturedVehicle();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.ModelYear = (int)dr["ModelYear"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.RetailPrice = (decimal)dr["RetailPrice"];
                        if (dr["SalePrice"] != DBNull.Value) { currentRow.SalePrice = (decimal)dr["SalePrice"]; }
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        featuredVehicles.Add(currentRow);
                    }
                }
            }
            return featuredVehicles;
        }

        public List<VehicleDetail> GetByNewOrUsed(bool isNew)
        {
            List<VehicleDetail> vehicles = new List<VehicleDetail>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectByNewOrUsed", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IsNew", isNew);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleDetail currentRow = new VehicleDetail();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.BodyTypeName = dr["BodyTypeName"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.InteriorColorName = dr["InteriorColorName"].ToString();
                        currentRow.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        currentRow.ModelYear = (int)dr["ModelYear"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.IsManual = (bool)dr["IsManual"];
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsSold = (bool)dr["IsSold"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.RetailPrice = (decimal)dr["RetailPrice"];
                        if (dr["SalePrice"] != DBNull.Value) { currentRow.SalePrice = (decimal)dr["SalePrice"]; }
                        if (dr["PurchasePrice"] != DBNull.Value) { currentRow.PurchasePrice = (decimal)dr["PurchasePrice"]; }
                        currentRow.VehicleDesc = dr["VehicleDesc"].ToString();
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public VehicleDetail GetDetailByID(string vin)
        {
            VehicleDetail vehicle = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDetailSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VIN", vin);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new VehicleDetail();
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.BodyTypeName = dr["BodyTypeName"].ToString();
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.InteriorColorName = dr["InteriorColorName"].ToString();
                        vehicle.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        vehicle.ModelYear = (int)dr["ModelYear"];
                        vehicle.IsNew = (bool)dr["IsNew"];
                        vehicle.IsManual = (bool)dr["IsManual"];
                        vehicle.IsFeatured = (bool)dr["IsFeatured"];
                        vehicle.IsSold = (bool)dr["IsSold"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.RetailPrice = (decimal)dr["RetailPrice"];
                        if (dr["SalePrice"] != DBNull.Value) { vehicle.SalePrice = (decimal)dr["SalePrice"]; }
                        if (dr["PurchasePrice"] != DBNull.Value) { vehicle.PurchasePrice = (decimal)dr["PurchasePrice"]; }
                        vehicle.VehicleDesc = dr["VehicleDesc"].ToString();
                        vehicle.ImageFileName = dr["ImageFileName"].ToString();
                    }
                }
            }
            return vehicle;
        }

        public IEnumerable<VehicleDetail> Search(VehicleSearchParameters parameters)
        {
            List<VehicleDetail> vehicles = new List<VehicleDetail>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 12 Vehicle.VIN, BodyType.BodyTypeName, Make.MakeName, Model.ModelName," +
                    " InteriorColor.InteriorColorName, ExteriorColor.ExteriorColorName, ModelYear, IsNew, IsManual, IsFeatured, IsSold," +
                    " Mileage, RetailPrice, SalePrice, PurchasePrice, VehicleDesc, ImageFileName" +
                    " FROM Vehicle" +
                    " INNER JOIN BodyType ON BodyType.BodyTypeID = Vehicle.BodyTypeID" +
                    " INNER JOIN Model ON Model.ModelID = Vehicle.ModelID" +
                    " INNER JOIN Make ON Model.MakeID = Make.MakeID" +
                    " INNER JOIN InteriorColor ON InteriorColor.InteriorColorID = Vehicle.InteriorColorID" +
                    " INNER JOIN ExteriorColor ON ExteriorColor.ExteriorColorID = Vehicle.ExteriorColorID" +
                    " WHERE 1 = 1";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.MinPrice.HasValue)
                {
                    query += $" AND (RetailPrice >= @MinPrice OR SalePrice >= @MinPrice) ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }
                if (parameters.MaxPrice.HasValue)
                {
                    query += $" AND (RetailPrice <= @MaxPrice OR SalePrice <= @MaxPrice) ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }
                if (parameters.MinYear.HasValue)
                {
                    query += $" AND ModelYear >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear.Value);
                }
                if (parameters.MaxYear.HasValue)
                {
                    query += $" AND ModelYear <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear.Value);
                }
                if (!string.IsNullOrEmpty(parameters.QuickSearch))
                {
                    query += $" AND (Model.ModelName LIKE @QuickSearch OR Make.MakeName LIKE @QuickSearch OR Vehicle.ModelYear LIKE @QuickSearch)";
                    cmd.Parameters.AddWithValue("@QuickSearch", '%' + parameters.QuickSearch + '%');
                }
                if (parameters.IsNew.HasValue)
                {
                    query += $" AND Vehicle.IsNew = @IsNew";
                    cmd.Parameters.AddWithValue("@IsNew", parameters.IsNew);
                }
                cmd.CommandText = query;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleDetail currentRow = new VehicleDetail();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.BodyTypeName = dr["BodyTypeName"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.InteriorColorName = dr["InteriorColorName"].ToString();
                        currentRow.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        currentRow.ModelYear = (int)dr["ModelYear"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.IsManual = (bool)dr["IsManual"];
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsSold = (bool)dr["IsSold"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.RetailPrice = (decimal)dr["RetailPrice"];
                        if (dr["SalePrice"] != DBNull.Value) { currentRow.SalePrice = (decimal)dr["SalePrice"]; }
                        if (dr["PurchasePrice"] != DBNull.Value) { currentRow.PurchasePrice = (decimal)dr["PurchasePrice"]; }
                        currentRow.VehicleDesc = dr["VehicleDesc"].ToString();
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }
    }
}
