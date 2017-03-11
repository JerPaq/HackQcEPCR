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

        private void reserver(JSONTaxiBus pDepart, JSONTaxiBus pArriver, DateTime pHeure)
        {
            // Permet d'aller chercher l'utilisateur connecter (l'objet)
            Reservation reservation = new Reservation();
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            reservation.client = user;
            reservation.depart = pDepart;
            reservation.arrivee = pArriver;
            reservation.heure = pHeure;

        }

        protected void btnSoumettre_Click(object sender, EventArgs e)
        {

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