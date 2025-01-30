<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="HR_Web_Application.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">

        <div class="content container-fluid">

            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">Welcome
                            <asp:Label runat="server" ID="lblShowUser"></asp:Label></h3>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item active">Dashboard</li>
                        </ul>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card">

                            <div class="card-body">

                                <div class="row" style="padding: 20px;" runat="server" id="gridArea" visible="true">
                                    
                                        <div class="col-md-3 col-xl-4 grid-margin stretch-card">
                                            <div class="card newsletter-card bg-gradient-warning">
                                                <div class="card-body">
                                                    <div class="d-flex flex-column align-items-center justify-content-center h-100">
                                                        <h5  style="padding-top: 17px; padding-bottom: 17px; font-size: 23px;">No. of Active profile</h5>

                                                        <asp:Label ID="lblgetEnrolledActiveStd" Style="font-size: 40px; font-weight: 600;"
                                                            runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-xl-4 grid-margin stretch-card">
                                            <div class="card newsletter-card bg-gradient-warning">
                                                <div class="card-body">
                                                    <div class="d-flex flex-column align-items-center justify-content-center h-100">
                                                        <h5 class="mb-12" style="padding-top: 17px; padding-bottom: 17px; font-size: 23px;">No. of Exam Given</h5>

                                                        <asp:Label ID="lblExamGivenData" Style="font-size: 40px; font-weight: 600;"
                                                            runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-xl-4 grid-margin stretch-card">
                                            <div class="card newsletter-card bg-gradient-warning">
                                                <div class="card-body">
                                                    <div class="d-flex flex-column align-items-center justify-content-center h-100">
                                                        <h5 class="mb-12" style="padding-top: 17px; padding-bottom: 17px; font-size: 23px;">No. of AI Tutor Use</h5>

                                                        <asp:Label ID="lblAiTutorUse" Style="font-size: 40px; font-weight: 600;"
                                                            runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    
                                </div>

                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>
</asp:Content>

