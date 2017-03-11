using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiteBus.Structures;

namespace TaxiteBus.Models
{
    public sealed class CreateurDeTrajets
    {
        private static readonly CreateurDeTrajets instance = new CreateurDeTrajets();

        private CreateurDeTrajets() { }

        public static CreateurDeTrajets Instance
        {
            get
            {
                return instance;
            }
        }
        
        private List<Trajet> trajets = new List<Trajet>();
        

        public void CalculerTrajets()
        {
            // Pour chaque ligne
            foreach (String currentZonesLignesNoms in ArretsTaxiBus.ZONES_LIGNES_NOMS)
            {
               
            }
            // Pour chaque réservation dans moins d'une heures
            // Découper par quatre en optimisant à partir du plus loin de la guare
        }

    }
}