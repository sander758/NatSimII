using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NatSimII
{
	class Rechthoek
	{
		public Point A { get; set; }
		public Size Afmetingen { get; set; }
		public Point Locatie
		{
			get { return A; }
			set { A = value; }
		}

		public Rechthoek() { }
		public Rechthoek(Point locatie, Size afmetingen)
		{
			Locatie = locatie;
			Afmetingen = afmetingen;
		}

		// private vars
		public int Breedte { get { return Afmetingen.Width; } }
		public int Hoogte { get { return Afmetingen.Height; } }
		public Point B { get { return new Point(A.X + Breedte, A.Y); } }
		public Point C { get { return new Point(A.X, A.Y + Hoogte); } }
		public Point D { get { return new Point(B.X, C.Y); } }

		// methods
		// static method om te bepalen of 2 objecten van het type 
		// rechthoek elkaar raken of buiten het tekengebied vallen
		public static Vlak GrensBereikt(Rechthoek r1, Rechthoek r2)
		{
			Vlak vlak = Vlak.Geen;
			// overschrijden linker of rechterkant
			if (r1.A.X <= r2.A.X ||
				r1.B.X >= r2.B.X)
			{
				vlak = Vlak.Verticaal;
			}
			// overschrijden onder of bovenrand
			if (r1.A.Y <= r2.A.Y ||
				r1.C.Y >= r2.C.Y)
			{
				if (vlak == Vlak.Verticaal)
					vlak = Vlak.Hoek;
				else
					vlak = Vlak.Horizontaal;
			}
			return vlak;
		}
		public Vlak GrensBereikt(Rechthoek r2)
		{
			// r1 is de huidige instantie van het object
			return GrensBereikt(this, r2);
		}
		public bool Overlap(Rechthoek r1)
		{
			return ((r1.D.X >= A.X && r1.A.X <= D.X) &&
					r1.D.Y >= A.Y && r1.A.Y <= D.Y);
		}

		public Rectangle ToRectangle()
		{
			return new Rectangle(Locatie, Afmetingen);
		}
		public int Oppervlakte()
		{
			return Hoogte * Breedte;
		}
		public int Omtrek()
		{
			return 2 * (Hoogte + Breedte);
		}
	}
}
