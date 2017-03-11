<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="TaxiteBus.Reservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
    </style>

</head>
<body>
    <form runat="server">

    <asp:HiddenField ID="HiddenFieldPlace1" runat="server" Value="Initiale" />
    <asp:HiddenField ID="HiddenFieldPlace2" runat="server" Value="Initiale" />

    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyB16oFkTxj39_YELrwqLJr5TMMBTAIkPFc&sensor=false&libraries=places"></script>
    <script type="text/javascript">
        google.maps.event.addDomListener(window, 'load', function () {
            var places = new google.maps.places.Autocomplete(document.getElementById('txtPlaces'));
            google.maps.event.addListener(places, 'place_changed', function () {
                var place = places.getPlace();
                var address = place.formatted_address;
                var latitude = place.geometry.location.lat();
                var longitude = place.geometry.location.lng();
                var mesg = "Address: " + address;
                mesg += "\nLatitude: " + latitude;
                mesg += "\nLongitude: " + longitude;
                alert(mesg);
            });
            var places2 = new google.maps.places.Autocomplete(document.getElementById('txtPlaces2'));
            google.maps.event.addListener(places, 'place_changed', function () {
                var place = places.getPlace();
                var address = place.formatted_address;
                var latitude = place.geometry.location.lat();
                var longitude = place.geometry.location.lng();
                var mesg = "Address: " + address;
                mesg += "\nLatitude: " + latitude;
                mesg += "\nLongitude: " + longitude;
                alert(mesg);
            });
        });
    </script>
    <span>Location:</span>
    
    <asp:TextBox runat="server" ID="txtPlaces" ></asp:TextBox>
        <asp:TextBox runat="server" ID="txtPlaces2" ></asp:TextBox>


    </form>

</body>
</html>
