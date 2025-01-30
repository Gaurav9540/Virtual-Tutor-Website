<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/admin.Master" AutoEventWireup="true" CodeBehind="viewquestion.aspx.cs" Inherits="HR_Web_Application.viewquestion" %>

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
                        <h3 class="page-title">Add Subject Wise Content</h3>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active">Add Subject Wise Content</li>
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
                                                ValidationGroup="attendance" InitialValue="0"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">Select Subject*: </label>

                                            <asp:DropDownList ID="ddlsubject" runat="server" CssClass="dobcss">
                                                <asp:ListItem Value="0">-Select Subject-</asp:ListItem>
                                                <asp:ListItem Value="1">English</asp:ListItem>
                                                <asp:ListItem Value="2">EVS</asp:ListItem>
                                                <asp:ListItem Value="3">Science</asp:ListItem>
                                                <asp:ListItem Value="4">Mathematics</asp:ListItem>
                                                <asp:ListItem Value="5">Social Science</asp:ListItem>
                                                <asp:ListItem Value="6">Social Study</asp:ListItem>
                                                <asp:ListItem Value="7">Hindi</asp:ListItem>
                                                <asp:ListItem Value="8">Marathi</asp:ListItem>
                                                <asp:ListItem Value="9">Sanskrit</asp:ListItem>
                                                <asp:ListItem Value="10">History</asp:ListItem>
                                                <asp:ListItem Value="11">Geography</asp:ListItem>
                                                <asp:ListItem Value="12">Civics</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvSubject"
                                                ControlToValidate="ddlsubject"
                                                ErrorMessage="Select Subject"
                                                ValidationGroup="attendance" InitialValue="0"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>

                                            <%--  <div id="errddlcategory" style="display: none; color: red;"></div>--%>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">Enter Subject Title*: </label>
                                            <asp:TextBox runat="server" ID="txttitle" MaxLength="100" AutoComplete="off" CssClass="dobcss" placeholder="Enter Subject Title"></asp:TextBox>

                                            <asp:RequiredFieldValidator runat="server" ID="tfvtitle"
                                                ControlToValidate="txttitle"
                                                ErrorMessage="Enter Subject Title"
                                                ValidationGroup="attendance"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">Enter Subject Video Link: </label>
                                            <asp:TextBox runat="server" ID="txtvideolink" AutoComplete="off" CssClass="dobcss" placeholder="Enter Subject Video Link"></asp:TextBox>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6" style="margin-bottom: 1rem !important">
                                            <label for="role">Enter Subject Description: </label>
                                            <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" Rows="4" Columns="50" AutoComplete="off" CssClass="dobcss" placeholder="Enter Subject Description"></asp:TextBox>
                                            <%--<asp:TextBox runat="server" ID="txtdescription"   ></asp:TextBox>--%>

                                            <%-- <asp:RequiredFieldValidator runat="server" ID="rfvtxtdescription"
                                                        ControlToValidate="txtdescription"
                                                        ErrorMessage="Enter Subject Description"
                                                        ValidationGroup="attendance"
                                                        Display="Dynamic"
                                                        ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12 mb-3">

                                            <asp:Button ID="addcontent" runat="server" Text="Submit" ValidationGroup="attendance" class="btn btn-sm btn-rounded btn-success" Style="border-radius: 5px !important; padding: 8px; font-size: 17px; font-weight: 800;"
                                                OnClick="addcontent_Click" />
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
