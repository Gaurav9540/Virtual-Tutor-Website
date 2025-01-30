<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/admin.Master" AutoEventWireup="true" CodeBehind="result.aspx.cs" Inherits="HR_Web_Application.result" %>

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
                                            <label for="role">Select ExamCode*: </label>

                                            <asp:DropDownList ID="ddlExamCode" runat="server" CssClass="dobcss" Style="padding: 13px;">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvClass"
                                                ControlToValidate="ddlExamCode"
                                                ErrorMessage="Select ExamCode"
                                                ValidationGroup="ValidationResult" InitialValue="0"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 mb-3">

                                            <asp:Button ID="showResultData" runat="server" Text="Show Result" ValidationGroup="ValidationResult" class="btn btn-sm btn-rounded btn-success" Style="border-radius: 5px !important; padding: 8px; font-size: 17px; font-weight: 800;"
                                                OnClick="showResultData_Click" />
                                        </div>
                                    </div>

                                    <div class="row" runat="server" id="showResultArea" visible="false">

                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <center>
                                                <table border="1" cellpadding="10">
                                                    <tr rowspan="2">
                                                        <th>My Result</th>
                                                    </tr>
                                                    <tr>
                                                        <td>Exam Code:</td>
                                                        <td>
                                                            <asp:Label ID="lblexamcode" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Date Of Exam:</td>
                                                        <td>
                                                            <asp:Label ID="lbldateOfExam" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Subject:</td>
                                                        <td>
                                                            <asp:Label ID="lblSubject" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Question Attempt:</td>
                                                        <td>
                                                            <asp:Label ID="lblQuestionAttempt" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Correct Answer:</td>
                                                        <td>
                                                            <asp:Label ID="lblCorrectAnswer" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Wrong Answer::</td>
                                                        <td>
                                                            <asp:Label ID="lblWrongAnswer" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Percentage:</td>
                                                        <td>
                                                            <asp:Label ID="lblPercentage" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Grade:</td>
                                                        <td>
                                                            <asp:Label ID="lblGrade" runat="server"></asp:Label></td>
                                                    </tr>
                                                </table>
                                            </center>

                                        </div>

                                    </div>




                                </form>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
