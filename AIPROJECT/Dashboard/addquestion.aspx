<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/admin.Master" AutoEventWireup="true" CodeBehind="addquestion.aspx.cs" Inherits="HR_Web_Application.addquestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">

        <!-- Date Picker -->
    /*$(function () {
        $("#ContentPlaceHolder1_txtAttendanceDate").datepicker({
            showOn: 'both',
            buttonImageOnly: true,
            buttonImage: 'assets/img/calendarnew.png',
            dateFormat: 'dd/mm/yy',
            changeMonth: true,
            changeYear: true,
            yearRange: '-80:+0',
            endDate: 'today',
            maxDate: '0',
            autoclose: true
        });
    });*/






    </script>

    <style>
        .dobcss {
            width: 100%;
            padding: 0.375rem 0.75rem;
            font-size: 1rem;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out;
        }
    </style>

    <div class="page-wrapper">
        <div class="content container-fluid">

            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <h3 class="page-title">Add Question</h3>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active">Add Question</li>
                        </ul>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card">

                            <div class="card-body">

                                <form class="needs-validation">
                                    <div class="row">
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">Enter Question*: </label>

                                            <asp:TextBox ID="txtQuestion" TextMode="MultiLine" runat="server"
                                                placeholder="Enter Question" CssClass="dobcss"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
                                                ControlToValidate="txtQuestion"
                                                ErrorMessage="Enter Question"
                                                ValidationGroup="questionBank"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">Option 1*: </label>

                                            <asp:TextBox ID="txtopt1" CssClass="dobcss" runat="server" placeholder="Enter Option 1"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2"
                                                ControlToValidate="txtopt1"
                                                ErrorMessage="Enter Option 1"
                                                ValidationGroup="questionBank"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">Option 2*: </label>

                                            <asp:TextBox ID="txtopt2" CssClass="dobcss" runat="server" placeholder="Enter Option 2"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3"
                                                ControlToValidate="txtopt2"
                                                ErrorMessage="Enter Option 3"
                                                ValidationGroup="questionBank"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">Option 3*: </label>

                                            <asp:TextBox ID="txtopt3" CssClass="dobcss" runat="server" placeholder="Enter Option 3"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4"
                                                ControlToValidate="txtopt3"
                                                ErrorMessage="Enter Option 3"
                                                ValidationGroup="questionBank"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">Option 4*: </label>

                                            <asp:TextBox ID="txtopt4" CssClass="dobcss" runat="server" placeholder="Enter Option 4"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5"
                                                ControlToValidate="txtopt4"
                                                ErrorMessage="Enter Option 4"
                                                ValidationGroup="questionBank"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">Correct Answer*: </label>

                                            <asp:TextBox ID="txtcorrect" CssClass="dobcss" runat="server" placeholder="Enter Correct Answer"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6"
                                                ControlToValidate="txtcorrect"
                                                ErrorMessage="Enter  Correct Answer"
                                                ValidationGroup="questionBank"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>



                                    <div class="row">
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">Select Class*: </label>

                                            <asp:DropDownList ID="ddlclass" runat="server" CssClass="dobcss">
                                                <asp:ListItem Value="0">-Select Class-</asp:ListItem>
                                                <asp:ListItem Value="1">Class V</asp:ListItem>
                                                <asp:ListItem Value="2">Class VI</asp:ListItem>
                                                <asp:ListItem Value="3">Class VII</asp:ListItem>
                                                <asp:ListItem Value="4">Class VIII</asp:ListItem>
                                                <asp:ListItem Value="5">Class IX</asp:ListItem>
                                                <asp:ListItem Value="6">Class X</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvClass"
                                                ControlToValidate="ddlclass"
                                                ErrorMessage="Select Class"
                                                ValidationGroup="questionBank" InitialValue="0"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">Select Subject*: </label>

                                            <asp:DropDownList ID="ddlsubject" runat="server" CssClass="dobcss">
                                                <asp:ListItem Value="0">-Select Subject-</asp:ListItem>
                                                <asp:ListItem Value="1">English</asp:ListItem>
                                                <asp:ListItem Value="2">EVS</asp:ListItem>
                                                <asp:ListItem Value="3">Science</asp:ListItem>
                                                <asp:ListItem Value="4">Mathematics</asp:ListItem>
                                                <asp:ListItem Value="5">Social Science</asp:ListItem>
                                                <asp:ListItem Value="6">ICT</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvSubject"
                                                ControlToValidate="ddlsubject"
                                                ErrorMessage="Select Subject"
                                                ValidationGroup="questionBank" InitialValue="0"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>

                                            <%--  <div id="errddlcategory" style="display: none; color: red;"></div>--%>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-12 mb-3">

                                            <asp:Button ID="addQuestion" runat="server" Text="Submit" ValidationGroup="questionBank" class="btn btn-sm btn-rounded btn-success" Style="border-radius: 5px !important; padding: 8px; font-size: 17px; font-weight: 800;"
                                                OnClick="addQuestion_Click" />
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
