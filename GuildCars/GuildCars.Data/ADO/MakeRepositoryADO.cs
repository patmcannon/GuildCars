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
    public class MakeRepositoryADO : IMakeRepository
    {

        public List<Make> GetAll()
        {
            List<Make> makes = new List<Make>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make currentRow = new Make();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        makes.Add(currentRow);
                    }
                }
            }
            return makes;
        }

        public Make GetByID(int makeID)
        {
            Make make = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeID", makeID);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        make = new Make();
                        make.MakeID = (int)dr["MakeID"];
                        make.MakeName = dr["MakeName"].ToString();
                    }
                }
            }
            return make;
        }

        public void Insert(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@MakeID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                cn.Open();
                cmd.ExecuteNonQuery();
                make.MakeID = (int)param.Value;
            }
        }

        public void Update(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeID", make.MakeID);
                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int makeID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeID", makeID);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
