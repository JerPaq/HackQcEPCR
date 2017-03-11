using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using TaxiteBus.Models;
using TaxiteBus.Structures;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace TaxiteBus
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login");
            }
            // Permet d'aller chercher l'utilisateur connecter (l'objet)
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        }

        protected void EnregistrerReservationJSON(object sender, EventArgs e)
        {
            List<Reservation> lstReservations = new List<Reservation>();

            lstReservations.Add(
                new Reservation(
                    new ApplicationUser(),
                    new JSONTaxiBus(),
                    new JSONTaxiBus()));
            lstReservations.Add(
                new Reservation(
                    new ApplicationUser(),
                    new JSONTaxiBus(),
                    new JSONTaxiBus()));
            lstReservations.Add(
                new Reservation(
                    new ApplicationUser(),
                    new JSONTaxiBus(),
                    new JSONTaxiBus()));
            lstReservations.Add(
                new Reservation(
                    new ApplicationUser(),
                    new JSONTaxiBus(),
                    new JSONTaxiBus()));

            string json = JsonConvert.SerializeObject(lstReservations.ToArray());
            System.IO.File.WriteAllText(@"D:\fichier.json", json);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string json = System.IO.File.ReadAllText(@"D:\fichier.json");
        }
    }
}