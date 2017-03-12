using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxiteBus.Structures;
using TaxiteBus.Structures.CiteBus;

namespace TaxiteBus
{
    public partial class ServiceCitebus : System.Web.UI.Page
    {

        public TaxiteBus.Structures.CiteBus.Features[] circuit11;
        public TaxiteBus.Structures.CiteBus.Features[] circuit21;
        public TaxiteBus.Structures.CiteBus.Features[] circuit31;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArretsCiteBus arretsCiteBus = ArretsCiteBus.Instance;

            circuit11 = arretsCiteBus.Arrets.Where(t => t.properties.Circuit == 11).ToArray();
            circuit21 = arretsCiteBus.Arrets.Where(t => t.properties.Circuit == 21).ToArray();
            circuit31 = arretsCiteBus.Arrets.Where(t => t.properties.Circuit == 31).ToArray();
        }

        protected string deuxDigits(TaxiteBus.Structures.CiteBus.Features arret)
        {
            //L'attribut "Horaire_SEM" est une string de la forme "7:08, 7:38, 8:08, 8:38..."
            //On a donc besoin des 2e et 3e caractères pour avoir nos deux digits
            string heure = arret.properties.Horaire_SEM;
            return heure.Substring(2, 2);
        }

    }
}