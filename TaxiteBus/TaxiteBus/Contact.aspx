<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TaxiteBus.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Contacts</h2>
    <h3>Services à contacter pour plus d'information</h3>
    
    <address>
        <img src="Images/SocieteTransports.png" /> <br />
        376, avenue de la Cathédrale<br />
        Rimouski (Québec) G5L 5K9<br />
        Téléphone: 418 723-5555
    </address>

    <address>
        <img src="Images/VilleRimouski.png" /> <br />
        205, avenue de la Cathédrale<br />
        Rimouski (Québec) G5L 7C7<br />
        Téléphone: 418 724-3171
    </address>

    <address>
        <strong>Direction générale:</strong>   <a href="mailto:direction.generale@ville.rimouski.qc.ca">direction.generale@ville.rimouski.qc.ca</a><br />
        <strong>Communications de la ville:</strong> <a href="mailto:communications@ville.rimouski.qc.ca">communications@ville.rimouski.qc.ca</a>
    </address>

</asp:Content>
