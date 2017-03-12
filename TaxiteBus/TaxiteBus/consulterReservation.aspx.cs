using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using TaxiteBus.Models;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TaxiteBus
{
    public partial class consulterReservation : System.Web.UI.Page
    {
        //Attributs
        public List<Reservation> lstReserves;
        public List<Trajet> lstTrajet;
        public Dictionary<String, Trajet> dicTrajet = new Dictionary<String, Trajet>();
        public List<ApplicationUser> lstChauffeur;
        public Dictionary<String, ApplicationUser> dicChauffeur = new Dictionary<String, ApplicationUser>();

        protected void Page_Load(object sender, EventArgs e)
        {
            lstReserves = ChargerReservationJSON();
            afficherTrajet();
            afficherChauffeur();
        }
        
        protected void afficherTrajet()
        {
            lstTrajet = CreateurDeTrajets.Instance.Trajets;
            foreach(Trajet trajet in lstTrajet)
            {
                StringBuilder cle = new StringBuilder();
                foreach(Reservation reserv in trajet.Reservations)
                {
                    cle.Append(reserv.Depart.ToString() + " à " + reserv.Arrivee.ToString() + ", " + reserv.Heure.ToString() + " / ");
                }
                dicTrajet.Add(cle.ToString(), trajet);
            }
            lstbxTrajet.DataSource = dicTrajet;
            lstbxTrajet.DataTextField = "Key";
            lstbxTrajet.DataValueField = "Value";
            lstbxTrajet.DataBind();
        }

        protected void afficherChauffeur()
        {
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            lstChauffeur = UserManager.Users.Where(u=>u.typeUtil == "CHAUFFEUR").ToList();
            foreach(ApplicationUser Util in lstChauffeur)
            {
                String cle = Util.prenom + " " + Util.nom;
                dicChauffeur.Add(cle, Util);
            }
            lstbxChauffeur.DataSource = dicChauffeur;
            lstbxChauffeur.DataTextField = "Key";
            lstbxChauffeur.DataValueField = "Value";
            lstbxChauffeur.DataBind();
        }

        protected List<Reservation> ChargerReservationJSON()
        {
            if (File.Exists("reservations.json"))
            {
                string json = System.IO.File.ReadAllText("reservations.json");
                return JsonConvert.DeserializeObject<List<Reservation>>(json);
            }
            else
            {
                return new List<Reservation>();
            }
        }

        //protected List<Trajet> ChargerTrajetJSON()
        //{
        //    if (File.Exists("Trajets.json"))
        //    {
        //        string json = System.IO.File.ReadAllText("Trajets.json");
        //        return JsonConvert.DeserializeObject<List<Trajet>>(json);
        //    }
        //    else
        //    {
        //        return new List<Trajet>();
        //    }
        //}
        //protected void EnregistrerTrajetJSON(List<Trajet> lstTrajet)
        //{
        //    string json = JsonConvert.SerializeObject(lstTrajet.ToArray());
        //    System.IO.File.WriteAllText("Trajets.json", json);
        //}

    }
}