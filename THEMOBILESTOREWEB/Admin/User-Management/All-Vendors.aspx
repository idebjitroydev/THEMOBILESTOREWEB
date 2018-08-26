<%@ Page Title="View All Vendors" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="All-Vendors.aspx.cs" Inherits="Admin_User_Management_All_Vendors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- inject:js -->
    <script src="../../../Content/js/off-canvas.js"></script>
    <script src="../../../Content/js/misc.js"></script>
    <!-- endinject -->
    <!-- Custom js for this page-->
    <!-- End custom js for this page-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <div class="alert alert-success alert-dismissible" runat="server" style="height: 45px;" id="popup">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <p id="message" runat="server"></p>
            </div>

            <div class="alert alert-danger alert-dismissible" runat="server" style="height: 45px;" id="popupDanger">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <p id="errMessage" runat="server"></p>
            </div>
        </div>
        <div class="col-lg-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <h4 class="card-title"><%= Page.Title %></h4>
                        </div>
                        <div class="col-md-6">
                            <p class="text-right">
                                <a href="/Admin/User-Management/Add-Vendor.aspx" class="btn btn-success">Add New Vendor</a>
                            </p>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="dgVendors" OnPageIndexChanging="dgVendors_PageIndexChanging" PagerSettings-Mode="NumericFirstLast" PagerStyle-CssClass="pagination-ys" runat="server" AllowPaging="true" PageSize="10" CssClass="table table-striped border-white" AutoGenerateColumns="false">
                            <Columns>
                                <%--<asp:BoundField DataField="ID" HeaderText="State ID" />--%>
                                <asp:BoundField DataField="Name" HeaderText="Vendor Name" />
                                <asp:BoundField DataField="Phone" HeaderText="Vendor Phone" />
                                <%--<asp:BoundField DataField="Type" HeaderText="Employee Type" />--%>
                                <asp:BoundField DataField="created_at" HeaderText="Created At" />
                                <asp:BoundField DataField="updated_at" HeaderText="Updated At" />
                                <%--<asp:CommandField ShowEditButton="true" />--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdID" Value='<%#Eval("ID") %>' runat="server" />
                                        <asp:LinkButton runat="server" CssClass="btn btn-primary btn-xs" ID="btnEdit" OnClick="btnEdit_Click">Edit Vendor</asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderTemplate>
                                        Actions
                                    </HeaderTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="text-right mt-5">
                        <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#myModal">
                            Reset Table
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdid" runat="server" />
    </div>

    <!-- The Modal -->
    <div class="modal fade modal-lg" id="myModal">
        <div class="modal-dialog">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Are You Sure?</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    Type Reset to <strong>DELETE</strong> all Data From Vendors
                    <asp:TextBox ID="txtReset" runat="server" CssClass="form-control resetBox"></asp:TextBox>
                    <small>
                        <asp:CustomValidator ID="ResetValidator" runat="server" OnServerValidate="ResetValidator_ServerValidate" ErrorMessage="You Need To Type <strong>Reset</strong> to Proceed" ControlToValidate="txtReset" ForeColor="#ff5666"></asp:CustomValidator>
                    </small>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button ID="btnTruncate" runat="server" Text="Reset" OnClick="btnTruncate_Click" CssClass="btn btn-danger btn-block" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>