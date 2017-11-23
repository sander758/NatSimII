using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NatSimII
{
	class Natuur : List<Leven>
	{
		private Timer _levensKlok = new Timer();

		public new void Add(Leven leven)
		{
			if (leven.IsDier)
			{
				Random rand = new Random();
				Snelheid snelheid = new Snelheid(rand.Next(-4, 4), rand.Next(-4, 4));
				((Dier) leven).SnelheidObject = snelheid;
			}
			base.Add(leven);
			if (NieuwLeven != null)
			{
				NieuwLeven(this, new NieuwLevenEventArgs(leven));
			}
			leven.Einde += leven_Einde;

			leven.OpObject += Leven_OpObject;
		}

		private void Leven_OpObject(object sender, EventArgs e)
		{
			if (Getroffen != null)
			{
				Getroffen(this, new GetroffenEventArgs((Leven)sender));
			}
		}

		public event EventHandler<NieuwLevenEventArgs> NieuwLeven;
		public event EventHandler<GetroffenEventArgs> Getroffen; 

		private void leven_Einde(object sender, EventArgs e)
		{
			this.Remove((Leven) sender);
		}

		public void LevenGeraakt(Point locatie)
		{
			foreach (Leven leven in this)
			{
				leven.IsOpObject(locatie);
			}
		}

		public Natuur() : base()
		{
			_levensKlok.Start();
			_levensKlok.Tick += _levensKlok_Tick;
			_levensKlok.Interval = 10;
		}

		public void _levensKlok_Tick(object sender, EventArgs e)
		{
			foreach (Leven leven in this)
			{
				if (leven.IsDier)
				{
					((Dier) leven).Beweeg();
				}
			}
		}
	}

	class GetroffenEventArgs : EventArgs
	{
		public GetroffenEventArgs(Leven leven)
		{
			Getroffen = leven;
			GeraaktOp = DateTime.Now;
		}

		public Leven Getroffen { get; set; }
		public DateTime GeraaktOp { get; set; }
	}
}