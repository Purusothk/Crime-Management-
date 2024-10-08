using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.models
{
    internal class LawEnforcementAgencies
    {
        public int AgencyID { get; set; }
        public string AgencyName { get; set; }
        public string Jurisdiction { get; set; }
        public string ContactInformation { get; set; } // Could include fields for address, phone number, etc.

        // Default constructor
        public LawEnforcementAgencies() { }

        // Parameterized constructor
        public LawEnforcementAgencies(int agencyID, string agencyName, string jurisdiction, string contactInformation)
        {
            AgencyID = agencyID;
            AgencyName = agencyName;
            Jurisdiction = jurisdiction;
            ContactInformation = contactInformation;
        }
        public override string ToString()
        {
            return $"AgencyID: {AgencyID}, AgencyName: {AgencyName}, Jurisdiction: {Jurisdiction}, ContactInformation: {ContactInformation}";
        }
        // Method to validate agency details
        public bool ValidateAgencyDetails()
        {
            if (string.IsNullOrWhiteSpace(AgencyName))
                throw new ArgumentException("Agency Name cannot be empty.");
            if (string.IsNullOrWhiteSpace(Jurisdiction))
                throw new ArgumentException("Jurisdiction cannot be empty.");
            if (string.IsNullOrWhiteSpace(ContactInformation))
                throw new ArgumentException("Contact Information cannot be empty.");

            return true; // Returns true if all validations pass
        }
    }
}
