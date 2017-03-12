using Newtonsoft.Json;
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

        //---------------------------------------------------------------------
        private List<Trajet> trajets = new List<Trajet>();
        public List<Trajet> Trajets
        {
            get
            {
                CalculerTrajets();
                return this.trajets;
            }
        }

        //---------------------------------------------------------------------
        public void CalculerTrajets()
        {
            List<Reservation> lstReservations = this.ChargerReservationJSON();

            this.DiviserReservationSurDeuxZones(lstReservations);

            GeoCoordinate gare = new GeoCoordinate(48.4506343914947, -68.5289754901558);

            // Pour chaque ligne groupe les réservations par quatre
            foreach (String currentZonesLignesNoms in ArretsTaxiBus.ZONES_LIGNES_NOMS)
            {
                Trajet trajetCourrant = new Trajet();
                this.trajets.Add(trajetCourrant);
                foreach (Reservation currentReservation
                    in lstReservations.Where(r => (r.Depart.properties.Type_arret == currentZonesLignesNoms || r.Arrivee.properties.Type_arret == currentZonesLignesNoms)
                                                && r.Heure < DateTime.Now.AddHours(1)
                                                && !r.DansTrajet)
                    .OrderByDescending(r => gare.GetDistanceTo(new GeoCoordinate(r.Depart.geometry.coordinates[1], r.Depart.geometry.coordinates[0]))))
                {
                    if (trajetCourrant.Reservations.Count == 4)
                    {
                        this.TrierFeatures(trajetCourrant);
                        trajetCourrant = new Trajet();

                        this.trajets.Add(trajetCourrant);
                    }
                    trajetCourrant.Reservations.Add(currentReservation);
                    currentReservation.DansTrajet = true;
                }
                if (trajetCourrant.Features.Count != 0)
                    this.TrierFeatures(trajetCourrant);
                else
                    this.trajets.Remove(trajetCourrant);
            }
        }

        //------------------------------------------------------------------------
        private void DiviserReservationSurDeuxZones(List<Reservation> lstReservations)
        {
            foreach (Reservation currentReservation in lstReservations
                .Where(r => r.Heure < DateTime.Now.AddHours(1)
                && r.Depart.properties.Type_arret != r.Arrivee.properties.Type_arret).ToList())
            {
                Reservation newReservation = new Reservation(currentReservation.Client, ArretsTaxiBus.Instance.Arrets.First(a => a.properties.CODE == "Gare"), currentReservation.Arrivee, currentReservation.Heure);
                currentReservation.Arrivee = ArretsTaxiBus.Instance.Arrets.First(a => a.properties.CODE == "Gare");
                lstReservations.Add(newReservation);
            }
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
            JSONCheminGoogle jSONCheminGoogle = new JSONCheminGoogle();

            using (MemoryStream mem = new MemoryStream(Encoding.UTF8.GetBytes(rep)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(jSONCheminGoogle.GetType());
                jSONCheminGoogle = ser.ReadObject(mem) as JSONCheminGoogle;
            }

            List<Features> tries = new List<Features>();
            argTrajet.FeaturesTries.Add(ArretsTaxiBus.Instance.Arrets.First(a => a.properties.CODE == "Gare"));
            foreach (int currentPoint in jSONCheminGoogle.routes[0].waypoint_order)
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

        //---------------------------------------------------------------------
        private List<Reservation> ChargerReservationJSON()
        {
            List<Reservation> result = new List<Reservation>(); ;
            if (File.Exists("reservations.json"))
            {
                string json = System.IO.File.ReadAllText("reservations.json");
                result = JsonConvert.DeserializeObject<List<Reservation>>(json);
            }
            else
            {
                result = this.CreerReservationsAleatoires();
            }
            return result;
        }

        //---------------------------------------------------------------------
        private List<Reservation> CreerReservationsAleatoires()
        {
            List<Reservation> result = new List<Reservation>();
            List<String> points = new List<string>();
            Random random = new Random();

            // Créer une liste de réservation au hasard
            for (int i = 0; i <= 0; i++)
            {
                Features depart = ArretsTaxiBus.Instance.Arrets[(int)(random.NextDouble() * ArretsTaxiBus.Instance.Arrets.Length)];

                // Features arret = ArretsTaxiBus.Instance.Arrets.Where(r => depart.properties.Type_arret == r.properties.Type_arret).ToArray()[(int)(random.NextDouble() * ArretsTaxiBus.Instance.Arrets.Where(r => depart.properties.Type_arret == r.properties.Type_arret).Count())];
                Features arret = null;
                do
                {
                   arret = ArretsTaxiBus.Instance.Arrets[(int)(random.NextDouble() * ArretsTaxiBus.Instance.Arrets.Length)];
                } while (arret == depart);

                result.Add(
                    new Reservation(
                        new ApplicationUser(),
                       depart,
                       arret,
                       DateTime.Now.AddMinutes((int)(random.NextDouble() * 50))));
            }

            return result;
        }

        //---------------------------------------------------------------------
    }
}