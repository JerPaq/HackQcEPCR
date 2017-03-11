﻿using System;
using System.Collections.Generic;
using System.Linq;
using TaxiteBus.Structures;

namespace TaxiteBus
{
    public partial class TestGino : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArretsTaxiBus arretTaxiBus = new ArretsTaxiBus();


            List<String> points = new List<string>();

          //  taxibus.jSONTaxiBus.features = taxibus.jSONTaxiBus.features.Where(t => t.properties.Type_arret == "Taxibus - Zone verte").ToArray();
            List<int> deja = new List<int>();
            Random random = new Random();
            int alea;
            String virgule = "";
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    alea = ((int)(random.NextDouble() * arretTaxiBus.jSONTaxiBus.features.Length));
                } while (deja.Contains(alea));
                deja.Add(alea);
                LiteralLatitude.Text += virgule + arretTaxiBus.jSONTaxiBus.features[alea].geometry.coordinates[1].ToString().Replace(',', '.');
                LiteralLongitude.Text += virgule + arretTaxiBus.jSONTaxiBus.features[alea].geometry.coordinates[0].ToString().Replace(',', '.');
                virgule = ",";
            }
            //  this.legs.AddRange(GoogleMapManager.GetOptimizedPath(points, true).routes.First().legs);
        }
    }
}