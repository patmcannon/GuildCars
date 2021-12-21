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
    public class BodyTypeRepositoryADO : IBodyTypeRepository
    {

        public List<BodyType> GetAll()
        {
            List<BodyType> bodyTypes = new List<BodyType>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyTypeSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyType currentRow = new BodyType();
                        currentRow.BodyTypeID = (int)dr["BodyTypeID"];
                        currentRow.BodyTypeName = dr["BodyTypeName"].ToString();

                        bodyTypes.Add(currentRow);
                    }

                }
            }
            return bodyTypes;
        }

        public BodyType GetByID(int bodyTypeID)
        {
            BodyType bodyType = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyTypeSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BodyTypeID", bodyTypeID);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        bodyType = new BodyType();
                        bodyType.BodyTypeID = (int)dr["BodyTypeID"];
                        bodyType.BodyTypeName = dr["BodyTypeName"].ToString();
                    }
                }
            }
            return bodyType;
        }

        public void Insert(BodyType bodyType)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyTypeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@BodyTypeID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@BodyTypeName", bodyType.BodyTypeName);
                cn.Open();
                cmd.ExecuteNonQuery();
                bodyType.BodyTypeID = (int)param.Value;
            }
        }

        public void Update(BodyType bodyType)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyTypeUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BodyTypeID", bodyType.BodyTypeID);
                cmd.Parameters.AddWithValue("@BodyTypeName", bodyType.BodyTypeName);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int bodyTypeID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyTypeDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BodyTypeID", bodyTypeID);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
