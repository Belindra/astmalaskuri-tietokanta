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

            List<string> medicine2 = new List<string>();

            foreach (var m in medicine)
            {
                medicine2.Add(Convert.ToString(m.MedicineId));
                medicine2.Add(Convert.ToString(m.MedicineName));
                medicine2.Add(Convert.ToString(m.TotalPortion));
                medicine2.Add(Convert.ToString(m.UsedPortion));
            }
            return medicine;
        }

        //public static async Task SavingToDatabase()
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