using Crime_Report_Managenent.models;
using Crime_Report_Managenent.Repositary;
using Crime_Report_Managenent.Repositary.Interfaces;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Crime_Report_Managenent.Test
{
  
    public class IncidentServiceTest
    {
        private IIncidents _incidentService;

        [SetUp]
        public void Setup()
        {
            // Initialize the incident service.
            _incidentService = new IncidentsImpl();
        }

        [Test]
        public void CreateIncident_ShouldCreateIncidentWithCorrectAttributes()
        {
            // Arrange
            var incident = new Incidents
            {
                IncidentID = 1,
                IncidentType = "Robbery",
                IncidentDate = DateTime.Now,
                Location = "123 Main St",
                Description = "A robbery occurred.",
                Status = "Open"
            };

            // Act
            var result = _incidentService.CreateIncident(incident);

            // Assert
            ClassicAssert.IsTrue(result, "Expected CreateIncident to return true for a valid incident.");

            // Additional verification could involve checking the attributes
            var createdIncident = _incidentService.GetIncidentById(1);
            //Assert.IsNotNull(createdIncident);
            ClassicAssert.AreEqual("Robbery", createdIncident.IncidentType);
            ClassicAssert.AreEqual("123 Main St", createdIncident.Location);
            ClassicAssert.AreEqual("A robbery occurred.", createdIncident.Description);
            ClassicAssert.AreEqual("Open", createdIncident.Status);
        }

        //[Test]
        //public void UpdateIncidentStatus_ShouldUpdateStatusSuccessfully()
        //{
        //    // Arrange
        //    var incident = new Incidents
        //    {
        //        IncidentID = 1,
        //        IncidentType = "Robbery",
        //        IncidentDate = DateTime.Now,
        //        Location = "123 Main St",
        //        Description = "A robbery occurred.",
        //        Status = "Open"
        //    };

        //    // Create the incident first
        //    _incidentService.CreateIncident(incident);

        //    // Act
        //    var result = _incidentService.UpdateIncidentStatus(1, "Closed");

        //    // Assert
        //    ClassicAssert.IsTrue(result, "Expected UpdateIncidentStatus to return true for a valid status update.");

        //    var updatedIncident = _incidentService.GetIncidentById(1);
        //    ClassicAssert.AreEqual("Closed", updatedIncident.Status);
        //}

        //[Test]
        //public void UpdateIncidentStatus_ShouldHandleInvalidStatus()
        //{
        //    // Arrange
        //    var incident = new Incidents
        //    {
        //        IncidentID = 1,
        //        IncidentType = "Robbery",
        //        IncidentDate = DateTime.Now,
        //        Location = "123 Main St",
        //        Description = "A robbery occurred.",
        //        Status = "Open"
        //    };

        //    // Create the incident first
        //    _incidentService.CreateIncident(incident);

        //    // Act
        //    var result = _incidentService.UpdateIncidentStatus(1, "InvalidStatus");

        //    // Assert
        //    ClassicAssert.IsFalse(result, "Expected UpdateIncidentStatus to return false for an invalid status.");

        //    var updatedIncident = _incidentService.GetIncidentById(1);
        //    ClassicAssert.AreEqual("Open", updatedIncident.Status, "Status should remain unchanged for invalid status.");
        //}
    }
}
