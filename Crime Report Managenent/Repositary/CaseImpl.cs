using Crime_Report.Utility;
using Crime_Report_Managenent.Exceptions;
using Crime_Report_Managenent.models;
using Crime_Report_Managenent.Repositary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Crime_Report_Managenent.Repositary
{
    public class CaseImpl : ICase
    {
        string connectionString = DbConnectionUtil.GetConnString();

        // Create a new case
        public Case CreateCase(string caseDescription, List<Incidents> incidents)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert the new case and output the generated CaseID
                    string insertCase = "INSERT INTO Cases (CaseDescription, CreationDate) OUTPUT INSERTED.CaseID VALUES (@CaseDescription, @CreationDate);";
                    SqlCommand cmd = new SqlCommand(insertCase, connection);
                    cmd.Parameters.AddWithValue("@CaseDescription", caseDescription);
                    cmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);

                    // Retrieve the new CaseID
                    int caseID = Convert.ToInt32(cmd.ExecuteScalar());

                    if (caseID == 0)
                    {
                        throw new Exception("Failed to retrieve CaseID. Insertion may have failed.");
                    }

                    // Insert associated incidents into CaseIncidents
                    foreach (Incidents incident in incidents)
                    {
                        string insertCaseIncident = "INSERT INTO CaseIncidents (CaseID, IncidentID) VALUES (@CaseID, @IncidentID)";
                        SqlCommand cmdIncident = new SqlCommand(insertCaseIncident, connection);
                        cmdIncident.Parameters.AddWithValue("@CaseID", caseID);
                        cmdIncident.Parameters.AddWithValue("@IncidentID", incident.IncidentID);
                        cmdIncident.ExecuteNonQuery(); // Insert each incident
                    }

                    // Return the newly created case object
                    return new Case
                    {
                        CaseID = caseID,
                        CaseDescription = caseDescription,
                        CreationDate = DateTime.Now,
                        AllIncident = incidents
                    };
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Error creating case: " + ex.Message, ex);
            }
        }






        // Retrieve a specific case by ID
        public Case GetCase(int caseId)
        {
            Case caseObj = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT CaseID, CaseDescription, CreationDate FROM Cases WHERE CaseID = @CaseID";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@CaseID", caseId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        caseObj = new Case
                        {
                            CaseID = reader.GetInt32(0),
                            CaseDescription = reader.GetString(1),
                            CreationDate = reader.GetDateTime(2)
                        };
                    }
                }
            }
            return caseObj;
        }

        // Update a case's description
        public bool UpdateCase(Case updatedCase)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Cases SET CaseDescription = @Description WHERE CaseID = @CaseID";
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@CaseID", updatedCase.CaseID);
                    cmd.Parameters.AddWithValue("@Description", updatedCase.CaseDescription);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Delete a case by its ID
        public bool DeleteCase(int caseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Cases WHERE CaseID = @CaseID";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@CaseID", caseId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Retrieve all cases
        public List<Case> GetAllCases()
        {
            List<Case> caseList = new List<Case>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT CaseID, CaseDescription, CreationDate FROM Cases";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Case caseObj = new Case
                        {
                            CaseID = reader.GetInt32(0),
                            CaseDescription = reader.GetString(1),
                            CreationDate = reader.GetDateTime(2)
                        };
                        caseList.Add(caseObj);
                    }
                }
            }
            return caseList;
        }

        // Method to add an incident to a case
        public bool AddIncidentToCase(int caseId, Incidents incident)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Incidents (CaseID, /* other incident fields */) VALUES (@CaseID, /* other parameters */)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@CaseID", caseId);
                    // Add other incident parameters here
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Method to add a victim to a case
        public bool AddVictimToCase(int caseId, Victims victim)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Victims (CaseID, Name, Address) VALUES (@CaseID, @Name, @Address)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@CaseID", caseId);
                    cmd.Parameters.AddWithValue("@Name", victim.Name);
                    cmd.Parameters.AddWithValue("@Address", victim.Address);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Method to add a suspect to a case
        public bool AddSuspectToCase(int caseId, Suspects suspect)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Suspects (CaseID, Name, LastKnownAddress) VALUES (@CaseID, @Name, @LastKnownAddress)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@CaseID", caseId);
                    cmd.Parameters.AddWithValue("@Name", suspect.Name);
                    cmd.Parameters.AddWithValue("@LastKnownAddress", suspect.LastKnownAddress);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        
    }
}
