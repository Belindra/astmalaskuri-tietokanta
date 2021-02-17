using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Asthma_Calc
{
    class Database
    {
        public static List<MedicineInfo> ReadingDatabase(int medId)
        {
            var context = new MedicineContext();
            var medicine = context.MedicineInfo
                    .Where(f => f.MedicineId == medId)
                    .ToList();

            return medicine;
        }

        public static List<EventInfo> GettingDate(int medId)
        {
            var context = new MedicineContext();
            var time = context.EventInfo
                .Where(t => t.MedicineId == medId)
                .ToList();       

            foreach (var item in time)
            {
                Console.WriteLine(item.Date);
            }
            return time;
        }
        

        //public static SavingToDatabase()
        //{
        //    using (var context = new MedicineContext())
        //    {
        //        var medicineInfoEntry = new MedicineInfo()
        //        {

        //        };
        //    }
        //}
    }
}