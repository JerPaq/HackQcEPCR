using System;
using System.Collections.Generic;
using System.Linq;
using TaxiteBus.Models;
using TaxiteBus.Structures;

namespace TaxiteBus
{
    public partial class TestGino : System.Web.UI.Page
    {
        List<Reservation> reservations = CreerReservationsAleatoires();
        protected void Page_Load(object sender, EventArgs e)
        {
            ArretsTaxiBus arretTaxiBus = ArretsTaxiBus.Instance;

            CreateurDeTrajets.Instance.CalculerTrajets(reservations);

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

        //---------------------------------------------------------------------
        private static List<Reservation> CreerReservationsAleatoires()
        {
            List<Reservation> result = new List<Reservation>();
            List<String> points = new List<string>();
            Random random = new Random();

            // Créer une liste de réservation au hasard
            for (int i = 0; i <= 0; i++)
            {
                Features depart = ArretsTaxiBus.Instance.Arrets[(int)(random.NextDouble() * ArretsTaxiBus.Instance.Arrets.Length)];

                // Features 
                Features arret = null;
                do
                {
                    arret = ArretsTaxiBus.Instance.Arrets.Where(r => depart.properties.Type_arret == r.properties.Type_arret).ToArray()[(int)(random.NextDouble() * ArretsTaxiBus.Instance.Arrets.Where(r => depart.properties.Type_arret == r.properties.Type_arret).Count())];
                    //arret = ArretsTaxiBus.Instance.Arrets[(int)(random.NextDouble() * ArretsTaxiBus.Instance.Arrets.Length)];
                } while (arret == depart);

                result.Add(
                    new Reservation(
                        new ApplicationUser(),
                       depart,
                       arret,
                       DateTime.Now.AddMinutes((int)(random.NextDouble() * 50))));
            }

            return result;
        }

        //---------------------------------------------------------------------
    }



}