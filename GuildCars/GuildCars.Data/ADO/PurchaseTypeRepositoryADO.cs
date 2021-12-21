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
    public class PurchaseTypeRepositoryADO : IPurchaseTypeRepository
    {

        public List<PurchaseType> GetAll()
        {
            List<PurchaseType> purchaseTypes = new List<PurchaseType>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypeSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseType currentRow = new PurchaseType();
                        currentRow.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                        currentRow.PurchaseTypeName = dr["PurchaseTypeName"].ToString();
                        purchaseTypes.Add(currentRow);
                    }
                }
            }
            return purchaseTypes;
        }

        public PurchaseType GetByID(int purchaseTypeID)
        {
            PurchaseType purchaseType = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypeSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PurchaseTypeID", purchaseTypeID);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        purchaseType = new PurchaseType();
                        purchaseType.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                        purchaseType.PurchaseTypeName = dr["PurchaseTypeName"].ToString();
                    }
                }
            }
            return purchaseType;
        }

        public void Insert(PurchaseType purchaseType)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@PurchaseTypeID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@PurchaseTypeName", purchaseType.PurchaseTypeName);
                cn.Open();
                cmd.ExecuteNonQuery();
                purchaseType.PurchaseTypeID = (int)param.Value;
            }
        }

        public void Update(PurchaseType purchaseType)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypeUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PurchaseTypeID", purchaseType.PurchaseTypeID);
                cmd.Parameters.AddWithValue("@PurchaseTypeName", purchaseType.PurchaseTypeName);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int purchaseTypeID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypeDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PurchaseTypeID", purchaseTypeID);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
