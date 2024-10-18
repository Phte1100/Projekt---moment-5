
using Projekt___moment_5;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; // Används för JSON-serialisering
#nullable disable

namespace Projekt___moment_5
{

    internal class Program
{
    private static void Main(string[] args)
    {
        LoanApplication loanApp = new();
        LoanReq loanReq = new(); // Instans för att hantera låneansökningar

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│                     LÅNEAPPEN                      │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ [1] - Gör en ny ansökan                            │");
            Console.WriteLine("│ [2] - Se gamla ansökningar                         │");
            Console.WriteLine("│ [3] - Avsluta                                      │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            Console.Write("Välj ett alternativ: ");

                string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Skapa en ny ansökan och spara den direkt
                    Entry newEntry = loanApp.Run();
                    loanReq.AddEntry(newEntry);
                    loanReq.SaveEntries();
                    Console.WriteLine("\nDin ansökan har sparats! \n\nTryck på valfri tangent för att fortsätta...");
                    Console.ReadKey();
                    break;

                case "2":
                    // Visa gamla ansökningar
                    loanReq.DisplayEntriesWithMenu();
                    Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                    Console.ReadKey();
                    break;

                case "3":
                    // Avsluta programmet
                    running = false;
                    Console.WriteLine("Programmet avslutas.");
                    break;

                default: // Felhantering
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
}

