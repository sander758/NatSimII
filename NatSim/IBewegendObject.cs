using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NatSimII
{
	interface IBewegendObject
	{
		// public vars
		Snelheid SnelheidObject { get; set; }
		Timer Klok { get; set; }

		// methds
		Point Stap();

		Point Stap(Snelheid snelheidsObject);

	}
}
