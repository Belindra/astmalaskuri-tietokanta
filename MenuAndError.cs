﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Asthma_Calc
{
    class MenuAndError
    {
        public static int Menu()
        {
            Console.WriteLine("1. Katso jäljellä olevat annosmäärät");
            Console.WriteLine("2. Kirjaa käyttämäsi lääke");
            Console.WriteLine("3. Resetoi käyttämäsi lääke");
            Console.WriteLine("4. Lopeta");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return choice;
        }

        public static void PrintError()
        {
            Console.WriteLine("Painoit väärää nappia, pässi");
        }
    }
}