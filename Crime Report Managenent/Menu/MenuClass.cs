using Crime_Report_Managenent.Exceptions;
using Crime_Report_Managenent.models;
using Crime_Report_Managenent.Repositary;
using Crime_Report_Managenent.Repositary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
 

namespace Crime_Report_Managenent.Menu
{
    internal class MenuClass
    {
 
        
            public void run()
            {

                IIncidents incidentService = new IncidentsImpl();
                IReport reportService = new ReportImpl();
                IVictims victimsService = new VictimsImpl();
                ISuspects suspectsImpl = new SuspectImpl();
                IOfficers officerService = new OfficersImpl();
                IEvidence evidenceService = new EvidenceImpl();
                ICase caseService = new CaseImpl();




            while (true) // Outer loop that runs continuously
            {
                Console.WriteLine("\nMain Menu");
                Console.WriteLine("Select a section to manage:");
                Console.WriteLine("1. Incidents");
                Console.WriteLine("2. Reports");
                Console.WriteLine("3. Victims");
                Console.WriteLine("4. Suspects");
                Console.WriteLine("5. Officers");
                Console.WriteLine("6. Evidence");
                Console.WriteLine("7. Cases");
                Console.WriteLine("8. Exit");
                Console.WriteLine("Enter your choice:");

                int n = int.Parse(Console.ReadLine()); // Main menu input

                if (n == 0) break; // Exit the outer loop if the user enters 0

                switch (n)
                {
                    case 1:
                        while (true)
                        {
                            Console.WriteLine("\nIncident Management");
                            Console.WriteLine("1. Add Incident");
                            Console.WriteLine("2. Get All Incidents");
                            Console.WriteLine("3. Get Incidents in Date Range");
                            Console.WriteLine("4. Get Incident by ID");
                            Console.WriteLine("5. Update Incident");
                            Console.WriteLine("6. Return to Main Menu");

                            int nn = int.Parse(Console.ReadLine());

                            if (nn == 6) break; // Exit inner loop and return to outer switch

                            switch (nn)
                            {
                                case 1:
                                    AddIncident(incidentService);
                                    break;
                                case 2:
                                    GetAllIncidents(incidentService);
                                    break;
                                case 3:
                                    GetIncidentsInDateRange(incidentService);
                                    break;
                                case 4:
                                    GetIncidentById(incidentService);
                                    break;
                                case 5:
                                    UpdateIncident(incidentService);
                                    break;
                                default:
                                    Console.WriteLine("Enter a valid input.");
                                    break;
                            }
                        }
                        break;

                    case 2:
                        while (true)
                        {
                            Console.WriteLine("\nReport Management");
                            Console.WriteLine("1. Create new Report");
                            Console.WriteLine("2. View all Reports");
                            Console.WriteLine("3. Get Report by ID");
                            Console.WriteLine("4. Update Report Status");
                            Console.WriteLine("5. Delete Report");
                            Console.WriteLine("6. Return to Main Menu");

                            int reportChoice = int.Parse(Console.ReadLine());

                            if (reportChoice == 6) break; // Exit inner loop and return to outer switch

                            switch (reportChoice)
                            {
                                case 1:
                                    CreateNewReport(reportService);
                                    break;
                                case 2:
                                    GetAllReports(reportService);
                                    break;
                                case 3:
                                    GetReportById(reportService);
                                    break;
                                case 4:
                                    UpdateReportStatus(reportService);
                                    break;
                                case 5:
                                    DeleteReport(reportService);
                                    break;
                                default:
                                    Console.WriteLine("Enter a valid input.");
                                    break;
                            }
                        }
                        break;

                    case 3:
                        while (true)
                        {
                            Console.WriteLine("\nVictim Management");
                            Console.WriteLine("1. Create Victim");
                            Console.WriteLine("2. Get Victims");
                            Console.WriteLine("3. Update Victim");
                            Console.WriteLine("4. Delete Victim");
                            Console.WriteLine("5. Return to Main Menu");

                            int victimChoice = int.Parse(Console.ReadLine());

                            if (victimChoice == 5) break; // Exit inner loop and return to outer switch

                            switch (victimChoice)
                            {
                                case 1:
                                    CreateVictim(victimsService);
                                    break;
                                case 2:
                                    GetVictims(victimsService);
                                    break;
                                case 3:
                                    UpdateVictim(victimsService);
                                    break;
                                case 4:
                                    DeleteVictim(victimsService);
                                    break;
                                default:
                                    Console.WriteLine("Enter a valid input.");
                                    break;
                            }
                        }
                        break;

                    case 4:
                        while (true)
                        {
                            Console.WriteLine("\nSuspect Management");
                            Console.WriteLine("1. Add a new suspect");
                            Console.WriteLine("2. Retrieve a suspect by ID");
                            Console.WriteLine("3. Update suspect information");
                            Console.WriteLine("4. Delete suspect by ID");
                            Console.WriteLine("5. View all suspects");
                            Console.WriteLine("6. Return to Main Menu");

                            int suspectChoice = int.Parse(Console.ReadLine());

                            if (suspectChoice == 6) break; // Exit inner loop and return to outer switch

                            switch (suspectChoice)
                            {
                                case 1:
                                    AddSuspect(suspectsImpl);
                                    break;
                                case 2:
                                    RetrieveSuspect(suspectsImpl);
                                    break;
                                case 3:
                                    UpdateSuspect(suspectsImpl);
                                    break;
                                case 4:
                                    DeleteSuspect(suspectsImpl);
                                    break;
                                case 5:
                                    ViewAllSuspects(suspectsImpl);
                                    break;
                                default:
                                    Console.WriteLine("Enter a valid input.");
                                    break;
                            }
                        }
                        break;

                    case 5:
                        while (true)
                        {
                            Console.WriteLine("\nOfficer Management");
                            Console.WriteLine("1. Add New Officer");
                            Console.WriteLine("2. View All Officers");
                            Console.WriteLine("3. Get Officer by ID");
                            Console.WriteLine("4. Update Officer");
                            Console.WriteLine("5. Delete Officer");
                            Console.WriteLine("6. Return to Main Menu");

                            int officerChoice = int.Parse(Console.ReadLine());

                            if (officerChoice == 6) break; // Exit inner loop and return to outer switch

                            switch (officerChoice)
                            {
                                case 1:
                                    AddNewOfficer(officerService);
                                    break;
                                case 2:
                                    ViewAllOfficers(officerService);
                                    break;
                                case 3:
                                    GetOfficerByID(officerService);
                                    break;
                                case 4:
                                    UpdateOfficer(officerService);
                                    break;
                                case 5:
                                    DeleteOfficer(officerService);
                                    break;
                                default:
                                    Console.WriteLine("Enter a valid input.");
                                    break;
                            }
                        }
                        break;

                    case 6:
                        while (true)
                        {
                            Console.WriteLine("\nEvidence Management");
                            Console.WriteLine("1. Create new Evidence");
                            Console.WriteLine("2. View all Evidence");
                            Console.WriteLine("3. Get Evidence by ID");
                            Console.WriteLine("4. Update Evidence");
                            Console.WriteLine("5. Delete Evidence");
                            Console.WriteLine("6. Return to Main Menu");

                            int evidenceChoice = int.Parse(Console.ReadLine());

                            if (evidenceChoice == 6) break; // Exit inner loop and return to outer switch

                            switch (evidenceChoice)
                            {
                                case 1:
                                    CreateNewEvidence(evidenceService);
                                    break;
                                case 2:
                                    GetAllEvidence(evidenceService);
                                    break;
                                case 3:
                                    GetEvidenceById(evidenceService);
                                    break;
                                case 4:
                                    UpdateEvidence(evidenceService);
                                    break;
                                case 5:
                                    DeleteEvidence(evidenceService);
                                    break;
                                default:
                                    Console.WriteLine("Enter a valid input.");
                                    break;
                            }
                        }
                        break;

                    case 7:
                        while (true)
                        {
                            Console.WriteLine("\nCase Management");
                            Console.WriteLine("1. Create Case");
                            Console.WriteLine("2. Get Case");
                            Console.WriteLine("3. Update Case");
                            Console.WriteLine("4. Delete Case");
                            Console.WriteLine("5. View All Cases");
                            Console.WriteLine("6. Return to Main Menu");

                            string caseChoice = Console.ReadLine();

                            if (caseChoice == "6") break; // Exit inner loop and return to outer switch

                            HandleUserInput(caseChoice, caseService);
                        }
                        break;

                    case 8:
                        Console.WriteLine("Exiting the program...");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Enter valid inputs...");
                        break;
                }
            }

        }




        #region Incident Methods

        static void AddIncident(IIncidents incidentService)
        {
            Console.WriteLine("Enter Incident ID: ");
            int incidentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Incident Type: ");
            string incidentType = Console.ReadLine();

            Console.WriteLine("Enter Incident Date (yyyy-mm-dd): ");
            DateTime incidentDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Location: ");
            string location = Console.ReadLine();

            Console.WriteLine("Enter Description: ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter Status: ");
            string status = Console.ReadLine();

            // Create a new Incident object
            Incidents incident = new Incidents
            {
                IncidentID = incidentId,
                IncidentType = incidentType,
                IncidentDate = incidentDate,
                Location = location,
                Description = description,
                Status = status
            };

            if (incidentService.CreateIncident(incident))
            {
                Console.WriteLine("Incident created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create incident.");
            }
        }

        static void GetAllIncidents(IIncidents incidentService)
        {
            incidentService.GetAllIncidents();
        }

        static void GetIncidentsInDateRange(IIncidents incidentService)
        {
            Console.WriteLine("Enter Start Date (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter End Date (yyyy-mm-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            List<Incidents> incidentsInRange = incidentService.GetIncidentsInDateRange(startDate, endDate);
            foreach (var incident in incidentsInRange)
            {
                Console.WriteLine(incident);
            }
        }

        static void UpdateIncident(IIncidents incidentService)
        {
            Console.WriteLine("Enter Incident ID to update: ");
            int incidentId = int.Parse(Console.ReadLine());

            // Prompt the user to enter the new values for the incident
            Console.WriteLine("Enter new Incident Type: ");
            string incidentType = Console.ReadLine();

            Console.WriteLine("Enter new Incident Date (yyyy-mm-dd): ");
            DateTime incidentDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Location: ");
            string location = Console.ReadLine();

            Console.WriteLine("Enter new Description: ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter new Status: ");
            string status = Console.ReadLine();

            // Create a new Incident object with the updated values
            Incidents incident = new Incidents
            {
                IncidentID = incidentId,
                IncidentType = incidentType,
                IncidentDate = incidentDate,
                Location = location,
                Description = description,
                Status = status
            };

            if (incidentService.UpdateIncident(incident))
            {
                Console.WriteLine("Incident updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update incident.");
            }
        }

        public static void GetIncidentById(IIncidents incidentService)
        {
            try
            {
                Console.Write("Enter Incident ID: ");
                if (int.TryParse(Console.ReadLine(), out int incidentId))
                {
                    Incidents incident = incidentService.GetIncidentById(incidentId);
                    Console.WriteLine($"Incident ID: {incident.IncidentID}, Incident Type: {incident.IncidentType}, Location: {incident.Location}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid incident ID.");
                }
            }
            catch (IncidentNumberNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }


        #endregion

        #region Evidence

        static void CreateNewEvidence(IEvidence evidenceService)
        {
            try
            {
                Console.WriteLine("Enter Evidence Description:");
                string description = Console.ReadLine();

                Console.WriteLine("Enter Location Found:");
                string locationFound = Console.ReadLine();

                Console.WriteLine("Enter Incident ID:");
                if (!int.TryParse(Console.ReadLine(), out int incidentId))
                {
                    Console.WriteLine("Invalid Incident ID. Please enter a valid number.");
                    return;
                }

                models.Evidence newEvidence = new models.Evidence
                {
                    Description = description,
                    LocationFound = locationFound,
                    IncidentID = incidentId // Assuming the Evidence class has an IncidentID property
                };

                if (evidenceService.CreateEvidence(newEvidence))
                {
                    Console.WriteLine("New evidence created successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to create evidence. Please check your input and try again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void GetAllEvidence(IEvidence evidenceService)
        {
            try
            {
                List<models.Evidence> allEvidence = evidenceService.GetAllEvidence();
                if (allEvidence.Count > 0)
                {
                    foreach (var evidence in allEvidence)
                    {
                        Console.WriteLine(evidence.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No evidence found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void GetEvidenceById(IEvidence evidenceService)
        {
            try
            {
                Console.WriteLine("Enter Evidence ID:");
                if (!int.TryParse(Console.ReadLine(), out int evidenceId))
                {
                    Console.WriteLine("Invalid Evidence ID. Please enter a valid number.");
                    return;
                }

                models.Evidence evidence = evidenceService.GetEvidenceById(evidenceId);
                if (evidence != null)
                {
                    Console.WriteLine(evidence.ToString());
                }
                else
                {
                    Console.WriteLine("Evidence not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void UpdateEvidence(IEvidence evidenceService)
        {
            try
            {
                Console.WriteLine("Enter Evidence ID to update:");
                if (!int.TryParse(Console.ReadLine(), out int evidenceId))
                {
                    Console.WriteLine("Invalid Evidence ID. Please enter a valid number.");
                    return;
                }

                models.Evidence existingEvidence = evidenceService.GetEvidenceById(evidenceId);
                if (existingEvidence != null)
                {
                    Console.WriteLine("Enter new Evidence Description (leave blank for no change):");
                    string description = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(description)) description = existingEvidence.Description;

                    Console.WriteLine("Enter new Location Found (leave blank for no change):");
                    string locationFound = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(locationFound)) locationFound = existingEvidence.LocationFound;

                    existingEvidence.Description = description;
                    existingEvidence.LocationFound = locationFound;

                    bool result = evidenceService.UpdateEvidence(existingEvidence);
                    Console.WriteLine(result ? "Evidence updated successfully." : "Failed to update evidence.");
                }
                else
                {
                    Console.WriteLine("Evidence not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void DeleteEvidence(IEvidence evidenceService)
        {
            try
            {
                Console.WriteLine("Enter Evidence ID to delete:");
                if (!int.TryParse(Console.ReadLine(), out int evidenceId))
                {
                    Console.WriteLine("Invalid Evidence ID. Please enter a valid number.");
                    return;
                }

                bool result = evidenceService.DeleteEvidence(evidenceId);
                Console.WriteLine(result ? "Evidence deleted successfully." : "Failed to delete evidence.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        #endregion

        #region Report

        


        static void CreateNewReport(IReport reportService)
        {
            Console.WriteLine("Enter ReportID :");
            int reportID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Incident ID:");
            int incidentID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Reporting Officer ID:");
            int officerID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Report Date (YYYY-MM-DD):");
            string reportDate = Console.ReadLine();
            Console.WriteLine("Enter Report Details:");
            string reportDetails = Console.ReadLine();
            Console.WriteLine("Enter Status:");
            string status = Console.ReadLine();

            Report newReport = new Report
            {
                ReportID = reportID,
                IncidentID = incidentID,
                ReportingOfficer = officerID,
                ReportDate = reportDate,
                ReportDetails = reportDetails,
                Status = status
            };

            reportService.CreateReport(newReport);
            Console.WriteLine("New Report created successfully!");
        }

        static void GetAllReports(IReport reportService)
        {
            reportService.GetAllReportsWithDetails();
        }

        static void GetReportById(IReport reportService)
        {
            Console.WriteLine("Enter Report ID to fetch:");
            int reportID = int.Parse(Console.ReadLine());
            Report report = reportService.GetReport(reportID);

            if (report != null)
            {
                Console.WriteLine($"Report ID: {report.ReportID}, " +
                                  $"Incident ID: {report.IncidentID}, " +
                                  $"Officer ID: {report.ReportingOfficer}, " +
                                  $"Report Date: {report.ReportDate}, " +
                                  $"Details: {report.ReportDetails}, " +
                                  $"Status: {report.Status}");
            }
            else
            {
                Console.WriteLine("No report found with the given ID.");
            }
        }

        static void UpdateReportStatus(IReport reportService)
        {
            Console.WriteLine("Enter Report ID to update:");
            int reportID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Status:");
            string status = Console.ReadLine();

            if (reportService.UpdateReportStatus(reportID, status))
            {
                Console.WriteLine("Report status updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update report status.");
            }
        }

        static void DeleteReport(IReport reportService)
        {
            Console.WriteLine("Enter Report ID to delete:");
            int reportID = int.Parse(Console.ReadLine());

            if (reportService.DeleteReport(reportID))
            {
                Console.WriteLine("Report deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete report.");
            }
        }

        #endregion

        #region Officer 
        

        static void AddNewOfficer(IOfficers officerService)
        {
            Console.WriteLine("\nEnter Officer Details:");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Badge Number: ");
            string badgeNumber = Console.ReadLine();

            Console.Write("Rank: ");
            string rank = Console.ReadLine();

            Console.Write("Contact Info: ");
            string contactInfo = Console.ReadLine();

            Console.Write("Agency ID: ");
            int agencyID = int.Parse(Console.ReadLine());

            Officers officer = new Officers
            {
                FirstName = firstName,
                LastName = lastName,
                BadgeNumber = badgeNumber,
                Rank = rank,
                ContactInfo = contactInfo,
                AgencyID = agencyID
            };

            if (officerService.CreateOfficer(officer))
            {
                Console.WriteLine("Officer added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add officer.");
            }
        }

        static void ViewAllOfficers(IOfficers officerService)
        {
            var officers = officerService.GetAllOfficers();

            if (officers.Count > 0)
            {
                Console.WriteLine("\nList of Officers:");
                foreach (var officer in officers)
                {
                    Console.WriteLine(officer.ToString());
                }
            }
            else
            {
                Console.WriteLine("No officers found.");
            }
        }

        static void GetOfficerByID(IOfficers officerService)
        {
            Console.Write("Enter Officer ID: ");
            int officerID = int.Parse(Console.ReadLine());

            Officers officer = officerService.GetOfficer(officerID);
            if (officer != null)
            {
                Console.WriteLine(officer.ToString());
            }
            else
            {
                Console.WriteLine("Officer not found.");
            }
        }

        static void UpdateOfficer(IOfficers officerService)
        {
            Console.Write("Enter Officer ID to update: ");
            int officerID = int.Parse(Console.ReadLine());

            Officers officer = officerService.GetOfficer(officerID);
            if (officer != null)
            {
                Console.Write("New First Name (leave blank to keep current): ");
                string firstName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(firstName)) officer.FirstName = firstName;

                Console.Write("New Last Name (leave blank to keep current): ");
                string lastName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(lastName)) officer.LastName = lastName;

                Console.Write("New Badge Number (leave blank to keep current): ");
                string badgeNumber = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(badgeNumber)) officer.BadgeNumber = badgeNumber;

                Console.Write("New Rank (leave blank to keep current): ");
                string rank = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(rank)) officer.Rank = rank;

                Console.Write("New Contact Info (leave blank to keep current): ");
                string contactInfo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(contactInfo)) officer.ContactInfo = contactInfo;

                Console.Write("New Agency ID (leave blank to keep current): ");
                string agencyIDStr = Console.ReadLine();
                if (int.TryParse(agencyIDStr, out int agencyID))
                {
                    officer.AgencyID = agencyID;
                }

                if (officerService.UpdateOfficer(officer))
                {
                    Console.WriteLine("Officer updated successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to update officer.");
                }
            }
            else
            {
                Console.WriteLine("Officer not found.");
            }
        }

        static void DeleteOfficer(IOfficers officerService)
        {
            Console.Write("Enter Officer ID to delete: ");
            int officerID = int.Parse(Console.ReadLine());

            if (officerService.DeleteOfficer(officerID))
            {
                Console.WriteLine("Officer deleted successfully!");
            }
            else
            {
                Console.WriteLine("Failed to delete officer.");
            }
        }
        #endregion

        #region suspects
         

        static void AddSuspect(ISuspects suspectsImpl)
        {
            Console.WriteLine("Enter suspect details:");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Date of Birth (yyyy-mm-dd): ");
            string dateOfBirth = Console.ReadLine();

            Console.Write("Gender: ");
            string gender = Console.ReadLine();

            Console.Write("Contact Information: ");
            string contactInformation = Console.ReadLine();

            Suspects newSuspect = new Suspects(0, firstName, lastName, dateOfBirth, gender, contactInformation);
            bool isAdded = suspectsImpl.CreateSuspect(newSuspect);

            if (isAdded)
            {
                Console.WriteLine("Suspect added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add suspect.");
            }
        }

        static void RetrieveSuspect(ISuspects suspectsImpl)
        {
            Console.Write("Enter Suspect ID: ");
            int suspectID = int.Parse(Console.ReadLine());
            Suspects suspect = suspectsImpl.GetSuspectByID(suspectID);

            if (suspect != null)
            {
                Console.WriteLine(suspect.ToString());
            }
            else
            {
                Console.WriteLine("Suspect not found.");
            }
        }

        static void UpdateSuspect(ISuspects suspectsImpl)
        {
            Console.Write("Enter Suspect ID to update: ");
            int suspectID = int.Parse(Console.ReadLine());
            Suspects suspect = suspectsImpl.GetSuspectByID(suspectID);

            if (suspect != null)
            {
                Console.WriteLine("Enter new details (leave blank for no change):");

                Console.Write($"First Name ({suspect.FirstName}): ");
                string firstName = Console.ReadLine();
                suspect.FirstName = string.IsNullOrEmpty(firstName) ? suspect.FirstName : firstName;

                Console.Write($"Last Name ({suspect.LastName}): ");
                string lastName = Console.ReadLine();
                suspect.LastName = string.IsNullOrEmpty(lastName) ? suspect.LastName : lastName;

                Console.Write($"Date of Birth ({suspect.DateOfBirth}): ");
                string dateOfBirth = Console.ReadLine();
                suspect.DateOfBirth = string.IsNullOrEmpty(dateOfBirth) ? suspect.DateOfBirth : dateOfBirth;

                Console.Write($"Gender ({suspect.Gender}): ");
                string gender = Console.ReadLine();
                suspect.Gender = string.IsNullOrEmpty(gender) ? suspect.Gender : gender;

                Console.Write($"Contact Information ({suspect.ContactInformation}): ");
                string contactInformation = Console.ReadLine();
                suspect.ContactInformation = string.IsNullOrEmpty(contactInformation) ? suspect.ContactInformation : contactInformation;

                bool isUpdated = suspectsImpl.UpdateSuspect(suspect);
                Console.WriteLine(isUpdated ? "Suspect updated successfully." : "Failed to update suspect.");
            }
            else
            {
                Console.WriteLine("Suspect not found.");
            }
        }

        static void DeleteSuspect(ISuspects suspectsImpl)
        {
            Console.Write("Enter Suspect ID to delete: ");
            int suspectID = int.Parse(Console.ReadLine());
            bool isDeleted = suspectsImpl.DeleteSuspect(suspectID);

            Console.WriteLine(isDeleted ? "Suspect deleted successfully." : "Failed to delete suspect.");
        }

        static void ViewAllSuspects(ISuspects suspectsImpl)
        {
            List<Suspects> suspects = suspectsImpl.GetAllSuspects();

            Console.WriteLine("Suspects List:");
            foreach (var suspect in suspects)
            {
                Console.WriteLine(suspect.ToString());
            }
        }

        #endregion

        #region Cases
        static void HandleUserInput(string choice, ICase caseService)
        {
            switch (choice)
            {
                case "1":
                    CreateCase(caseService);
                    break;
                case "2":
                    GetCase(caseService);
                    break;
                case "3":
                    UpdateCase(caseService);
                    break;
                case "4":
                    DeleteCase(caseService);
                    break;
                case "5":
                    ViewAllCases(caseService);
                    break;
                case "6":
                    Environment.Exit(0); // Exit the program
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }


        private static void CreateCase(ICase caseService)
        {
            Console.WriteLine("Enter Case Description:");
            string caseDescription = Console.ReadLine();

            // Collecting incidents for the case (for demonstration, we're just adding a dummy incident)
            List<Incidents> incidents = new List<Incidents>();

            // You could prompt the user to enter details of each incident here, but for now, we will add a dummy incident
            Console.WriteLine("Enter number of incidents:");
            int numOfIncidents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfIncidents; i++)
            {
                Console.WriteLine($"Enter IncidentID for incident {i + 1}:");
                int incidentId = int.Parse(Console.ReadLine());

                // Create and add each incident to the list
                Incidents newIncident = new Incidents { IncidentID = incidentId };
                incidents.Add(newIncident);
            }

            // Create a new case using the caseService
            Case newCase = caseService.CreateCase(caseDescription, incidents);

            // Check if the case is created successfully by inspecting the returned object
            if (newCase != null)
            {
                Console.WriteLine($"Case created successfully. Case ID: {newCase.CaseID}, Description: {newCase.CaseDescription}, Created on: {newCase.CreationDate}");
            }
            else
            {
                Console.WriteLine("Failed to create case.");
            }
        }


        private static void GetCase(ICase caseService)
        {
            Console.WriteLine("Enter CaseID to retrieve:");
            int retrieveCaseId = int.Parse(Console.ReadLine());
            var caseDetails = caseService.GetCase(retrieveCaseId);

            if (caseDetails != null)
            {
                Console.WriteLine($"CaseID: {caseDetails.CaseID}, Description: {caseDetails.CaseDescription}, Created On: {caseDetails.CreationDate}");
            }
            else
            {
                Console.WriteLine("Case not found.");
            }
        }

        private static void UpdateCase(ICase caseService)
        {
            Console.WriteLine("Enter CaseID to update:");
            int updateCaseId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Case Description:");
            string newDescription = Console.ReadLine();
            var updatedCase = new Case(updateCaseId, newDescription, DateTime.Now); // Update the case

            if (caseService.UpdateCase(updatedCase))
            {
                Console.WriteLine("Case updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update case.");
            }
        }

        private static void DeleteCase(ICase caseService)
        {
            Console.WriteLine("Enter CaseID to delete:");
            int deleteCaseId = int.Parse(Console.ReadLine());

            if (caseService.DeleteCase(deleteCaseId))
            {
                Console.WriteLine("Case deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete case.");
            }
        }

        private static void ViewAllCases(ICase caseService)
        {
            var allCases = caseService.GetAllCases();
            foreach (var c in allCases)
            {
                Console.WriteLine($"CaseID: {c.CaseID}, Description: {c.CaseDescription}, Created On: {c.CreationDate}");
            }
        }
        #endregion

        #region Victims
        

        private static void CreateVictim(IVictims victimsService)
        {
            try
            {
                Console.WriteLine("Enter Victim ID:");
                int victimID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter First Name:");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name:");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter Date of Birth (YYYY-MM-DD):");
                string dateOfBirth = Console.ReadLine();
                Console.WriteLine("Enter Gender:");
                string gender = Console.ReadLine();
                Console.WriteLine("Enter Contact Information:");
                string contactInformation = Console.ReadLine();

                Victims newVictim = new Victims(victimID, firstName, lastName, dateOfBirth, gender, contactInformation);
                bool success = victimsService.CreateVictim(newVictim);

                if (success)
                {
                    Console.WriteLine("Victim created successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to create victim.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private static void GetVictims(IVictims victimsService)
        {
            List<Victims> victims = victimsService.GetVictims();
            if (victims.Count == 0)
            {
                Console.WriteLine("No victims found.");
            }
            else
            {
                Console.WriteLine("List of Victims:");
                foreach (var victim in victims)
                {
                    Console.WriteLine(victim.ToString());
                }
            }
        }

        private static void UpdateVictim(IVictims victimsService)
        {
            try
            {
                Console.WriteLine("Enter Victim ID to update:");
                int victimID = int.Parse(Console.ReadLine());

                // Retrieve existing victim
                var victims = victimsService.GetVictims();
                var existingVictim = victims.Find(v => v.VictimID == victimID);
                if (existingVictim == null)
                {
                    Console.WriteLine("Victim not found.");
                    return;
                }

                Console.WriteLine("Updating details for victim: " + existingVictim.ToString());
                Console.WriteLine("Enter new First Name (leave blank to keep current):");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter new Last Name (leave blank to keep current):");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter new Date of Birth (leave blank to keep current):");
                string dateOfBirth = Console.ReadLine();
                Console.WriteLine("Enter new Gender (leave blank to keep current):");
                string gender = Console.ReadLine();
                Console.WriteLine("Enter new Contact Information (leave blank to keep current):");
                string contactInformation = Console.ReadLine();

                // Update existing victim details
                existingVictim.FirstName = string.IsNullOrWhiteSpace(firstName) ? existingVictim.FirstName : firstName;
                existingVictim.LastName = string.IsNullOrWhiteSpace(lastName) ? existingVictim.LastName : lastName;
                existingVictim.DateOfBirth = string.IsNullOrWhiteSpace(dateOfBirth) ? existingVictim.DateOfBirth : dateOfBirth;
                existingVictim.Gender = string.IsNullOrWhiteSpace(gender) ? existingVictim.Gender : gender;
                existingVictim.ContactInformation = string.IsNullOrWhiteSpace(contactInformation) ? existingVictim.ContactInformation : contactInformation;

                bool success = victimsService.UpdateVictim(existingVictim);
                if (success)
                {
                    Console.WriteLine("Victim updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update victim.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private static void DeleteVictim(IVictims victimsService)
        {
            try
            {
                Console.WriteLine("Enter Victim ID to delete:");
                int victimID = int.Parse(Console.ReadLine());
                bool success = victimsService.DeleteVictim(victimID);
                if (success)
                {
                    Console.WriteLine("Victim deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to delete victim.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
    #endregion

    //#region  LawEnforce
    //static void HandleLawEnforcementAgencyManagement(ILawEnforcementAgencies agencyDao)
    //{
    //    Console.WriteLine("1. Add Agency");
    //    Console.WriteLine("2. Update Agency");
    //    Console.WriteLine("3. Remove Agency");
    //    Console.WriteLine("4. Get Agency by ID");
    //    Console.WriteLine("5. List All Agencies");
    //    Console.WriteLine("6. Exit ");
    //    Console.Write("Select an option (1-6): ");

    //    if (int.TryParse(Console.ReadLine(), out int agencyChoice))
    //    {
    //        switch (agencyChoice)
    //        {
    //            case 1:
    //                AddAgency(agencyDao);
    //                break;
    //            case 2:
    //                UpdateAgency(agencyDao);
    //                break;
    //            case 3:
    //                RemoveAgency(agencyDao);
    //                break;
    //            case 4:
    //                GetAgencyById(agencyDao);
    //                break;
    //            case 5:
    //                ListAllAgencies(agencyDao);
    //                break;
    //            case 6:
    //                Environment.Exit(0);
    //                break;
    //            default:
    //                Console.WriteLine("Invalid option. Please select between 1 and 5.");
    //                break;
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("Invalid input. Please enter a number.");
    //    }
    //}

    //// Adding an agency
    //static void AddAgency(ILawEnforcementAgencies agencyDao)
    //{
    //    Console.Write("Enter Agency ID: ");
    //    int agencyId = int.Parse(Console.ReadLine());

    //    Console.Write("Enter Agency Name: ");
    //    string agencyName = Console.ReadLine();

    //    Console.Write("Enter Jurisdiction: ");
    //    string jurisdiction = Console.ReadLine();

    //    Console.Write("Enter Contact Information: ");
    //    string contactInfo = Console.ReadLine();

    //    var newAgency = new LawEnforcementAgencies
    //    {
    //        AgencyID = agencyId,
    //        AgencyName = agencyName,
    //        Jurisdiction = jurisdiction,
    //        ContactInformation = contactInfo
    //    };

    //    agencyDao.AddAgency(newAgency); // Check if this method exists in your DAO
    //    Console.WriteLine("Agency added successfully.");
    //}

    //// Updating an agency
    //static void UpdateAgency(ILawEnforcementAgencies agencyDao)
    //{
    //    Console.Write("Enter Agency ID to update: ");
    //    if (int.TryParse(Console.ReadLine(), out int agencyId))
    //    {
    //        var agency = agencyDao.GetAgencyById(agencyId); // Ensure this method exists
    //        if (agency != null)
    //        {
    //            // Prompt for updates
    //            Console.Write($"Current Agency Name: {agency.AgencyName}. Enter new name (leave blank to keep current): ");
    //            string newName = Console.ReadLine();
    //            agency.AgencyName = string.IsNullOrWhiteSpace(newName) ? agency.AgencyName : newName;

    //            Console.Write($"Current Jurisdiction: {agency.Jurisdiction}. Enter new jurisdiction (leave blank to keep current): ");
    //            string newJurisdiction = Console.ReadLine();
    //            agency.Jurisdiction = string.IsNullOrWhiteSpace(newJurisdiction) ? agency.Jurisdiction : newJurisdiction;

    //            Console.Write($"Current Contact Info: {agency.ContactInformation}. Enter new info (leave blank to keep current): ");
    //            string newContactInfo = Console.ReadLine();
    //            agency.ContactInformation = string.IsNullOrWhiteSpace(newContactInfo) ? agency.ContactInformation : newContactInfo;

    //            agencyDao.UpdateAgency(agency); // Ensure this method exists
    //            Console.WriteLine("Agency updated successfully.");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Agency not found.");
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("Invalid Agency ID.");
    //    }
    //}

    //// Removing an agency
    //static void RemoveAgency(ILawEnforcementAgencies agencyDao)
    //{
    //    Console.Write("Enter Agency ID to remove: ");
    //    if (int.TryParse(Console.ReadLine(), out int agencyId))
    //    {
    //        agencyDao.RemoveAgency(agencyId); // Ensure this method exists
    //        Console.WriteLine("Agency removed successfully.");
    //    }
    //    else
    //    {
    //        Console.WriteLine("Invalid Agency ID.");
    //    }
    //}

    //// Get agency by ID
    //static void GetAgencyById(ILawEnforcementAgencies agencyDao)
    //{
    //    Console.Write("Enter Agency ID: ");
    //    if (int.TryParse(Console.ReadLine(), out int agencyId))
    //    {
    //        var agency = agencyDao.GetAgencyById(agencyId); // Ensure this method exists
    //        if (agency != null)
    //        {
    //            Console.WriteLine(agency);
    //        }
    //        else
    //        {
    //            Console.WriteLine("Agency not found.");
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("Invalid Agency ID.");
    //    }
    //}

    //// List all agencies
    //static void ListAllAgencies(ILawEnforcementAgencies agencyDao)
    //{
    //    List<LawEnforcementAgencies> agencies = agencyDao.GetAllAgencies(); // Ensure this method exists
    //    Console.WriteLine("\n--- List of Law Enforcement Agencies ---");
    //    foreach (var agency in agencies)
    //    {
    //        Console.WriteLine(agency);
    //    }
    //}


    //#endregion
}
    

 
