using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Managements
{
    public class AppointmentManagement
    {
        private readonly HMSDBContext context;

        public AppointmentManagement() 
        {
            context = new HMSDBContext();
        }

        public void ScheduleAppointment(int patientId, int doctorId, DateTime datetime)
        {
            var patient = context.Patients.FirstOrDefault(p => p.Id == patientId);

            if (patient == null)
            {
                Console.WriteLine($"There is no any patient with {patientId} ID!");
                return;
            }

            var doctor = context.Doctors.FirstOrDefault(p => p.Id == doctorId);

            if (doctor == null)
            {
                Console.WriteLine($"There is no any doctor with {doctorId} ID!");
                return;
            }

            bool isDoctorAvailiable = context.Appointments.Any(d => d.DoctorId == doctorId && d.AppointmentDate.Equals(datetime));

            if (isDoctorAvailiable)
            {
                Console.WriteLine($"Doctor {doctor.Name} is not available at {datetime}");
                return;
            }

            bool hasPatientSchedule = context.Appointments.Any(d => d.PatientId == patientId && d.AppointmentDate.Equals(datetime));

            if (hasPatientSchedule)
            {
                Console.WriteLine($"Patient {patient.Name} is not available at {datetime}");
                return;
            }

            context.Appointments.Add(new Entities.Appointment 
            { 
                AppointmentDate = datetime, 
                Patient = patient, 
                Doctor = doctor, 
                Status = AppointmentStatus.Scheduled 
            });
            context.SaveChanges();
            Console.WriteLine("Appointment scheduled successfully!");
        }
    
        public void ViewScheduleByPatientId(int patientId)
        {
            bool isPatient = context.Appointments.Any(p => p.PatientId == patientId);

            if (!isPatient)
            {
                Console.WriteLine($"There is no any patient with {patientId} ID!");
                return;
            }

            var appointments = context.Appointments.Include(p => p.Patient).Where(p => p.PatientId == patientId).AsNoTracking().ToList();

            if (appointments.Count > 0)
            {
                Console.WriteLine($"{appointments[0].Patient.Name}'s Appointments:");
                foreach (var app in appointments)
                {
                    Console.WriteLine(app.ToString());
                }
            }
            else
            {
                Console.WriteLine("No appointments found for this patient.");
            }
        }

        public void ViewScheduleByDoctorId(int doctorId)
        {
            bool isDoctor = context.Appointments.Any(p => p.DoctorId == doctorId);

            if (!isDoctor)
            {
                Console.WriteLine($"There is no any patient with {doctorId} ID!");
                return;
            }

            var appointments = context.Appointments.Include(p => p.Doctor).Where(p => p.DoctorId == doctorId).AsNoTracking().ToList();

            if (appointments.Count > 0)
            {
                Console.WriteLine($"{appointments[0].Doctor.Name}'s Appointments:");
                foreach (var app in appointments)
                {
                    Console.WriteLine(app.ToString());
                }
            }
            else
            {
                Console.WriteLine("No appointments found for this doctor.");
            }
        }

        public void CancelAppointment(int id)
        {
            var appointment = context.Appointments.FirstOrDefault(p => p.AppointmentId == id);

            if (appointment == null) 
            {
                Console.WriteLine($"There is no any appointment with {id} ID!");
            }

            appointment.Status = AppointmentStatus.Canceled;
            context.SaveChanges();
            Console.WriteLine("Appointment canceled successfully!");
        }

        public void UpdateAppointment(int id, int patientId, int doctorId, DateTime datetime, int status)
        {
            var appointment = context.Appointments.FirstOrDefault(a => a.AppointmentId == id);

            if (appointment is null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }

            appointment.PatientId = patientId;
            appointment.DoctorId = doctorId;
            appointment.AppointmentDate = datetime;
            appointment.Status = (AppointmentStatus)status;

            context.SaveChanges();
            Console.WriteLine("Appointment updated successfully.");
        }
    }
}
