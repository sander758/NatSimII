
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace NatSimII
{
    class Venijnboom : Plant {
        // constructors
        public Venijnboom() : base(1, "Taxus baccata", 2000, Bloeiwijze.kegel){
            initClass(new Point(0, 0));
        }
        public Venijnboom(Point locatie) : base(1, "Taxus baccata", 2000, Bloeiwijze.kegel) { 
            initClass(locatie);
        }
        // initialisatie
        private void initClass(Point locatie)
        {
            Locatie = locatie;
            Tekengebied.Afmetingen = new Size(10, 400);
            Kleur = Color.ForestGreen;
        }

        // private vars
        private List<string> _geneesmiddelVoor = new List<string> { "longkanker", "borstkanker" };
        private int _maximaleGrootte = 20000;

        public List<string> GeneesmiddelVoor { get { return _geneesmiddelVoor; } }
        public int MaximaleGrootte { get { return _maximaleGrootte; } }

        // public vars
        public double AantalKubiekeMetersHout { get; set; }
    }
}