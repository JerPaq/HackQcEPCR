<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceCitebus.aspx.cs" Inherits="TaxiteBus.ServiceCitebus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk&sensor=false"></script>

    <script type="text/javascript">

        //Au chargement de la page
        if (navigator.geolocation)
        {
            navigator.geolocation.getCurrentPosition(success);
        }
        else
        {
            alert("Laissez-nous vous espionner!");
        }

        var markers = [];
        var directionsDisplay = new google.maps.DirectionsRenderer({ suppressMarkers: true });
        var lats = [<asp:Literal ID="LiteralLatitude" runat="server"></asp:Literal >];
        var longs = [<asp:Literal ID="LiteralLongitude" runat="server"></asp:Literal >];

        var lats11 = [<asp:Literal ID="LiteralLatitude11" runat="server"></asp:Literal >];
        var longs11 = [<asp:Literal ID="LiteralLongitude11" runat="server"></asp:Literal >];

        var lats21 = [<asp:Literal ID="LiteralLatitude21" runat="server"></asp:Literal >];
        var longs21 = [<asp:Literal ID="LiteralLongitude21" runat="server"></asp:Literal >];

        var lats31 = [<asp:Literal ID="LiteralLatitude31" runat="server"></asp:Literal >];
        var longs31 = [<asp:Literal ID="LiteralLongitude31" runat="server"></asp:Literal >];

        function success(position)
        {
            chargerCarte(null, null, false);
        }

        function afficherCircuit(noCircuit)
        {
            deleteMarkers();
            retirerRoute();
            $('#Circuit11').css('display', 'none');
            $('#Circuit21').css('display', 'none');
            $('#Circuit31').css('display', 'none');
            switch (noCircuit)
            {
                case 11:
                    $('#Circuit11').css('display', 'table');
                    chargerCarte(lats11, longs11, false);
                break;
                case 21:
                    $('#Circuit21').css('display', 'table');
                    chargerCarte(lats21, longs21, false);
                break;
                case 31:
                    $('#Circuit31').css('display', 'table');
                    chargerCarte(lats31, longs31, false);
                break;
            }
        }

        function chargerCarte(pLats, pLongs, afficherRoute)
        {
            var lat = 48.4525;//position.coords.latitude;
            var long = -68.5232;//position.coords.longitude;
            var city = "Rimouski";//position.coords.locality;
            var myLatlng = new google.maps.LatLng(lat, long);
            var myOptions = { center: myLatlng, zoom: 12, mapTypeId: google.maps.MapTypeId.ROADMAP };
            var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

            if (afficherRoute)
            {
                //Ici affiche les points avec le trajet entre.
                var waypts = [];
                for (i = 1; i < pLats.length - 1; i++)
                {
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
                },
                function (response, status)
                {
                    if (status === google.maps.DirectionsStatus.OK)
                    {
                        //var directionsDisplay = new google.maps.DirectionsRenderer({ suppressMarkers: true });
                        directionsDisplay = new google.maps.DirectionsRenderer({ suppressMarkers: true });
                        directionsDisplay.setMap(map);
                        directionsDisplay.setDirections(response);
                        directionsDisplay.su
                    }
                    else
                    {
                    window.alert('Directions request failed ' + status);
                    }
                });
            }

            // Ajoute les marqueurs à la main, qui lorsque cliqués appellent le serveur
            for (i = 0; i < pLats.length; i++)
            {
                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(pLats[i], pLongs[i]),
                    map: map,
                    title: 'Hello World!' + i
                });

                marker.setLabel();
                marker.addListener('dblclick', function ()
                {
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
        function addMarker(location)
        {
            var marker = new google.maps.Marker({
                position: location,
                map: map
            });
            markers.push(marker);
        }

        // Sets the map on all markers in the array.
        function setMapOnAll(map)
        {
            for (var i = 0; i < markers.length; i++)
            {
                markers[i].setMap(map);
            }
        }

        // Removes the markers from the map, but keeps them in the array.
        function clearMarkers()
        {
            setMapOnAll(null);
        }
        // Deletes all markers in the array by removing references to them.
        function deleteMarkers()
        {
            clearMarkers();
            markers = [];
        }

        function retirerRoute()
        {
            if (directionsDisplay != null)
            {
                directionsDisplay.setMap(null);
                directionsDisplay = null;
            }
        }
    </script>

    <h2>Service Citébus</h2>

    <div id="map_canvas" style="height:500px;width:500px"></div>

    <div class="dropdown">
        <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
            Choisir un circuit
   
            <span class="caret"></span>
        </button>
        <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
            <li><a onclick="afficherCircuit(11)" href="#">Circuit 11</a></li>
            <li><a onclick="afficherCircuit(21)" href="#">Circuit 21</a></li>
            <li><a onclick="afficherCircuit(31)" href="#">Circuit 31</a></li>
        </ul>
    </div>
    
    <!-- Table affichée par défaut -->
    <div id="partieGauche">
            <div id="Circuit11">
            <h3>Circuit 11</h3>
            Du <b>lundi au vendredi</b> de <b>06:45</b> à <b>23:15</b>
            <br />
            Le <b>samedi et dimanche</b> de <b>07:15</b> à <b>18:15</b>
            <br />
            Heures de pointe du <b>lundi au vendredi</b>:
            <ul>
                <li><b>06:46</b> à <b>09:15</b></li>
                <li><b>11:16</b> à <b>13:15</b></li>
                <li><b>16:16</b> à <b>18:15</b></li>
            </ul>
            <a href="http://www.ville.rimouski.qc.ca/webconcepteurcontent63/000022830000/upload/citoyens/circulation/Carte_circuit_11.pdf">Voir la carte du trajet</a>
            <table class="tblCitebus">
                <tr>
                    <th class="noArret">
                        #
                    </th>
                    <th class="citebusNom">
                        Arrêt
                    </th>
                    <th class="citebusHeure">
                        Passage
                    </th>
                    <th class="citebusHeure">
                        Heures de pointe
                    </th>
                </tr>
                <% foreach (TaxiteBus.Structures.CiteBus.Features arret in circuit11) { %>
                <tr>
                    <td class="noArret">
                        <%= arret.properties.OBJECTID - 114 %>
                    </td>
                    <td class="citebusNom">
                        <%= arret.properties.Nom %>
                    </td>
                    <td class="citebusHeure">
                        XX:<%= deuxDigits(arret) %>
                    </td>
                    <td class="citebusHeure">
                        XX:<%= 30 + Int32.Parse(deuxDigits(arret)) %>
                    </td>
                </tr>
                <% } %>
            </table>
        </div>
    
        <div id="Circuit21" style="display: none">
            <h3>Circuit 21</h3>
            <b>Tout les jours</b> de <b>06:45</b> à <b>18:15</b>
            <br />
            <a href="http://www.ville.rimouski.qc.ca/webconcepteurcontent63/000022830000/upload/citoyens/circulation/Carte_circuit_21.pdf">Voir la carte du trajet</a>
            <table class="tblCitebus">
                <tr>
                    <th class="noArret">
                        #
                    </th>
                    <th class="citebusNom">
                        Arrêt
                    </th>
                    <th class="citebusHeure">
                        Passage
                    </th>
                </tr>
                <% foreach (TaxiteBus.Structures.CiteBus.Features arret in circuit21) { %>
                <tr>
                    <td class="noArret">
                        <%= arret.properties.OBJECTID - 34 %>
                    </td>
                    <td class="citebusNom">
                        <%= arret.properties.Nom %>
                    </td>
                    <td class="citebusHeure">
                        XX:<%= deuxDigits(arret) %>
                    </td>
                </tr>
                <% } %>
            </table>
        </div>

        <div id="Circuit31" style="display: none">
            <h3>Circuit 31</h3>
            Du <b>lundi au vendredi</b> de <b>06:45</b> à <b>23:15</b>
            <br />
            Le <b>samedi et dimanche</b> de <b>07:15</b> à <b>18:15</b>
            <br />
            <a href="http://www.ville.rimouski.qc.ca/webconcepteurcontent63/000022830000/upload/citoyens/circulation/Carte_circuit_31.pdf">Voir la carte du trajet</a>
            <table class="tblCitebus">
                <tr>
                    <th class="noArret">
                        #
                    </th>
                    <th class="citebusNom">
                        Arrêt
                    </th>
                    <th class="citebusHeure">
                        Passages
                    </th>
                </tr>
                <% foreach (TaxiteBus.Structures.CiteBus.Features arret in circuit31) { %>
                <tr>
                    <td class="noArret">
                        <%= arret.properties.OBJECTID %>
                    </td>
                    <td class="citebusNom">
                        <%= arret.properties.Nom %>
                    </td>
                    <td class="citebusHeure">
                        XX:<%= deuxDigits(arret) %>
                        -
                        XX:<%= 30 + Int32.Parse(deuxDigits(arret)) %>
                    </td>
                </tr>
                <% } %>
            </table>
        </div>
    </div>

</asp:Content>
