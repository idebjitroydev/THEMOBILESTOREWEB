<%@ Page Title="Add New Customer" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Add-Customer.aspx.cs" Inherits="Admin_User_Management_Add_Vendor" %>

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
                    Customer info
                </p>
                <div class="row">

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">AC NO.</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtAccountNumber" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">CST Name</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Customer Name is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtName" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">CST Email</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" SetFocusOnError="true" Display="Dynamic" ValidationGroup="sub" ForeColor="#ff5666"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Vendor Email is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtEmail" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">CST Phone</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtPhone" TextMode="Phone" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Vendor Phone is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPhone" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">CST Address</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Vendor Address is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtAddress" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">CST City</label>

                            <div class="col-sm-9">
                                <asp:DropDownList ID="drpCity" AutoPostBack="true" OnSelectedIndexChanged="drpCity_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Vendor City is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="drpCity" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">CST State</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtState" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Vendor State is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtState" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">CST Pincode</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtPincode" runat="server" MaxLength="6" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Vendor Pincode is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPincode" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">CST Country</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtCountry" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">CST Type</label>

                            <div class="col-sm-9">
                                <asp:DropDownList ID="drpType" runat="server" CssClass="form-control">
                                    <asp:ListItem>Flying Customer</asp:ListItem>
                                    <asp:ListItem>Fixed Customer</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:Button ID="btnSave" OnClick="btnSave_Click" ValidationGroup="sub" runat="server" Text="Save Customer" CssClass="btn btn-success" />
                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-danger" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>