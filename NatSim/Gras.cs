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

        // public method om te kunnen zaaien
        public static void Zaaien(Point locatie, Graphics papier, int lengte, int breedte, int zaaiAfstand)
        {
            // berekenen van het punt vanaf waar gezaaid gaat worden
            // de locatie ligt midden in het gebied
            int puntX = locatie.X - lengte / 2;
            int puntY = locatie.Y - breedte / 2;

            // variabelen die de uitgangspositie bewaren zodat
            // deze hersteld en opnieuw gebruikt kunnen worden
            Point oorspronkelijkeLocatie = locatie;
            int startpuntY = puntY;

            // bepalen tot welke locatie er gezaaid moet worden
            lengte = puntX + lengte;
            breedte = puntY  + lengte;
            while (puntX < lengte) {
                while (puntY < breedte) {
                    locatie = new Point(puntX, puntY);
                    Gras gras = new Gras(locatie);
                    gras.Teken(papier);
                    puntY = puntY + zaaiAfstand;
                }
                puntY = startpuntY;
                puntX = puntX + zaaiAfstand;
            }
        }
        public static void Zaaien(Point locatie, Graphics papier, Plant plant) {
            Zaaien(locatie, papier, 150, 46, 15);
        }
    }
}
