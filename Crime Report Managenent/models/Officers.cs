using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.models
{
    internal class Officers
    {
        public int OfficerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BadgeNumber { get; set; }
        public string Rank { get; set; }
        public string ContactInfo { get; set; }
        public int AgencyID { get; set; }


        public Officers() { }

        public Officers(int officerID, string firstName, string lastName, string badgeNumber, string rank, string ContactInfo, int agencyID)
        {
            OfficerID = officerID;
            FirstName = firstName;
            LastName = lastName;
            BadgeNumber = badgeNumber;
            Rank = rank;
            ContactInfo = ContactInfo;
            AgencyID = agencyID;
        }
        public override string ToString()
        {
            return $"OfficerID : {OfficerID}, FirstName: {FirstName}, LastName: {LastName}, BadgeNumber: {BadgeNumber} Rank {Rank} ContactInformation {ContactInfo} AgencyID{AgencyID}";
        }
    }
}
