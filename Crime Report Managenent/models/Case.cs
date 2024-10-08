using System;
using System.Collections.Generic;

namespace Crime_Report_Managenent.models
{
    public class Case
    {
        private DateTime now;

        public int CaseID { get; set; }
        public string CaseDescription { get; set; }
        public DateTime CreationDate { get; set; }

        public List<Incidents> AllIncident { get; set; }

        public Case()
        {
            AllIncident = new List<Incidents>();
            CreationDate = DateTime.Now;
        }

        public Case(int caseId, string? caseDescription, DateTime now)
        {
            CaseID = caseId;
            CaseDescription = caseDescription;
            this.now = now;
        }

        public override string ToString()
        {
            string incidentsDetails = string.Join("\n", AllIncident);
            return $"Case ID: {CaseID}, Description: {CaseDescription}, Creation Date: {CreationDate}, Incidents: \n{incidentsDetails}";
        }
    }
}
