<%@ Page Title="Edit Existing Employee" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Edit-Employee.aspx.cs" Inherits="Admin_User_Management_Edit_Employee" %>

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
                    Employee info
                </p>
                <div class="row">

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">AC NO.</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtAccountNumber" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">EM Name</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Employee Name is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtName" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">EM Email</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" SetFocusOnError="true" Display="Dynamic" ValidationGroup="sub" ForeColor="#ff5666"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Employee Email is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtEmail" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <%--<div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">EM Password</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtPass" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Employee Password is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPass" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>--%>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">EM Phone</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtPhone" TextMode="Phone" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Employee Phone is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPhone" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">EM Address</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Employee Address is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtAddress" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">EM City</label>

                            <div class="col-sm-9">
                                <asp:DropDownList ID="drpCity" AutoPostBack="true" OnSelectedIndexChanged="drpCity_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Employee City is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="drpCity" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">EM State</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtState" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Employee State is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtState" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">EM Pincode</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtPincode" runat="server" MaxLength="6" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Employee Pincode is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPincode" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">EM Country</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtCountry" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">EM Gender</label>

                            <div class="col-sm-9">
                                <asp:DropDownList ID="drpGender" runat="server" CssClass="form-control">
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Employee Gender is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="drpGender" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">EM Type</label>

                            <div class="col-sm-9">
                                <asp:DropDownList ID="drpType" runat="server" CssClass="form-control">
                                    <asp:ListItem>Admin</asp:ListItem>
                                    <asp:ListItem>Sellor</asp:ListItem>
                                </asp:DropDownList>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Employee Type is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="drpType" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">EM Status</label>

                            <div class="col-sm-9">
                                <asp:DropDownList ID="drpStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem>Active</asp:ListItem>
                                    <asp:ListItem>Inactive</asp:ListItem>
                                </asp:DropDownList>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Employee Status is Required" Display="Dynamic" SetFocusOnError="true" ControlToValidate="drpStatus" ValidationGroup="sub" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" ValidationGroup="sub" runat="server" Text="Update Employee" CssClass="btn btn-success" />
                            <a href="#" class="btn btn-danger" data-toggle="modal" data-target="#deleteModal">Delete Employee</a>
                            <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#changePassword">Change Password</a>
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Delete Modal -->
    <div class="modal modal-delete fade modal-lg" id="deleteModal">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Are You Sure?</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    This Employee Would Be Deleted and this action cannot be reverted!
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" Text="Delete" CssClass="btn btn-danger btn-block" />
                </div>
            </div>
        </div>
    </div>

    <!-- Change Password Modal -->
    <div class="modal fade modal-lg" id="changePassword">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Change Password</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="txtPassword">Password</label>
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="change" runat="server" ErrorMessage="Password Field is Required" ControlToValidate="txtPassword" Display="Dynamic" SetFocusOnError="true" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="txtPasswordConfirm">Confirm Password</label>
                                <asp:TextBox ID="txtPasswordConfirm" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Both Password Should Match" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm" Display="Dynamic" SetFocusOnError="true" ForeColor="#ff5666"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="change" runat="server" ErrorMessage="Password Field is Required" ControlToValidate="txtPasswordConfirm" Display="Dynamic" SetFocusOnError="true" ForeColor="#ff5666"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button ID="btnChangePassword" ValidationGroup="change" OnClick="btnChangePassword_Click" runat="server" Text="Change Password" CssClass="btn btn-primary btn-block" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>