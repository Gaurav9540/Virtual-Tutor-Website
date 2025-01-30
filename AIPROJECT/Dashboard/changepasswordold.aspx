<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/admin.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="HR_Web_Application.forgotpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body class="account-page">

        <div class="main-wrapper">
            <div class="account-content">

                <div class="account-logo">
                </div>
                <div class="account-box">
                    <div class="account-wrapper">
                        <h3 class="account-title">Change Password</h3>
                        <form>
                            <div class="input-block mb-3">
                                <label class="col-form-label">Old password</label>
                                <asp:TextBox runat="server" type="password" CssClass="form-control" ID="txtOldPass" placeholder="Old Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtoldpass"
                                    ErrorMessage="Enter old password"
                                    ValidationGroup="passwordGroup"
                                    Display="Dynamic"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="input-block mb-3">
                                <label class="col-form-label">New password</label>
                                <asp:TextBox runat="server" type="password" CssClass="form-control" ID="txtNewPass" placeholder="New Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtNewPass"
                                    ErrorMessage="Enter new password"
                                    ValidationGroup="passwordGroup"
                                    Display="Dynamic"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="input-block mb-3">
                                <label class="col-form-label">Confirm password</label>
                                <asp:TextBox type="password" CssClass="form-control" runat="server" ID="txtConPass" placeholder="Confirm Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="txtConPass"
                                    ErrorMessage="Enter confirm password"
                                    ValidationGroup="passwordGroup"
                                    Display="Dynamic"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtConPass"
                                    ControlToValidate="txtNewPass" Display="Dynamic" ErrorMessage="Confirm password not matched with new password, try again" ForeColor="Red"
                                      ValidationGroup="passwordGroup"></asp:CompareValidator>
                            </div>
                            <div class="submit-section mb-4">

                                <asp:Button ID="Button1" runat="server" ValidationGroup="passwordGroup" Text="Update Password" class="btn btn-sm btn-rounded btn-success" OnClick="Button1_Click" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>

        <script src="assets/js/jquery-3.7.0.min.js"></script>

        <script src="assets/js/bootstrap.bundle.min.js"></script>

        <script src="assets/js/jquery.slimscroll.min.js"></script>

        <script src="assets/js/select2.min.js"></script>

        <script src="assets/js/app.js"></script>

    </body>
</asp:Content>
