using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatSimII
{
    abstract class Planteneter : Dier
    {
        public Planteneter(int verhoudingTicksJaren, string latijnseNaam, int levensduur, double gewichtMaximaal) 
            : base(verhoudingTicksJaren, latijnseNaam, levensduur, gewichtMaximaal) {
        }

        public override void Eet(Leven leven) {

            if (leven.IsPlant)
            {
                if (WordtVergiftigdDoor.Contains(leven.NederlandseNaam))
                {
                    // Alleen als ze honger hebben dan eten ze giftige planten
                    if (Honger())
                    {
                        // het dier gaat dood maar ook de plant
                        this.Sterf();
                     //   leven.Sterf();
                    }
                    else
                    {
                        // geen honger dus wegwezen
                        SnelheidObject = SnelheidObject.KeerOm();
                    }
                }
                else if (MaagGevuld < 100)
                {
                    // er is nog ruimte, eten maar
                    MaagGevuld += leven.Voedingswaarde;
                }
            }
            else {
                // het is geen plant dus niet eetbaar voor de planteneter
                SnelheidObject = SnelheidObject.KeerOm();
            }
        }
    }
}
