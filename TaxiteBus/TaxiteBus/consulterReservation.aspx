<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="consulterReservation.aspx.cs" Inherits="TaxiteBus.consulterReservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Réservation</h1>

    <table id="tableReserves">
        <tr>
            <th>
                Client
            </th>
            <th>
                Téléphone
            </th>
            <th>
                Point de départ
            </th>
            <th>
                Destination
            </th>
            <th>
                Heure
            </th>
            <th>
                Chauffeur
            </th>
        </tr>
        <% foreach (TaxiteBus.Models.Reservation reserve in lstReserves) { %>
        <tr>
            <td>
                <%= reserve.Client.nom %>  <%= reserve.Client.prenom %>   
            </td>
            <td>
                <%=  reserve.Client.PhoneNumber %>
            </td>
            <td>
            <!--    <= reserve.Depart.ToString() %> --> Départ
            </td>
            <td>
            <!--    <= reserve.Arrivee.ToString() %> --> Arrivée
            </td>
            <td>
                <%= reserve.Heure.ToString() %>
            </td>
            <td>
                Chauffeur
            </td>
        </tr>
        <% } %>
    </table>
    
</asp:Content>
