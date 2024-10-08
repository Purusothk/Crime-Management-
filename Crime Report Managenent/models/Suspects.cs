using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.models
{
    public class Suspects
    {
        public int SuspectID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ContactInformation { get; set; } // Could include fields for address, phone number, etc.
        public object Name { get; internal set; }
        public object LastKnownAddress { get; internal set; }

        // Default constructor
        public Suspects() { }

        // Parameterized constructor
        public Suspects(int suspectID, string firstName, string lastName, string dateOfBirth, string gender, string contactInformation)
        {
            SuspectID = suspectID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ContactInformation = contactInformation;
        }

        public override string ToString()
        {
            return $"SuspectID ID: {SuspectID}, FirstName: {FirstName}, LastName: {LastName}, DateOfBirth: {DateOfBirth} Gender {Gender} ContactInformation {ContactInformation}";
        }
    }
}
