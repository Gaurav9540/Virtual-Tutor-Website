<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/admin.Master" AutoEventWireup="true" CodeBehind="myprofile.aspx.cs" Inherits="HR_Web_Application.myprofile" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link href='https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/ui-lightness/jquery-ui.css' rel='stylesheet'>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>

    <script>

        $(document).ready(function () {
            $('.keyup-email').keyup(function () {
                $('span.error-keyup-7').remove();
                var inputVal = $(this).val();
                var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
                if (!emailReg.test(inputVal)) {
                    $(this).after('<span class="error error-keyup-7">Invalid Email Format.</span>');
                }
            });
        });


        function onlyAlphabets(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
                    return true;
                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function validatePan(evt) {
            var panValue = document.getElementById('ContentPlaceHolder1_txtPan').value;
            var regex = /[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}$/;

            if (regex.test(panValue)) {
                alert('123');
                return true;
            } else {
                document.getElementById('validatepan').style.display = 'block';
                document.getElementById('validatepan').innerText = 'Please enter proper pancard';
                return false;
            }

        }



        $(function () {
            $("#ContentPlaceHolder1_txtDob").datepicker({
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
        });

    </script>

    <style>
        .dobcss {
            width: 85%;
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

        .newformcontrol {
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
                        <h3 class="page-title">PROFILE</h3>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active">My Profile</li>
                        </ul>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">

                        <div class="card">

                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm">
                                        <form class="needs-validation">
                                            <div class="row">

                                                <div class="col-md-4 mb-3">
                                                    <label for="FirstName">Username</label>
                                                    <asp:TextBox CssClass="newformcontrol" runat="server" ID="txtUsername" placeholder="User Name" ReadOnly="true"></asp:TextBox>

                                                </div>
                                                <div class="col-md-4 mb-3">
                                                    <label for="FirstName">First Name</label>
                                                    <asp:TextBox CssClass="newformcontrol" onkeypress="return onlyAlphabets(event,this);" runat="server" ID="txtFname" placeholder="First Name"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        ControlToValidate="txtFname"
                                                        ErrorMessage="Enter Name Please!!"
                                                        ValidationGroup="profileGroup"
                                                        Display="Dynamic"
                                                        ForeColor="Red">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 mb-3">
                                                    <label for="Lastname">Last Name</label>
                                                    <asp:TextBox CssClass="newformcontrol" onkeypress="return onlyAlphabets(event,this);" runat="server" ID="txtLname" placeholder="Last Name"></asp:TextBox>
                                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                        ControlToValidate="txtLname"
                                                        ErrorMessage="Enter Name Please!!"
                                                        ValidationGroup="profileGroup"
                                                        Display="Dynamic"
                                                        ForeColor="Red">
                                                    </asp:RequiredFieldValidator>--%>
                                                </div>


                                            </div>
                                            <div class="row">
                                                <div class="col-md-4 mb-3">
                                                    <label for="Mobile">Mobile Number</label>
                                                    <asp:TextBox onkeypress="return isNumberKey(event)" ReadOnly="true" CssClass="newformcontrol" runat="server" ID="txtPhone" placeholder="Mobile Number" MaxLength="10"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                        ControlToValidate="txtPhone"
                                                        ErrorMessage="Enter Valid Number!!"
                                                        ValidationGroup="profileGroup"
                                                        Display="Dynamic"
                                                        ForeColor="Red">
                                                    </asp:RequiredFieldValidator>
                                                </div>

                                                <div class="col-md-4 mb-3">
                                                    <label>Email ID</label>
                                                    <asp:TextBox CssClass="newformcontrol keyup-email text-input" runat="server" ID="txtEmail" placeholder="Email ID"></asp:TextBox>
                                                </div>

                                                <div class="col-md-4 mb-3">
                                                    <label for="DateofBirth">Date oF Birth</label>
                                                    <div class="input-group">
                                                        <asp:TextBox CssClass="dobcss" runat="server" ID="txtDob" placeholder="Date of Birth"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row">


                                                <div class="col-md-4 mb-3">
                                                    <label for="status">Status:</label>
                                                    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="newformcontrol"  ReadOnly="true" style="height: 40px;">
                                                        <asp:ListItem Value="0">-Select Status-</asp:ListItem>
                                                        <asp:ListItem Value="1">active</asp:ListItem>
                                                        <asp:ListItem Value="2">deactive</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                        ControlToValidate="ddlstatus"
                                                        ErrorMessage="Select Field!!"
                                                        ValidationGroup="profileGroup"
                                                        Display="Dynamic"
                                                        ForeColor="Red">
                                                    </asp:RequiredFieldValidator>

                                                </div>
                                                <div class="col-md-4 mb-3">
                                                    <label for="roles">Roles:</label>
                                                    <asp:DropDownList ID="ddlRoles" runat="server" CssClass="newformcontrol"  ReadOnly="true" style="height: 40px;">
                                                        <asp:ListItem Value="0">-Select Role-</asp:ListItem>
                                                        <asp:ListItem Value="1">admin</asp:ListItem>
                                                        <asp:ListItem Value="2">sub admin</asp:ListItem>
                                                        <asp:ListItem Value="3">user</asp:ListItem>


                                                    </asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                        ControlToValidate="ddlRoles"
                                                        ErrorMessage="Select Field!!"
                                                        ValidationGroup="profileGroup"
                                                        Display="Dynamic"
                                                        ForeColor="Red">
                                                    </asp:RequiredFieldValidator>

                                                </div>




                                                <div class="col-md-4 mb-3">
                                                    <label for="validationCustom01">Date of Joining</label>
                                                    <asp:TextBox CssClass="newformcontrol" runat="server" ID="txtDOJ" placeholder="Date of Joining"  ReadOnly="true"></asp:TextBox>

                                                </div>


                                            </div>

                                            <div class="row">
                                            </div>

                                            <div class="row">
                                                <div class="col-md-4 mb-3">
                                                    <label for="validationCustom01">Select State</label>
                                                    <asp:DropDownList ID="ddlStates" runat="server" CssClass="newformcontrol" style="height: 40px;"></asp:DropDownList>

                                                </div>

                                                <div class="col-md-4 mb-3">
                                                    <label for="validationCustom01">Address</label>
                                                    <asp:TextBox CssClass="newformcontrol" TextMode="MultiLine" runat="server" ID="txtAdd" placeholder="Enter Your Address"></asp:TextBox>

                                                </div>



                                            </div>


                                            <div>
                                                <asp:Button ID="Button1" runat="server" Text="Update" ValidationGroup="profileGroup" class="btn btn-sm btn-rounded btn-success" OnClick="Button1_Click"  Style="border-radius: 5px !important; padding: 8px; font-size: 17px; font-weight: 800;" />
                                            </div>
                                        </form>
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
