using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatSimII
{
    abstract class Alleseter : Dier
    {
        public Alleseter(int verhoudingTicksJaren, string latijnseNaam, int levensduur, double gewichtMaximaal) 
            : base(verhoudingTicksJaren, latijnseNaam, levensduur, gewichtMaximaal) {
        }

        public override void Eet(Leven leven) {
            bool eet = false;
            if (leven.IsDier) {
                // Grotere dieren worden niet opgegeten:
                Dier prooidier = (Dier)leven;
                if (prooidier.GewichtMaximaal > this.GewichtMaximaal) {
                    SnelheidObject = SnelheidObject.KeerOm();
                }
                else eet = true;
            }
            else if (leven.IsPlant) {
                // Wat doet een alleseter met giftige planten?
                if (WordtVergiftigdDoor.Contains(leven.NederlandseNaam)) {
                    if (Honger()) {
                        this.Sterf();
                        leven.Sterf();
                    }
                    else {
                        // Als de plant niet eetbaar is, keer dan om:
                        SnelheidObject = SnelheidObject.KeerOm();
                    }
                }
                else eet = true;
            }
            // Alles wat niet giftig of te groot wordt opgegeten,
            // tenminste als er nog plek is:
            if (eet == true) {
                if ((MaagGevuld < 100)) {
                    MaagGevuld = MaagGevuld + leven.Voedingswaarde;
                    leven.Sterf();
                }
                else {
                    SnelheidObject = SnelheidObject.KeerOm();
                }
            }
        }
    }
}
