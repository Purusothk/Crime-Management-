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
    internal class VictimsImpl:IVictims
    {
        private readonly string connectionString;

        public VictimsImpl(string dbConnectionString)
        {
            connectionString = dbConnectionString ?? throw new ArgumentNullException(nameof(dbConnectionString));
        }


        public VictimsImpl()
        {
            connectionString = DbConnectionUtil.GetConnString();
        }

        public bool CreateVictim(Victims  victim)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Victims (VictimID, FirstName, LastName, DateOfBirth, Gender, ContactInformation) VALUES (@VictimID, @FirstName, @LastName, @DateOfBirth, @Gender, @ContactInformation)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VictimID", victim.VictimID);
                    cmd.Parameters.AddWithValue("@FirstName", victim.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", victim.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", victim.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", victim.Gender);
                    cmd.Parameters.AddWithValue("@ContactInformation", victim.ContactInformation);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error creating victim: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public List<Victims> GetVictims()
        {
            List<Victims> victimsList = new List<Victims>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Victims";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var victim = new Victims 
                        {
                            VictimID = (int)reader["VictimID"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DateOfBirth = reader["DateOfBirth"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            ContactInformation = reader["ContactInformation"].ToString()
                        };
                        victimsList.Add(victim);
                    }
                }
            }

            return victimsList;
        }

        public bool UpdateVictim(Victims victim)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Victims SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, Gender = @Gender, ContactInformation = @ContactInformation WHERE VictimID = @VictimID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VictimID", victim.VictimID);
                    cmd.Parameters.AddWithValue("@FirstName", victim.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", victim.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", victim.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", victim.Gender);
                    cmd.Parameters.AddWithValue("@ContactInformation", victim.ContactInformation);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error updating victim: " + ex.Message);
                        return false;
                    }
                }
            }
        }


        public bool DeleteVictim(int victimID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Victims WHERE VictimID = @VictimID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VictimID", victimID);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error deleting victim: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
