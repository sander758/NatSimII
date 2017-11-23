
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace NatSimII
{

    class Vingerhoedskruid : Plant
    {

        /**
         * 
         */
        public Vingerhoedskruid() : base(4, "Digitalis Purpurea", 4, Bloeiwijze.tros) {
            initClass(new Point(0, 0));
        }
        public Vingerhoedskruid(Point locatie) : base(4, "Digitalis Purpurea", 4, Bloeiwijze.tros){
            initClass(locatie);
        }
        
        protected void initClass(Point locatie) {
            Locatie = locatie;
            Tekengebied.Afmetingen = new Size(10, 400);
            Kleur = Color.ForestGreen;
        }

    }
}