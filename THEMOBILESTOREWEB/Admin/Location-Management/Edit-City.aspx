<%@ Page Title="Edit Existing City" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Edit-City.aspx.cs" Inherits="Admin_Location_Management_Edit_City" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- inject:js -->
    <script src="../../../Content/js/off-canvas.js"></script>
    <script src="../../../Content/js/misc.js"></script>
    <!-- endinject -->
    <!-- Custom js for this page-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="col-12 grid-margin">
        <div class="alert alert-success alert-dismissible" runat="server" style="height: 45px;" id="popup">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <p id="message" runat="server"></p>
        </div>

        <div class="alert alert-danger alert-dismissible" runat="server" style="height: 45px;" id="popupDanger">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <p id="errMessage" runat="server"></p>
        </div>
        <div class="card">
            <div class="card-body">
                <h4 class="card-title"><%= Page.Title %></h4>
                <p class="card-description">
                    City info
                </p>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">City Name</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="State Name is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtName" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">Select State</label>

                            <div class="col-sm-9 dropdown">
                                <asp:DropDownList ID="drpState" CssClass="form-control" runat="server"></asp:DropDownList>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select a State" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtName" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" ValidationGroup="sub" runat="server" Text="Update City" CssClass="btn btn-success" />
                            <a href="#" class="btn btn-danger" data-toggle="modal" data-target="#deleteModal">Delete City</a>
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- The Modal -->
    <div class="modal fade modal-lg" id="deleteModal">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Are You Sure?</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    This City Would Be Deleted and this action cannot be reverted!
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" Text="Delete" CssClass="btn btn-danger btn-block" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>