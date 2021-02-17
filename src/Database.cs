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