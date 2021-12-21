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
    public class ModelRepositoryADO : IModelRepository
    {

        public List<Model> GetAll()
        {
            List<Model> models = new List<Model>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        models.Add(currentRow);
                    }
                }
            }
            return models;
        }

        public Model GetByID(int modelID)
        {
            Model model = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ModelID", modelID);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        model = new Model();
                        model.ModelID = (int)dr["ModelID"];
                        model.MakeID = (int)dr["MakeID"];
                        model.ModelName = dr["ModelName"].ToString();
                    }
                }
            }
            return model;
        }

        public void Insert(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ModelID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@MakeID", model.MakeID);
                cn.Open();
                cmd.ExecuteNonQuery();
                model.ModelID = (int)param.Value;
            }
        }

        public void Update(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ModelID", model.ModelID);
                cmd.Parameters.AddWithValue("@MakeID", model.MakeID);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int modelID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ModelID", modelID);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
