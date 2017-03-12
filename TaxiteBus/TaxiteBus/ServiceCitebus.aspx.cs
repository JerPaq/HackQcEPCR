using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxiteBus.Structures;
using TaxiteBus.Structures.CiteBus;

namespace TaxiteBus
{
    public partial class ServiceCitebus : System.Web.UI.Page
    {

        public TaxiteBus.Structures.CiteBus.Features[] circuit11;
        public TaxiteBus.Structures.CiteBus.Features[] circuit21;
        public TaxiteBus.Structures.CiteBus.Features[] circuit31;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArretsCiteBus arretsCiteBus = ArretsCiteBus.Instance;

            List<int> deja = new List<int>();
            Random random = new Random();
            int alea;
            String virgule = "";
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    alea = ((int)(random.NextDouble() * arretsCiteBus.Arrets.Length));
                } while (deja.Contains(alea));
                deja.Add(alea);
                LiteralLatitude.Text += virgule + arretsCiteBus.Arrets[alea].geometry.coordinates[1].ToString().Replace(',', '.');
                LiteralLongitude.Text += virgule + arretsCiteBus.Arrets[alea].geometry.coordinates[0].ToString().Replace(',', '.');
                virgule = ",";
            }

            //Circuit 11
            circuit11 = arretsCiteBus.Arrets.Where(t => t.properties.Circuit == 11).ToArray();
            virgule = "";
            for (int i = 0; i < circuit11.Count(); i++)
            {
                LiteralLatitude11.Text += virgule + circuit11[i].geometry.coordinates[1].ToString().Replace(',', '.');
                LiteralLongitude11.Text += virgule + circuit11[i].geometry.coordinates[0].ToString().Replace(',', '.');
                virgule = ",";
            }
            //Circuit 21
            circuit21 = arretsCiteBus.Arrets.Where(t => t.properties.Circuit == 21).ToArray();
            virgule = "";
            for (int i = 0; i < circuit21.Count(); i++)
            {
                LiteralLatitude21.Text += virgule + circuit21[i].geometry.coordinates[1].ToString().Replace(',', '.');
                LiteralLongitude21.Text += virgule + circuit21[i].geometry.coordinates[0].ToString().Replace(',', '.');
                virgule = ",";
            }
            //Circuit 31
            circuit31 = arretsCiteBus.Arrets.Where(t => t.properties.Circuit == 31).ToArray();
            virgule = "";
            for (int i = 0; i < circuit31.Count(); i++)
            {
                LiteralLatitude31.Text += virgule + circuit31[i].geometry.coordinates[1].ToString().Replace(',', '.');
                LiteralLongitude31.Text += virgule + circuit31[i].geometry.coordinates[0].ToString().Replace(',', '.');
                virgule = ",";
            }

        }

        protected string deuxDigits(TaxiteBus.Structures.CiteBus.Features arret)
        {
            //L'attribut "Horaire_SEM" est une string de la forme "7:08, 7:38, 8:08, 8:38..."
            //On a donc besoin des 2e et 3e caractères pour avoir nos deux digits
            string heure = arret.properties.Horaire_SEM;
            return heure.Substring(2, 2);
        }

    }
}