<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestGino.aspx.cs" Inherits="TaxiteBus.TestGino" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
  
   
    <form id="form1" runat="server">
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
            for (i = 1; i < lats.length-1; i++) {
                waypts.push({
                    location: lats[i]+","+longs[i],
                    stopover: true
                });             
            }

            var directionsService = new google.maps.DirectionsService;
            directionsService.route({
                origin: lats[0]+","+longs[0],
                destination:   lats[lats.length-1]+","+longs[lats.length-1],
                waypoints: waypts,
                optimizeWaypoints: false,
                travelMode: google.maps.TravelMode.DRIVING
            }, function(response, status) {

                if (status === google.maps.DirectionsStatus.OK) {
                    var directionsDisplay = new google.maps.DirectionsRenderer({suppressMarkers: true});
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
                    title: 'Hello World!'+i
                });
                marker.setLabel(""+(i+1));
                marker.addListener('dblclick', function() {
                    map.setCenter(marker.getPosition());
                    alert("Position"+i);
                    //map.setZoom(8);
    
                    $('#MainContent_HiddenField1').val(i);
                    $('#MainContent_Button1').trigger('click');
    
                });
            }
        }
            </script>

            <div id="map_canvas" style="width: 1400px; height: 700px"></div>
        </div>
    </form>
</body>
</html>
