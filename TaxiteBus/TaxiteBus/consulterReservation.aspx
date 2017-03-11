<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="consulterReservation.aspx.cs" Inherits="TaxiteBus.consulterReservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Réservation</h1>
    <div>
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
    </div>    
    <div>
        <asp:ListBox ID="lstbxReservation" runat="server" Width="600px"></asp:ListBox>
        <asp:Button ID="btnAjouter" runat="server" Text="Ajouter au trajet" />
    </div>
    <div>
        <asp:ListBox ID="lstbxTrajet" runat="server" Width="600px"></asp:ListBox>
        <asp:Button ID="btnCreer" runat="server" Text="Nouveau Trajet" />
    </div>
    
</asp:Content>
