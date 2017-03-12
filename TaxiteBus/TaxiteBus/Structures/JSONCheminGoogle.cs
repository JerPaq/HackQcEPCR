using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiteBus.Structures
{
    // Type created for JSON at <<root>>
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class JSONCheminGoogle
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Geocoded_waypoints[] geocoded_waypoints;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Routes[] routes;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string status;
    }

    // Type created for JSON at <<root>> --> geocoded_waypoints
    [System.Runtime.Serialization.DataContractAttribute(Name = "geocoded_waypoints")]
    public partial class Geocoded_waypoints
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string geocoder_status;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string place_id;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] types;
    }

    // Type created for JSON at <<root>> --> routes
    [System.Runtime.Serialization.DataContractAttribute(Name = "routes")]
    public partial class Routes
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Bounds bounds;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string copyrights;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Legs[] legs;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Overview_polyline overview_polyline;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string summary;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] warnings;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int[] waypoint_order;
    }

    // Type created for JSON at <<root>> --> bounds
    [System.Runtime.Serialization.DataContractAttribute(Name = "bounds")]
    public partial class Bounds
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Northeast northeast;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Southwest southwest;
    }

    // Type created for JSON at <<root>> --> bounds --> northeast
    [System.Runtime.Serialization.DataContractAttribute(Name = "northeast")]
    public partial class Northeast
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lat;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lng;
    }

    // Type created for JSON at <<root>> --> bounds --> southwest
    [System.Runtime.Serialization.DataContractAttribute(Name = "southwest")]
    public partial class Southwest
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lat;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lng;
    }

    // Type created for JSON at <<root>> --> legs
    [System.Runtime.Serialization.DataContractAttribute(Name = "legs")]
    public partial class Legs
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Distance distance;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Duration duration;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string end_address;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public End_location end_location;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string start_address;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Start_location start_location;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Steps[] steps;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] traffic_speed_entry;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] via_waypoint;
    }

    // Type created for JSON at <<root>> --> distance
    [System.Runtime.Serialization.DataContractAttribute(Name = "distance")]
    public partial class Distance
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string text;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int value;
    }

    // Type created for JSON at <<root>> --> duration
    [System.Runtime.Serialization.DataContractAttribute(Name = "duration")]
    public partial class Duration
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string text;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int value;
    }

    // Type created for JSON at <<root>> --> end_location
    [System.Runtime.Serialization.DataContractAttribute(Name = "end_location")]
    public partial class End_location
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lat;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lng;
    }

    // Type created for JSON at <<root>> --> start_location
    [System.Runtime.Serialization.DataContractAttribute(Name = "start_location")]
    public partial class Start_location
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lat;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lng;
    }

    // Type created for JSON at <<root>> --> steps
    [System.Runtime.Serialization.DataContractAttribute(Name = "steps")]
    public partial class Steps
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Distance1 distance;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Duration1 duration;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public End_location1 end_location;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string html_instructions;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Polyline polyline;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Start_location1 start_location;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string travel_mode;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string maneuver;
    }

    // Type created for JSON at <<root>> --> distance
    [System.Runtime.Serialization.DataContractAttribute(Name = "distance")]
    public partial class Distance1
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string text;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int value;
    }

    // Type created for JSON at <<root>> --> duration
    [System.Runtime.Serialization.DataContractAttribute(Name = "duration")]
    public partial class Duration1
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string text;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int value;
    }

    // Type created for JSON at <<root>> --> end_location
    [System.Runtime.Serialization.DataContractAttribute(Name = "end_location")]
    public partial class End_location1
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lat;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lng;
    }

    // Type created for JSON at <<root>> --> polyline
    [System.Runtime.Serialization.DataContractAttribute(Name = "polyline")]
    public partial class Polyline
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string points;
    }

    // Type created for JSON at <<root>> --> start_location
    [System.Runtime.Serialization.DataContractAttribute(Name = "start_location")]
    public partial class Start_location1
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lat;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lng;
    }

    // Type created for JSON at <<root>> --> overview_polyline
    [System.Runtime.Serialization.DataContractAttribute(Name = "overview_polyline")]
    public partial class Overview_polyline
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string points;
    }

}