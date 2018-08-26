<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Admin_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Custom js for this page-->
    <script src="../../../Content/js/dashboard.js"></script>
    <!-- End custom js for this page-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="row">
        <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 grid-margin stretch-card">
            <div class="card card-statistics">
                <div class="card-body">
                    <div class="clearfix">
                        <div class="float-left">
                            <i class="mdi mdi-account-circle text-danger icon-lg"></i>
                        </div>
                        <div class="float-right">
                            <p class="mb-0 text-right">Customers</p>
                            <div class="fluid-container">
                                <h3 class="font-weight-medium text-right mb-0" runat="server" id="cstCard"></h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 grid-margin stretch-card">
            <div class="card card-statistics">
                <div class="card-body">
                    <div class="clearfix">
                        <div class="float-left">
                            <i class="mdi mdi-account-multiple-outline text-warning icon-lg"></i>
                        </div>
                        <div class="float-right">
                            <p class="mb-0 text-right">Vendors</p>
                            <div class="fluid-container">
                                <h3 class="font-weight-medium text-right mb-0" runat="server" id="vendorsCard"></h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 grid-margin stretch-card">
            <div class="card card-statistics">
                <div class="card-body">
                    <div class="clearfix">
                        <div class="float-left">
                            <i class="mdi mdi-account-location text-info icon-lg"></i>
                        </div>
                        <div class="float-right">
                            <p class="mb-0 text-right">Employees</p>
                            <div class="fluid-container">
                                <h3 class="font-weight-medium text-right mb-0" runat="server" id="empCard"></h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 grid-margin stretch-card">
            <div class="card card-statistics">
                <div class="card-body">
                    <div class="clearfix">
                        <div class="float-left">
                            <i class="mdi mdi-shopping text-success icon-lg"></i>
                        </div>
                        <div class="float-right">
                            <p class="mb-0 text-right">Products</p>
                            <div class="fluid-container">
                                <h3 class="font-weight-medium text-right mb-0" runat="server" id="prdCard"></h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 grid-margin stretch-card">
            <div class="card card-statistics">
                <div class="card-body">
                    <div class="clearfix">
                        <div class="float-left">
                            <i class="mdi mdi-label-outline text-behance icon-lg"></i>
                        </div>
                        <div class="float-right">
                            <p class="mb-0 text-right">Categories</p>
                            <div class="fluid-container">
                                <h3 class="font-weight-medium text-right mb-0" runat="server" id="catCard"></h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-lg-3 col-md-3 col-sm-6 grid-margin stretch-card">
            <div class="card card-statistics">
                <div class="card-body">
                    <div class="clearfix">
                        <div class="float-left">
                            <i class="mdi mdi-lumx text-facebook icon-lg"></i>
                        </div>
                        <div class="float-right">
                            <p class="mb-0 text-right">Brands</p>
                            <div class="fluid-container">
                                <h3 class="font-weight-medium text-right mb-0" runat="server" id="brandCard"></h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>