using System;

namespace Asthma_Calc
{
    public class Program
    {
        static void Main(string[] args)
        {
            Calculator calc1 = new Calculator();
            calc1.Medicine();
            //var flixotide = Database.ReadingDatabase(2);
            //System.Threading.Thread.Sleep(1000);
            //var ventoline = Database.ReadingDatabase(3);

            //foreach (var f in flixotide)
            //{
            //    Console.WriteLine(f.MedicineName);
            //    Console.WriteLine(f.TotalPortion);
            //}
            //Console.WriteLine(flixotide.Result);
            Console.ReadKey();
        }
    }
}
