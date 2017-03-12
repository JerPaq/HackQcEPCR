<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceCitebus.aspx.cs" Inherits="TaxiteBus.ServiceCitebus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>

    </script>

    <h2>Service Citébus</h2>

    <div class="dropdown">
            <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                Choisir un circuit
   
                <span class="caret"></span>
            </button>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                <li><a onclick="afficherCircuit('11')" href="#">Circuit 11/12</a></li>
                <li><a onclick="afficherCircuit('21')" href="#">Circuit 21</a></li>
                <li><a onclick="afficherCircuit('31')" href="#">Circuit 31</a></li>
            </ul>
        </div>
    
    <table id="Circuit11">
        <tr>
            <th>
                Arrêts
            </th>
            <th>
                Lundi au Vendredi
            </th>
            <th>
                Samedi et Dimanche
            </th>
        </tr>
    </table>

    <table id="Circuit12">
        <tr>
            <th>
                06:46 à 09:15<br />
                11:15 à 13:15<br />
                16:16 à 18:15
            </th>
        </tr>
    </table>

    <table id="Circuit21">
        <tr>
            <th>
                Arrêts
            </th>
            <th>
                Lundi au Vendredi
            </th>
        </tr>
    </table>

</asp:Content>
