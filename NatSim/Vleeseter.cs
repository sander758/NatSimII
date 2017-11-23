using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatSimII
{
    abstract class Vleeseter : Dier
    {
        public Vleeseter(int verhoudingTicksJaren, string latijnseNaam, int levensduur, double gewichtMaximaal) 
            : base(verhoudingTicksJaren, latijnseNaam, levensduur, gewichtMaximaal) {
        }

        public override void Eet(Leven leven) {
            // de vleeseter eet alleen maar andere dieren die kleiner zijn
            if (leven.IsDier) {
                // Grotere dieren worden niet opgegeten:
                Dier prooidier = (Dier)leven;
                if (prooidier.GewichtMaximaal > this.GewichtMaximaal) {
                    SnelheidObject = SnelheidObject.KeerOm();
                }
                // Als er plek is in zijn maag, eet het dier een ander dier op:
                else if (MaagGevuld < 100) {               
                    MaagGevuld = MaagGevuld + leven.Voedingswaarde;
                    leven.Sterf();
                }
            }
            // Als het leven geen dier is keert de vleeseter om.
            else {
                SnelheidObject = SnelheidObject.KeerOm();
            }
        }
    }
}
