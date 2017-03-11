<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="consulterReservation.aspx.cs" Inherits="TaxiteBus.consulterReservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Réservation</h1>

    <table>
        <% foreach (var reserve in lstReserves) { %>

        

        <% } %>
    </table>
    
</asp:Content>
