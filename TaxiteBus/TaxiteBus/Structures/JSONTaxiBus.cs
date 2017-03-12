using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiteBus.Structures
{

    // Type created for JSON at <<root>>
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class JSONTaxiBus
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string type;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Features[] features;
    }

    // Type created for JSON at <<root>> --> features
    [System.Runtime.Serialization.DataContractAttribute(Name = "features")]
    public partial class Features
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string type;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Geometry geometry;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Properties properties;

        public override string ToString()
        {
            return properties.CODE;
        }

    }

    // Type created for JSON at <<root>> --> geometry
    [System.Runtime.Serialization.DataContractAttribute(Name = "geometry")]
    public partial class Geometry
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string type;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[] coordinates;
    }

    // Type created for JSON at <<root>> --> properties
    [System.Runtime.Serialization.DataContractAttribute(Name = "properties")]
    public partial class Properties
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OBJECTID;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CODE;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type_arret;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double X;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Y;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SEM_SEUL;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FDS_SEUL;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FDS_VERS_BUS;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SEM_VERS_BUS;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SEM_VERS_TAXI;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FDS_VERS_TAXI;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Notes;
    }

}