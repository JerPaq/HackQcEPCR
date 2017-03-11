using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using TaxiteBus.Models;
using TaxiteBus.Structures;

namespace TaxiteBus
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            estConnecter();
            
            ArretsTaxiBus arretTaxiBus = ArretsTaxiBus.Instance;

            List<String> points = new List<string>();

            List<int> deja = new List<int>();
            Random random = new Random();
            int alea;
            String virgule = "";
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    alea = ((int)(random.NextDouble() * arretTaxiBus.Arrets.Length));
                } while (deja.Contains(alea));
                deja.Add(alea);
                LiteralLatitude.Text += virgule + arretTaxiBus.Arrets[alea].geometry.coordinates[1].ToString().Replace(',', '.');
                LiteralLongitude.Text += virgule + arretTaxiBus.Arrets[alea].geometry.coordinates[0].ToString().Replace(',', '.');
                virgule = ",";
            }
        }

        protected void btnReserver_Click(object sender, EventArgs e)
        {
            Response.Redirect("reservation.aspx");
        }

        private void estConnecter()
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login");
            }
        }

        protected bool utilEstClient()
        {
            return System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).typeUtil == "CLIENT";
        }

        protected bool utilEstCentral()
        {
            return System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).typeUtil == "CENTRAL";
        }

        protected void BtnReserver_Click1(object sender, EventArgs e)
        {

        }

        protected void BtnConsulterReserves_Click(object sender, EventArgs e)
        {
            Response.Redirect("~Consulter");
        }
    }
}