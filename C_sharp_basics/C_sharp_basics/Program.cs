using System;
using System.Collections.Generic;
using System.Linq;

namespace C_sharp_basics
{
    class Program
    {
        static void Main(string[] args)
        {
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

            var mainVariable = Menu();

            while (mainVariable != 0)
            {
                switch (mainVariable)
                {
                    case 1:
                        Console.WriteLine("Lista svih pjesama");
                        foreach (var pair in playlist)
                        {
                            Console.WriteLine(pair.Key + " " + pair.Value);
                        }
                        mainVariable = Decision();
                        break;
                    case 2:
                        Console.WriteLine("Upišite redni broj pjesme koju želite odabrati.");
                        var songNumber = int.Parse(Console.ReadLine());
                        if (songNumber <= playlist.Count && songNumber > 0)
                        {
                            Console.WriteLine(playlist[songNumber]);
                            mainVariable = Decision();
                        }
                        else
                        {
                            Console.WriteLine("Zatražena pjesma ne postoji u listi");
                            mainVariable = Decision();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Upišite ime pjesme koju želite odabrati.");
                        var songName = Console.ReadLine();
                        var controlCounter = 0;
                        foreach (var pair in playlist)
                        {
                            bool equality1 = pair.Value.Equals(songName, StringComparison.OrdinalIgnoreCase);
                            if (equality1 == true)
                            {
                                Console.WriteLine($"Zatražena pjesma nalazi se pod rednim brojem: {pair.Key}");
                            }
                            else
                            {
                                controlCounter++;
                            }
                        }
                        if (controlCounter >= playlist.Count)
                        {
                            Console.WriteLine("Zatražena pjesma ne postoji u listi");
                        }
                        mainVariable = Decision();
                        break;
                    case 4:
                        Console.WriteLine("Unesite ime pjesme koju želite dodati.");
                        var newSongName = Console.ReadLine();
                        foreach (var pair in playlist)
                        {
                            if (pair.Value == newSongName)
                            {
                                Console.WriteLine("Nemoguće dodati pjesmu, pjesma je već u listi.");
                                Decision();
                            }
                            else
                            {
                                playlist.Add(playlist.Count + 1, newSongName);
                            }
                        }
                        foreach (var pair in playlist)
                        {
                            Console.WriteLine(pair.Key + " " + pair.Value);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Unesite redni broj pjesme koju želite izbrisati.");
                        var deleteSongNumber = int.Parse(Console.ReadLine());
                        var helpVariable = 0;
                        var addition = 0;
                        Console.WriteLine("Odabrali ste opciju brisanja pjesme. Jeste li sigurni da želite nastaviti s ovom akcijom? (da/ne)");
                        var answer1 = Console.ReadLine();
                        if (answer1 == "da")
                        {
                            foreach (var pair in playlist)
                            {
                                if (pair.Key == deleteSongNumber)
                                {
                                    playlist.Remove(pair.Key);
                                }
                                else if (pair.Key > deleteSongNumber)
                                {
                                    playlist.Add(deleteSongNumber + addition, pair.Value);
                                    playlist.Remove(pair.Key);
                                }
                                else
                                {
                                    helpVariable = helpVariable++;
                                }
                                addition = addition++;
                            }
                            if (helpVariable == playlist.Count)
                            {
                                Console.WriteLine("Zatražena pjesma ne postoji u listi");
                                Decision();
                            }
                            foreach (var pair in playlist)
                            {
                                Console.WriteLine(pair.Key + " " + pair.Value);
                            }
                        }
                        else
                        {
                            Decision();
                        }
                        break;
                    case 6:
                        Console.WriteLine("Unesite ime pjesme koju želite izbrisati.");
                        var deleteSongName = Console.ReadLine();
                        var keyCounter = 0;
                        Console.WriteLine("Odabrali ste opciju brisanja pjesme. Jeste li sigurni da želite nastaviti s ovom akcijom? (da/ne)");
                        var answer2 = Console.ReadLine();
                        if (answer2 == "da")
                        {
                            foreach (var pair in playlist)
                            {
                                if (pair.Value == deleteSongName)
                                {
                                    playlist.Remove(pair.Key);
                                    playlist.Add(pair.Key + keyCounter, playlist[(pair.Key) + keyCounter + 1]);
                                    keyCounter = keyCounter++;
                                }
                                else
                                {
                                    keyCounter = 0;
                                }

                            }
                            if (keyCounter == 0)
                            {
                                Console.WriteLine("Zatražena pjesma ne postoji u listi");
                                Decision();
                            }
                        }
                        else
                        {
                            Decision();
                        }
                        break;
                    case 7:
                        Console.WriteLine("Odabrali ste opciju brisanja cijele liste. Jeste li sigurni da želite nastaviti s ovom akcijom? (da/ne)");
                        var answer = Console.ReadLine();
                        if (answer == "da")
                        {
                            playlist.Clear();
                        }
                        else
                        {
                            Decision();
                        }
                        break;
                    case 8:
                        Console.WriteLine("Unesite broj pjesme kojoj želite promijeniti ime.");
                        var changeName = int.Parse(Console.ReadLine());
                        foreach (var pair in playlist)
                        {
                            if (pair.Value == playlist[changeName])
                            {
                                Console.WriteLine("Unesite novo ime kako želite preimenovati pjesmu.");
                                var newName = Console.ReadLine();
                                (playlist[changeName]) = newName;
                            }
                            else
                            {
                                Console.WriteLine("Zatraženi broj ne postoji u listi");
                                Decision();
                            }
                        }
                        break;
                    case 9:
                        Console.WriteLine("Unesite broj pjesme kojoj želite promijeniti mjesto.");
                        var changeNumber = int.Parse(Console.ReadLine());
                        foreach (var pair in playlist)
                        {
                            if (pair.Key == changeNumber)
                            {
                                Console.WriteLine("Unesite novi redni broj na koji želite premjestiti pjesmu.");
                                var newNumber = int.Parse(Console.ReadLine());
                                var keeper = playlist[newNumber];
                                playlist[newNumber] = playlist[changeNumber];
                                for (var i = 0; i < Math.Abs(newNumber - changeNumber); i++)
                                {
                                    playlist[changeNumber - i] = playlist[changeNumber - i - 1];
                                }
                            }
                            else if (changeNumber > playlist.Count)
                            {
                                Console.WriteLine("Zatraženi broj ne postoji u listi");
                                Decision();
                            }
                        }
                        foreach (var pair in playlist)
                        {
                            Console.WriteLine(pair.Key + " " + pair.Value);
                        }
                        break;
                    case 10:
                        Console.WriteLine("Shuffle pjesama.");
                        var ListOfKeys = new List<int>() { };
                        foreach (var pair in playlist)
                        {
                            ListOfKeys.Add(pair.Key);
                        }
                        var shuffled = ListOfKeys.OrderBy(x => Guid.NewGuid()).ToList();
                        var ShuffledMix = new Dictionary<int, string>() { };
                        foreach (var element in shuffled)
                        {
                            ShuffledMix.Add(element, playlist[element]);
                        }
                        foreach (var pair in ShuffledMix)
                        {
                            Console.WriteLine(pair.Key + " " + pair.Value);
                        }
                        break;
                    default:
                        break;
                }
                if (mainVariable == 100)
                {
                    break;
                }
                mainVariable = Menu();
                if (mainVariable == 0)
                {
                    break;
                }
            }


                

            static int Menu()
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
                Console.WriteLine("10 - Shuffle pjesama");
                Console.WriteLine("0 - Izlaz iz aplikacije");

                var choiceOfAction = int.Parse(Console.ReadLine());

                return choiceOfAction;

            }

            static int Decision()
            {
                Console.WriteLine("Povratak na izbornik?(da/ne)");
                var goBack = Console.ReadLine();
                bool equality = goBack.Equals("da", StringComparison.OrdinalIgnoreCase);
                if (equality == true)
                {
                    var finalDecision = 0;
                    return finalDecision;
                }
                else
                {
                    Console.WriteLine("Kraj programa");
                    var finalDecision = 100;
                    return finalDecision;
                }
            }
        }
    }
}



