<%@ Page Title="Edit Existing Product" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Edit-Product.aspx.cs" Inherits="Admin_Product_Management_Edit_Products" %>

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
                    Product info
                </p>
                <div class="row">

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">Product NO.</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtAccountNumber" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">Product Name</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Brand Name is Required" ControlToValidate="txtName" SetFocusOnError="true" Display="Dynamic" ForeColor="#ff5666" ValidationGroup="sub" />
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">Product Code</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtCode" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Product Code is Required" ControlToValidate="txtCode" SetFocusOnError="true" Display="Dynamic" ForeColor="#ff5666" ValidationGroup="sub" />
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">Product Barcode</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtBarcode" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Product Barcode is Required" ControlToValidate="txtBarcode" SetFocusOnError="true" Display="Dynamic" ForeColor="#ff5666" ValidationGroup="sub" />
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">Product Category</label>

                            <div class="col-sm-9">
                                <asp:DropDownList ID="drpCat" runat="server" CssClass="form-control"></asp:DropDownList>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Product Category is Required" ControlToValidate="drpCat" SetFocusOnError="true" Display="Dynamic" ForeColor="#ff5666" ValidationGroup="sub" />
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">Product Brand</label>

                            <div class="col-sm-9">
                                <asp:DropDownList ID="drpBrand" runat="server" CssClass="form-control"></asp:DropDownList>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Product Brand is Required" ControlToValidate="drpBrand" SetFocusOnError="true" Display="Dynamic" ForeColor="#ff5666" ValidationGroup="sub" />
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">Product CP</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtCP" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Product Cost Price is Required" ControlToValidate="txtCP" SetFocusOnError="true" Display="Dynamic" ForeColor="#ff5666" ValidationGroup="sub" />
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">Product SP</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtSP" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Product Selling Price is Required" ControlToValidate="txtSP" SetFocusOnError="true" Display="Dynamic" ForeColor="#ff5666" ValidationGroup="sub" />
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">Product Discount</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control"></asp:TextBox>
                                <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Product Discount is Required" ControlToValidate="txtDiscount" SetFocusOnError="true" Display="Dynamic" ForeColor="#ff5666" ValidationGroup="sub" />
                                </small>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label">Product Stock</label>

                            <div class="col-sm-9">
                                <asp:TextBox ID="txtStock" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" ValidationGroup="sub" runat="server" Text="Update Product" CssClass="btn btn-success" />
                            <a href="#" class="btn btn-danger" data-toggle="modal" data-target="#deleteModal">DELETE Product</a>
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
                    This Product Would Be Deleted and this action cannot be reverted!
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" Text="Delete" CssClass="btn btn-danger btn-block" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>