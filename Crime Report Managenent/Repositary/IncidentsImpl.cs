using ConsoleTables;
using Crime_Report.Utility;
using Crime_Report_Managenent.models;
using System.Data.SqlClient;
using Crime_Report_Managenent.Exceptions;
using Crime_Report_Managenent.Repositary.Interfaces;

namespace Crime_Report_Managenent.Repositary
{
    public class IncidentsImpl : IIncidents
    {
        private string connectionString;


        public IncidentsImpl()
        {
            connectionString = DbConnectionUtil.GetConnString();
        }



        public bool CreateIncident(Incidents incident)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Incidents (IncidentID, IncidentType, IncidentDate, Location, Description, Status) VALUES (@IncidentID, @IncidentType, @IncidentDate, @Location, @Description, @Status)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@IncidentID", incident.IncidentID);
                    cmd.Parameters.AddWithValue("@IncidentType", incident.IncidentType);
                    cmd.Parameters.AddWithValue("@IncidentDate", incident.IncidentDate != DateTime.MinValue? incident.IncidentDate : DateTime.Now);
                    cmd.Parameters.AddWithValue("@Location", incident.Location);
                    cmd.Parameters.AddWithValue("@Description", incident.Description);
                    cmd.Parameters.AddWithValue("@Status", incident.Status);

                    //return cmd.ExecuteNonQuery() > 0;
                    try
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch {
                        Console.WriteLine($"Error: Incident with ID {incident.IncidentID} already exists.");
                        return false;
                    }
                }
            }
        }

        public void GetAllIncidents()
        {
            List<Incidents> incidentList = new List<Incidents>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT IncidentID, IncidentType, IncidentDate, Location, Description, Status FROM Incidents";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Incidents incident = new Incidents
                        {
                            IncidentID = reader.GetInt32(0),
                            IncidentType = reader.GetString(1),
                            IncidentDate = reader.GetDateTime(2),
                            Location = reader.GetString(3),
                            Description = reader.GetString(4),
                            Status = reader.GetString(5)
                        };
                        incidentList.Add(incident);
                    }
                }
            }

            // Display results in a console table
            var table = new ConsoleTable("Incident ID", "Incident Type", "Incident Date", "Location", "Description", "Status");

            foreach (var incident in incidentList)
            {
                table.AddRow(incident.IncidentID, incident.IncidentType, incident.IncidentDate, incident.Location, incident.Description, incident.Status);
            }

            table.Write();
            Console.WriteLine();
        
        }

        public List<Incidents> GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            List<Incidents> incidentList = new List<Incidents>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT IncidentID, IncidentType, IncidentDate, Location, Description, Status FROM Incidents WHERE IncidentDate BETWEEN @StartDate AND @EndDate";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Incidents incident = new Incidents
                        {
                            IncidentID = reader.GetInt32(0),
                            IncidentType = reader.GetString(1),
                            IncidentDate = reader.GetDateTime(2),
                            Location = reader.GetString(3),
                            Description = reader.GetString(4),
                            Status = reader.GetString(5)
                        };
                        incidentList.Add(incident);
                    }
                }
            }
            return incidentList;
        }

        public bool UpdateIncident(Incidents incident)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Incidents SET IncidentType = @IncidentType, IncidentDate = @IncidentDate, Location = @Location, Description = @Description, Status = @Status WHERE IncidentID = @IncidentID";
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@IncidentID", incident.IncidentID);
                    cmd.Parameters.AddWithValue("@IncidentType", incident.IncidentType);
                    cmd.Parameters.AddWithValue("@IncidentDate", incident.IncidentDate);
                    cmd.Parameters.AddWithValue("@Location", incident.Location);
                    cmd.Parameters.AddWithValue("@Description", incident.Description);
                    cmd.Parameters.AddWithValue("@Status", incident.Status);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public Incidents GetIncidentById(int incidentID)
    {
        Incidents incident = null;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT * FROM Incidents WHERE IncidentID = @IncidentID";
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@IncidentID", incidentID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    incident = new Incidents
                    {
                        IncidentID = reader.GetInt32(0),
                        IncidentType = reader.GetString(1),
                        IncidentDate = reader.GetDateTime(2),
                        Location = reader.GetString(3),
                        Description = reader.GetString(4),
                        Status = reader.GetString(5)
                    };
                }
                else
                {
                    // Throw custom exception when incident number is not found
                    throw new IncidentNumberNotFoundException($"Incident number {incidentID} does not exist.");
                }
            }
        }

        return incident;
    }
    }
}
 






