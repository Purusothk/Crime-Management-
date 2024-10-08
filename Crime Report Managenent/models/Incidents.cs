using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.models
{
    public class Incidents
    {
        public int IncidentID { get; set; }
        public string IncidentType { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? VictimID { get; set; }
        public int? SuspectID { get; set; }

        public override string ToString()
        {
            return $"ID: {IncidentID}, Type: {IncidentType}, Date: {IncidentDate.ToShortDateString()}, Location: {Location}, Status: {Status}";
        }
    }
}
