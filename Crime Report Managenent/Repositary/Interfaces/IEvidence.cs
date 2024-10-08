using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crime_Report_Managenent.models;

namespace Crime_Report_Managenent.Repositary.Interfaces
{
    public interface IEvidence
    {
        bool CreateEvidence(Evidence evidence);
        List<Evidence> GetAllEvidence();
        Evidence GetEvidenceById(int evidenceId);
        bool UpdateEvidence(Evidence evidence);
        bool DeleteEvidence(int evidenceId);
    }
}
