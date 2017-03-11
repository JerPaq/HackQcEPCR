<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reservation.aspx.cs" Inherits="TaxiteBus.reservation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyB16oFkTxj39_YELrwqLJr5TMMBTAIkPFc&sensor=false&libraries=places"></script>
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
                    $('#MainContent_HiddenField1').val(latitude + "," + longitude);
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
                    $('#MainContent_HiddenField2').val(latitude + "," + longitude);
                    alert(mesg);
                });
            });
    </script>

    <asp:HiddenField ID="HiddenField1" runat="server" Value="Initiale" />
    <asp:HiddenField ID="HiddenField2" runat="server" Value="Initiale" />

    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-4">
            <h2>Réservation</h2>
            <div class="input-group">
                <label>Départ :</label>
                <asp:TextBox runat="server" class="form-control" ID="txtPlaces" ></asp:TextBox>
               <%-- <asp:Button ID="btnDepart" runat="server" CssClass="btn btn-default" Text="+" OnClick="btnDepart_Click" />--%>
                    <button type="button" class="btn btn-default"  aria-label="Help" data-toggle="modal" data-target="#myModal">
                        <span class="glyphicon glyphicon-map-marker"></span>
                    </button>
            </div>
            <br />
            <div class="input-group">
                <label>Vers :</label>
                <asp:TextBox runat="server" class="form-control" ID="txtPlaces2" ></asp:TextBox>
                    
                    <%--<button type="button" class="btn btn-default" aria-label="Help" data-toggle="modal" data-target="#myModal2">
                        <span class="glyphicon glyphicon-map-marker"></span>
                    </button>--%>
            </div>
            <br />
            <button type="button" class="btn btn-default navbar-btn">Soumettre</button>
        </div>
        <div class="col-md-4"></div>
    </div>
                <!-- Modal -->
            <div id="myModal" class="modal fade" role="dialog">
                <div class="modal-dialog">

                    <script type="text/javascript">
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
                                    var directionsDisplay = new google.maps.DirectionsRenderer({ suppressMarkers: true });
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

                                    //$('#MainContent_HiddenField1').val(i);
                                    //$('#MainContent_Button1').trigger('click');

                                });
                            }
                        }
                    </script>

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Carte</h4>
                        </div>
                        <div class="modal-body">
                            <p>Some text in the modal.</p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>

                </div>
            </div>

       


</asp:Content>
