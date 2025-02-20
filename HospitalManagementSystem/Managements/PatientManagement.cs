using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Managements
{
    public class PatientManagement
    {
        private readonly HMSDBContext context;
        public PatientManagement() 
        {
            context = new HMSDBContext();
        }

        public List<Patient> GetAllPatients()
        {
            return context.Patients.AsNoTracking().ToList();
        }

        //public Patient GetPatientById(int id)
        //{
        //    return context.Patients.FirstOrDefault(p => p.Id == id);
        //}

        public void AddNewPatient(string name, int age, string gender, string contactNumber, string address)
        {
            context.Patients.Add(new Patient
            {
                Name = name,
                Age = age,
                Gender = gender,
                ContactNumber = contactNumber,
                Address = address
            });
            context.SaveChanges();
            Console.WriteLine("Patient added successfully.");
        }

        public void UpdatePatient(int patientId, string name, int age, string gender, string contactNumber, string address)
        {
            var patient = context.Patients.FirstOrDefault(p => p.Id == patientId);

            if (patient is null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            patient.Name = name;
            patient.Age = age;
            patient.Gender = gender;
            patient.ContactNumber = contactNumber;
            patient.Address = address;

            context.SaveChanges();
            Console.WriteLine("Patient updated successfully.");
        }

        public void DeletePatient(int patientId)
        {
            var patient = context.Patients.FirstOrDefault(p => p.Id == patientId);

            if (patient is null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            context.Patients.Remove(patient);
            context.SaveChanges();
            Console.WriteLine("Patient deleted successfully.");
        }

    }
}
