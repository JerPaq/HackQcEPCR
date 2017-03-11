using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace TaxiteBus.Structures
{
    public class ArretsTaxiBus
    {
        public static readonly String [] ZONES_LIGNES_NOMS = { "Taxibus - Zone verte", "Taxibus - Ligne rouge", "Taxibus - Zone bleue" };

        private static readonly ArretsTaxiBus instance = new ArretsTaxiBus();
        public static ArretsTaxiBus Instance
        {
            get
            {
                return instance;
            }
        }

        Features[] arrets;
        public Features[] Arrets
        {
            get
            {
                return this.arrets;
            }
        }

        private ArretsTaxiBus()
        {

            String uRL = "https://www.donneesquebec.ca/recherche/dataset/6715ead7-147a-4dcf-a534-f4e9e428905e/resource/3c40aae3-f662-4264-8ef7-26442181a3ad/download/arrettaxibus.json";
            Uri uri = new Uri(uRL);

            string rep = GetRequest(uri);

            JSONTaxiBus JSONTaxiBus = new JSONTaxiBus();
            using (MemoryStream mem = new MemoryStream(Encoding.UTF8.GetBytes(rep)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(JSONTaxiBus.GetType());
                this.arrets = (ser.ReadObject(mem) as JSONTaxiBus).features;
            }
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