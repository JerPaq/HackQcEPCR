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
        public ArretsTaxiBus depart { get; set; }
        public ArretsTaxiBus arrivee { get; set; }
        public string heure { get; set; }

        public Reservation() { }

        public Reservation(ApplicationUser pClient, ArretsTaxiBus pDepart, ArretsTaxiBus pArrivee)
        {
            client = pClient;
            depart = pDepart;
            arrivee = pArrivee;
        }

        public string getJsonString(string path)
        {
            return JsonConvert.SerializeObject(this);
        }


    }
}