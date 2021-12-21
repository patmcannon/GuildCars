using GuildCars.Data.Interfaces;
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
    public class PurchaseRepositoryADO : IPurchaseRepository
    {

        public List<Purchase> GetAll()
        {
            List<Purchase> purchases = new List<Purchase>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Purchase currentRow = new Purchase();
                        currentRow.PurchaseID = (int)dr["PurchaseID"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                        currentRow.PurchaseDate = Convert.ToDateTime(dr["PurchaseDate"]);
                        currentRow.CustomerFirstName = dr["CustomerFirstName"].ToString();
                        currentRow.CustomerLastName = dr["CustomerLastName"].ToString();
                        currentRow.CustomerEmail = dr["CustomerEmail"].ToString();
                        currentRow.CustomerPhone = dr["CustomerPhone"].ToString();
                        currentRow.StreetAddress = dr["StreetAddress"].ToString();
                        currentRow.City = dr["City"].ToString();
                        currentRow.StateAbbr = dr["StateAbbr"].ToString();
                        currentRow.Zipcode = dr["Zipcode"].ToString();
                        purchases.Add(currentRow);
                    }
                }
            }
            return purchases;
        }

        public Purchase GetByID(int purchaseID)
        {
            Purchase purchase = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PurchaseID", purchaseID);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        purchase = new Purchase();
                        purchase.PurchaseID = (int)dr["PurchaseID"];
                        purchase.VIN = dr["VIN"].ToString();
                        purchase.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                        purchase.PurchaseDate = Convert.ToDateTime(dr["PurchaseDate"]);
                        purchase.CustomerFirstName = dr["CustomerFirstName"].ToString();
                        purchase.CustomerLastName = dr["CustomerLastName"].ToString();
                        purchase.CustomerEmail = dr["CustomerEmail"].ToString();
                        purchase.CustomerPhone = dr["CustomerPhone"].ToString();
                        purchase.StreetAddress = dr["StreetAddress"].ToString();
                        purchase.City = dr["City"].ToString();
                        purchase.StateAbbr = dr["StateAbbr"].ToString();
                        purchase.Zipcode = dr["Zipcode"].ToString();
                    }
                }
            }
            return purchase;
        }

        public void Insert(Purchase purchase)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@PurchaseID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@PurchaseTypeID", purchase.PurchaseTypeID);
                cmd.Parameters.AddWithValue("@VIN", purchase.VIN);
                cmd.Parameters.AddWithValue("@PurchaseDate", purchase.PurchaseDate);
                cmd.Parameters.AddWithValue("@CustomerFirstName", purchase.CustomerFirstName);
                cmd.Parameters.AddWithValue("@CustomerLastName", purchase.CustomerLastName);
                cmd.Parameters.AddWithValue("@CustomerEmail", purchase.CustomerEmail);
                cmd.Parameters.AddWithValue("@CustomerPhone", purchase.CustomerPhone);
                cmd.Parameters.AddWithValue("@StreetAddress", purchase.StreetAddress);
                cmd.Parameters.AddWithValue("@City", purchase.City);
                cmd.Parameters.AddWithValue("@StateAbbr", purchase.StateAbbr);
                cmd.Parameters.AddWithValue("@Zipcode", purchase.Zipcode);
                cn.Open();
                cmd.ExecuteNonQuery();
                purchase.PurchaseID = (int)param.Value;
            }
        }

        public void Update(Purchase purchase)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PurchaseID", purchase.PurchaseID);
                cmd.Parameters.AddWithValue("@VIN", purchase.VIN);
                cmd.Parameters.AddWithValue("@PurchaseTypeID", purchase.PurchaseTypeID);
                cmd.Parameters.AddWithValue("@PurchaseDate", purchase.PurchaseDate);
                cmd.Parameters.AddWithValue("@CustomerFirstName", purchase.CustomerFirstName);
                cmd.Parameters.AddWithValue("@CustomerLastName", purchase.CustomerLastName);
                cmd.Parameters.AddWithValue("@CustomerEmail", purchase.CustomerEmail);
                cmd.Parameters.AddWithValue("@CustomerPhone", purchase.CustomerPhone);
                cmd.Parameters.AddWithValue("@StreetAddress", purchase.StreetAddress);
                cmd.Parameters.AddWithValue("@City", purchase.City);
                cmd.Parameters.AddWithValue("@StateAbbr", purchase.StateAbbr);
                cmd.Parameters.AddWithValue("@Zipcode", purchase.Zipcode);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int purchaseID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PurchaseID", purchaseID);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
