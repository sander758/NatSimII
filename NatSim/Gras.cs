using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NatSimII
{
    class Gras : Plant
    {
        // constructors
        public Gras() : base (1, "Gramineae", 4, Bloeiwijze.aar){
            initClass(new Point(0, 0));
        }
        public Gras(Point locatie) : base (1, "Gramineae", 4, Bloeiwijze.aar)
        {
            initClass(locatie);
        }
        // initialisatie
        private void initClass(Point locatie)
        {
            Locatie = locatie;
            Tekengebied.Afmetingen = new Size(2, 10);
            Kleur = Color.LawnGreen;
            Voedingswaarde = 1;       
        }

        // private readonly's
        private Bloeiwijze _bloeiwijzePlant = Bloeiwijze.aar;
        private string _latijnseNaam = "Gramineae";
        private int _leeftijd = 4;
        private int _verhoudingTicksJaren = 4;

        
    }
}
