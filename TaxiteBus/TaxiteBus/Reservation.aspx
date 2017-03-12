<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reservation.aspx.cs" Inherits="TaxiteBus.reservation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Button" Visible="true" CssClass="cache" />--%>
     <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk&sensor=false&libraries=places"></script>
        <script type="text/javascript">
            google.maps.event.addDomListener(window, 'load', function () {
                var places = new google.maps.places.Autocomplete(document.getElementById('MainContent_txtPlaces'));
                var places2 = new google.maps.places.Autocomplete(document.getElementById('MainContent_txtPlaces2'));
                google.maps.event.addListener(places, 'place_changed', function () {
                    var place = places.getPlace();
                    var address = place.formatted_address;
                    var latitude = place.geometry.location.lat();
                    var longitude = place.geometry.location.lng();
                    var mesg = "Address: " + address;
                    mesg += "\nLatitude: " + latitude;
                    mesg += "\nLongitude: " + longitude;
                    $("#<%= HiddenField1.ClientID %>").val(latitude + "," + longitude);
                    //$('#MainContent_HiddenField1').val(latitude + "," + longitude);
                    alert(mesg);
                });

                google.maps.event.addListener(places2, 'place_changed', function () {
                    var place = places2.getPlace();
                    var address = place.formatted_address;
                    var latitude = place.geometry.location.lat();
                    var longitude = place.geometry.location.lng();
                    var mesg = "Address: " + address;
                    mesg += "\nLatitude: " + latitude;
                    mesg += "\nLongitude: " + longitude;
                    $("#<%= HiddenField2.ClientID %>").val(latitude + "," + longitude);
                    //$('#MainContent_HiddenField2').val(latitude + "," + longitude);
                    alert(mesg);
                });
            });


            </script>



            <script type="text/javascript">
            navigator.geolocation.getCurrentPosition(success);
            var markers = [];
            var directionsDisplay = new google.maps.DirectionsRenderer({suppressMarkers: true });
            var lats = [<asp:Literal ID="LiteralLatitude" runat="server"></asp:Literal >];
            var longs = [<asp:Literal ID="LiteralLongitude" runat="server"></asp:Literal >];
            var lats2 = [<asp:Literal ID="LiteralLatitude2" runat="server"></asp:Literal >];
            var longs2 = [<asp:Literal ID="LiteralLongitude2" runat="server"></asp:Literal >];
            var hiddenField = $("#<%= HiddenFieldBtnCliquer.ClientID %>").val();

            function success(position) {

                // C# remplie le tableau avec les points selon les points choisies dans TaxiBus.cs
                hiddenField = $("#<%= HiddenFieldBtnCliquer.ClientID %>").val();
                if (hiddenField == "destination") {
                    chargerCarte(lats2, longs2, true);
                }
                else {
                    chargerCarte(lats, longs, true);
                }


            }

            function chargerCarte(pLats, pLongs, afficherRoute) {
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
                hiddenField = $("#<%= HiddenFieldBtnCliquer.ClientID %>").val();
                if (hiddenField == "destination") {
                    // Ajoute les marqueurs à la main, qui lorsque cliqués appellent le serveur
                    for (i = 0; i < pLats.length; i++) {
                        marker = new google.maps.Marker({
                            position: new google.maps.LatLng(pLats[i], pLongs[i]),
                            map: map,
                            title: 'Hello World!'
                        });
                        marker.setLabel("" + (i + 1));
                        marker.addListener('dblclick', function () {
                            map.setCenter(marker.getPosition());
                            alert("Position");
                            //map.setZoom(8);

                            $('#MainContent_HiddenFieldDestinataire').val(lat + "," + long);
                            $('#MainContent_Button2').trigger('click');

                        });
                        markers.push(marker);
                    }
                }
                else {
                    // Ajoute les marqueurs à la main, qui lorsque cliqués appellent le serveur
                    for (i = 0; i < pLats.length; i++) {
                        marker = new google.maps.Marker({
                            position: new google.maps.LatLng(pLats[i], pLongs[i]),
                            map: map,
                            title: 'Hello World!'
                        });
                        marker.setLabel("" + (i + 1));
                        marker.addListener('dblclick', function () {
                            map.setCenter(marker.getPosition());
                            $('#MainContent_Button1').attr('disabled', false);
                            //alert("Position");
                            //map.setZoom(8);



                            $('#MainContent_HiddenFieldDepart').val(lat + "," + long);
                            $('#MainContent_Button1').trigger('click');

                        });
                        markers.push(marker);
                    }
                }
               
                }

            //NOTE : Source : https://developers.google.com/maps/documentation/javascript/examples/marker-remove?hl=fr
            //Le tableau de markers[] est défini en haut mais la "map" n'est pas déclarée

            

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

            function retirerRoute() {
                if (directionsDisplay != null) {
                    directionsDisplay.setMap(null);
                    directionsDisplay = null;
                }

            }

            function afficherZone(zone) {
                //alert(zone);
                deleteMarkers();
                retirerRoute();
                if (zone === "bleue") {
                    chargerCarte(latsBleu, longsBleu, false);
                }
                else if (zone === "verte") {
                    chargerCarte(latsVert, longsVert, false);
                }
                else if (zone === "rouge") {
                    chargerCarte(latsRouge, longsRouge, false);
                }
                else if (zone === "mauve") {
                    chargerCarte(latsMauve, longsMauve, false);
                }

            }


        </script>

    <div id="map_canvas" style="width: 100%; height: 400px"></div>
    <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
    <asp:HiddenField ID="HiddenFieldDepart" runat="server" Value="" />
    <asp:HiddenField ID="HiddenFieldDestinataire" runat="server" Value="" />
    <asp:HiddenField ID="HiddenField2" runat="server" Value="" />
    <asp:HiddenField ID="HiddenFieldBtnCliquer" runat="server" Value="" />

    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-4">
            <h2>Réservation</h2>
            <div class="input-group">
                <label>Départ :</label>
                <label>Arrêt :</label>
                <asp:TextBox runat="server" class="form-control" ID="txtPlaces" ></asp:TextBox>
                <asp:TextBox runat="server" Enabled="false" class="form-control" ID="TxbDepart" ></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Rechercher" />
            </div>
            <br />
            <div class="input-group">
                <label>Vers :</label>
                <label>Arrêt :</label>
                <asp:TextBox runat="server" class="form-control" ID="txtPlaces2" ></asp:TextBox>
                <asp:TextBox runat="server" Enabled="false" class="form-control" ID="TxbDestination" ></asp:TextBox>
                <br />
            </div>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Rechercher" />
            <br />
            <asp:Button ID="btnSoumettre" runat="server" Text="Soumettre" OnClick="btnSoumettre_Click" CssClass="btn btn-primary" />
        </div>
        <div class="col-md-4"></div>
    </div>
       


</asp:Content>
