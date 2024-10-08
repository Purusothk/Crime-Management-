using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.models
{
    public class Victims
    {
        public int VictimID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ContactInformation { get; set; }
        public object Name { get; internal set; }
        public object Address { get; internal set; }

        // Default constructor
        public Victims() { }

        // Parameterized constructor
        public Victims(int victimID, string firstName, string lastName, string dateOfBirth, string gender, string contactInformation)
        {
            VictimID = victimID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ContactInformation = contactInformation;
        }

        public override string ToString()
        {
            return $"VictimID: {VictimID}, Name: {FirstName} {LastName}, DateOfBirth: {DateOfBirth}, Gender: {Gender}, ContactInformation: {ContactInformation}";
        }
    }
}

