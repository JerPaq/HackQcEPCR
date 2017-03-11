using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
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
        public List<Trajet> Trajets
        {
            get { return this.trajets; }
        }


        public void CalculerTrajets()
        {
            ArretsTaxiBus arretTaxiBus = ArretsTaxiBus.Instance;
            List<Reservation> lstReservations = new List<Reservation>();
            List<String> points = new List<string>();
            Random random = new Random();

            for (int i = 0; i <= 10; i++)
            {
                lstReservations.Add(
                    new Reservation(
                        new ApplicationUser(),
                       arretTaxiBus.Arrets[(int)(random.NextDouble() * arretTaxiBus.Arrets.Length)],
                       arretTaxiBus.Arrets[(int)(random.NextDouble() * arretTaxiBus.Arrets.Length)],
                       DateTime.Now));
            }


            ArretsTaxiBus arretsTaxiBus = ArretsTaxiBus.Instance;
            GeoCoordinate gare = new GeoCoordinate(48.4506343914947, -68.5289754901558);

   
            // Pour chaque ligne
       //     foreach (String currentZonesLignesNoms in ArretsTaxiBus.ZONES_LIGNES_NOMS)
            {
                //Groupe les réservations par quatre
                Trajet trajetCourrant  = new Trajet();
                this.trajets.Add(trajetCourrant);
                foreach (Reservation currentReservation in lstReservations.OrderByDescending(r=>gare.GetDistanceTo(new GeoCoordinate(r.Depart.geometry.coordinates[1], r.Depart.geometry.coordinates[0]))))
                {
                    if (trajetCourrant.Reservations.Count == 4)
                    {
                        this.TrierFeatures(trajetCourrant);
                        trajetCourrant = new Trajet();
                        
                        this.trajets.Add(trajetCourrant);
                    }
                    trajetCourrant.Reservations.Add(currentReservation);
                }




            }
            // Pour chaque réservation dans moins d'une heures
            // Découper par quatre en optimisant à partir du plus loin de la guare
        }

        //---------------------------------------------------------------------
        public void TrierFeatures(Trajet argTrajet)
        {
            String uRL = "https://maps.googleapis.com/maps/api/directions/json";
            uRL += "?origin=48.4500474479996,-68.5221157196905";
            uRL += "&destination=48.4500474479996,-68.5221157196905";
            uRL += "&waypoints=optimize:true";
            foreach (Features currentFeatures in argTrajet.Features)
            {
                uRL += "|" + currentFeatures.geometry.coordinates[1].ToString().Replace(',', '.') + "," + currentFeatures.geometry.coordinates[0].ToString().Replace(',', '.');
            }
            uRL += "&key=AIzaSyB16oFkTxj39_YELrwqLJr5TMMBTAIkPFc";


            Uri uri = new Uri(uRL);

            string rep = GetRequest(uri);
            JSONCheminEntreDeuxPoints jSONCheminEntreDeuxPoints = new JSONCheminEntreDeuxPoints();

            using (MemoryStream mem = new MemoryStream(Encoding.UTF8.GetBytes(rep)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(jSONCheminEntreDeuxPoints.GetType());
                jSONCheminEntreDeuxPoints = ser.ReadObject(mem) as JSONCheminEntreDeuxPoints;
            }

            List<Features> tries = new List<Features>();
            argTrajet.FeaturesTries.Add(ArretsTaxiBus.Instance.Arrets.First(a=>a.properties.CODE=="Gare"));
            foreach (int currentPoint in jSONCheminEntreDeuxPoints.routes[0].waypoint_order)
            {
                argTrajet.FeaturesTries.Add(argTrajet.Features.ElementAt(currentPoint));

            }
            argTrajet.FeaturesTries.Add(ArretsTaxiBus.Instance.Arrets.First(a => a.properties.CODE == "Gare"));
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// Méthode pour envoyer la requête http
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string GetRequest(Uri uri)
        {
            string answer = string.Empty;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
            {
                if (req.HaveResponse && res.StatusCode == HttpStatusCode.OK)
                    using (Stream resin = res.GetResponseStream())
                    {
                        using (StreamReader rea = new StreamReader(resin))
                        {
                            answer = rea.ReadToEnd();
                        }
                    }
            }

            return answer;
        }

    }
}