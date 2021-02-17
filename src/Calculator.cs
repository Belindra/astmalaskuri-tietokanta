using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Asthma_Calc
{
    class Calculator
    {
        int exit = 0;
        public void Medicine()
        {
            Console.WriteLine("Lunan astmalääkelaskuri\n");
            Console.WriteLine("Versio 2.1\n");

            //using (var context2 = new MedicineContext())
            //{
            //    var lastEvent = new EventInfo()
            //        .Where(m => m.Date == m.Date.Max)
            //        .ToList();
            //}

            var flixotide = Database.ReadingDatabase(2);
            var ventoline = Database.ReadingDatabase(3);

            do
            {
                int choice = MenuAndError.Menu();

                switch (choice)
                {
                    case 1:
                        int unusedvl = Convert.ToInt32(ventoline[0].TotalPortion) - Convert.ToInt32(ventoline[0].UsedPortion);
                        int unusedfx = Convert.ToInt32(flixotide[0].TotalPortion) - Convert.ToInt32(flixotide[0].UsedPortion);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"Flixotidea on jäljellä {unusedfx} annosta,");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write($"Ventolinea on jäljellä {unusedvl} annosta\n\n");
                        Console.ResetColor();
                        break;
                    case 2:
                        Console.WriteLine("Kumpaa astmalääkettä käytit?\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("1. Flixotide");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("2. Ventoline");
                        Console.ResetColor();
                        int medicine = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("Kuinka monta annosta otit?\n");
                        Console.WriteLine("1");
                        Console.WriteLine("2");
                        int portion = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        if (medicine == 1)
                        {
                            if (portion == 1)
                            {
                                flixotide[0].UsedPortion = Convert.ToInt32(flixotide[0].UsedPortion) + 1;
                                int unused = flixotide[0].TotalPortion - flixotide[0].UsedPortion;
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"Flixotidea on jäljellä {unused} annosta\n");
                                Console.ResetColor();

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

                            else if (portion == 2)
                            {
                                flixotide[0].UsedPortion = Convert.ToInt32(flixotide[0].UsedPortion) + 2;
                                int unused = flixotide[0].TotalPortion - flixotide[0].UsedPortion;
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"Flixotidea on jäljellä {unused} annosta\n");
                                Console.ResetColor();

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

                            else
                                MenuAndError.PrintError();
                        }

                        else if (medicine == 2)
                        {
                            if (portion == 1)
                            {
                                ventoline[0].UsedPortion = Convert.ToInt32(ventoline[0].UsedPortion) + 1;
                                int unused = ventoline[0].TotalPortion - ventoline[0].UsedPortion;
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine($"Ventolinea on jäljellä {unused} annosta\n");
                                Console.ResetColor();

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

                            else if (portion == 2)
                            {
                                ventoline[0].UsedPortion = Convert.ToInt32(ventoline[0].UsedPortion) + 2;
                                int unused = ventoline[0].TotalPortion - ventoline[0].UsedPortion;
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine($"Ventolinea on jäljellä {unused} annosta\n");
                                Console.ResetColor();

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

                            else
                            {
                                MenuAndError.PrintError();
                            }
                        }

                        else
                        {
                            MenuAndError.PrintError();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Kumman lääkkeen haluat resetoida?\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("1. Flixotide");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("2. Ventoline");
                        Console.ResetColor();
                        int reset = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        if (reset == 1)
                        {
                            flixotide[0].UsedPortion = 0;
                        }

                        else
                        {
                            ventoline[0].UsedPortion = 0;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Ohjelma loppuu. Mene pois");
                        exit = 1;
                        break;
                    default:
                        Console.WriteLine("Väärä valinta, yritä uudelleen");
                        break;
                }
            }
            while (exit == 0);
            //Database.SavingToDatabase();
        }
    }
}