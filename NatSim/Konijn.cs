using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NatSimII
{
    class Konijn : Planteneter
    {
        // constructors
        public Konijn() : base( _verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal) {
            initClass(new Point(0, 0), "", Color.Brown);
        }
        public Konijn(Point locatie) : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(locatie, "", Color.Brown);
        }
        public Konijn(Point locatie, string naam, Color kleur) : base (_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(locatie, naam, kleur);
        }
        // initialisatie
        private void initClass(Point locatie, string naam, Color kleur) {
            Locatie = locatie;
            Naam = naam;
            Kleur = kleur;
            Tekengebied.Afmetingen = new Size(10,10 );
            WordtVergiftigdDoor.Add("Venijnboom");
            WordtVergiftigdDoor.Add("Vingerhoedskruid");
            Gewicht = 5;
            Voedingswaarde = 1;
        }

        // private variabelen
        //
        // algemene gegevens
        //
        private const string _latijnseNaam = "Oryctolagus cuniculus"; // latijnse naam
        private const double _gewichtMaximaal = 10; // hoe zwaar kan een konijn worden
        private const int _leeftijd = 9; // de maximale leeftijd 
        private const int _verhoudingTicksJaren = 1;
        
        // EIGENSCHAPPEN
        public string Naam { get ; set ; }
        public double Gewicht { get ;set; }
        public DateTime Geboortedatum { get ; set ; }
        public DateTime Sterfdatum { get; set; }
    }
}
