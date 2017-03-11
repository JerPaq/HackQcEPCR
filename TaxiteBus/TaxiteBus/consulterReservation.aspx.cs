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
    public partial class consulterReservation : System.Web.UI.Page
    {
        public List<Reservation> lstReservation { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}