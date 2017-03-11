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
            ArretsTaxiBus arretTaxiBus = ArretsTaxiBus.Instance;
            string coorDepart = this.HiddenField1.Value;
            string[] tblCoorDepart = coorDepart.Split(',');
            string coorDestination = this.HiddenField2.Value;
            string[] tblCoorDestinatition = coorDestination.Split(',');
            List<String> points = new List<string>();

            
            List<int> deja = new List<int>();
            int nbArret = (int)(arretTaxiBus.Arrets.Length);

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

        protected void EnregistrerReservationJSON(List<Reservation> lstReservations)
        { 
            string json = JsonConvert.SerializeObject(lstReservations.ToArray());
            System.IO.File.WriteAllText("reservations.json", json);
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

        private void reserver(JSONTaxiBus pDepart, JSONTaxiBus pArriver, DateTime pHeure)
        {
            // Permet d'aller chercher l'utilisateur connecter (l'objet)
            List<Reservation> lstReservations = ChargerReservationJSON();
            Reservation reservation = new Reservation();
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            reservation.client = user;
            reservation.depart = pDepart;
            reservation.arrivee = pArriver;
            reservation.heure = pHeure;
            lstReservations.Add(reservation);
            EnregistrerReservationJSON(lstReservations);
        }

        protected void btnSoumettre_Click(object sender, EventArgs e)
        {
            //string json = '{"name":"arrettaxibus","type":"FeatureCollection","features":[{"type":"Feature","geometry":{"type":"Point","coordinates":[-68.7300404059768,48.3642527016064]},"properties":{"OBJECTID":1,"CODE":"2919","Type_arret":"Taxibus - Zone verte","X":213665.7513,"Y":5359125.5464,"SEM_SEUL":"6:40, 7:10, 7:40, 7:50, 8:20, 8:40, 11:10, 11:50, 12:20, 12:40, 14:40, 16:10, 16:20, 16:50, 17:10, 17:20, 17:40, 18:20, 21:20","FDS_SEUL":"7:40, 8:20, 8:40, 9:20, 10:40, 11:20, 12:40, 13:20, 13:40, 16:20, 16:40","FDS_VERS_BUS":"7:40*, 8:40*, 10:40*, 12:40*, 13:40*, 16:40*","SEM_VERS_BUS":"6:40, 7:10, 7:40, 8:40*, 11:10, 12:10***, 12:40*, 14:40*, 16:10, 17:10***, 17:40*","SEM_VERS_TAXI":"7:50, 8:20, 11:50, 12:20, 16:20, 16:50, 17:20, 18:20, 21:20**, 23:20**","FDS_VERS_TAXI":"8:20**, 9:20**, 11:20**, 13:20**, 16:20**, 18:20**","Notes":"* Correspondance avec CitÃ©bus plus rapide Ã  partir du MusÃ©e.\r\n** DÃ©part Ã  partir du MusÃ©e seulement.\r\n***MusÃ©e : demi-circuit Ã  destination de la Gare."}},{"type":"Feature","geometry":{"type":"Point","coordinates":[-68.592594042149,48.4333552821971]},"properties":{"OBJECTID":255,"CODE":"2520","Type_arret":"Taxibus - Zone verte","X":223958.6354,"Y":5366654.4043,"SEM_SEUL":"6:40, 7:10, 7:40, 7:50, 8:20, 8:40, 11:10, 11:50, 12:20, 12:40, 14:40, 16:10, 16:20, 16:50, 17:10, 17:20, 17:40, 18:20, 21:20","FDS_SEUL":"7:40, 8:20, 8:40, 9:20, 10:40, 11:20, 12:40, 13:20, 13:40, 16:20, 16:40","FDS_VERS_BUS":"7:40*, 8:40*, 10:40*, 12:40*, 13:40*, 16:40*","SEM_VERS_BUS":"6:40, 7:10, 7:40, 8:40*, 11:10, 12:10***, 12:40*, 14:40*, 16:10, 17:10***, 17:40*","SEM_VERS_TAXI":"7:50, 8:20, 11:50, 12:20, 16:20, 16:50, 17:20, 18:20, 21:20**, 23:20**","FDS_VERS_TAXI":"8:20**, 9:20**, 11:20**, 13:20**, 16:20**, 18:20**","Notes":"* Correspondance avec CitÃ©bus plus rapide Ã  partir du MusÃ©e.\r\n** DÃ©part Ã  partir du MusÃ©e seulement.\r\n***MusÃ©e : demi-circuit Ã  destination de la Gare."}}]}';
            reserver(null, null, new DateTime(2017,03,13,15,53,0));
            
        }
    }
}