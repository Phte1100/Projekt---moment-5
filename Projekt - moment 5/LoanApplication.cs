using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Projekt___moment_5
{
    public class LoanApplication
    {
        // Metoden som kör hela låneansökningsprocessen
        public Entry Run()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│ [1] - NAMN                                         │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ Skriv ditt namn                                    │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            string applicantName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│ [2] - Hur mycket vill du låna?                     │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ Du kan ansöka om privatlån mellan 20 000 & 500 000 │");
            Console.WriteLine("│ SEK. Ange belopp                                   │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            float loanAmount;
            while (!float.TryParse(Console.ReadLine(), out loanAmount) || loanAmount < 20000 || loanAmount > 500000)
            {
                Console.WriteLine("Ogiltig inmatning. Ange ett belopp mellan 20 000 och 500 000 SEK.");
            }
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│ [3] - Syfte med lånet                              │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ [1] - Renovering av bostad                         │");
            Console.WriteLine("│ [2] - Lösa andra lån                               │");
            Console.WriteLine("│ [3] - Köp av bil                                   │");
            Console.WriteLine("│ [4] - Övrig konsumtion                             │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            int loanReason;
            while (!int.TryParse(Console.ReadLine(), out loanReason) || loanReason < 1 || loanReason > 4)
            {
                Console.WriteLine("Ogiltigt val. Välj ett alternativ mellan 1 och 4.");
            }
            float renoveringAvBostad = 0F, lösenLån = 0F, köpAvBil = 0F, övrigKonsumtion = 0F;
            switch (loanReason)
            {
                case 1:
                    renoveringAvBostad = 1F;
                    break;
                case 2:
                    lösenLån = 1F;
                    break;
                case 3:
                    köpAvBil = 1F;
                    break;
                case 4:
                    övrigKonsumtion = 1F;
                    break;
            }
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│ [4] - Återbetalningstid                            │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ Du kan välja mellan 1-12 år. Ange antal år:        │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            float loanRepay;
            while (!float.TryParse(Console.ReadLine(), out loanRepay) || loanRepay < 1 || loanRepay > 12)
            {
                Console.WriteLine("Ogiltig inmatning. Välj ett antal år mellan 1 och 12.");
            }
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│ [5] - Sysselsättning                               │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ [1] - Tillsvidareanställning                       │");
            Console.WriteLine("│ [2] - Egenföretagare                               │");
            Console.WriteLine("│ [3] - Pensionär                                    │");
            Console.WriteLine("│ [4] - Arbetssökande                                │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            int employment;
            while (!int.TryParse(Console.ReadLine(), out employment) || employment < 1 || employment > 4)
            {
                Console.WriteLine("Ogiltigt val. Välj ett alternativ mellan 1 och 4.");
            }

            float tillsvidareAnställning = 0F, egenföretagare = 0F, pensionär = 0F, arbetssökande = 0F;
            switch (employment)
            {
                case 1:
                    tillsvidareAnställning = 1F;
                    break;
                case 2:
                    egenföretagare = 1F;
                    break;
                case 3:
                    pensionär = 1F;
                    break;
                case 4:
                    arbetssökande = 1F;
                    break;
            }
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│ [6] - Civilstånd                                   │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ [1] - Gift                                         │");
            Console.WriteLine("│ [2] - Sambo                                        │");
            Console.WriteLine("│ [3] - Ensamstående                                 │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            int civilStatus;
            while (!int.TryParse(Console.ReadLine(), out civilStatus) || civilStatus < 1 || civilStatus > 3)
            {
                Console.WriteLine("Ogiltigt val. Välj ett alternativ mellan 1 och 3.");
            }

            float civilståndGift = 0F, civilståndSambo = 0F, civilståndEnsamstående = 0F;
            switch (civilStatus)
            {
                case 1:
                    civilståndGift = 1F;
                    break;
                case 2:
                    civilståndSambo = 1F;
                    break;
                case 3:
                    civilståndEnsamstående = 1F;
                    break;
            }
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│ [7] - Medsökande                                   │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ [1] - Ja                                           │");
            Console.WriteLine("│ [2] - Nej                                          │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            int coApplicant;
            while (!int.TryParse(Console.ReadLine(), out coApplicant) || (coApplicant != 1 && coApplicant != 2))
            {
                Console.WriteLine("Ogiltigt val. Välj [1] för Ja eller [2] för Nej.");
            }

            float medsökande = coApplicant == 1 ? 1F : 0F;
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│ [8] - Antal barn under 20 år                       │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            float barnUnder20;
            while (!float.TryParse(Console.ReadLine(), out barnUnder20) || barnUnder20 < 0)
            {
                Console.WriteLine("Ogiltig inmatning. Ange ett positivt tal.");
            }
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│ [9] - Boendetyp                                    │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ [1] - Villa                                        │");
            Console.WriteLine("│ [2] - Bostadsrätt                                  │");
            Console.WriteLine("│ [3] - Hyresrätt                                    │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            int homeType;
            while (!int.TryParse(Console.ReadLine(), out homeType) || homeType < 1 || homeType > 3)
            {
                Console.WriteLine("Ogiltigt val. Välj ett alternativ mellan 1 och 3.");
            }

            float villa = 0F, bostadsrätt = 0F, hyresrätt = 0F;
            switch (homeType)
            {
                case 1:
                    villa = 1F;
                    break;
                case 2:
                    bostadsrätt = 1F;
                    break;
                case 3:
                    hyresrätt = 1F;
                    break;
            }
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│ [10] - Betalningsanmärkningar                      │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ [1] - Ja                                           │");
            Console.WriteLine("│ [2] - Nej                                          │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            int paymentRemarks;
            while (!int.TryParse(Console.ReadLine(), out paymentRemarks) || (paymentRemarks != 1 && paymentRemarks != 2))
            {
                Console.WriteLine("Ogiltigt val. Välj [1] för Ja eller [2] för Nej.");
            }

            float betalningsanmärkningar = paymentRemarks == 1 ? 1F : 0F;
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("│ [11] - Andra lån                                   │");
            Console.WriteLine("├────────────────────────────────────────────────────┤");
            Console.WriteLine("│ Ange totalsumman i SEK                             │");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            float otherLoans;
            while (!float.TryParse(Console.ReadLine(), out otherLoans) || otherLoans < 0)
            {
                Console.WriteLine("Ogiltig inmatning. Ange ett positivt tal.");
            }

            // Skapa och returnera ett Entry-objekt
            var sampleData = new MLModel1.ModelInput()
            {
                Lånebelopp = loanAmount,
                RenoveringAvBostad = renoveringAvBostad,
                LösenLån = lösenLån,
                KöpAvBil = köpAvBil,
                ÖvrigKonsumtion = övrigKonsumtion,
                Återbetalningstid = loanRepay,
                TillsvidareAnställning = tillsvidareAnställning,
                Egenföretagare = egenföretagare,
                Pensionär = pensionär,
                Arbetssökande = arbetssökande,
                CivilståndGift = civilståndGift,
                CivilståndSambo = civilståndSambo,
                CivilståndEnsamstående = civilståndEnsamstående,
                Medsökande = medsökande,
                Barn20årEllerYngre = barnUnder20,
                Villa = villa,
                Bostadsrätt = bostadsrätt,
                Hyresrätt = hyresrätt,
                Betalningsanmärkningar = betalningsanmärkningar,
                AndraLån = otherLoans
            };

            bool isApproved = false; // Standardvärde för lånegodkännande

            try
            {
                // Använd data i modellen och gör en prediktion
                var predictionResult = MLModel1.Predict(sampleData);

                // Visa resultatet av förutsägelsen
                // Kontrollera vad datatypen för PredictedLabel är och gör en jämförelse därefter
                if (predictionResult.PredictedLabel == 1)
                {
                    isApproved = true;
                }
                else if (predictionResult.PredictedLabel == 0)
                {
                    isApproved = false;
                }
                Console.Clear();
                Console.WriteLine("┌────────────────────────────────────────────────────┐");
                Console.WriteLine("│ RESULTAT                                           │");
                Console.WriteLine("└────────────────────────────────────────────────────┘");
                Console.WriteLine($"\nDin ansökan är: {(isApproved ? "G O D K Ä N D" : "I C K E   G O D K Ä N D")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel har uppstått: {ex.Message}");
            }

            

            // Returnera entry med alla data samt status för om lånet är godkänt eller inte
            return new Entry
            {
                ApplicantName = applicantName,
                LoanAmount = loanAmount,
                RenoveringAvBostad = renoveringAvBostad,
                LösenLån = lösenLån,
                KöpAvBil = köpAvBil,
                ÖvrigKonsumtion = övrigKonsumtion,
                LoanRepay = loanRepay,
                TillsvidareAnställning = tillsvidareAnställning,
                Egenföretagare = egenföretagare,
                Pensionär = pensionär,
                Arbetssökande = arbetssökande,
                CivilståndGift = civilståndGift,
                CivilståndSambo = civilståndSambo,
                CivilståndEnsamstående = civilståndEnsamstående,
                Medsökande = medsökande,
                BarnUnder20 = barnUnder20,
                Villa = villa,
                Bostadsrätt = bostadsrätt,
                Hyresrätt = hyresrätt,
                Betalningsanmärkningar = betalningsanmärkningar,
                OtherLoans = otherLoans,
                IsApproved = isApproved,
                ApplicationDate = DateTime.Now
            };
        }
    }
}
