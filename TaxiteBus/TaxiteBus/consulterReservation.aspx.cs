using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using TaxiteBus.Models;

namespace TaxiteBus
{
    public partial class consulterReservation : System.Web.UI.Page
    {
        //Attributs
        public List<Reservation> lstReserves;
        public List<Trajet> lstTrajet;
        public Dictionary<String, Reservation> dicReserv = new Dictionary<String, Reservation>();

        protected void Page_Load(object sender, EventArgs e)
        {
            afficherReserv();
            afficherTrajet();
        }

        protected void afficherReserv()
        {
            lstReserves = ChargerReservationJSON();
            foreach (Reservation reserv in lstReserves)
            {
                if (!reserv.DansTrajet)
                {
                    String cle = reserv.Depart.ToString() + " à " + reserv.Arrivee.ToString() + ", " + reserv.Heure.ToString();
                    dicReserv.Add(cle, reserv);
                }
            }
            lstbxReservation.DataSource = dicReserv;
            lstbxReservation.DataTextField = "Key";
            lstbxReservation.DataValueField = "Value";
            lstbxReservation.DataBind();
        }

        protected void afficherTrajet()
        {

        }

        protected List<Reservation> ChargerReservationJSON()
        {
            if (File.Exists("reservations.json"))
            {
                string json = System.IO.File.ReadAllText("reservations.json");
                return JsonConvert.DeserializeObject<List<Reservation>>(json);
            }
            else
            {
                return new List<Reservation>();
            }
        }

        protected List<Trajet> ChargerTrajetJSON()
        {
            if (File.Exists("Trajets.json"))
            {
                string json = System.IO.File.ReadAllText("Trajets.json");
                return JsonConvert.DeserializeObject<List<Trajet>>(json);
            }
            else
            {
                return new List<Trajet>();
            }
        }
        protected void EnregistrerTrajetJSON(List<Trajet> lstTrajet)
        {
            string json = JsonConvert.SerializeObject(lstTrajet.ToArray());
            System.IO.File.WriteAllText("Trajets.json", json);
        }

    }
}