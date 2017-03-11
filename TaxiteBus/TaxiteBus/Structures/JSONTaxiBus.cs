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
        public string Nom;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Circuit;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Remarque;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double X;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Y;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Horaire_SEM;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Horaire_SAM;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Horaire_DIM;
    }

}