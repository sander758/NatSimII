using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NatSimII
{
    public partial class frmNatSimII : Form
    {
        //
        // Initialisatie
        //
        Graphics papier;

	    SoortLeven soortPlant = SoortLeven.Gras;
	    SoortLeven soortDier = SoortLeven.Konijn;

	    Natuur natuur = new Natuur();

		public frmNatSimII()
        {
            InitializeComponent();
            papier = pbWereld.CreateGraphics();
	        natuur.NieuwLeven += natuur_NieuwLeven;
	        natuur.Getroffen += natuur_Getroffen;
        }

	    void natuur_NieuwLeven(object sender, NieuwLevenEventArgs e)
	    {
		    e.NieuwLeven.Teken(papier);
	    }

	    void natuur_Getroffen(object sender, GetroffenEventArgs e)
	    {
		    lblInformatie.Text = e.GeraaktOp.ToString("hh:mm:ss tt") +
		                         Environment.NewLine + Environment.NewLine +
		                         e.Getroffen.ToString();
	    }

        private void ResizePictureBox() {
            // Deze methode zorgt ervoor dat de grootte van de picturebox
            // aangepast wordt als het formulier geresized wordt

            int margeBreedte = 40;
            int margeHoogte = 64;

            pbWereld.Width = this.Width - grbDieren.Width - grbPlanten.Width - margeBreedte;
            pbWereld.Height = this.Height - margeHoogte;
            pbWereld.CreateGraphics();
        }

        private void ResizeLblInformatie() {
            // Deze methode zorgt ervoor dat de hoogte van het label
            // aangepast wordt als het formulier geresized wordt

            int margeHoogte = 88;

            lblInformatie.Height = this.Height - margeHoogte - pnlKnoppen.Height;
        }

        private void frmNatSim_Resize(object sender, EventArgs e)
        {
            // methodes voor resizen picturebox en lbl aanroepen
            ResizePictureBox();
            ResizeLblInformatie();
        }

        private void pbWereld_MouseClick(object sender, MouseEventArgs e)
        {
			SoortLeven soortleven = SoortLeven.Gras;
	        if (e.Button == MouseButtons.Left)
	        {
		        soortleven = soortDier;
	        }
	        else if (e.Button == MouseButtons.Right)
	        {
		        soortleven = soortPlant;
	        }
			Console.WriteLine("blah: " + soortleven );
	        switch (soortleven)
	        {
		        case SoortLeven.Gras:
			        natuur.Add(new Gras(e.Location));
			        break;
		        case SoortLeven.Vingerhoedskruid:
			        natuur.Add(new Vingerhoedskruid(e.Location));
			        break;
		        case SoortLeven.Venijnboom:
			        natuur.Add(new Venijnboom(e.Location));
			        break;
		        case SoortLeven.Koe:
			        natuur.Add(new Koe(e.Location));
			        break ;
		        case SoortLeven.Konijn:
			        natuur.Add(new Konijn(e.Location));
			        break;
		        case SoortLeven.Beer:
			        //natuur.Add(new Beer(e.Location));
			        break;
			    case SoortLeven.Lynx:
				    //natuur.Add(new Lynx(e.Location));
			        break;
				default:
			        break;
		    }
		}

	    private void rdbKonijn_CheckedChanged(object sender, EventArgs e)
	    {
			if (rdbKonijn.Checked) soortDier = SoortLeven.Konijn;
		}

		private void rdbKoe_CheckedChanged(object sender, EventArgs e)
		{
			if (rdbKoe.Checked) soortDier = SoortLeven.Koe;
		}

		private void rdbLynx_CheckedChanged(object sender, EventArgs e)
		{
			if (rdbLynx.Checked) soortDier = SoortLeven.Lynx;
		}

		private void rdbBeer_CheckedChanged(object sender, EventArgs e)
		{
			if (rdbBeer.Checked) soortDier = SoortLeven.Beer;
		}


	    private void rdbGras_CheckedChanged(object sender, EventArgs e)
	    {
		    if (rdbGras.Checked) soortPlant = SoortLeven.Gras;
		}

		private void rdbVenijnBoom_CheckedChanged(object sender, EventArgs e)
		{
			if (rdbVenijnBoom.Checked) soortPlant = SoortLeven.Venijnboom;
		}

		private void rdbVingerhoedskruid_CheckedChanged(object sender, EventArgs e)
		{
			if (rdbVingerhoedskruid.Checked) soortPlant = SoortLeven.Vingerhoedskruid;
		}

		private void pbWereld_MouseMove(object sender, MouseEventArgs e)
		{
			if (chkZaai.Checked)
			{
				if (rdbGras.Checked)
				{
					natuur.Zaaien(e.Location, pbWereld.CreateGraphics(), new Gras());
				}
				else if (rdbVenijnBoom.Checked)
				{
					natuur.Zaaien(e.Location, pbWereld.CreateGraphics(), new Venijnboom());
				}
				else if (rdbVingerhoedskruid.Checked)
				{
					natuur.Zaaien(e.Location, pbWereld.CreateGraphics(), new Vingerhoedskruid());
				}
				
			}
			else
			{
				lblInformatie.Text = "";
				natuur.LevenGeraakt(e.Location);
			}
		}
	}
}
