using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatSimII
{
	class NieuwLevenEventArgs : EventArgs
	{
		public NieuwLevenEventArgs(Leven leven)
		{
			NieuwLeven = leven;
		}

		public Leven NieuwLeven { get; set; }

	}
}
