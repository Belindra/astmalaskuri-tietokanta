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
        public static async Task ReadingDatabase()
        {
            var context = new MedicineContext();
            var flixotide = await context.MedicineInfo
                    .Where(f => f.MedicineId == 2)
                    .ToListAsync();

            var ventoline = await context.MedicineInfo
                    .Where(v => v.MedicineId == 3)
                    .ToListAsync();

            foreach (var f in flixotide)
            {
                Console.WriteLine(f.MedicineName);
                Console.WriteLine(f.TotalPortion);
            }

            foreach (var v in ventoline)
            {
                Console.WriteLine(v.MedicineName);
                Console.WriteLine(v.TotalPortion);
            }


            //Console.WriteLine(ventoline);
        }
        //public static string GetFlixotide()
        //{
        //    return "Flixotide";
        //}

        //public static string GetVentoline()
        //{
        //    return "Ventoline";
        //}
        //public static async Task WritingToDatabase()
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