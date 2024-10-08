using Crime_Report_Managenent.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.Repositary.Interfaces
{
    public interface IIncidents
    {
        bool CreateIncident(Incidents incident);
        void GetAllIncidents();
        List<Incidents> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);
        bool UpdateIncident(Incidents incident);
        Incidents GetIncidentById(int indidentid);


    }
}
