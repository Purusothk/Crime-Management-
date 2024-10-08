using Crime_Report_Managenent.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.Repositary.Interfaces
{
    internal interface IOfficers
    {
        bool CreateOfficer(Officers officer);
        Officers GetOfficer(int officerID);
        bool UpdateOfficer(Officers officer);
        bool DeleteOfficer(int officerID);
        List<Officers> GetAllOfficers();
    }
}
