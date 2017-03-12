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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Device.Location;

namespace TaxiteBus
{

    public partial class reservation : System.Web.UI.Page
    {
        ArretsTaxiBus arretTaxiBus = ArretsTaxiBus.Instance;

        
        public List<string> lstString;


        protected void Page_Load(object sender, EventArgs e)
        {
            TxbDepart.Text = HiddenFieldDepart.Value;
            TxbDestination.Text = HiddenFieldDestinataire.Value;

            //if (txtPlaces.Text = "");
            //{

            //}
           
        }

        protected void EnregistrerReservationJSON(List<Reservation> lstReservations)
        { 
            string json = JsonConvert.SerializeObject(lstReservations.ToArray());
            System.IO.File.WriteAllText("reservations.json", json);
        }

        private double calculerDistanceDepart(double lat, double lon, double lat2, double lon2)
        {
            var coord1 = new GeoCoordinate(lat, lon);
            var coord2 = new GeoCoordinate(lat2, lon2);
            return coord1.GetDistanceTo(coord2);
        }

        protected List<Reservation> ChargerReservationJSON()
        {
            if(File.Exists("reservations.json"))
            {
                string json = System.IO.File.ReadAllText("reservations.json");
                return JsonConvert.DeserializeObject<List<Reservation>>(json);
            }
            else
            {
                return new List<Reservation>();
            }            
        }

        private void reserver(Features pDepart, Features pArriver, DateTime pHeure)
        {
            // Permet d'aller chercher l'utilisateur connecter (l'objet)
            List<Reservation> lstReservations = ChargerReservationJSON();
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            Reservation reservation = new Reservation(user,pDepart,pArriver,pHeure);
            lstReservations.Add(reservation);
            EnregistrerReservationJSON(lstReservations);
        }

        protected void btnSoumettre_Click(object sender, EventArgs e)
        {
            reserver(null, null, new DateTime(2017, 03, 13, 15, 53, 0));
        }

        public void afficherCarte()
        {
            List<String> points = new List<string>();

            List<int> deja = new List<int>();
            Random random = new Random();
            int alea;
            String virgule = "";
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    alea = ((int)(random.NextDouble() * arretTaxiBus.Arrets.Length));
                } while (deja.Contains(alea));
                deja.Add(alea);
                LiteralLatitude.Text += virgule + arretTaxiBus.Arrets[alea].geometry.coordinates[1].ToString().Replace(',', '.');
                LiteralLongitude.Text += virgule + arretTaxiBus.Arrets[alea].geometry.coordinates[0].ToString().Replace(',', '.');
                virgule = ",";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HiddenFieldBtnCliquer.Value = "depart";
            string coorDepart = this.HiddenField1.Value;
            string[] tblCoorDepart = coorDepart.Split(',');
            double coorDepartLat = Double.Parse(tblCoorDepart[0].Replace('.', ','));
            double coorDepartLong = Double.Parse(tblCoorDepart[1].Replace('.', ','));
            
            if (this.HiddenField2.Value != "")
            {
                string coorDestination = this.HiddenField2.Value;
                string[] tblCoorDestination = coorDestination.Split(',');
                double coorDestitLat = Double.Parse(tblCoorDestination[0].Replace('.', ','));
                double coorDestiLong = Double.Parse(tblCoorDestination[1].Replace('.', ','));
            }
            
            List<String> points = new List<string>();


            int nbArret = (int)(arretTaxiBus.Arrets.Length);


            int index = 0;
            List<List<double>> lstDistances = new List<List<double>>();
            for (int i = 0; i < nbArret - 1; i++)
            {
                double lat = arretTaxiBus.Arrets[i].geometry.coordinates[0];
                double lon = arretTaxiBus.Arrets[i].geometry.coordinates[1];
                double lat2 = arretTaxiBus.Arrets[i + 1].geometry.coordinates[0];
                double lon2 = arretTaxiBus.Arrets[i + 1].geometry.coordinates[1];

                double valeur = calculerDistanceDepart(coorDepartLat, coorDepartLong, coorDepartLat, coorDepartLong) -
                     calculerDistanceDepart(coorDepartLat, coorDepartLong, lat2, lon2);
                List<double> lstDistance = new List<double>();
                lstDistance.Add(valeur);
                lstDistance.Add(i);
                lstDistances.Add(lstDistance);

            }
            lstDistances[0].OrderBy(d => d);
            string virgule = "";
            LiteralLatitude.Text = "";
            LiteralLongitude.Text = "";
            
            for (int i = 0; i < 5; i++)
            {
                LiteralLatitude.Text += virgule + arretTaxiBus.Arrets[(int)lstDistances[i][1]].geometry.coordinates[1].ToString().Replace(',', '.');
                LiteralLongitude.Text += virgule + arretTaxiBus.Arrets[(int)lstDistances[i][1]].geometry.coordinates[0].ToString().Replace(',', '.');
                virgule = ",";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HiddenFieldBtnCliquer.Value = "destination";
            string coorDepart = this.HiddenField2.Value;
            string[] tblCoorDepart = coorDepart.Split(',');
            double coorDepartLat = Double.Parse(tblCoorDepart[0].Replace('.', ','));
            double coorDepartLong = Double.Parse(tblCoorDepart[1].Replace('.', ','));
            string coorDestination = this.HiddenField2.Value;
            string[] tblCoorDestination = coorDestination.Split(',');
            List<String> points = new List<string>();


            int nbArret = (int)(arretTaxiBus.Arrets.Length);


            int index = 0;
            List<List<double>> lstDistances = new List<List<double>>();
            for (int i = 0; i < nbArret - 1; i++)
            {
                double lat = arretTaxiBus.Arrets[i].geometry.coordinates[0];
                double lon = arretTaxiBus.Arrets[i].geometry.coordinates[1];
                double lat2 = arretTaxiBus.Arrets[i + 1].geometry.coordinates[0];
                double lon2 = arretTaxiBus.Arrets[i + 1].geometry.coordinates[1];

                double valeur = calculerDistanceDepart(coorDepartLat, coorDepartLong, coorDepartLat, coorDepartLong) -
                     calculerDistanceDepart(coorDepartLat, coorDepartLong, lat2, lon2);
                List<double> lstDistance = new List<double>();
                lstDistance.Add(valeur);
                lstDistance.Add(i);
                lstDistances.Add(lstDistance);

            }
            //lstDistances[0].OrderBy(d => d);
            string virgule = "";
            LiteralLatitude.Text = "";
            LiteralLongitude.Text = "";
        
            for (int i = 0; i < 5; i++)
            {
                LiteralLatitude2.Text += virgule + arretTaxiBus.Arrets[(int)lstDistances[i][1]].geometry.coordinates[1].ToString().Replace(',', '.');
                LiteralLongitude2.Text += virgule + arretTaxiBus.Arrets[(int)lstDistances[i][1]].geometry.coordinates[0].ToString().Replace(',', '.');
                virgule = ",";
            }
        }
    }
}