<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TaxiteBus.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>À propos</h2>
    <h3>Réservez vos trajets Taxibus via Internet et visionnez les points d'arrêts disponibles!</h3>
    <p>
        Cette application Web permet à quiconque de s'inscrire à la société des transport de la <a href="http://www.ville.rimouski.qc.ca">ville de Rimouski</a>
        via Internet et d'utiliser le service Taxibus de la ville. Les réservations prises en ligne sont alors traités comme tout autre type de réservation. Il est
        également possible de consulter les zones différentes de Taxibus ainsi que les points d'arrêts disponibles pour les voyages.
    </p>
    <h4>Plus de détails sur le système <a href="http://www.ville.rimouski.qc.ca/fr/citoyens/nav/circulation/Rimouskibus.html">Taxibus</a> de Rimouski</h4>
    <ul>
        <li>
            <b>Zones et lignes Taxibus</b>
            <p>
                Le service Taxibus est offert sur le territoire dans différentes zones et lignes identifiées par des couleurs. Pour connaître l’arrêt situé le plus près de vos besoins, vous devez consulter la carte de votre zone ou de votre ligne et l’horaire qui lui est assorti.
            </p>
        </li>
        <li>
            <b>Inscription à Taxibus</b>
            <p>
                Vous devez être inscrit à Taxibus pour utiliser le service.  L'inscription se fait au bureau de La Société entre 8 h 30 et 17 h du lundi au vendredi. Après avoir fourni vos coordonnées et été photographié, vous recevez une carte d’identification portant un numéro d’usager.
            </p>
        </li>
        <li>
            <b>Frais d’inscription à Taxibus</b>
            <p>
                Des frais d’inscription de 1 $ sont exigés. Ils sont non remboursables, non transférables et non récurrents. L’inscription est valide à vie.
            </p>
        </li>
        <li>
            <b>Réservation par téléphone</b>
            <p>
                Le service Taxibus est un service « sur demande » qui nécessite une réservation. Un seul appel au 418 723-5555 est requis pour un ou plusieurs déplacements. Les réservations doivent être faites au moins une (1) heure à l’avance, à l’exception des réservations de fin de soirée, qui doivent être faites avant 21 h, auprès de La Société.
                <b>Nous recevons vos appels du lundi au vendredi, de 5 h 30 à 21 h, et le samedi, de 5 h 30 à 18 h.</b>
            </p>
        </li>
        <li>
            <b>Modification</b>
            <p>
                Une réservation peut être modifiée jusqu’à une (1) heure avant le départ, à l’exception de celle pour un déplacement de fin de soirée, qui doit être modifiée avant 21 h, seulement auprès de La Société. Le chauffeur n’est pas autorisé à accepter une modification.
            </p>
        </li>
        <li>
            <b>Annulation</b>
            <p>
                Un déplacement peut être annulé. Cependant, l’annulation doit être faite au moins 30 minutes avant l’heure prévue auprès de La Société, à défaut de quoi, une pénalité équivalente au tarif d’un déplacement sera exigée.
            </p>
        </li>
        <li>
            <b>Embarquement et débarquement</b>
            <p>
                L’embarquement et le débarquement se font uniquement à l’arrêt ou de l’autre côté de la voie publique, face à l’arrêt. Dans les cas d’exception prévus au 
                <a href="http://www.ville.rimouski.qc.ca/fr/citoyens/nav/circulation/Rimouskibus.html#reglements">Règlement sur les normes de base en transport collectif pour le territoire de la ville de Rimouski</a>
                , l’embarquement et le débarquement se font face à l’adresse civique et sur ce côté de la voie publique uniquement, pour des motifs de sécurité.
            </p>
        </li>
        <li>
            <b>Présence à l’arrêt Taxibus</b>
            <p>
                Vous devez être présent à l’arrêt Taxibus à l’heure réservée du déplacement.  L’heure de référence est celle du
                <a href="http://www.nrc-cnrc.gc.ca/fra/services/heure/horloge_web.html">Conseil national de recherches Canada</a>.
            </p>
        </li>
        <li>
            <b>Délai d’attente</b>
            <p>
                Le service Taxibus prévoit un délai d’attente pouvant aller jusqu’à 15 minutes. Ce délai varie selon le nombre de passagers et selon l’ordre d’embarquement.
            </p>
        </li>
        <li>
            <b>Jumelage</b>
            <p>
                Le service Taxibus n’est pas un service de taxi privé. Les courses Taxibus peuvent inclure jusqu’à 4 usagers.
            </p>
        </li>
        <li>
            <b>Siège d’enfant</b>
            <p>
                Sur demande préalable au moment de la réservation, des sièges d’enfants sont disponibles dans les véhicules Taxibus.
            </p>
        </li>
        <li>
            <b>Bagage</b>
            <p>
                Les bagages à main sont permis dans les Taxibus. Ils doivent être placés sur les genoux de l’usager, sans nuire aux autres passagers. Aucun bagage ne peut être déposé dans le coffre arrière.
            </p>
        </li>
        <li>
            <b>Poussette</b>
            <p>
                Les poussettes pour enfant doivent être pliées et déposées dans le coffre arrière du Taxibus par l’usager. Le chauffeur ne manipule pas les poussettes.
            </p>
        </li>
        <li>
            <b>Enfants âgés de moins de 10 ans </b>
            <p>
                Tout enfant âgé de moins de 10 ans doit être accompagné d’un adulte pendant toute la durée de son déplacement en transport collectif.
            </p>
        </li>
        <li>
            <b>Jours fériés</b>
            <ul>
                <li>Le 1er janvier</li>
                <li>Le 2 janvier</li>
                <li>Le lundi de Pâques</li>
                <li>La journée nationale des Patriotes</li>
                <li>La fête nationale du Québec</li>
                <li>La fête du Canada</li>
                <li>La fête du Travail</li>
                <li>L'Action de grâce</li>
                <li>Le 25 décembre</li>
                <li>Le 26 décembre</li>
            </ul>
        </li>
    </ul>
    <p>
        Source:<a href="http://www.ville.rimouski.qc.ca/fr/citoyens/nav/circulation/Rimouskibus.html#taxibus">http://www.ville.rimouski.qc.ca/fr/citoyens/nav/circulation/Rimouskibus.html#taxibus</a>
    </p>

</asp:Content>
