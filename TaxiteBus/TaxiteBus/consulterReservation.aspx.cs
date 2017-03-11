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
        public Dictionary<String, Reservation> dictionnaire = new Dictionary<String, Reservation>();

        protected void Page_Load(object sender, EventArgs e)
        {
            lstReserves = ChargerReservationJSON();
            foreach (Reservation reserv in lstReserves)
            {
                String cle = reserv.Depart.ToString() + " à " + reserv.Arrivee.ToString() + ", " + reserv.Heure.ToString();
                dictionnaire.Add(cle, reserv);
            }
            lstbxReservation.DataSource = dictionnaire;
            lstbxReservation.DataTextField = "Key";
            lstbxReservation.DataValueField = "Value";
            lstbxReservation.DataBind();
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

    }
}