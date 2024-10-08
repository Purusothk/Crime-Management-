using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.models
{
    public class Evidence
    {
        public int EvidenceID { get; set; }
        public string Description { get; set; }
        public string LocationFound { get; set; }
        public int IncidentID { get; set; } // Foreign key to Incident

        public override string ToString()
        {
            return $"EvidenceID: {EvidenceID}, Description: {Description}, LocationFound: {LocationFound}, IncidentID: {IncidentID}";
        }

        // Default constructor
        public Evidence() { }

        // Parameterized constructor
        public Evidence(int evidenceID, string description, string locationFound, int incidentID)
        {
            EvidenceID = evidenceID;
            Description = description;
            LocationFound = locationFound;
            IncidentID = incidentID;
        }
         
    }
}
