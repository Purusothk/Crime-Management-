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
    internal class SuspectImpl : ISuspects
    {
        private string connectionString;

        // Constructor using DbConnectionUtil to get the connection string
        public SuspectImpl()
        {
            connectionString = DbConnectionUtil.GetConnString(); // Get connection string from utility class
        }

        // Method to retrieve all suspects
        public List<Suspects> GetAllSuspects()
        {
            List<Suspects> suspectList = new List<Suspects>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SuspectID, FirstName, LastName, DateOfBirth, Gender, ContactInformation FROM Suspects";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Suspects suspect = new Suspects(
                                (int)reader["SuspectID"],
                                reader["FirstName"].ToString(),
                                reader["LastName"].ToString(),
                                reader["DateOfBirth"].ToString(),
                                reader["Gender"].ToString(),
                                reader["ContactInformation"] != DBNull.Value ? reader["ContactInformation"].ToString() : string.Empty
                            );
                            suspectList.Add(suspect);
                        }
                    }
                }
            }

            return suspectList;
        }

        // Method to retrieve a specific suspect by ID
        public Suspects GetSuspectByID(int suspectID)
        {
            Suspects suspect = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SuspectID, FirstName, LastName, DateOfBirth, Gender, ContactInformation FROM Suspects WHERE SuspectID = @SuspectID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SuspectID", suspectID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            suspect = new Suspects(
                                (int)reader["SuspectID"],
                                reader["FirstName"].ToString(),
                                reader["LastName"].ToString(),
                                reader["DateOfBirth"].ToString(),
                                reader["Gender"].ToString(),
                                reader["ContactInformation"] != DBNull.Value ? reader["ContactInformation"].ToString() : string.Empty
                            );
                        }
                    }
                }
            }

            return suspect;
        }

        // Method to create a new suspect
        public bool CreateSuspect(Suspects suspect)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Suspects (FirstName, LastName, DateOfBirth, Gender, ContactInformation) " +
                               "VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @ContactInformation)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", suspect.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", suspect.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", suspect.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", suspect.Gender);
                    cmd.Parameters.AddWithValue("@ContactInformation", suspect.ContactInformation);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        // Method to update an existing suspect
        public bool UpdateSuspect(Suspects suspect)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Suspects SET FirstName = @FirstName, LastName = @LastName, " +
                               "DateOfBirth = @DateOfBirth, Gender = @Gender, ContactInformation = @ContactInformation " +
                               "WHERE SuspectID = @SuspectID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", suspect.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", suspect.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", suspect.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", suspect.Gender);
                    cmd.Parameters.AddWithValue("@ContactInformation", suspect.ContactInformation);
                    cmd.Parameters.AddWithValue("@SuspectID", suspect.SuspectID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Method to delete a suspect
        public bool DeleteSuspect(int suspectID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Suspects WHERE SuspectID = @SuspectID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SuspectID", suspectID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}