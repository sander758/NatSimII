using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NatSimII
{

    class Koe : Planteneter
    {
        // constructors
        public Koe() : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(new Point(0, 0), "", Kleur);
        }
        public Koe(Point locatie) : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(locatie, "", Kleur);
        }
        public Koe(Point locatie, string naam, Color kleur) : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(locatie, naam, kleur);
        }

        // initialisatie
        private void initClass(Point locatie, string naam, Color kleur)
        {
            Locatie = locatie;
            Naam = naam;
            Kleur = kleur; Tekengebied.Afmetingen = new Size(80, 40);
            WordtVergiftigdDoor.Add("Venijnboom");
            WordtVergiftigdDoor.Add("Vingerhoedskruid");
            Gewicht = 50; // startgewicht staat niet in het boek
            Voedingswaarde = 1;

        }

        // private vars
        private const double _gewichtMaximaal = 800;
        private const int _leeftijd = 25;
        private const string _latijnseNaam = "Bos Taurus";
        private const int _verhoudingTicksJaren = 1;

        // public properties
        public int AantalLitersMelk { get; set; }
        public DateTime GeboorteDatum { get; set; } 
        public string Naam { get; set; } 
        public DateTime SterfDatum {  get; set; }
        public double Gewicht { get; set; }
     }
}