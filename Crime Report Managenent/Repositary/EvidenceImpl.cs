using ConsoleTables;
using Crime_Report.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crime_Report_Managenent.models;
using System.Collections.Generic;
using Crime_Report_Managenent.Repositary.Interfaces;

namespace Crime_Report_Managenent.Repositary
{
    public  class EvidenceImpl :IEvidence
    {
        private string connectionString;

        // Constructor using DbConnectionUtil to get the connection string
        public EvidenceImpl()
        {
            connectionString = DbConnectionUtil.GetConnString(); // Get connection string from utility class
        }

        public bool CreateEvidence(Evidence evidence)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Evidence (Description, LocationFound, IncidentID) " +
                               "VALUES (@Description, @LocationFound, @IncidentID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Description", evidence.Description);
                    cmd.Parameters.AddWithValue("@LocationFound", evidence.LocationFound);
                    cmd.Parameters.AddWithValue("@IncidentID", evidence.IncidentID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if rows were affected, false otherwise
                }
            }
        }


        public Evidence GetEvidenceById(int evidenceId)
        {
            Evidence evidence = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Evidence WHERE EvidenceID = @EvidenceID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EvidenceID", evidenceId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            evidence = new Evidence
                            {
                                EvidenceID = (int)reader["EvidenceID"],
                                Description = reader["Description"].ToString(),
                                LocationFound = reader["LocationFound"].ToString(),
                                IncidentID = (int)reader["IncidentID"]
                            };
                        }
                    }
                }
            }

            return evidence;
        }

        public bool UpdateEvidence(Evidence evidence)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Evidence SET Description = @Description, LocationFound = @LocationFound, " +
                               "IncidentID = @IncidentID WHERE EvidenceID = @EvidenceID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Description", evidence.Description);
                    cmd.Parameters.AddWithValue("@LocationFound", evidence.LocationFound);
                    cmd.Parameters.AddWithValue("@IncidentID", evidence.IncidentID);
                    cmd.Parameters.AddWithValue("@EvidenceID", evidence.EvidenceID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if the update was successful
                }
            }
        }

        public bool DeleteEvidence(int evidenceId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Evidence WHERE EvidenceID = @EvidenceID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EvidenceID", evidenceId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if the deletion was successful
                }
            }
        }

        public List<Evidence> GetAllEvidence()
        {
            List<Evidence> evidenceList = new List<Evidence>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();  // Open connection to the database
                    string query = "SELECT * FROM Evidence";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Create a ConsoleTable to store the data
                            var table = new ConsoleTable("EvidenceID", "Description", "LocationFound", "IncidentID");

                            while (reader.Read())
                            {
                                // Create an Evidence object and populate its properties
                                Evidence evidence = new Evidence
                                {
                                    EvidenceID = (int)reader["EvidenceID"],
                                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                                    LocationFound = reader["LocationFound"] != DBNull.Value ? reader["LocationFound"].ToString() : string.Empty,
                                    IncidentID = (int)reader["IncidentID"]
                                };

                                // Add the evidence object to the list
                                evidenceList.Add(evidence);

                                // Add the row to the table
                                table.AddRow(evidence.EvidenceID, evidence.Description, evidence.LocationFound, evidence.IncidentID);
                            }

                            // Write the table to the console
                            table.Write();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while fetching evidence data: " + ex.Message);
                // Optionally, log the error or rethrow it based on your requirement
            }

            return evidenceList;
        }
    }
}
