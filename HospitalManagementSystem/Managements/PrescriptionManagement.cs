using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Managements
{
    public class PrescriptionManagement
    {
        private readonly HMSDBContext context;
        public PrescriptionManagement() 
        {
            context = new HMSDBContext();
        }

        public void IssuePrescription(int patientId, int doctorId, List<int> medicationIds)
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

            var totalPrice = 0m;
            var medicationAvaliables = new List<Medication>();
            for (int i = 0; i < medicationIds.Count; i++) 
            { 
                var medication = context.Medications.FirstOrDefault(p => p.MedicationId == medicationIds[i]);

                if (medication == null)
                {
                    Console.WriteLine($"There is no any medication with {medicationIds[i]} ID!");
                }
                else
                {
                    if(medication.Quantity <= 0)
                    {
                        Console.WriteLine($"The Quantity of medication with {medicationIds[i]} ID is ZERO!");
                    }
                    else
                    {
                        totalPrice += medication.Price;
                        medication.Quantity --;
                        medicationAvaliables.Add(medication);
                    }
                }
                
            }

            context.Prescriptions.Add(new Prescription
            {
                PrescriptionDate = DateTime.Now,
                DoctorId = doctorId,
                PatientId = patientId,
                Medications = medicationAvaliables
            });

            //context.Bills.Add(new Bill
            //{
            //    PrescriptionId = patientId,
            //});

            context.SaveChanges();

        }
    
        public void ViewPrescriptions()
        {
            var prescriptions = context.Prescriptions.AsNoTracking().ToList();
            foreach (var prescription in prescriptions)
            {
                Console.WriteLine(prescription.ToString());
            }
        }


    }
}
