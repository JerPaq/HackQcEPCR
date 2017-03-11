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

        protected void Page_Load(object sender, EventArgs e)
        {

            lstReserves = ChargerReservationJSON();
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