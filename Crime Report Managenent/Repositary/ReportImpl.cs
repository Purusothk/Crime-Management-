using ConsoleTables;
using Crime_Report.Utility;
using Crime_Report_Managenent.models;
using Crime_Report_Managenent.Repositary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Crime_Report_Managenent.Repositary
{
    internal class ReportImpl : IReport
    {
        private string connectionString;

        public ReportImpl()
        {
            connectionString = DbConnectionUtil.GetConnString();
        }

        public bool CreateReport(Report report)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Reports (ReportID, IncidentID, ReportingOfficer, ReportDate, ReportDetails, Status) VALUES (@ReportID, @IncidentID, @ReportingOfficer, @ReportDate, @ReportDetails, @Status)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReportID", report.ReportID);
                    cmd.Parameters.AddWithValue("@IncidentID", report.IncidentID);
                    cmd.Parameters.AddWithValue("@ReportingOfficer", report.ReportingOfficer);
                    cmd.Parameters.AddWithValue("@ReportDate", report.ReportDate);
                    cmd.Parameters.AddWithValue("@ReportDetails", report.ReportDetails);
                    cmd.Parameters.AddWithValue("@Status", report.Status);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error inserting report: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public Report GetReport(int reportID)
        {
            Report report = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Reports WHERE ReportID = @ReportID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReportID", reportID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            report = new Report
                            {
                                ReportID = (int)reader["ReportID"],
                                IncidentID = (int)reader["IncidentID"],
                                ReportingOfficer = (int)reader["ReportingOfficer"],
                                ReportDate = reader["ReportDate"].ToString(),
                                ReportDetails = reader["ReportDetails"].ToString(),
                                Status = reader["Status"].ToString()
                            };
                        }
                    }
                }
            }

            return report;
        }

        public bool UpdateReportStatus(int reportID, string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Reports SET Status = @Status WHERE ReportID = @ReportID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@ReportID", reportID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeleteReport(int reportID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Reports WHERE ReportID = @ReportID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReportID", reportID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public void GetAllReportsWithDetails()
        {
            var query = @"SELECT r.ReportID, r.ReportDate, r.ReportDetails, r.Status, 
                      i.IncidentType AS IncidentType, 
                      v.FirstName AS VictimName, 
                      o.FirstName + ' ' + o.LastName AS OfficerName
                      FROM Reports r
                      JOIN Incidents i ON r.IncidentID = i.IncidentID
                      JOIN Victims v ON i.VictimID = v.VictimID
                      JOIN Officers o ON r.ReportingOfficer = o.OfficerID";

            var results = new List<Dictionary<string, object>>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>
                        {
                            { "ReportID", reader["ReportID"] },
                            { "ReportDate", reader["ReportDate"] },
                            { "ReportDetails", reader["ReportDetails"] },
                            { "Status", reader["Status"] },
                            { "IncidentType", reader["IncidentType"] },
                            { "VictimName", reader["VictimName"] },
                            { "OfficerName", reader["OfficerName"] }
                        };
                            results.Add(row);
                        }
                    }
                }
            }

            // Display results in a console table
            var table = new ConsoleTable("Report ID", "Report Date", "Report Details", "Status", "Incident Type", "Victim Name", "Officer Name");

            foreach (var report in results)
            {
                table.AddRow(report["ReportID"], report["ReportDate"], report["ReportDetails"], report["Status"], report["IncidentType"], report["VictimName"], report["OfficerName"]);
            }

            table.Write();
            Console.WriteLine();
        }
    }
}