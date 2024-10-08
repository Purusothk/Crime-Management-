using Crime_Report_Managenent.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.Repositary.Interfaces
{
    public interface ISuspects
    {
        List<Suspects> GetAllSuspects();
        Suspects GetSuspectByID(int suspectID);
        bool CreateSuspect(Suspects suspect);
        bool UpdateSuspect(Suspects suspect);
        bool DeleteSuspect(int suspectID);
    }
}
