using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TaxiteBus.Models
{
    public class Reservation
    {
        //Attributs
        public ApplicationUser client { get; set; }
        public ArretTaxibus depart { get; set; }
        public ArretTaxibus arrivee { get; set; }

        public Reservation() { }

        public string getJsonString(string path)
        {
            return JsonConvert.SerializeObject(this);
        }

        

    }
}