<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/admin.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="HR_Web_Application.changepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">





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
                        <h3 class="page-title">Change Password</h3>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active">change Password</li>
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
                                            <label for="role">Enter Register Mobile Number*: </label>
                                            <asp:TextBox runat="server" ID="txtmobile" AutoComplete="off" CssClass="dobcss number-only" placeholder="Enter Register Mobile Number" MaxLength="10"
                                                oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"></asp:TextBox>

                                            <asp:RegularExpressionValidator ID="revMobile" runat="server" ControlToValidate="txtmobile"
                                                ErrorMessage="Please enter a valid 10-digit mobile number" Display="Dynamic" ValidationGroup="attendance" ForeColor="red"
                                                ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>

                                            <asp:RequiredFieldValidator runat="server" ID="tfvtitle"
                                                ControlToValidate="txtmobile"
                                                ErrorMessage="Enter Mobile Number"
                                                ValidationGroup="attendance"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">Old Password*: </label>
                                            <asp:TextBox runat="server" ID="txtoldpass" MaxLength="100" AutoComplete="off" TextMode="Password" CssClass="dobcss" placeholder="Enter Old Password"></asp:TextBox>

                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
                                                ControlToValidate="txtoldpass"
                                                ErrorMessage="Enter Old Password"
                                                ValidationGroup="attendance"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">New Password*: </label>
                                            <asp:TextBox runat="server" ID="txtnewpass" MaxLength="100" AutoComplete="off" TextMode="Password" CssClass="dobcss" placeholder="Enter New Password"></asp:TextBox>

                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2"
                                                ControlToValidate="txtnewpass"
                                                ErrorMessage="Enter New Password"
                                                ValidationGroup="attendance"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-4" style="margin-bottom: 1rem !important">
                                            <label for="role">Confirm Password*: </label>
                                            <asp:TextBox runat="server" ID="txtconfirmpass" MaxLength="100" AutoComplete="off" TextMode="Password" CssClass="dobcss" placeholder="Enter Confirm Password"></asp:TextBox>

                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3"
                                                ControlToValidate="txtconfirmpass"
                                                ErrorMessage="Enter Confirm Password"
                                                ValidationGroup="attendance"
                                                Display="Dynamic"
                                                ForeColor="Red"></asp:RequiredFieldValidator>

                                            <asp:CompareValidator ID="cvPasswordMatch" runat="server" ControlToValidate="txtconfirmpass"
                                                ControlToCompare="txtnewpass" ErrorMessage="Passwords do not match" Display="Dynamic" ForeColor="Red"
                                                ValidationGroup="attendance"></asp:CompareValidator>
                                        </div>
                                    </div>





                                    <div class="row">
                                        <div class="col-md-12 mb-3">

                                            <asp:Button ID="changepass" runat="server" Text="Submit" ValidationGroup="attendance" class="btn btn-sm btn-rounded btn-success" Style="border-radius: 5px !important; padding: 8px; font-size: 17px; font-weight: 800;"
                                                OnClick="changepass_Click" />
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
                <script>

                    $('.alpha-only').bind('keyup blur', function () {
                        $(this).val($(this).val().replace(/[^A-Za-z_\s]/, ''));
                    }
                    );
                    $('.number-only').bind('keyup blur', function () {
                        $(this).val($(this).val().replace(/[^0-9\+\s\-\()]/, ''));
                    }
                    );
                </script>
</asp:Content>
