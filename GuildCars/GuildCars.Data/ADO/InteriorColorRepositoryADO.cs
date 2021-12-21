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
    public class InteriorColorRepositoryADO : IInteriorColorRepository
    {

        public List<InteriorColor> GetAll()
        {
            List<InteriorColor> interiorColors = new List<InteriorColor>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InteriorColor currentRow = new InteriorColor();
                        currentRow.InteriorColorID = (int)dr["InteriorColorID"];
                        currentRow.InteriorColorName = dr["InteriorColorName"].ToString();
                        currentRow.InteriorColorHex = dr["InteriorColorHex"].ToString();
                        interiorColors.Add(currentRow);
                    }
                }
            }
            return interiorColors;
        }

        public InteriorColor GetByID(int interiorColorID)
        {
            InteriorColor interiorColor = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InteriorColorID", interiorColorID);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        interiorColor = new InteriorColor();
                        interiorColor.InteriorColorID = (int)dr["InteriorColorID"];
                        interiorColor.InteriorColorName = dr["InteriorColorName"].ToString();
                        interiorColor.InteriorColorHex = dr["InteriorColorHex"].ToString();
                    }
                }
            }
            return interiorColor;
        }

        public void Insert(InteriorColor interiorColor)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@InteriorColorID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@InteriorColorName", interiorColor.InteriorColorName);
                cmd.Parameters.AddWithValue("@InteriorColorHex", interiorColor.InteriorColorHex);
                cn.Open();
                cmd.ExecuteNonQuery();
                interiorColor.InteriorColorID = (int)param.Value;
            }
        }

        public void Update(InteriorColor interiorColor)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InteriorColorID", interiorColor.InteriorColorID);
                cmd.Parameters.AddWithValue("@InteriorColorName", interiorColor.InteriorColorName);
                cmd.Parameters.AddWithValue("@InteriorColorHex", interiorColor.InteriorColorHex);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int interiorColorID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InteriorColorID", interiorColorID);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
