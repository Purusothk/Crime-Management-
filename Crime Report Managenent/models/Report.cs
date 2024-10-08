using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.models
{
    internal class Report
    {
        public int ReportID { get; set; }
        public int IncidentID { get; set; } // Foreign Key linking to Incidents
        public int ReportingOfficer { get; set; } // Foreign Key linking to Officers
        public string ReportDate { get; set; }
        public string ReportDetails { get; set; }
        public string Status { get; set; }

        // Default constructor
        public Report() { }

        // Parameterized constructor
        public Report(int reportID, int incidentID, int reportingOfficer, string reportDate, string reportDetails, string status)
        {
            ReportID = reportID;
            IncidentID = incidentID;
            ReportingOfficer = reportingOfficer;
            ReportDate = reportDate;
            ReportDetails = reportDetails;
            Status = status;
        }
        public override string ToString()
        {
            return $"ReportID : {ReportID}, IncidentID: {IncidentID}, ReportingOfficer: {ReportingOfficer}, ReportDate: {ReportDate} ReportDetails {ReportDetails}  Status{Status}";
        }
    }
}
