<%@ Page Title="Edit Existing Vendor" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Edit-Vendor.aspx.cs" Inherits="Admin_User_Management_Edit_Vendor" %>

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
                    Vendor info
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
                            <label class="col-sm-3 col-form-label">VD Name</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vendor Name is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtName" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">VD Email</label>

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
                            <label class="col-sm-3 col-form-label">VD Phone</label>

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
                            <label class="col-sm-3 col-form-label">VD Phone Alternate</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtPhone2" TextMode="Phone" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">VD Address</label>

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
                            <label class="col-sm-3 col-form-label">VD City</label>

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
                            <label class="col-sm-3 col-form-label">VD State</label>

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
                            <label class="col-sm-3 col-form-label">VD Pincode</label>

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
                            <label class="col-sm-3 col-form-label">VD Country</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtCountry" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">VD GST No</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtGST" MaxLength="20" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Vendor GST is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtGST" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">VD License No</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtLicense" MaxLength="20" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Vendor GST is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtLicense" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">VD Aadhar No</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtAadhar" MaxLength="16" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Vendor Aadhar is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtAadhar" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">VD Brand</label>

                            <div class="col-sm-9">
                                <asp:DropDownList ID="drpBrand" AutoPostBack="true" CssClass="form-control" runat="server">
                                    <asp:ListItem>Samsung</asp:ListItem>
                                    <asp:ListItem>Apple</asp:ListItem>
                                </asp:DropDownList>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Vendor Brand is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="drpBrand" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" ValidationGroup="sub" runat="server" Text="Update Vendor" CssClass="btn btn-success" />
                                <a href="#" class="btn btn-danger" data-toggle="modal" data-target="#deleteModal">Delete</a>
                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-danger" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Delete Modal -->
    <div class="modal modal-delete fade modal-lg" id="deleteModal">
        <div class="modal-dialog">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Are You Sure?</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    This Vendor Would Be Deleted and this action cannot be reverted!
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" Text="Delete" CssClass="btn btn-danger btn-block" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>