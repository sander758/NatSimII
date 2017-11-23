using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NatSimII
{
    public struct Snelheid
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Snelheid(int x, int y) : this()
		{
            X = x;
            Y = y;
        }

        public Snelheid KeerOm()
		{
            X = -1 * X;
            Y = -1 * Y;
            return new Snelheid(X,Y);
        }

        public Snelheid Stuiter(Vlak vlak)
		{
            switch (vlak) {
                case Vlak.Horizontaal:
                    Y = -1 * Y;
                    break;
                case Vlak.Verticaal:
                    X = -1 * X;
                    break;
                case Vlak.Hoek:
                    X = -1 * X;
                    Y = -1 * Y;
                    break;
            }
            return new Snelheid(X, Y);

        }
    }
}
