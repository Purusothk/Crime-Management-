//using Crime_Report_Managenent.Exceptions;
//using Crime_Report_Managenent.models;
//using Crime_Report_Managenent.Repositary;
//using NUnit.Framework;
//using NUnit.Framework.Legacy;
//using System;

//namespace Crime_Report_Managenent.Test
//{
//    [TestFixture]
//    public class IncidentServiceStatusUpdateTest
//    {
//        private IIncidents _incidentService;

//        [SetUp]
//        public void Setup()
//        {
//            _incidentService = new IncidentsImpl();
//        }

//        [Test]
//        public void UpdateIncidentStatus_ShouldUpdateStatusSuccessfully()
//        {
//            // Arrange
//            var incident = new Incidents
//            {
//                IncidentType = "Burglary",
//                Location = "789 Main St",
//                Description = "Burglary reported",
//                Status = "Open",
//                IncidentDate = DateTime.Now
//            };
//            var createdIncident = _incidentService.CreateIncident(incident);

//            // Act
//            var updatedStatus = "Closed"; // New status
//            _incidentService.UpdateIncidentStatus(createdIncident.IncidentID, updatedStatus);

//            // Assert
//            var fetchedIncident = _incidentService.GetIncidentById(createdIncident.IncidentID);
//            ClassicAssert.AreEqual(updatedStatus, fetchedIncident.Status, "Incident status should be updated successfully");
//        }

//        [Test]
//        public void UpdateIncidentStatus_ShouldThrowException_WhenStatusIsInvalid()
//        {
//            // Arrange
//            var incident = new Incidents
//            {
//                IncidentType = "Theft",
//                Location = "123 Elm St",
//                Description = "Theft reported",
//                Status = "Open",
//                IncidentDate = DateTime.Now
//            };
//            var createdIncident = _incidentService.CreateIncident(incident);

//            // Act & Assert
//            var ex = Assert.Throws<InvalidStatusUpdateException>(() => _incidentService.UpdateIncidentStatus(createdIncident.IncidentID, "InvalidStatus"));
//            ClassicAssert.AreEqual($"Invalid status update attempted for Incident ID {createdIncident.IncidentID}.", ex.Message);
//        }
//    }
//}
