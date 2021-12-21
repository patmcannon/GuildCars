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
    public class SpecialRepositoryADO : ISpecialRepository
    {

        public List<Special> GetAll()
        {
            List<Special> specials = new List<Special>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special currentRow = new Special();
                        currentRow.SpecialID = (int)dr["SpecialID"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.SpecialTitle = dr["SpecialTitle"].ToString();
                        currentRow.SpecialDescription = dr["SpecialDescription"].ToString();
                        specials.Add(currentRow);
                    }
                }
            }
            return specials;
        }

        public Special GetByID(int specialID)
        {
            Special special = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SpecialID", specialID);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        special = new Special();
                        special.SpecialID = (int)dr["SpecialID"];
                        special.VIN = dr["VIN"].ToString();
                        special.SpecialTitle = dr["SpecialTitle"].ToString();
                        special.SpecialDescription = dr["SpecialDescription"].ToString();
                    }
                }
            }
            return special;
        }

        public void Insert(Special special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@SpecialID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@VIN", special.VIN);
                cmd.Parameters.AddWithValue("@SpecialTitle", special.SpecialTitle);
                cmd.Parameters.AddWithValue("@SpecialDescription", special.SpecialDescription);
                cn.Open();
                cmd.ExecuteNonQuery();
                special.SpecialID = (int)param.Value;
            }
        }

        public void Update(Special special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SpecialID", special.SpecialID);
                cmd.Parameters.AddWithValue("@VIN", special.VIN);
                cmd.Parameters.AddWithValue("@SpecialTitle", special.SpecialTitle);
                cmd.Parameters.AddWithValue("@SpecialDescription", special.SpecialDescription);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int specialID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SpecialID", specialID);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
