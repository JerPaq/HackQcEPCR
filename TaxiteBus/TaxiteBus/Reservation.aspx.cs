using System;
using System.Collections.Generic;
using System.Linq;
using TaxiteBus.Structures;

namespace TaxiteBus
{

    public partial class reservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArretsTaxiBus arretTaxiBus = new ArretsTaxiBus();
            string coorDepart = this.HiddenField1.Value;
            string[] tblCoorDepart = coorDepart.Split(',');
            string coorDestination = this.HiddenField2.Value;
            string[] tblCoorDestinatition = coorDestination.Split(',');
            List<String> points = new List<string>();

            
            List<int> deja = new List<int>();
            int nbArret = (int)(arretTaxiBus.jSONTaxiBus.features.Length);

            //for ()
            //{

            //}

            String virgule = "";
            for (int i = 0; i < 10; i++)
            {
                //do
                //{
                    //alea = ((int)(arretTaxiBus.jSONTaxiBus.features.Length));
                //} while (deja.Contains(alea));
                //deja.Add(alea);
                //LiteralLatitude.Text += virgule + arretTaxiBus.jSONTaxiBus.features[alea].geometry.coordinates[1].ToString().Replace(',', '.');
                //LiteralLongitude.Text += virgule + arretTaxiBus.jSONTaxiBus.features[alea].geometry.coordinates[0].ToString().Replace(',', '.');
               // virgule = ",";
            }
            //  this.legs.AddRange(GoogleMapManager.GetOptimizedPath(points, true).routes.First().legs);
        }
    }
}