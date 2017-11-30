using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatSimII
{
    abstract class Plant : Leven
    {
        // constructors
        public Plant() {
        }
        public Plant(int verhoudingTicksJaren, string latijnseNaam, int levensduur, Bloeiwijze bloeiwijzePlant) :
            base(verhoudingTicksJaren, latijnseNaam, levensduur) {
            BloeiwijzePlant = bloeiwijzePlant;
        }

        //public vars
        public Bloeiwijze BloeiwijzePlant { get; set; }

        // methodes

	    public override string ToString()
	    {
		    return "Latijnse naam: " + LatijnseNaam + Environment.NewLine
		           + Environment.NewLine + "Nederlandse naam: " + NederlandseNaam
		           + Environment.NewLine + Environment.NewLine + "Levensduur: " + Levensduur
		           + Environment.NewLine + Environment.NewLine + "Bloeiwijze: " + BloeiwijzePlant
		           + Environment.NewLine + Environment.NewLine + "Locatie: " + Locatie.ToString();
		}

	    public Gras ToGras()
	    {
		    if (this.GetType() == typeof(Gras))
		    {
			    return (Gras)this;
		    }
		    else
		    {
			    return null;
		    }
	    }

		public Venijnboom ToVenijnboom()
	    {
			if (this.GetType() == typeof(Venijnboom))
			{
				return (Venijnboom) this;
			}
			else
			{
				return null;
			}
		}

	    public Vingerhoedskruid ToToVingerhoedskruid()
		{
			if (this.GetType() == typeof(Vingerhoedskruid))
			{
				return (Vingerhoedskruid)this;
			}
			else
			{
				return null;
			}
		}

	}
}
