using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NatSimII
{
    abstract class Dier : Leven, IBewegendObject
    {
        // constructor
        public Dier(int verhoudingTicksJaren, string latijnseNaam, int levensduur, double gewichtMaximaal) 
            : base (verhoudingTicksJaren, latijnseNaam, levensduur) {
            initDier(gewichtMaximaal);
        }
        // initialisatie
        private void initDier(double gewichtMaximaal) {
            _gewichtMaximaal = gewichtMaximaal;
            WordtVergiftigdDoor = new List<string>();
        }
        // private vars
        private double _gewichtMaximaal = 0;
        // eigenschappen voor alle dieren
        public int MaagGevuld { get; set; }
        public int SpijsverteringsDuur { get; set; }
        public double GewichtMaximaal { get { return _gewichtMaximaal; } }
        public List<string> WordtVergiftigdDoor { get; set; }
        public Snelheid SnelheidObject { get; set; }
        public Timer Klok {get; set; }

        //methoden
        public abstract void Eet(Leven leven);
        public bool Honger() {
            return (MaagGevuld < 25);
        }
		
	    public Point Stap()
	    {
		    return Stap(this.SnelheidObject);
	    }

	    public Point Stap(Snelheid snelheidsObject)
	    {
		    this.SnelheidObject = snelheidsObject;
			// waar komt het object terecht bij de Stap?
		    int berekendeX = Locatie.X + SnelheidObject.X;
		    int berekendeY = Locatie.Y + SnelheidObject.Y;
			// bepalen van het nieuwe tekengebied waar het object getekend gaat worden
			Rechthoek nieuwTekenGebied = new Rechthoek(new Point(berekendeX, berekendeY), Tekengebied.Afmetingen);
			// Berekenen van een nieuwe richting nav een eventuele overschrijding van een grens

		    Vlak vlak = Rechthoek.GrensBereikt(nieuwTekenGebied, GrafischVenster);
			// berekenen van een nieuwe ichting als het object een rand tegenekomt
		    SnelheidObject = snelheidsObject.Stuiter(vlak);
			// opnieuw berekenen van de snelheid zodat een wijziging van de richting meegenomen wordt
		    berekendeX = Locatie.X + SnelheidObject.X;
		    berekendeY = Locatie.Y + SnelheidObject.Y;

			return new Point(berekendeX, berekendeY);
	    }


	    public bool IsBotsing(Leven leven)
	    {
		    if (this.Tekengebied.Overlap(leven.Tekengebied))
		    {
			    Dier dier = leven.ToDier();
			    if (dier != null)
			    {
				    this.SnelheidObject = this.SnelheidObject.KeerOm();
				    dier.SnelheidObject = dier.SnelheidObject.KeerOm();
			    }
				Eet(leven);

			    return true;
		    }
		    return false;
	    }


	    public override string ToString()
	    {
		    return "Latijnse naam: " + LatijnseNaam + Environment.NewLine
		           + Environment.NewLine + "Nederlandse naam: " + NederlandseNaam
		           + Environment.NewLine + Environment.NewLine + "Levensduur: " + Levensduur
		           + Environment.NewLine + Environment.NewLine + "Locatie: " + Locatie.ToString();
	    }

		public void Beweeg()
	    {
		    Verwijder();
		    Locatie = Stap();
			Teken();
	    }
    }
}
