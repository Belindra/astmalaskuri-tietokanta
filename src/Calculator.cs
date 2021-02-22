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
            var context = new MedicineContext();
            Console.WriteLine("Lunan astmalääkelaskuri versio 2.0\n");
            Console.WriteLine("Flixotidea kirjattu viimeksi " + Database.GettingDate(2));
            Console.WriteLine("Ventolinea kirjattu viimeksi " + Database.GettingDate(3));
            Console.Write("\n");

            var flixotide =  context.MedicineInfo
                    .Where(f => f.MedicineId == 2)
                    .ToList();

            var ventoline = context.MedicineInfo
                    .Where(f => f.MedicineId == 3)
                    .ToList();

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
                                context.SaveChanges();

                                Database.SavingFlixotide(flixotide, portion);

                            }

                            else if (portion == 2)
                            {
                                flixotide[0].UsedPortion = Convert.ToInt32(flixotide[0].UsedPortion) + 2;
                                int unused = flixotide[0].TotalPortion - flixotide[0].UsedPortion;
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"Flixotidea on jäljellä {unused} annosta\n");
                                Console.ResetColor();
                                context.SaveChanges();

                                Database.SavingFlixotide(flixotide, portion);
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
                                context.SaveChanges();

                                Database.SavingVentoline(ventoline, portion);

                            }

                            else if (portion == 2)
                            {
                                ventoline[0].UsedPortion = Convert.ToInt32(ventoline[0].UsedPortion) + 2;
                                int unused = ventoline[0].TotalPortion - ventoline[0].UsedPortion;
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine($"Ventolinea on jäljellä {unused} annosta\n");
                                Console.ResetColor();
                                context.SaveChanges();

                                Database.SavingVentoline(ventoline, portion);
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
                            context.SaveChanges();
                        }

                        else
                        {
                            ventoline[0].UsedPortion = 0;
                            context.SaveChanges();
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
        }
    }
}
