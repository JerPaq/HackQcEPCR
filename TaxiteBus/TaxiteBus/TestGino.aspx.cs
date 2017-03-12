using System;
using System.Collections.Generic;
using System.Linq;
using TaxiteBus.Models;
using TaxiteBus.Structures;

namespace TaxiteBus
{
    public partial class TestGino : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArretsTaxiBus arretTaxiBus = ArretsTaxiBus.Instance;

            CreateurDeTrajets.Instance.CalculerTrajets();

            List<String> points = new List<string>();

          //  taxibus.jSONTaxiBus.features = taxibus.jSONTaxiBus.features.Where(t => t.properties.Type_arret == "Taxibus - Zone verte").ToArray();
           
            String virgule = "";
            foreach (Features currentFeature in CreateurDeTrajets.Instance.Trajets[0].FeaturesTries)
            {
                LiteralLatitude.Text += virgule + currentFeature.geometry.coordinates[1].ToString().Replace(',', '.');
                LiteralLongitude.Text += virgule + currentFeature.geometry.coordinates[0].ToString().Replace(',', '.');
                virgule = ",";
            }
            //  this.legs.AddRange(GoogleMapManager.GetOptimizedPath(points, true).routes.First().legs);
        }
    }
}