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
    public class ExteriorColorRepositoryADO : IExteriorColorRepository
    {

        public List<ExteriorColor> GetAll()
        {
            List<ExteriorColor> exteriorColors = new List<ExteriorColor>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ExteriorColor currentRow = new ExteriorColor();
                        currentRow.ExteriorColorID = (int)dr["ExteriorColorID"];
                        currentRow.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        currentRow.ExteriorColorHex = dr["ExteriorColorHex"].ToString();
                        exteriorColors.Add(currentRow);
                    }
                }
            }
            return exteriorColors;
        }

        public ExteriorColor GetByID(int exteriorColorID)
        {
            ExteriorColor exteriorColor = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ExteriorColorID", exteriorColorID);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        exteriorColor = new ExteriorColor();
                        exteriorColor.ExteriorColorID = (int)dr["ExteriorColorID"];
                        exteriorColor.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        exteriorColor.ExteriorColorHex = dr["ExteriorColorHex"].ToString();
                    }
                }
            }
            return exteriorColor;
        }

        public void Insert(ExteriorColor exteriorColor)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ExteriorColorID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@ExteriorColorName", exteriorColor.ExteriorColorName);
                cmd.Parameters.AddWithValue("@ExteriorColorHex", exteriorColor.ExteriorColorHex);
                cn.Open();
                cmd.ExecuteNonQuery();
                exteriorColor.ExteriorColorID = (int)param.Value;
            }
        }

        public void Update(ExteriorColor exteriorColor)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ExteriorColorID", exteriorColor.ExteriorColorID);
                cmd.Parameters.AddWithValue("@ExteriorColorName", exteriorColor.ExteriorColorName);
                cmd.Parameters.AddWithValue("@ExteriorColorHex", exteriorColor.ExteriorColorHex);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int exteriorColorID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ExteriorColorID", exteriorColorID);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
