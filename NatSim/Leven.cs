using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NatSimII
{
    class Leven : GrafischObject
    {
        // private vars
        private const int _aantalTicksPerSeconde = 1000;
        private string _latijnseNaam;
        private double _levensduur;
        private Timer _verouder;

        //public vars
        public int Leeftijd { get; set; }
        public int VerhoudingTicksJaren { get; set; }
        public int Voedingswaarde { get; set; }

        // readonly vars
        public string LatijnseNaam { get { return _latijnseNaam; } }
        public double Levensduur { get { return _levensduur; } }
        public string NederlandseNaam { get { return base.ToString().Split('.').Last(); } }
        public Timer Verouder { get { return _verouder; } }

        // constructors
        public Leven() {
            InitClass(1, "", int.MaxValue);
        }
        public Leven(int verhoudingTicksJaren, string latijnseNaam, int levensduur) {
            InitClass(verhoudingTicksJaren, latijnseNaam, levensduur);
        }

        // methods
        protected void InitClass(int verhoudingTicksJaren, string latijnseNaam, int levensduur) {
            VerhoudingTicksJaren = verhoudingTicksJaren;
            _latijnseNaam = latijnseNaam;
            _levensduur = levensduur;
            _verouder = new Timer();
            _verouder.Interval = _aantalTicksPerSeconde * VerhoudingTicksJaren;
			_verouder.Start();
			_verouder.Tick += _verouder_Tick;
			
        }

		private void _verouder_Tick(object sender, EventArgs e)
		{
			if (Leeftijd < Levensduur)
			{
				Leeftijd++;
			}
			else
			{
				_verouder.Stop();
				Sterf();
			}
		}

		public void Sterf() {
            Verwijder();
			OnEinde();
		}

	    public Dier ToDier()
	    {
		    if (IsDier) return (Dier) this;
		    return null;
	    }

	    public Plant ToPlant()
	    {
		    if (IsPlant) return (Plant) this;
		    return null;
	    }

	    public Gras ToGras()
	    {
		    if (this.GetType() == typeof(Gras))
		    {
			    return (Gras) this;
		    }
		    else
		    {
			    return null;
		    }
	    }

	    public SoortLeven ToLower()
	    {
		    switch (NederlandseNaam.ToLower())
		    {
				case "beer": return SoortLeven.Beer;
			    case "gras": return SoortLeven.Gras;
			    case "l<oe": return SoortLeven.Koe;
			    case "konijn": return SoortLeven.Konijn;
			    case "lynx": return SoortLeven.Lynx;
			    case "venijnboom": return SoortLeven.Venijnboom;
			    case "vingerhoedskruid": return SoortLeven.Vingerhoedskruid;
			    default: return SoortLeven.Gras;

			}
		}

        public bool IsPlant {        
            // deze code kijkt of het type van het object erft van Plant
            // GetType() bepaalt type object, IsSubclassOf bepaalt of het erft van Plant
            get { return this.GetType().IsSubclassOf(typeof(Plant)); }
        }
        public bool IsDier {
            // deze code kijkt of het type van het object erft van Plant
            get { return this.GetType().IsSubclassOf(typeof(Dier)); }
        }

	    public event EventHandler<EventArgs> Einde;

	    protected virtual void OnEinde()
	    {
		    if (Einde != null)
		    {
			    Einde(this, EventArgs.Empty);
		    }
	    }
    }
}
