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

        public static string  GettingDate(int medId)
        {
            var context = new MedicineContext();
            var time = context.EventInfo
                .Where(t => t.MedicineId == medId)
                .ToList();

            var medEntryTime = Convert.ToString(time[time.Count - 1].Date);
            return medEntryTime;
        }

        public static void SavingFlixotide(List<MedicineInfo> flixotide, int portion)
        {
            using (var context = new MedicineContext())
            {
                var medEventEntry = new EventInfo()
                {
                    MedicineId = flixotide[0].MedicineId,
                    UsedPortionNow = portion,
                    Date = DateTime.Now
                };

                context.EventInfo.Add(medEventEntry);
                context.SaveChanges();
            }
        }


        public static void SavingVentoline(List<MedicineInfo> ventoline, int portion)
        {
            using (var context = new MedicineContext())
            {
                var medEventEntry = new EventInfo()
                {
                    MedicineId = ventoline[0].MedicineId,
                    UsedPortionNow = portion,
                    Date = DateTime.Now
                };

                context.EventInfo.Add(medEventEntry);
                context.SaveChanges();
            }
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