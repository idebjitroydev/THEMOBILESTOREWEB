<%@ Page Title="Add New State" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Add-State.aspx.cs" Inherits="Admin_Location_Management_Add_State" %>

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
                    State info
                </p>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">State Name</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="State Name is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtName" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator1" OnServerValidate="CustomValidator1_ServerValidate" runat="server" ErrorMessage="State Name Exists" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtName" ValidationGroup="sub" ForeColor="#ff5666"></asp:CustomValidator>
                                </small>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" ValidationGroup="sub" runat="server" Text="Save State" CssClass="btn btn-success" />
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>