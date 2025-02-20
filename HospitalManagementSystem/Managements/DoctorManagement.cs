using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Managements
{
    public class DoctorManagement
    {
        private readonly HMSDBContext context;
        public DoctorManagement()
        {
            context = new HMSDBContext();
        }

        public List<Doctor> GetAllDoctors()
        {
            return context.Doctors.AsNoTracking().ToList();
        }

        public void AddNewDoctor(string name, int age, string gender, string contactNumber, string address, string email, string specialty)
        {
            context.Doctors.Add(new Doctor
            {
                Name = name,
                Age = age,
                Gender = gender,
                ContactNumber = contactNumber,
                Address = address,
                Email = email,
                Specialty = specialty
            });
            context.SaveChanges();
            Console.WriteLine("Doctor added successfully.");
        }

        public void UpdateDoctor(int doctorId, string name, int age, string gender, string contactNumber, string address, string email, string specialty)
        {
            var doctor = context.Doctors.FirstOrDefault(p => p.Id == doctorId);

            if (doctor is null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            doctor.Name = name;
            doctor.Age = age;
            doctor.Gender = gender;
            doctor.ContactNumber = contactNumber;
            doctor.Address = address;
            doctor.Email = email;
            doctor.Specialty = specialty;

            context.SaveChanges();
            Console.WriteLine("Doctor updated successfully.");
        }

        public void DeleteDoctor(int doctorId)
        {
            var doctor = context.Doctors.FirstOrDefault(p => p.Id == doctorId);

            if (doctor is null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            context.Doctors.Remove(doctor);
            context.SaveChanges();
            Console.WriteLine("Doctor deleted successfully.");
        }

    }
}
