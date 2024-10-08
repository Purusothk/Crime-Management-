using Crime_Report.Utility;
using Crime_Report_Managenent.models;
using Crime_Report_Managenent.Repositary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.Repositary
{
    internal class OfficersImpl : IOfficers
    {
        private string connectionString;

        // Constructor using DbConnectionUtil to get the connection string
        public OfficersImpl()
        {
            connectionString = DbConnectionUtil.GetConnString(); // Get connection string from utility class
        }

        // Method to create an officer
        public bool CreateOfficer(Officers officer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Officers (FirstName, LastName, BadgeNumber, Rank, ContactInfo, AgencyID) " +
                               "VALUES (@FirstName, @LastName, @BadgeNumber, @Rank, @ContactInfo, @AgencyID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", officer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", officer.LastName);
                    cmd.Parameters.AddWithValue("@BadgeNumber", officer.BadgeNumber);
                    cmd.Parameters.AddWithValue("@Rank", officer.Rank);
                    cmd.Parameters.AddWithValue("@ContactInfo", officer.ContactInfo);
                    cmd.Parameters.AddWithValue("@AgencyID", officer.AgencyID);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        // Method to retrieve an officer by their ID
        public Officers GetOfficer(int officerID)
        {
            Officers officer = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Officers WHERE OfficerID = @OfficerID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OfficerID", officerID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            officer = new Officers
                            {
                                OfficerID = (int)reader["OfficerID"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                BadgeNumber = reader["BadgeNumber"].ToString(),
                                Rank = reader["Rank"].ToString(),
                                ContactInfo = reader["ContactInfo"].ToString(),
                                AgencyID = (int)reader["AgencyID"]
                            };
                        }
                    }
                }
            }

            return officer;
        }

        // Method to update an officer's details
        public bool UpdateOfficer(Officers officer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Officers SET FirstName = @FirstName, LastName = @LastName, BadgeNumber = @BadgeNumber, " +
                               "Rank = @Rank, ContactInfo = @ContactInfo, AgencyID = @AgencyID WHERE OfficerID = @OfficerID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", officer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", officer.LastName);
                    cmd.Parameters.AddWithValue("@BadgeNumber", officer.BadgeNumber);
                    cmd.Parameters.AddWithValue("@Rank", officer.Rank);
                    cmd.Parameters.AddWithValue("@ContactInfo", officer.ContactInfo);
                    cmd.Parameters.AddWithValue("@AgencyID", officer.AgencyID);
                    cmd.Parameters.AddWithValue("@OfficerID", officer.OfficerID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Method to delete an officer
        public bool DeleteOfficer(int officerID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Officers WHERE OfficerID = @OfficerID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OfficerID", officerID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Optional: Method to retrieve all officers
        public List<Officers> GetAllOfficers()
        {
            List<Officers> officerList = new List<Officers>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT OfficerID, FirstName, LastName, BadgeNumber, Rank, ContactInfo, AgencyID FROM Officers";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Officers officer = new Officers
                            {
                                OfficerID = (int)reader["OfficerID"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                BadgeNumber = reader["BadgeNumber"].ToString(),
                                Rank = reader["Rank"].ToString(),
                                ContactInfo = reader["ContactInfo"] != DBNull.Value ? reader["ContactInfo"].ToString() : string.Empty,
                                AgencyID = (int)reader["AgencyID"]
                            };
                            officerList.Add(officer);
                        }
                    }
                }
            }

            return officerList;
        }
    }
}