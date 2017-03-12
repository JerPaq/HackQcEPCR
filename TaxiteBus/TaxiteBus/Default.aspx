<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TaxiteBus._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        
      
        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk&sensor=false">
        </script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>

        <script type="text/javascript">
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(success);
            }
            else {
                alert("Laissez-nous vous espionner!");
            }

            var markers = [];
            var directionsDisplay = new google.maps.DirectionsRenderer({ suppressMarkers: true });
            var lats = [<asp:Literal ID="LiteralLatitude" runat="server"></asp:Literal >];
            var longs = [<asp:Literal ID="LiteralLongitude" runat="server"></asp:Literal >];

            var latsBleu = [<asp:Literal ID="LiteralLatitudeBleu" runat="server"></asp:Literal >];
            var longsBleu = [<asp:Literal ID="LiteralLongitudeBleu" runat="server"></asp:Literal >];

            var latsVert = [<asp:Literal ID="LiteralLatitudeVert" runat="server"></asp:Literal >];
            var longsVert = [<asp:Literal ID="LiteralLongitudeVert" runat="server"></asp:Literal >];

            var latsRouge = [<asp:Literal ID="LiteralLatitudeRouge" runat="server"></asp:Literal >];
            var longsRouge = [<asp:Literal ID="LiteralLongitudeRouge" runat="server"></asp:Literal >];

            var latsMauve = [<asp:Literal ID="LiteralLatitudeMauve" runat="server"></asp:Literal >];
            var longsMauve = [<asp:Literal ID="LiteralLongitudeMauve" runat="server"></asp:Literal >];

            function success(position)
            {
               
                // C# remplie le tableau avec les points selon les points choisies dans TaxiBus.cs
                chargerCarte(null, null,false);
            }

            function chargerCarte(pLats, pLongs,afficherRoute)
            {
                var lat = 48.4525;//position.coords.latitude;
                var long = -68.5232;//position.coords.longitude;
                var city = "Rimouski";//position.coords.locality;
                var myLatlng = new google.maps.LatLng(lat, long);
                var myOptions = { center: myLatlng, zoom: 12, mapTypeId: google.maps.MapTypeId.ROADMAP };
                var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

                if (afficherRoute) {
                    //Ici affiche les points avec le trajet entre.
                    var waypts = [];
                    for (i = 1; i < pLats.length - 1; i++) {
                        waypts.push({
                            location: pLats[i] + "," + pLongs[i],
                            stopover: true
                        });
                    }

                    var directionsService = new google.maps.DirectionsService;
                    directionsService.route({
                        origin: pLats[0] + "," + pLongs[0],
                        destination: pLats[pLats.length - 1] + "," + pLongs[pLats.length - 1],
                        waypoints: waypts,
                        optimizeWaypoints: false,
                        travelMode: google.maps.TravelMode.DRIVING
                    }, function (response, status) {

                        if (status === google.maps.DirectionsStatus.OK) {
                            //var directionsDisplay = new google.maps.DirectionsRenderer({ suppressMarkers: true });
                            directionsDisplay = new google.maps.DirectionsRenderer({ suppressMarkers: true });
                            directionsDisplay.setMap(map);
                            directionsDisplay.setDirections(response);
                            directionsDisplay.su
                        } else {
                            window.alert('Directions request failed ' + status);
                        }
                    });

                }

                // Ajoute les marqueurs à la main, qui lorsque cliqués appellent le serveur
                for (i = 0; i < pLats.length; i++) {
                    marker = new google.maps.Marker({
                        position: new google.maps.LatLng(pLats[i], pLongs[i]),
                        map: map,
                        title: 'Hello World!' + i
                    });
                    marker.setLabel("" + (i + 1));
                    marker.addListener('dblclick', function () {
                        map.setCenter(marker.getPosition());
                        alert("Position" + i);
                        //map.setZoom(8);

                        $('#MainContent_HiddenField1').val(i);
                        $('#MainContent_Button1').trigger('click');

                    });
                    markers.push(marker);
                }

                /*
                var coordTrace = [];
                for (i = 0; i < pLats.length; i++)
                {
                    triangleCoords.push(new google.maps.LatLng(pLats[i], pLongs[i]));
                }


                //TEST POLYGON
                var polygonMap = new google.maps.Polygon({
                    paths: coordTrace,
                    strokeColor: '#FF0000',
                    strokeOpacity: 0.8,
                    strokeWeight: 1,
                    fillColor: '#FF0000',
                    fillOpacity: 0.35,
                    name: 'name 1', // dynamic, not an official API property..
                    map: map
                });
                polygonMap.setMap(map);
                */
            }

            //NOTE : Source : https://developers.google.com/maps/documentation/javascript/examples/marker-remove?hl=fr
            //Le tableau de markers[] est défini en haut mais la "map" n'est pas déclarée

            // Adds a marker to the map and push to the array.
            function addMarker(location) {
                var marker = new google.maps.Marker({
                    position: location,
                    map: map
                });
                markers.push(marker);
            }

            // Sets the map on all markers in the array.
            function setMapOnAll(map) {
                for (var i = 0; i < markers.length; i++) {
                    markers[i].setMap(map);
                }
            }

            // Removes the markers from the map, but keeps them in the array.
            function clearMarkers() {
                setMapOnAll(null);
            }
            // Deletes all markers in the array by removing references to them.
            function deleteMarkers() {
                clearMarkers();
                markers = [];
            }

            function retirerRoute()
            {
                if (directionsDisplay != null) {
                    directionsDisplay.setMap(null);
                    directionsDisplay = null;
                }
                
                //directionsDisplay = new google.maps.DirectionsRenderer(rendererOptions);
                //directionsDisplay.setMap(map);
                //directionsDisplay.setPanel(document.getElementById("directionsPanel"));
            }

            function afficherZone(zone)
            {
                //alert(zone);
                deleteMarkers();
                retirerRoute();
                if (zone === "bleue")
                {
                    chargerCarte(latsBleu, longsBleu, false);
                }
                else if (zone === "verte")
                {
                    chargerCarte(latsVert, longsVert, false);
                }
                else if (zone === "rouge")
                {
                    chargerCarte(latsRouge, longsRouge, false);
                }
                else if (zone === "mauve")
                {
                    chargerCarte(latsMauve, longsMauve, false);
                }
                
            }


        </script>
        <br />
        <div class="dropdown">
            <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                Choisir une zone
   
                <span class="caret"></span>
            </button>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                <li><a onclick="afficherZone('bleue')" href="#">Zone bleue</a></li>
                <li><a onclick="afficherZone('verte')" href="#">Zone verte</a></li>
                <li><a onclick="afficherZone('rouge')" href="#">Ligne rouge</a></li>
                <li><a onclick="afficherZone('mauve')" href="#">Ligne mauve</a></li>
            </ul>
        </div>
        <div id="map_canvas" style="width: 100%; height: 400px"></div>
    </div>


    <div>
        <label ID="labelTest" runat="server"></label>
    </div>

    <% if (utilEstClient()) {%>

    <asp:Button ID="BtnReserver" runat="server" Text="Faire une réservation" OnClick="BtnReserver_Click" class="btn btn-primary" />

    <% } %>

    <% if (utilEstCentral()) {%>

    <asp:Button ID="BtnConsulterReserves" runat="server" Text="Consulter les réservations" OnClick="BtnConsulterReserves_Click" class="btn btn-primary" />

    <% } %>

</asp:Content>
