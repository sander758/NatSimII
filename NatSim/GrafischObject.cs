using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NatSimII
{
    abstract class GrafischObject
    {
        // private vars
        private Rechthoek _grafischVenster;
        private Guid _id;
        private bool _verwijderd = false;
        private Graphics _papier;

        // readonly vars
        public Rechthoek GrafischVenster { get { return _grafischVenster; } }
        public Guid Id { get { return _id; } }

        // public vars
        public Color KaderKleur{get;set;}
        public Color Kleur { get; set; }
        public Point Locatie {
            get {return Tekengebied.Locatie; }
            set { Tekengebied.Locatie = value; }
        }
        public Graphics Papier
        {
            get { return _papier; }
            set
            {
                _papier = value;
                if (value != null)
                {
                    int breedteVenster = (int)Papier.VisibleClipBounds.Width;
                    int hoogteVenster = (int)Papier.VisibleClipBounds.Height;
                    _grafischVenster = new Rechthoek(new Point(0, 0), new Size(breedteVenster, hoogteVenster));
                }
            }
        }
        public Rechthoek Tekengebied { get; set; }
        public Color WisKleur { get; set; }

	    public event EventHandler<EventArgs> OpObject;

	    protected virtual void OnOpObject(object sender)
	    {
		    if (OpObject != null)
			{
				OpObject(this, EventArgs.Empty);
			}
		}

	    public void IsOpObject(Point punt)
	    {
		    if (punt.X >= Tekengebied.A.X &&
				punt.X <= Tekengebied.B.X &&
				punt.Y >= Tekengebied.A.Y &&
				punt.Y <= Tekengebied.D.Y
		    )
		    {
			    OnOpObject(this);
		    }
	    }

        // constructor
        public GrafischObject() {
            InitClass();
        }

        protected void InitClass() {
            KaderKleur = Color.Black;
            Kleur = Color.WhiteSmoke;
            WisKleur = Color.PaleGoldenrod;

            Tekengebied = new Rechthoek(); // Oorspronkelijk geen default constructor in Rechthoek
            _id = new Guid();

        }

        // methods
        public void Teken() {
            Teken(Papier);
        }
        public void Teken(Graphics papier) {
            Papier = papier;
            Pen pen = new Pen(KaderKleur, 2);

            if (Papier != null) {
                Papier.DrawRectangle(pen, Tekengebied.ToRectangle());
                pen.Dispose();

                SolidBrush kwast = new SolidBrush(Kleur);
                Papier.FillRectangle(kwast, Tekengebied.ToRectangle());
                kwast.Dispose();
            }
        }
        public void Verwijder()
        {
            _verwijderd = true;
            Wis();
        }
        public void Wis() { 
            Color oudeKleur = Kleur;
            Color oudeKaderKleur = KaderKleur;
            Kleur = WisKleur;
            KaderKleur = WisKleur;
            Teken();
            KaderKleur = oudeKaderKleur;
            Kleur = oudeKleur;
        }

    }
}
