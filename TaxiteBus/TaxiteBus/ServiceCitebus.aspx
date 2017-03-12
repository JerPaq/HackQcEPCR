<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceCitebus.aspx.cs" Inherits="TaxiteBus.ServiceCitebus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.1.1.min.js"></script>
    <script>

        function afficherCircuit(noCircuit)
        {
            $('#Circuit11').css('display', 'none');
            $('#Circuit21').css('display', 'none');
            $('#Circuit31').css('display', 'none');
            switch (noCircuit)
            {
                case 11: $('#Circuit11').css('display', 'table');
                break;
                case 21: $('#Circuit21').css('display', 'table');
                break;
                case 31: $('#Circuit31').css('display', 'table');
                break;
            }
        }

    </script>

    <h2>Service Citébus</h2>

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
        <a href="http://www.ville.rimouski.qc.ca/webconcepteurcontent63/000022830000/upload/citoyens/circulation/Carte_circuit_21.pdf">Voir la carte du trajet</a>
        <table class="tblCitebus">
            <tr>
                <th class="citebusNom">
                    Arrêt
                </th>
                <th class="citebusHeure">
                    Passage
                </th>
            </tr>
            <% foreach (TaxiteBus.Structures.CiteBus.Features arret in circuit21) { %>
            <tr>
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
        <a href="http://www.ville.rimouski.qc.ca/webconcepteurcontent63/000022830000/upload/citoyens/circulation/Carte_circuit_31.pdf">Voir la carte du trajet</a>
        <table class="tblCitebus">
            <tr>
                <th class="citebusNom">
                    Arrêt
                </th>
                <th class="citebusHeure">
                    Passages
                </th>
            </tr>
            <% foreach (TaxiteBus.Structures.CiteBus.Features arret in circuit21) { %>
            <tr>
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
    
</asp:Content>
