using Crime_Report_Managenent.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.Repositary.Interfaces
{
    internal interface IVictims
    {
        bool CreateVictim(Victims victim);  // Method to create a new victim
        List<Victims> GetVictims();         // Method to retrieve a list of victims
        bool UpdateVictim(Victims victim);  // Method to update an existing victim
        bool DeleteVictim(int victimID);    // Method to delete a victim by ID
    }
}
