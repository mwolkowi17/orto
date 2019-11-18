using System;
using System.Linq;

namespace Orto
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SlowaN())
            {
                bool starting = true;
                while (starting == true)
                {
                    Console.WriteLine("Jeśli chcesz wprowadzić nowe słowa wpisz: nowe");
                    Console.WriteLine("Jeśli chcesz zobaczyć słowa w słowniczku wpisz: lista");
                    Console.WriteLine("Jeśli chcesz wprowadzić korektę słowniczka wpisz: change");
                    Console.WriteLine("Jeśli chcesz sprawdzić wiedzę franka wpisz: test");
                    Console.WriteLine("Jeśli chcesz zakończyć wpisz: end");
                    string choiceA = Console.ReadLine();
                    if (choiceA == "nowe")
                    {
                        bool noweStart = true;
                        while (noweStart == true)
                        {
                            Console.WriteLine("Wprowadź nowe słowo:");
                            string slowoNext = Console.ReadLine();
                            var bazaSlow = db.BazaSlow;
                            bazaSlow.Add
                            (new Przyklady
                            {
                                przykladSample = slowoNext
                            }

                            );
                            db.SaveChanges();
                            Console.WriteLine("Wprowadzasz dalej t/n?");
                            string decyzjaEdit=Console.ReadLine();
                            if (decyzjaEdit=="n")
                            {
                                noweStart=false;

                            }
                        }
                    }

                    if (choiceA == "lista")
                    {
                        var slowniczek = db.BazaSlow.ToList();
                        Colorgreen();
                        Console.WriteLine("----------------------");
                        foreach (var n in slowniczek)
                        {

                            Console.WriteLine($"|{n.przykladyId,-4}|{n.przykladSample,15}|");

                        }
                        Console.WriteLine("----------------------");
                        Colorgrey();
                    }

                    if (choiceA == "change")
                    {
                        var slowniczek = db.BazaSlow.ToList();
                        Colorgreen();
                        Console.WriteLine("----------------------");
                        foreach (var n in slowniczek)
                        {


                            Console.WriteLine($"|{n.przykladyId,-4}|{n.przykladSample,15}|");

                        }
                        Console.WriteLine("----------------------");
                        Colorgrey();
                        Console.WriteLine("Wprowadź numer Id słowa które chcesz zmienić/poprawić.");
                        string changeId = Console.ReadLine();
                        int changeIdInt = Convert.ToInt32(changeId);
                        var singleSlownik = db.BazaSlow
                        .Single(b => b.przykladyId == changeIdInt);
                        Colorred();
                        Console.WriteLine("==========================");
                        Console.WriteLine($"Wybrałeś słowo: {singleSlownik.przykladSample}");
                        Console.WriteLine("==========================");
                        Colorgrey();
                        Console.WriteLine("Wprowadź poprawione słowo:");
                        string ChangedWordPol = Console.ReadLine();
                        singleSlownik.przykladSample = ChangedWordPol;
                        db.SaveChanges();


                    }

                    if (choiceA == "test")
                    {
                        int DobrzeA = 0;
                        
                        Console.WriteLine("Podaj ilość przykładów");
                        string examples = Console.ReadLine();
                        int examplesInt = Convert.ToInt32(examples);
                        
                        for (int n = 1; n <= examplesInt; n++)
                        {
                            var testA = db.BazaSlow.ToList();
                            var rand = new Random();
                            int testnum = rand.Next(testA.Count);
                            var singleTest = testA.ElementAt(testnum);



                            string zdanie = singleTest.przykladSample;

                            if (zdanie.Contains("ó") || zdanie.Contains("u") || zdanie.Contains("ż") || zdanie.Contains("rz"))
                            {
                                string zdanieNew = zdanie.Replace("ó", "_");
                                string zdanieNewB = zdanieNew.Replace("u", "_");
                                string zdanieNewC = zdanieNewB.Replace("ż", "_");
                                string zdanieNewD = zdanieNewC.Replace("rz", "_");
                                Console.WriteLine(zdanieNewD);
                            }
                            else
                            {
                                Console.WriteLine(zdanie);
                            }
                            Console.WriteLine("wpisz poprawnie słowo:");
                            string zdaniePopr = Console.ReadLine();
                            if (zdaniePopr.Equals(zdanie) == true)
                            {
                                Colorgreen();
                                Console.WriteLine("Dobrze");
                                Colorgrey();
                                DobrzeA++;
                            }
                            else
                            {
                                Colorred();
                                Console.WriteLine("Źle");
                                Colorgrey();
                            }

                        }
                        Console.WriteLine("======================================================");
                        Console.WriteLine($"Zrobiłeś dobrze{DobrzeA} na {examplesInt} przykładów.");
                        Console.WriteLine("======================================================");
                    }

                    if (choiceA == "end")
                    {
                        starting = false;
                    }
                    static void Colorgreen()
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    static void Colorgrey()
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    static void Colorred()
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }
            }
        }
    }
}
