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
                        var secondCounter = 0;
                        foreach (var pair in playlist)
                        {
                            bool equality2 = pair.Value.Equals(newSongName, StringComparison.OrdinalIgnoreCase);
                            if (equality2 == true)
                            {
                                Console.WriteLine("Nemoguće dodati pjesmu, pjesma je već u listi.");
                                mainVariable = Decision();
                            }
                            else
                            {
                                secondCounter++;
                            }
                        }
                        if (secondCounter == playlist.Count)
                        {
                            playlist.Add(playlist.Count + 1, newSongName);
                            Console.WriteLine("Ažuriran popis pjesama.");
                            foreach (var pair in playlist)
                            {
                                Console.WriteLine(pair.Key + " " + pair.Value);
                            }
                        }
                        mainVariable = Decision();
                        break;
                    case 5:
                        Console.WriteLine("Unesite redni broj pjesme koju želite izbrisati.");
                        var deleteSongNumber = int.Parse(Console.ReadLine());
                        var checkingVariable = 0;
                        var helpVariable = 0;
                        Console.WriteLine("Odabrali ste opciju brisanja pjesme. Jeste li sigurni da želite nastaviti s ovom akcijom? (da/ne)");
                        var answer1 = Console.ReadLine();
                        bool equality = answer1.Equals("da", StringComparison.OrdinalIgnoreCase);
                        if (equality == true)
                        {
                            for (var i = 1; i <= playlist.Count; i++)
                            {
                                if (i == deleteSongNumber)
                                {
                                    checkingVariable = i;
                                }
                                else
                                {
                                    helpVariable = helpVariable++;
                                }
                            }
                            if (helpVariable == playlist.Count)
                            {
                                Console.WriteLine("Zatražena pjesma ne postoji u listi");
                                mainVariable = Decision();
                            }
                            else
                            {
                                playlist.Remove(checkingVariable);
                                playlist.Add(checkingVariable, playlist[checkingVariable + 1]);
                                for (var i = checkingVariable + 1; i <= playlist.Count; i++)
                                {
                                    playlist[i - 1] = playlist[i];
                                }
                                playlist.Remove(playlist.Count);
                                Console.WriteLine("Ažurirana lista pjesama.");
                                foreach (var pair in playlist)
                                {
                                    Console.WriteLine(pair.Key + " " + pair.Value);
                                }
                                mainVariable = Decision();
                            }
                        }
                        else
                        {
                            mainVariable = Decision();
                        }
                        break;
                    case 6:
                        Console.WriteLine("Unesite ime pjesme koju želite izbrisati.");
                        var deleteSongName = Console.ReadLine();
                        var songToDelete = 0;
                        var keyCounter = 0;
                        Console.WriteLine("Odabrali ste opciju brisanja pjesme. Jeste li sigurni da želite nastaviti s ovom akcijom? (da/ne)");
                        var answer2 = Console.ReadLine();
                        bool equality3 = answer2.Equals("da", StringComparison.OrdinalIgnoreCase);
                        if (equality3 == true)
                        {
                            foreach (var pair in playlist)
                            {
                                bool equality4 = pair.Value.Equals(deleteSongName, StringComparison.OrdinalIgnoreCase);
                                if (equality4 == true)
                                {
                                    songToDelete = pair.Key;
                                }
                                else
                                {
                                    keyCounter++;
                                }
                            }
                            if (keyCounter == playlist.Count)
                            {
                                Console.WriteLine("Zatražena pjesma ne postoji u listi");
                                mainVariable = Decision();
                            }
                            else
                            {
                                playlist.Remove(songToDelete);
                                playlist.Add(songToDelete, playlist[songToDelete + 1]);
                                for (var i = songToDelete + 1; i <= playlist.Count; i++)
                                {
                                    playlist[i - 1] = playlist[i];
                                }
                                playlist.Remove(playlist.Count);
                                Console.WriteLine("Ažurirana lista pjesama.");
                                foreach (var pair in playlist)
                                {
                                    Console.WriteLine(pair.Key + " " + pair.Value);
                                }
                                mainVariable = Decision();
                            }
                        }
                        else
                        {
                            mainVariable = Decision();
                        }
                        break;
                    case 7:
                        Console.WriteLine("Odabrali ste opciju brisanja cijele liste. Jeste li sigurni da želite nastaviti s ovom akcijom? (da/ne)");
                        var answer3 = Console.ReadLine();
                        bool equality5 = answer3.Equals("da", StringComparison.OrdinalIgnoreCase);
                        if (equality5 == true)
                        {
                            playlist.Clear();
                            Console.WriteLine("Lista pjesama je prazna.");
                            mainVariable = Decision();
                        }
                        else
                        {
                            mainVariable = Decision();
                        }
                        break;
                    case 8:
                        Console.WriteLine("Unesite broj pjesme kojoj želite promijeniti ime.");
                        var changeName = int.Parse(Console.ReadLine());
                        var chosenSong = 0;
                        var controler = 0;
                        if (changeName <= playlist.Count && changeName > 0)
                        {
                            for (var i = 1; i <= playlist.Count; i++)
                            {
                                if (i == changeName)
                                {
                                    chosenSong = i;
                                }
                                else
                                {
                                    controler++;
                                }
                            }
                            if (controler == playlist.Count)
                            {
                                Console.WriteLine("Zatraženi broj ne postoji u listi");
                                mainVariable = Decision();
                            }
                            else
                            {
                                Console.WriteLine("Unesite novo ime kako želite preimenovati pjesmu.");
                                var newName = Console.ReadLine();
                                (playlist[chosenSong]) = newName;
                                mainVariable = Decision();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Zatražena pjesma ne postoji u listi");
                            mainVariable = Decision();
                        }
                        break;
                    case 9:
                        Console.WriteLine("Unesite broj pjesme kojoj želite promijeniti mjesto.");
                        var changeNumber = int.Parse(Console.ReadLine());
                        if (changeNumber <= playlist.Count && changeNumber > 0)
                        {
                            Console.WriteLine("Unesite novi redni broj na koji želite premjestiti pjesmu.");
                            var newNumber = int.Parse(Console.ReadLine());
                            if (newNumber <= playlist.Count && newNumber > 0)
                            {
                                var valueKeeper = playlist[newNumber];
                                playlist[newNumber] = playlist[changeNumber];
                                if (newNumber < changeNumber)
                                {
                                    for (var i = 0; i < (Math.Abs(newNumber - changeNumber) - 1); i++)
                                    {
                                        playlist[changeNumber - i] = playlist[changeNumber - i - 1];
                                    }
                                    playlist[newNumber + 1] = valueKeeper;
                                }
                                else if (newNumber == changeNumber)
                                {
                                    playlist[changeNumber] = playlist[newNumber];
                                }
                                else
                                {
                                    for (var i = 0; i < (Math.Abs(newNumber - changeNumber) - 1); i++)
                                    {
                                        playlist[changeNumber + i] = playlist[changeNumber + i + 1];
                                    }
                                    playlist[newNumber - 1] = valueKeeper;
                                }
                                Console.WriteLine("Ažurirana lista.");
                                foreach (var pair in playlist)
                                {
                                    Console.WriteLine(pair.Key + " " + pair.Value);
                                }
                                mainVariable = Decision();
                            }
                            else
                            {
                                Console.WriteLine("Zatraženi broj ne postoji u listi");
                                mainVariable = Decision();
                            }

                        }
                        else
                        {
                            Console.WriteLine("Zatraženi broj ne postoji u listi");
                            mainVariable = Decision();
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
                        mainVariable = Decision();
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



