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
        private ApplicationUser client;
        public ApplicationUser Client
        {
            get { return this.client; }
            set { this.client = value; }
        }

        private Features depart;
        public Features Depart
        {
            get { return this.depart; }
            set { this.depart = value; }
        }
        private Features arrivee;
        public Features Arrivee
        {
            get { return this.arrivee; }
            set { this.arrivee = value; }
        }

        private DateTime heure;
        public DateTime Heure
        {
            get { return this.heure; }
            set { this.heure = value; }
        }

        public Reservation() { }

        public Reservation(ApplicationUser pClient, Features pDepart, Features pArrivee, DateTime pHeure)
        {
            this.client = pClient;
            this.depart = pDepart;
            this.arrivee = pArrivee;
            this.heure = pHeure;
        }

        public string getJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }


    }
}