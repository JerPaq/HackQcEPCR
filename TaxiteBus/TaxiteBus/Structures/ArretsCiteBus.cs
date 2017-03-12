using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using TaxiteBus.Structures.CiteBus;

namespace TaxiteBus.Structures
{
    public class ArretsCiteBus
    {
        private static readonly ArretsCiteBus instance = new ArretsCiteBus();
        public static ArretsCiteBus Instance
        {
            get
            {
                return instance;
            }
        }

        TaxiteBus.Structures.CiteBus.Features[] arrets;
        public TaxiteBus.Structures.CiteBus.Features[] Arrets
        {
            get
            {
                return this.arrets;
            }
        }

        private ArretsCiteBus()
        {

            String uRL = "https://www.donneesquebec.ca/recherche/dataset/6715ead7-147a-4dcf-a534-f4e9e428905e/resource/cd0e470f-4719-4c14-b23a-03b2ae56bd69/download/arretcitebus.json";
            Uri uri = new Uri(uRL);

            string rep = GetRequest(uri);

            JSONCiteBus jSONCiteBus = new JSONCiteBus();
            using (MemoryStream mem = new MemoryStream(Encoding.UTF8.GetBytes(rep)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(jSONCiteBus.GetType());
                this.arrets = (ser.ReadObject(mem) as JSONCiteBus).features;
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