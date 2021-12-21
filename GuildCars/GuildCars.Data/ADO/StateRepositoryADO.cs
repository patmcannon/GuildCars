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
    public class StateRepositoryADO : IStateRepository
    {

        public List<State> GetAll()
        {
            List<State> states = new List<State>();
            using(var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StateSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        State currentRow = new State();
                        currentRow.StateAbbr = dr["StateAbbr"].ToString();
                        currentRow.StateName = dr["StateName"].ToString();
                        states.Add(currentRow);
                    }
                }
            }
            return states;
        }

        public State GetByID(string stateAbbr)
        {
            State state = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StateSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateAbbr", stateAbbr);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        state = new State();
                        state.StateAbbr = dr["StateAbbr"].ToString();
                        state.StateName = dr["StateName"].ToString();
                    }
                }
            }
            return state;
        }

        public void Insert(State state)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StateInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateAbbr", state.StateAbbr);
                cmd.Parameters.AddWithValue("@StateName", state.StateName);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(State state)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StateUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateAbbr", state.StateAbbr);
                cmd.Parameters.AddWithValue("@StateName", state.StateName);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string stateAbbr)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StateDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateAbbr", stateAbbr);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
