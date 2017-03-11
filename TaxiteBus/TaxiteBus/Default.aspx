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
            function success(position) {
                var lat = 48.4525;//position.coords.latitude;
                var long = -68.5232;//position.coords.longitude;
                var city = "Rimouski";//position.coords.locality;
                var myLatlng = new google.maps.LatLng(lat, long);
                var myOptions = { center: myLatlng, zoom: 12, mapTypeId: google.maps.MapTypeId.ROADMAP };
                var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

                // C# remplie le tableau avec les points selon les points choisies dans TaxiBus.cs
                var lats = [<asp:Literal ID="LiteralLatitude" runat="server"></asp:Literal >];
                var longs = [<asp:Literal ID="LiteralLongitude" runat="server"></asp:Literal >];

                //Ici affiche les points avec le trajet entre.
                var waypts = [];
                for (i = 1; i < lats.length - 1; i++) {
                    waypts.push({
                        location: lats[i] + "," + longs[i],
                        stopover: true
                    });
                }

                var directionsService = new google.maps.DirectionsService;
                directionsService.route({
                    origin: lats[0] + "," + longs[0],
                    destination: lats[lats.length - 1] + "," + longs[lats.length - 1],
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

                // Ajoute les marqueurs à la main, qui lorsque cliqués appellent le serveur
                for (i = 0; i < lats.length; i++) {
                    marker = new google.maps.Marker({
                        position: new google.maps.LatLng(lats[i], longs[i]),
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
                alert(zone);
                if (zone === "verte")
                {
                    
                }
                
            }


        </script>
        <div class="dropdown">
            <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                Choisir une zone
   
                <span class="caret"></span>
            </button>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                <li><a onclick="afficherZone('bleu')" href="#">Zone bleu</a></li>
                <li><a onclick="afficherZone('verte')" href="#">Zone verte</a></li>
                <li><a onclick="afficherZone('rouge')" href="#">Ligne rouge</a></li>
                <li><a onclick="afficherZone('mauve')" href="#">Ligne mauve</a></li>
            </ul>
        </div>
        <div id="map_canvas" style="width: 100%; height: 400px"></div>
    </div>


    <div style="visibility: hidden;">
        <asp:Button ID="btnReserver" runat="server" Text="Réserver" OnClick="btnReserver_Click" />
    </div>


</asp:Content>
