using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using TaxiteBus.Structures;

namespace TaxiteBus.Models
{
    public class Reservation
    {
        //Attributs
        public ApplicationUser client { get; set; }
        public JSONTaxiBus depart { get; set; }
        public JSONTaxiBus arrivee { get; set; }
        public DateTime heure { get; set; }

        public Reservation() { }

        public Reservation(ApplicationUser pClient, JSONTaxiBus pDepart, JSONTaxiBus pArrivee)
        {
            client = pClient;
            depart = pDepart;
            arrivee = pArrivee;
        }

        public string getJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }


    }
}