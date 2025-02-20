using HospitalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Managements
{
    public class MedicationManagement
    {
        private readonly HMSDBContext context;
        public MedicationManagement()
        {
            context = new HMSDBContext();
        }

        public void PrintAllMedications()
        {
            var m = context.Medications.ToList();
            foreach (var item in m)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void AddMedication(string name, int quantity, decimal price)
        {
            var medication = new Medication
            {
                Name = name,
                Quantity = quantity,
                Price = price
            };

            context.Medications.Add(medication);
            context.SaveChanges();
            Console.WriteLine("Medication added successfully.");
        }

        public void UpdateMedication(int medicationId, string name, int quantity, decimal price)
        {
            var medication = context.Medications.FirstOrDefault(m => m.MedicationId == medicationId);

            if (medication == null)
            {
                Console.WriteLine("Medication not found.");
                return;
            }

            medication.Name = name;
            medication.Quantity = quantity;
            medication.Price = price;

            context.SaveChanges();
            Console.WriteLine("Medication updated successfully.");
        }

        public void TrackMedicationInventory()
        {
            var medications = context.Medications.ToList();
            foreach (var medication in medications)
            {
                Console.WriteLine($"Id: {medication.MedicationId}, Name: {medication.Name}, Quantity: {medication.Quantity}");
            }
        }

        public void DeleteMedication(int id) 
        {
            var med = context.Medications.FirstOrDefault(p => p.MedicationId == id);

            if (med is null)
            {
                Console.WriteLine("Medication not found.");
                return;
            }

            context.Medications.Remove(med);
            context.SaveChanges();
            Console.WriteLine("Medication deleted successfully.");
        }
    }
}
