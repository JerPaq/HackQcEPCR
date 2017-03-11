using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiteBus.Models
{
    public class ArretTaxibus
    {
        //Attributs
        public string code { get; set; }
        public string zone { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }


        public ArretTaxibus() { }

    }
}