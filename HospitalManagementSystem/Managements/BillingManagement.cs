using HospitalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Managements
{
    public class BillingManagement
    {
        private readonly HMSDBContext context;

        public BillingManagement() 
        {
            context = new HMSDBContext();
        }

        public void ViewBills()
        {
            var bills = context.Bills.ToList();

            if(bills.Count > 0 )
            {
                foreach (var bill in bills)
                {
                    Console.WriteLine(bill.ToString());
                }
            }
        }

        public void UpdateBillStatus(int id, int status)
        {
            var bill = context.Bills.FirstOrDefault(b => b.BillId == id);

            if (bill == null)
            {
                Console.WriteLine("Bill not found.");
                return;
            }

            bill.Status = (BillStatus)status;
            context.SaveChanges();
            Console.WriteLine("Bill Status updated successfully.");
        }
    }
}
