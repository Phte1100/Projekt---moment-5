using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
#nullable disable

namespace Projekt___moment_5
{
    public class LoanReq
    {
        // Lista för att hålla alla låneansökningar
        private List<Entry> entries;

        // Filnamn där låneansökningarna sparas
        private const string FileName = "loanRequests.json";

        // Konstruktor som initialiserar listan och laddar tidigare sparade ansökningar från filen
        public LoanReq()
        {
            entries = new List<Entry>();
            LoadEntries(); // Ladda in ansökningar från fil om de finns
        }

        // Metod för att lägga till en ny ansökan
        public void AddEntry(Entry newEntry)
        {
            entries.Add(newEntry);
        }

        // Metod för att ta bort en ansökan baserat på index
        private void RemoveEntry(int index)
        {
            if (index >= 0 && index < entries.Count)
            {
                entries.RemoveAt(index);
                SaveEntries(); // Uppdatera filen efter borttagning
                Console.WriteLine("Ansökan har tagits bort.");
            }
            else
            {
                Console.WriteLine("Ogiltigt index.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }


        // Metod för att visa alla ansökningar
        public void DisplayEntriesWithMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("┌────────────────────────────────────────────────────┐");
                Console.WriteLine("│                    LÅNEANSÖKNINGAR                 │");
                Console.WriteLine("├────────────────────────────────────────────────────┤");
                Console.WriteLine("│ [1] Granska detaljerad ansökan                     │");
                Console.WriteLine("│ [2] Sortera ansökningar                            │");
                Console.WriteLine("│ [3] Visa endast godkända/icke godkända ansökningar │");
                Console.WriteLine("│ [4] Ta bort en ansökan                             │");
                Console.WriteLine("│ [5] Tillbaka                                       │");
                Console.WriteLine("└────────────────────────────────────────────────────┘");


                if (isRunning)
                {
                    if (entries.Count > 0)
                    {

                            DisplayEntriesWithIndex();

                    }
                    else
                    {
                        Console.WriteLine("Inga ansökningar finns.");
                    }

                }

                Console.Write("\nVälj ett alternativ: ");
                string choice = Console.ReadLine();



                switch (choice)
                {
                    case "1":
                        HandleEntryInteraction(); // Metod för att hantera granskning av en specifik ansökan
                        break;
                    case "2":
                        // Sortera ansökningar
                        SortEntries();
                        break;
                    case "3":
                        // Visa endast godkända eller icke godkända ansökningar
                        FilterApprovedEntries();
                        break;
                    case "4":
                        // Ta bort en ansökan
                        Console.Clear();
                        RemoveEntry();
                        break;
                    case "5":
                        // Avsluta till huvudmenyn
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        private void HandleEntryInteraction()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│    Ange indexet för den ansökan du vill granska    │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");

            DisplayEntriesWithIndex(); // Visa alla ansökningar med index

            Console.Write("Index: ");
            int selectedIndex;

            if (int.TryParse(Console.ReadLine(), out selectedIndex) && selectedIndex >= 0 && selectedIndex < entries.Count)
            {
                bool viewingEntry = true;

                while (viewingEntry)
                {
                    Console.Clear();
                    Console.WriteLine("┌────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                       GRANSKA                      │");
                    Console.WriteLine("├────────────────────────────────────────────────────┤");
                    Console.WriteLine("│ [1] Godkänn/Neka ansökan                           │");
                    Console.WriteLine("│ [2] Ta bort ansökan                                │");
                    Console.WriteLine("│ [3] Tillbaka                                       │");
                    Console.WriteLine("└────────────────────────────────────────────────────┘");
                    Console.WriteLine("┌────────────────────────────────────────────────────┐");
                    // Visa detaljerna för den valda ansökan
                    DisplayEntryDetails(entries[selectedIndex]);
                    Console.WriteLine("└────────────────────────────────────────────────────┘");
                    Console.Write("\nVälj ett alternativ: ");
                    string entryChoice = Console.ReadLine();

                    switch (entryChoice)
                    {
                        case "1":
                            // Hantera godkännande eller nekande av ansökan
                            ToggleApproval(entries[selectedIndex]);
                            break;
                        case "2":
                            // Ta bort ansökan
                            RemoveEntry(selectedIndex);
                            viewingEntry = false; // Gå tillbaka efter att ha tagit bort
                            break;
                        case "3":
                            // Tillbaka till huvudmenyn
                            viewingEntry = false;
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt index.");
            }
        }

        private void ToggleApproval(Entry entry)
        {
            if (entry.IsApproved)
            {
                Console.WriteLine("Ansökan är redan godkänd. Vill du neka den? [y/n]");
            }
            else
            {
                Console.WriteLine("Ansökan är inte godkänd. Vill du godkänna den? [y/n]");
            }

            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                entry.IsApproved = !entry.IsApproved; // Växla mellan godkänd och icke godkänd
                SaveEntries(); // Spara ändringarna i filen
                Console.WriteLine("Ansökan har uppdaterats.");
            }
            else
            {
                Console.WriteLine("Ingen ändring gjord.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }


        private void SortEntries() // Metod för sortering
        {
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│                Sorteringsalternativ                │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ [1] Sortera efter datum (nyast först)              │");
            Console.WriteLine("│ [2] Sortera efter datum (äldst först)              │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            Console.Write("\nVälj ett alternativ: ");
            string sortChoice = Console.ReadLine();

            switch (sortChoice)
            {
                case "1":
                    entries = entries.OrderByDescending(e => e.ApplicationDate).ToList();
                    break;
                case "2":
                    entries = entries.OrderBy(e => e.ApplicationDate).ToList();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }

            Console.WriteLine("\nSorteringen är klar. Tryck på valfri tangent för att fortsätta...");
        }

        private void FilterApprovedEntries() // Metod för filtrering
        {
    Console.Clear();
    Console.WriteLine("┌────────────────────────────────────────────────────┐");
    Console.WriteLine("│          Filtrera godkända/icke godkända           │");
    Console.WriteLine("├────────────────────────────────────────────────────┤");
    Console.WriteLine("│ [1] Visa endast godkända                           │");
    Console.WriteLine("│ [2] Visa endast icke godkända                      │");
    Console.WriteLine("└────────────────────────────────────────────────────┘");
            DisplayEntriesWithIndex();
    Console.Write("Välj ett alternativ: ");
    string filterChoice = Console.ReadLine();

    List<Entry> filteredEntries = new List<Entry>();

    // Kontrollera om inmatningen är giltig
    if (filterChoice != "1" && filterChoice != "2")
    {
        Console.WriteLine("Ogiltigt val. Försök igen.");
        Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
        return;
    }

    // Utför filtreringen baserat på valet
    filteredEntries = (filterChoice == "1")
        ? entries.Where(e => e.IsApproved).ToList()
        : entries.Where(e => !e.IsApproved).ToList();

    // Rensa konsolen och visa resultaten
    if (filteredEntries.Count > 0)
    {
                Console.Clear();
                Console.WriteLine("┌────────────────────────────────────────────────────┐");
                Console.WriteLine("│               Godkända/Icke godkända               │");
                Console.WriteLine("├────────────────────────────────────────────────────┤");
                foreach (var entry in filteredEntries)
        {
                    DisplayEntryDetails(entry);
                }
    }
    else
    {
        Console.WriteLine("Inga ansökningar matchar filtret.");
    }
            Console.WriteLine("└────────────────────────────────────────────────────┘");

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
    Console.ReadKey();
}


        private void RemoveEntry() // Tar bort ansökan
        {
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│    Ange indexet för den ansökan du vill granska    │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            DisplayEntriesWithIndex();
            Console.Write("Index: ");
            int index;
            bool isNumeric = int.TryParse(Console.ReadLine(), out index);

            if (isNumeric && index >= 0 && index < entries.Count)
            {
                entries.RemoveAt(index);
                Console.WriteLine("Ansökan har tagits bort.");
                SaveEntries();
            }
            else
            {
                Console.WriteLine("Ogiltigt index.");
            }

        }

        public void DisplayEntriesWithIndex() // Visar lista med ansökningar och index
        {
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│                Lista över ansökningar              │");
            if (entries.Count > 0)
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    Console.WriteLine($"  [{i}] - {entries[i].ApplicantName} \n        Lånebelopp: {entries[i].LoanAmount} SEK");
                    if (entries[i].IsApproved == false)
                    {
                        Console.WriteLine($"        Status: Icke godkänd");
                    }
                    else
                    {
                        Console.WriteLine($"        Status: Godkänd");
                    }
                    Console.WriteLine($"        {entries[i].ApplicationDate}");
                }
            }
            else
            {
                Console.WriteLine("Inga ansökningar finns.");
            }
            Console.WriteLine("\n└────────────────────────────────────────────────────┘");
        }

        private void DisplayEntryDetails(Entry entry) // Visar detaljerad lista med ansökningar
        {
            Console.WriteLine($"\n  Namn: {entry.ApplicantName}");
            Console.WriteLine($"  Lånebelopp: {entry.LoanAmount} SEK");
            Console.WriteLine($"  Återbetalningstid: {entry.LoanRepay} år");
            Console.WriteLine($"  Renovering av bostad: {(entry.RenoveringAvBostad == 1 ? "Ja" : "Nej")}");
            Console.WriteLine($"  Lösen av andra lån: {(entry.LösenLån == 1 ? "Ja" : "Nej")}");
            Console.WriteLine($"  Köp av bil: {(entry.KöpAvBil == 1 ? "Ja" : "Nej")}");
            Console.WriteLine($"  Övrig konsumtion: {(entry.ÖvrigKonsumtion == 1 ? "Ja" : "Nej")}");
            Console.WriteLine($"  Sysselsättning: " +
                              $"{(entry.TillsvidareAnställning == 1 ? "Tillsvidareanställning" : "")}" +
                              $"{(entry.Egenföretagare == 1 ? "Egenföretagare" : "")}" +
                              $"{(entry.Pensionär == 1 ? "Pensionär" : "")}" +
                              $"{(entry.Arbetssökande == 1 ? "Arbetssökande" : "")}");
            Console.WriteLine($"  Civilstånd: " +
                              $"{(entry.CivilståndGift == 1 ? "Gift" : "")}" +
                              $"{(entry.CivilståndSambo == 1 ? "Sambo" : "")}" +
                              $"{(entry.CivilståndEnsamstående == 1 ? "Ensamstående" : "")}");
            Console.WriteLine($"  Medsökande: {(entry.Medsökande == 1 ? "Ja" : "Nej")}");
            Console.WriteLine($"  Barn under 20 år: {entry.BarnUnder20}");
            Console.WriteLine($"  Boendeform: " +
                              $"{(entry.Villa == 1 ? "Villa" : "")}" +
                              $"{(entry.Bostadsrätt == 1 ? "Bostadsrätt" : "")}" +
                              $"{(entry.Hyresrätt == 1 ? "Hyresrätt" : "")}");
            Console.WriteLine($"  Betalningsanmärkningar: {(entry.Betalningsanmärkningar == 1 ? "Ja" : "Nej")}");
            Console.WriteLine($"  Andra lån: {entry.OtherLoans} SEK");
            Console.WriteLine($"  Ansökan godkänd: {(entry.IsApproved ? "Ja" : "Nej")}");
            Console.WriteLine($"  Datum för ansökan: {entry.ApplicationDate}");
        }

        public void SaveEntries() //sparar ändringar osv
        {
            try
            {
                string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
                File.WriteAllText(FileName, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid sparande av ansökningar: {ex.Message}");
            }
        }

        // Metod för att ladda ansökningar från JSON-fil
        public void LoadEntries()
        {
            if (File.Exists(FileName))
            {
                try
                {
                    string json = File.ReadAllText(FileName);
                    entries = JsonConvert.DeserializeObject<List<Entry>>(json) ?? new List<Entry>();
                    Console.WriteLine($"Ansökningar har laddats: {entries.Count}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fel vid inläsning av ansökningar: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Ingen befintlig fil hittades. Skapar en ny lista.");
            }
        }
    }
}
