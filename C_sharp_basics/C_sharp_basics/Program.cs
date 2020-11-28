using System;
using System.Collections.Generic;

namespace C_sharp_basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Ispis cijele liste");
            Console.WriteLine("2 - Ispis imena pjesme unosom pripadajućeg rednog broja");
            Console.WriteLine("3 - Ispis rednog broja pjesme unosom pripadajućeg imena");
            Console.WriteLine("4 - Unos nove pjesme");
            Console.WriteLine("5 - Brisanje pjesme po rednom broju");
            Console.WriteLine("6 - Brisanje pjesme po imenu");
            Console.WriteLine("7 - Brisanje cijele liste");
            Console.WriteLine("8 - Uređivanje imena pjesme");
            Console.WriteLine("9 - Uređivanje rednog broja pjesme");
            Console.WriteLine("0 - Izlaz iz aplikacije");

            var choiceOfAction = int.Parse(Console.ReadLine());

            var playlist = new Dictionary<int, string>()
            {
                { 1, "Chris Isaak - Wicked game" },
                { 2, "Queen - Bohemian rhapsody" },
                { 3, "Foo Fighters - Best of you" },
                { 4, "Oliver - Jubav iza kantuna" },
                { 5, "Guns N' Roses - Don't cry" },
                { 6, "Scorpions - Still loving you" },
                { 7, "Gibonni - Zlatne godine" },
                { 8, "U2 - I still haven't found what I'm looking for" },
                { 9, "Dalmatino - Lozje" },
                { 10, "Kings Of Leon - Use somebody" }
            };

        }
    }
}
