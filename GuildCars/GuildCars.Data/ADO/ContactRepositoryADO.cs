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
    public class ContactRepositoryADO : IContactRepository
    {

        public List<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Contact currentRow = new Contact();
                        currentRow.ContactID = (int)dr["ContactID"];
                        currentRow.ContactName = dr["ContactName"].ToString();
                        if (dr["ContactEmail"] != DBNull.Value)  currentRow.ContactEmail = dr["ContactEmail"].ToString();
                        if (dr["ContactPhone"] != DBNull.Value)  currentRow.ContactPhone = dr["ContactPhone"].ToString();
                        currentRow.ContactMessage = dr["ContactMessage"].ToString();
                        contacts.Add(currentRow);
                    }
                }
            }
            return contacts;
        }

        public Contact GetByID(int contactID)
        {
            Contact contact = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactID", contactID);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        contact = new Contact();
                        contact.ContactID = (int)dr["ContactID"];
                        contact.ContactName = dr["ContactName"].ToString();
                        if (dr["ContactEmail"] != DBNull.Value) contact.ContactEmail = dr["ContactEmail"].ToString();
                        if (dr["ContactPhone"] != DBNull.Value) contact.ContactPhone = dr["ContactPhone"].ToString();
                        contact.ContactMessage = dr["ContactMessage"].ToString();
                    }
                }
            }
            return contact;
        }

        public void Insert(Contact contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ContactID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@ContactName", contact.ContactName);
                if (contact.ContactEmail != null)
                {
                    cmd.Parameters.AddWithValue("@ContactEmail", contact.ContactEmail);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ContactEmail", DBNull.Value);
                }
                if (contact.ContactPhone != null)
                {
                    cmd.Parameters.AddWithValue("@ContactPhone", contact.ContactPhone);
                } else
                {
                    cmd.Parameters.AddWithValue("@ContactPhone", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@ContactMessage", contact.ContactMessage);
                cn.Open();
                cmd.ExecuteNonQuery();
                contact.ContactID = (int)param.Value;
            }
        }
        public void Delete(int contactID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactID", contactID);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
