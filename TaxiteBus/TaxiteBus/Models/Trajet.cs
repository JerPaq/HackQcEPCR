using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiteBus.Structures;

namespace TaxiteBus.Models
{
    public class Trajet
    {
        private List<Reservation> reservations = new List<Reservation>();
        public List<Reservation> Reservations
        {
            get { return this.reservations; }
            set { this.reservations = value; }
        }

        public HashSet<Features> Features
        {
            get
            {
                HashSet<Features> result = new HashSet<Features>();
                foreach (Reservation currentReservation in this.reservations)
                {
                    result.Add(currentReservation.Depart);
                    result.Add(currentReservation.Arrivee);
                }
                return result;

            }
        }

        private List<Features> featuresTries = new List<Features>();
        public List<Features> FeaturesTries
        {
            get { return this.featuresTries; }
            set { this.featuresTries = value; }
        }
    }
}