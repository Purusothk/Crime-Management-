using Crime_Report_Managenent.models;
using System.Collections.Generic;

namespace Crime_Report_Managenent.Repositary.Interfaces
{
    public interface ICase
    {
        Case CreateCase(string caseDescription, List<Incidents> incidents);
        Case GetCase(int caseId);
        bool UpdateCase(Case updatedCase);
        bool DeleteCase(int caseId);
        List<Case> GetAllCases();
    }

}
