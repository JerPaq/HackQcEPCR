using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using TaxiteBus.Models;
using TaxiteBus.Structures;

namespace TaxiteBus
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArretsTaxiBus arretTaxiBus = new ArretsTaxiBus();

            List<String> points = new List<string>();

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

        protected void btnReserver_Click(object sender, EventArgs e)
        {
            Response.Redirect("reservation.aspx");
        }

        protected void btnTestClick(object sender, EventArgs e)
        {
            labelTest.InnerText = Context.User.Identity.Name;
        }

    }
}