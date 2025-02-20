using HospitalManagementSystem;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Managements;
using System;
using System.Net;

class Program
{

    static void Main(string[] args)
    {

        //DoctorManagement doctorManagement = new DoctorManagement();
        //doctorManagement.AddNewDoctor("Sara", 28, "Female", "0510005214", "Ramallah", "sara@gmail.com", "Aa");



        //AppointmentManagement a = new AppointmentManagement();
        //a.ScheduleAppointment(1, 1, DateTime.ParseExact("23-4-2025 2 pm", Strings.DateTimeFormat, null));

        //a.CancelAppointment(1);
        //a.ViewScheduleByPatientId(1);
        //a.ViewScheduleByDoctorId(2);

        //MedicationManagement medicationManagement = new MedicationManagement();
        //medicationManagement.PrintAllMedications();

        //HMSDBContext context = new HMSDBContext();  
        //var e = context.Doctors.ToList();
        //foreach (var i in e) { 
        //    Console.WriteLine(i.Name);
        //}

        //PrescriptionManagement p = new PrescriptionManagement();
        //p.IssuePrescription(2,2, [44]);



        Menu();

    }

    private static void Menu()
    {
        PatientManagement patientManagement = new PatientManagement();
        DoctorManagement doctorManagement = new DoctorManagement();
        AppointmentManagement appointmentManagement = new AppointmentManagement();
        PrescriptionManagement prescriptionManagement = new PrescriptionManagement();
        MedicationManagement medicicationManagement = new MedicationManagement(); 
        BillingManagement billingManagement = new BillingManagement();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("========== Hospital Management System ==========");
            Console.WriteLine("1. Patient Management");
            Console.WriteLine("2. Doctor Management");
            Console.WriteLine("3. Appointment Management");
            Console.WriteLine("4. Prescription Management");
            Console.WriteLine("5. Medication Management");
            Console.WriteLine("6. Billing Management");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice (1-7): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PatientMenu(patientManagement);
                    break;
                case "2":
                    DoctorMenu(doctorManagement);
                    break;
                case "3":
                    AppointmentMenu(appointmentManagement);
                    break;
                case "4":
                    PrescriptionMenu(prescriptionManagement);
                    break;
                case "5":
                    MedicationMenu(medicicationManagement);
                    break;
                case "6":
                    BillingMenu(billingManagement);
                    break;
                case "7":
                    Console.WriteLine("Exiting... Goodbye!");
                    return;
                default:
                    break;
            }
        }
    }

    private static void PatientMenu(PatientManagement patientManagement)
    {
        Console.Clear();
        Console.WriteLine("===== Patient Management =====");
        Console.WriteLine("1. Add Patient");
        Console.WriteLine("2. View Patients");
        Console.WriteLine("3. Update Patient");
        Console.WriteLine("4. Delete Patient");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter patient name:");
                string name;
                while (true)
                {
                    name = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(name))
                        break;
                    Console.WriteLine("Name cannot be empty. Please enter a valid name:");
                }

                Console.WriteLine("Enter patient age:");
                int age;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out age) && age >= 0 && age <= 120)
                        break;
                    Console.WriteLine("Invalid age. Please enter a valid age (0-120):");
                }

                Console.WriteLine("Enter patient gender (M/F):");
                string gender;
                while (true)
                {
                    gender = Console.ReadLine()?.Trim().ToUpper();
                    if (gender == "F")
                    {
                        gender = "Female";
                        break;
                    }
                    else if (gender == "M")
                    {
                        gender = "Male";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'M' for Male or 'F' for Female:");
                    }
                }

                Console.WriteLine("Enter patient phone number:");
                string phoneNumber;
                while (true)
                {
                    phoneNumber = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(phoneNumber) && phoneNumber.All(char.IsDigit) && phoneNumber.Length == 10 && phoneNumber[0]=='0' && phoneNumber[1] == '5')
                        break;
                    Console.WriteLine("Invalid phone number. Please enter a valid number (10 digits, started by 05):");
                }

                Console.WriteLine("Enter patient address:");
                string address;
                while (true)
                {
                    address = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(address))
                        break;
                    Console.WriteLine("Address cannot be empty. Please enter a valid address:");
                }

                patientManagement.AddNewPatient(name, age, gender, phoneNumber, address);
                break;
            case "2":
                var pats = patientManagement.GetAllPatients();
                foreach(var p in pats)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine("Enter any key to back.");
                Console.ReadKey();
                break;
            case "3":
                Console.WriteLine("Enter the ID of the patient you want to update:");
                int patientId;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out patientId) && patientId > 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric patient ID:");
                }

                Console.WriteLine("Enter new patient name:");
                string name2;
                while (true)
                {
                    name2 = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(name2))
                        break;
                    Console.WriteLine("Name cannot be empty. Please enter a valid name:");
                }

                Console.WriteLine("Enter new patient age:");
                int age2;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out age2) && age2 >= 0 && age2 <= 120)
                        break;
                    Console.WriteLine("Invalid age. Please enter a valid age (0-120):");
                }

                Console.WriteLine("Enter a correct patient gender (M/F):");
                string gender2;
                while (true)
                {
                    gender2 = Console.ReadLine()?.Trim().ToUpper();
                    if (gender2 == "F")
                    {
                        gender2 = "Female";
                        break;
                    }
                    else if (gender2 == "M")
                    {
                        gender2 = "Male";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'M' for Male or 'F' for Female:");
                    }
                }

                Console.WriteLine("Enter new patient phone number:");
                string phoneNumber2;
                while (true)
                {
                    phoneNumber2 = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(phoneNumber2) && phoneNumber2.All(char.IsDigit) && phoneNumber2.Length == 10 && phoneNumber2[0] == '0' && phoneNumber2[1] == '5')
                        break;
                    Console.WriteLine("Invalid phone number. Please enter a valid number (10 digits, started by 05):");
                }

                Console.WriteLine("Enter new patient address:");
                string address2;
                while (true)
                {
                    address2 = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(address2))
                        break;
                    Console.WriteLine("Address cannot be empty. Please enter a valid address:");
                }
                patientManagement.UpdatePatient(patientId, name2, age2, gender2, phoneNumber2, address2);
                break;
            case "4":
                Console.WriteLine("Enter the ID of the patient you want to delete:");
                int patientId2;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out patientId2) && patientId2 > 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric patient ID:");
                }
                patientManagement.DeletePatient(patientId2);
                break;
            case "5":
                return; 
            default:
                Console.WriteLine("Invalid choice! Please select a valid option.");
                break;
        }
        PatientMenu(patientManagement);
    }

    private static void DoctorMenu(DoctorManagement doctorManagement)
    {
        Console.Clear();
        Console.WriteLine("===== Doctor Management =====");
        Console.WriteLine("1. Add Doctor");
        Console.WriteLine("2. View Doctors");
        Console.WriteLine("3. Update Doctor");
        Console.WriteLine("4. Delete Doctor");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter doctor name:");
                string name;
                while (true)
                {
                    name = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(name))
                        break;
                    Console.WriteLine("Name cannot be empty. Please enter a valid name:");
                }

                Console.WriteLine("Enter doctor age:");
                int age;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                        break;
                    Console.WriteLine("Invalid age. Please enter a valid age (> 0):");
                }

                Console.WriteLine("Enter doctor gender (M/F):");
                string gender;
                while (true)
                {
                    gender = Console.ReadLine()?.Trim().ToUpper();
                    if (gender == "F")
                    {
                        gender = "Female";
                        break;
                    }
                    else if (gender == "M")
                    {
                        gender = "Male";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'M' for Male or 'F' for Female:");
                    }
                }

                Console.WriteLine("Enter doctor email:");
                string email;
                while (true)
                {
                    email = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(email) && email.Contains("@"))
                        break;
                    Console.WriteLine("Invalid email. Please enter a valid email:");
                }

                Console.WriteLine("Enter doctor phone number:");
                string phoneNumber;
                while (true)
                {
                    phoneNumber = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(phoneNumber) && phoneNumber.All(char.IsDigit) && phoneNumber.Length == 10 && phoneNumber.StartsWith("05"))
                        break;
                    Console.WriteLine("Invalid phone number. Please enter a valid number (10 digits, started by 05):");
                }

                Console.WriteLine("Enter patient address:");
                string address;
                while (true)
                {
                    address = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(address))
                        break;
                    Console.WriteLine("Address cannot be empty. Please enter a valid address:");
                }

                Console.WriteLine("Enter doctor specialty:");
                string specialty;
                while (true)
                {
                    specialty = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(specialty))
                        break;
                    Console.WriteLine("Specialty cannot be empty. Please enter a valid specialty:");
                }

                doctorManagement.AddNewDoctor(name, age, gender, phoneNumber, address, email, specialty);
                break;
            case "2":
                var doctors = doctorManagement.GetAllDoctors();
                foreach (var doctor in doctors)
                {
                    Console.WriteLine(doctor.ToString());
                }
                Console.WriteLine("\nPress any key to back...");
                Console.ReadKey();
                break;
            case "3":
                Console.WriteLine("Enter the ID of the patient you want to update:");
                int doctorId;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out doctorId) && doctorId > 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric patient ID:");
                }

                Console.WriteLine("Enter new patient name:");
                string name2;
                while (true)
                {
                    name2 = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(name2))
                        break;
                    Console.WriteLine("Name cannot be empty. Please enter a valid name:");
                }

                Console.WriteLine("Enter new patient age:");
                int age2;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out age2) && age2 >= 0 && age2 <= 120)
                        break;
                    Console.WriteLine("Invalid age. Please enter a valid age (0-120):");
                }

                Console.WriteLine("Enter a correct patient gender (M/F):");
                string gender2;
                while (true)
                {
                    gender2 = Console.ReadLine()?.Trim().ToUpper();
                    if (gender2 == "F")
                    {
                        gender2 = "Female";
                        break;
                    }
                    else if (gender2 == "M")
                    {
                        gender2 = "Male";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'M' for Male or 'F' for Female:");
                    }
                }

                Console.WriteLine("Enter new patient phone number:");
                string phoneNumber2;
                while (true)
                {
                    phoneNumber2 = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(phoneNumber2) && phoneNumber2.All(char.IsDigit) && phoneNumber2.Length == 10 && phoneNumber2[0] == '0' && phoneNumber2[1] == '5')
                        break;
                    Console.WriteLine("Invalid phone number. Please enter a valid number (10 digits, started by 05):");
                }

                Console.WriteLine("Enter new patient address:");
                string address2;
                while (true)
                {
                    address2 = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(address2))
                        break;
                    Console.WriteLine("Address cannot be empty. Please enter a valid address:");
                }

                Console.WriteLine("Enter new patient address:");
                string email2;
                while (true)
                {
                    email2 = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(email2) && email2.Contains("@"))
                        break;
                    Console.WriteLine("Email cannot be empty. Please enter a valid address:");
                }

                Console.WriteLine("Enter new patient address:");
                string specialy2;
                while (true)
                {
                    specialy2 = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(specialy2))
                        break;
                    Console.WriteLine("Address cannot be empty. Please enter a valid address:");
                }


                doctorManagement.UpdateDoctor(doctorId, name2, age2, gender2, phoneNumber2, address2, email2, specialy2);
                break;
            case "4":
                Console.WriteLine("Enter the ID of the doctor you want to delete:");
                int doctorIdToDelete;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out doctorIdToDelete) && doctorIdToDelete > 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric doctor ID:");
                }
                doctorManagement.DeleteDoctor(doctorIdToDelete);
                break;
            case "5":
                return;
            default:
                Console.WriteLine("Invalid choice! Please select a valid option.");
                break;
        }
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
        DoctorMenu(doctorManagement);
    }

    private static void AppointmentMenu(AppointmentManagement appointmentManagement)
    {
        Console.Clear();
        Console.WriteLine("===== Appointment Management =====");
        Console.WriteLine("1. Schedule Appointment");
        Console.WriteLine("2. View Appointments by pateint Id");
        Console.WriteLine("3. View Appointments by doctor Id");
        Console.WriteLine("4. Update Appointments");
        Console.WriteLine("5. Cancel Appointment");
        Console.WriteLine("6. Back to Main Menu");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                // DateTime.ParseExact("23-4-2025 2 pm", Strings.DateTimeFormat, null)
                Console.WriteLine("Enter Patient ID:");
                int patientId;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out patientId) && patientId > 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Patient ID:");
                }

                Console.WriteLine("Enter Doctor ID:");
                int doctorId;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out doctorId) && doctorId > 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Doctor ID:");
                }

                Console.WriteLine("Enter Appointment Date (d-M-yyyy h tt):");
                DateTime appointmentDate;
                while (true)
                {
                    string dateInput = Console.ReadLine()?.Trim();
                    if (DateTime.TryParseExact(dateInput, "d-M-yyyy h tt", null, System.Globalization.DateTimeStyles.None, out appointmentDate))
                        break;
                    Console.WriteLine("Invalid format. Please enter the date in 'd-M-yyyy h tt' format (e.g., 5-3-2025 2 PM):");
                }

                appointmentManagement.ScheduleAppointment(patientId, doctorId, appointmentDate);
                break;
            case "2":
                Console.WriteLine("Enter Patient ID to view appointments:");
                int viewPatientId;
                while (!int.TryParse(Console.ReadLine(), out viewPatientId) || viewPatientId <= 0)
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Patient ID:");

                appointmentManagement.ViewScheduleByPatientId(viewPatientId);
               
                Console.WriteLine("\nPress any key to back...");
                Console.ReadKey();
                break;
            case "3":
                Console.WriteLine("Enter Patient ID to view appointments:");
                int viewDoctorId;
                while (!int.TryParse(Console.ReadLine(), out viewDoctorId) || viewDoctorId <= 0)
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Patient ID:");

                appointmentManagement.ViewScheduleByDoctorId(viewDoctorId);
                
                Console.WriteLine("\nPress any key to back...");
                Console.ReadKey();
                break;
            case "4":
                Console.WriteLine("Enter Appointment ID to update:");
                int appointmentId;
                while (!int.TryParse(Console.ReadLine(), out appointmentId) || appointmentId <= 0)
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Appointment ID:");

                Console.WriteLine("Enter patient ID to update:");
                int updatePAtientId;
                while (!int.TryParse(Console.ReadLine(), out updatePAtientId) || updatePAtientId <= 0)
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Patient ID:");

                Console.WriteLine("Enter Doctor ID to update:");
                int updateDoctorId;
                while (!int.TryParse(Console.ReadLine(), out updateDoctorId) || updateDoctorId <= 0)
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Doctor ID:");

                Console.WriteLine("Enter Appointment Date (d-M-yyyy h tt) to update:");
                DateTime updateAppointmentDate;
                while (true)
                {
                    string dateInput2 = Console.ReadLine()?.Trim();
                    if (DateTime.TryParseExact(dateInput2, "d-M-yyyy h tt", null, System.Globalization.DateTimeStyles.None, out updateAppointmentDate))
                        break;
                    Console.WriteLine("Invalid format. Please enter the date in 'd-M-yyyy h tt' format (e.g., 5-3-2025 2 PM):");
                }

                Console.WriteLine("Enter new Appointment Status (1 for Scheduled, 2 for Completed, 3 for Canceled):");
                int statusChoice;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out statusChoice) && statusChoice >= 1 && statusChoice <= 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid status (1 for Scheduled, 2 for Completed, 3 for Canceled):");
                    }
                }

                appointmentManagement.UpdateAppointment(appointmentId, updatePAtientId, updateDoctorId, updateAppointmentDate, statusChoice);
                break;
            case "5":
                Console.WriteLine("Enter Appointment ID to cancel:");
                int cancelAppointmentId;
                while (!int.TryParse(Console.ReadLine(), out cancelAppointmentId) || cancelAppointmentId <= 0)
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Appointment ID:");

                appointmentManagement.CancelAppointment(cancelAppointmentId);
                break;
            case "6":
                return;
            default:
                Console.WriteLine("Invalid choice! Please select a valid option.");
                break;
        }
        Console.WriteLine("\nPress any key to back...");
        Console.ReadKey();
        AppointmentMenu(appointmentManagement);
    }

    private static void PrescriptionMenu(PrescriptionManagement prescriptionManagement)
    {
        Console.Clear();
        Console.WriteLine("===== Prescription Management =====");
        Console.WriteLine("1. Issue Prescription");
        Console.WriteLine("2. View Prescriptions");
        Console.WriteLine("3. Update Prescriptions");
        Console.WriteLine("4. Delete Prescriptions");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter Patient ID:");
                int patientId;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out patientId) && patientId > 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Patient ID:");
                }

                Console.WriteLine("Enter Doctor ID:");
                int doctorId;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out doctorId) && doctorId > 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Doctor ID:");
                }

                Console.WriteLine("Enter at least one Medication ID (Enter 0 to stop after adding at least one):");
                List<int> medicationIds = new List<int>();
                while (true)
                {
                    Console.Write("Medication ID: ");
                    int medId;

                    if (int.TryParse(Console.ReadLine(), out medId) && medId > 0)
                    {
                        medicationIds.Add(medId);
                    }
                    else if (medId == 0 && medicationIds.Count > 0)
                    {
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid Medication ID.");
                    }
                }
                prescriptionManagement.IssuePrescription(patientId, doctorId, medicationIds);
                break;
            case "2":
                prescriptionManagement.ViewPrescriptions();
                Console.WriteLine("\nPress any key to return...");
                Console.ReadKey();
                break;
            case "3":
                Console.WriteLine("Enter Prescription ID:");
                int prescriptionId2;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out prescriptionId2) && prescriptionId2 > 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Prescription ID:");
                }

                Console.WriteLine("Enter Patient ID:");
                int patientId2;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out patientId2) && patientId2 > 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Patient ID:");
                }

                Console.WriteLine("Enter Doctor ID:");
                int doctorId2;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out doctorId2) && doctorId2 > 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Doctor ID:");
                }

                Console.WriteLine("Enter at least one Medication ID (Enter 0 to stop after adding at least one):");
                List<int> medicationIds2 = new List<int>();
                while (true)
                {
                    Console.Write("Medication ID: ");
                    int medId;

                    if (int.TryParse(Console.ReadLine(), out medId) && medId > 0)
                    {
                        medicationIds2.Add(medId);
                    }
                    else if (medId == 0 && medicationIds2.Count > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid Medication ID.");
                    }
                }

                prescriptionManagement.UpdatePrescription(prescriptionId2, patientId2, doctorId2, medicationIds2);
                break;
            case "4":
                Console.WriteLine("Enter Prescription ID:");
                int deletePreId;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out deletePreId) && deletePreId > 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Prescription ID:");
                }

                prescriptionManagement.DeleteDoctor(deletePreId);
                break;
            case "5":
                return;
            default:
                Console.WriteLine("Invalid choice! Please select a valid option.");
                break;
        }
        PrescriptionMenu(prescriptionManagement);
    }

    private static void MedicationMenu(MedicationManagement medicationManagement)
    {
        Console.Clear();
        Console.WriteLine("===== Medication Management =====");
        Console.WriteLine("1. Add Medication");
        Console.WriteLine("2. View Medications");
        Console.WriteLine("3. Update Medication");
        Console.WriteLine("4. Track Medication Inventory");
        Console.WriteLine("5. Delete Medication");
        Console.WriteLine("6. Back to Main Menu");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter medication name:");
                string name;
                while (true)
                {
                    name = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(name))
                        break;
                    Console.WriteLine("Name cannot be empty. Please enter a valid name:");
                }

                Console.WriteLine("Enter Medication Quantity:");
                int quantity;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 0)
                        break;
                    Console.WriteLine("Invalid quantity. Please enter a valid number:");
                }

                Console.WriteLine("Enter Medication Price (in decimal format):");
                decimal price;
                while (true)
                {
                    if (decimal.TryParse(Console.ReadLine(), out price) && price >= 0)
                        break;
                    Console.WriteLine("Invalid price. Please enter a valid decimal value:");
                }

                medicationManagement.AddMedication(name, quantity, price);
                break;
            case "2":
                medicationManagement.PrintAllMedications();
                break;
            case "3":
                Console.WriteLine("Enter Medication ID to update:");
                int medicationId;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out medicationId) && medicationId >= 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Medication ID:");
                }

                Console.WriteLine("Enter medication name:");
                string updatename;
                while (true)
                {
                    updatename = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(updatename))
                        break;
                    Console.WriteLine("Name cannot be empty. Please enter a valid name:");
                }

                Console.WriteLine("Enter Medication Quantity:");
                int updatequantity;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out updatequantity) && updatequantity >= 0)
                        break;
                    Console.WriteLine("Invalid quantity. Please enter a valid number:");
                }

                Console.WriteLine("Enter Medication Price (in decimal format):");
                decimal updateprice;
                while (true)
                {
                    if (decimal.TryParse(Console.ReadLine(), out updateprice) && updateprice >= 0)
                        break;
                    Console.WriteLine("Invalid price. Please enter a valid decimal value:");
                }

                medicationManagement.UpdateMedication(medicationId, updatename, updatequantity, updateprice);
                break;
            case "4":
                medicationManagement.TrackMedicationInventory();
                break;
            case "5":
                Console.WriteLine("Enter Medication ID to delete:");
                int DelmedicationId;
                while (true)
                {
                    // Validate if the input is a valid positive integer
                    if (int.TryParse(Console.ReadLine(), out DelmedicationId) && DelmedicationId > 0)
                        break;
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Medication ID:");
                }
                medicationManagement.DeleteMedication(DelmedicationId);
                break;
            case "6":
                return;
            default:
                Console.WriteLine("Invalid choice! Please select a valid option.");
                break;
        }
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
        MedicationMenu(medicationManagement);
    }

    private static void BillingMenu(BillingManagement billingManagement)
    {
        Console.Clear();
        Console.WriteLine("===== Billing Management =====");
        Console.WriteLine("1. View Bills");
        Console.WriteLine("2. Update Bill Status");
        Console.WriteLine("3. Back to Main Menu");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                billingManagement.ViewBills();
                break;
            case "2":
                Console.WriteLine("Enter Bill ID to update status:");
                int billId;
                while (!int.TryParse(Console.ReadLine(), out billId) || billId <= 0)
                    Console.WriteLine("Invalid ID. Please enter a valid numeric Bill ID:");

                Console.WriteLine("Enter new status (1 for Paid, 2 for Unpaid):");
                int statusChoice;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out statusChoice) && (statusChoice == 1 || statusChoice == 2))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 1 for Paid or 2 for Unpaid.");
                    }
                }
                billingManagement.UpdateBillStatus(billId, statusChoice);
                break;
            case "3":
                return;
            default:
                Console.WriteLine("Invalid choice! Please select a valid option.");
                break;
        }
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
        BillingMenu(billingManagement);
    }

    
}
