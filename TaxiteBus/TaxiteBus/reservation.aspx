<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TaxiteBus._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-4">
            <h2>Réservation</h2>
            <div class="input-group">
                <label>Départ :</label>
                <input type="text" class="form-control" aria-describedby="basic-addon1">
                    <button type="button" class="btn btn-default"  aria-label="Help" data-toggle="modal" data-target="#myModal">
                        <span class="glyphicon glyphicon-map-marker"></span>
                    </button>
            </div>
            <br />
            <div class="input-group">
                <label>Vers :</label>
                <input type="text" class="form-control" aria-describedby="basic-addon1">
                    
                    <button type="button" class="btn btn-default" aria-label="Help" data-toggle="modal" data-target="#myModal">
                        <span class="glyphicon glyphicon-map-marker"></span>
                    </button>
            </div>
            <br />
            <button type="button" class="btn btn-default navbar-btn">Soumettre</button>
        </div>
        <div class="col-md-4"></div>
    </div>
                <!-- Modal -->
            <div id="myModal" class="modal fade" role="dialog">
                <div class="modal-dialog">

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
