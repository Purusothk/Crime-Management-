using Crime_Report_Managenent.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.Repositary.Interfaces
{
    internal interface IReport
    {
        bool CreateReport(Report report);
        Report GetReport(int reportID);
        void GetAllReportsWithDetails();
        bool UpdateReportStatus(int reportID, string status);
        bool DeleteReport(int reportID);
    }
}
