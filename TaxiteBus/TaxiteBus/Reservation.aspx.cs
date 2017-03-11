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

        protected void EnregistrerReservationJSON(object sender, EventArgs e)
        {
            List<Reservation> lstReservations = new List<Reservation>();

            lstReservations.Add(
                new Reservation(
                    new ApplicationUser(),
                    new JSONTaxiBus(),
                    new JSONTaxiBus()));
            lstReservations.Add(
                new Reservation(
                    new ApplicationUser(),
                    new JSONTaxiBus(),
                    new JSONTaxiBus()));
            lstReservations.Add(
                new Reservation(
                    new ApplicationUser(),
                    new JSONTaxiBus(),
                    new JSONTaxiBus()));
            lstReservations.Add(
                new Reservation(
                    new ApplicationUser(),
                    new JSONTaxiBus(),
                    new JSONTaxiBus()));

            string json = JsonConvert.SerializeObject(lstReservations.ToArray());
            System.IO.File.WriteAllText(@"D:\fichier.json", json);
        }

        protected void ChargerReservationJSON(object sender, EventArgs e)
        {
            string json = System.IO.File.ReadAllText(@"D:\fichier.json");
            List<Reservation> lstReservations = JsonConvert.DeserializeObject<List<Reservation>>(json);
        }

    }
}