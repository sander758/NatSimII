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

		public void CollisionDetection(Dier dier)
		{
			for (int i = 0; i < this.Count; i++)
			{
				if (dier.Id != this[i].Id)
				{
					dier.IsBotsing(this[i]);
				}
			}
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

		private void _levensKlok_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < this.Count; i++)
			{
				Dier dier = this[i].ToDier();
				if (dier != null)
				{
					dier.Beweeg();
					CollisionDetection(dier);
				}
			}
		}

		// public method om te kunnen zaaien
		public void Zaaien(Point locatie, Graphics papier, int lengte, int breedte, int zaaiAfstand, Plant plant)
		{
			int puntX = locatie.X - lengte / 2;
			int puntY = locatie.Y - breedte / 2;
			
			Point oorspronkelijkeLocatie = locatie;
			int startpuntY = puntY;
			
			lengte = puntX + lengte;
			breedte = puntY + lengte;
			while (puntX < lengte)
			{
				while (puntY < breedte)
				{
					locatie = new Point(puntX, puntY);

					if (plant.ToGras() != null)
					{
						Gras gras = new Gras(locatie);
						Add(gras);
					}
					else if (plant.ToVenijnboom() != null)
					{
						Venijnboom boom = new Venijnboom(locatie);
						Add(boom);
					}
					else if (plant.ToToVingerhoedskruid() != null)
					{
						Vingerhoedskruid vingerhoedskruid = new Vingerhoedskruid(locatie);
						Add(vingerhoedskruid);
					}

					puntY = puntY + zaaiAfstand;
				}
				puntY = startpuntY;
				puntX = puntX + zaaiAfstand;
			}
		}

		public void Zaaien(Point locatie, Graphics papier, Plant plant)
		{
			Zaaien(locatie, papier, 150, 46, 15, plant);
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