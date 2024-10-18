using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Projekt___moment_5
{
    public class Entry
    {
        // Egenskaper för låneansökan
        public string ApplicantName { get; set; }
        public float LoanAmount { get; set; }
        public float RenoveringAvBostad { get; set; }
        public float LösenLån { get; set; }
        public float KöpAvBil { get; set; }
        public float ÖvrigKonsumtion { get; set; }
        public float LoanRepay { get; set; }
        public float TillsvidareAnställning { get; set; }
        public float Egenföretagare { get; set; }
        public float Pensionär { get; set; }
        public float Arbetssökande { get; set; }
        public float CivilståndGift { get; set; }
        public float CivilståndSambo { get; set; }
        public float CivilståndEnsamstående { get; set; }
        public float Medsökande { get; set; }
        public float BarnUnder20 { get; set; }
        public float Villa { get; set; }
        public float Bostadsrätt { get; set; }
        public float Hyresrätt { get; set; }
        public float Betalningsanmärkningar { get; set; }
        public float OtherLoans { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ApplicationDate { get; set; }

        // Konstruktor för att skapa ett nytt inlägg
        public Entry(
            string applicantName,
            float loanAmount,
            float renoveringAvBostad,
            float lösenLån,
            float köpAvBil,
            float övrigKonsumtion,
            float loanRepay,
            float tillsvidareAnställning,
            float egenföretagare,
            float pensionär,
            float arbetssökande,
            float civilståndGift,
            float civilståndSambo,
            float civilståndEnsamstående,
            float medsökande,
            float barnUnder20,
            float villa,
            float bostadsrätt,
            float hyresrätt,
            float betalningsanmärkningar,
            float otherLoans,
            bool isApproved // Lägg till godkännande som parameter
        )
        {
            ApplicantName = applicantName;
            LoanAmount = loanAmount;
            RenoveringAvBostad = renoveringAvBostad;
            LösenLån = lösenLån;
            KöpAvBil = köpAvBil;
            ÖvrigKonsumtion = övrigKonsumtion;
            LoanRepay = loanRepay;
            TillsvidareAnställning = tillsvidareAnställning;
            Egenföretagare = egenföretagare;
            Pensionär = pensionär;
            Arbetssökande = arbetssökande;
            CivilståndGift = civilståndGift;
            CivilståndSambo = civilståndSambo;
            CivilståndEnsamstående = civilståndEnsamstående;
            Medsökande = medsökande;
            BarnUnder20 = barnUnder20;
            Villa = villa;
            Bostadsrätt = bostadsrätt;
            Hyresrätt = hyresrätt;
            Betalningsanmärkningar = betalningsanmärkningar;
            OtherLoans = otherLoans;
            IsApproved = isApproved;
        }

        // Konstruktor för deserialisering
        public Entry()
        {
            ApplicationDate = DateTime.Now; // Sätter ansökningsdatum till nuvarande tid som standard
        }
    }
}
