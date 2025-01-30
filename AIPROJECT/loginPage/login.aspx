<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AI_Project.loginPage.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />

    <link rel="stylesheet" href="style.css" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body style="background-image: url('images/slide3.jpg'); background-repeat: no-repeat; width: 100%; background-size: cover;">
    <div style="padding: 25px 16px; box-shadow: 0 5px 10px rgba(0,0,0,0.2); font-size: 30px; font-weight: 800; text-align: center; color: white;">
        <p>Welcome to AI Assitance</p>
        <p style="font-size: 17px;">Your Complete Study Search Ends Here</p>
    </div>
    <div class="container classDiv" style="float: inline-end;">

        <input type="checkbox" id="flip">

        <div class="cover">
            <div class="front">
                <img src="images/aiImage.png" alt="">
                <div class="text">
                    <span class="wordcontainer textword">Your complete solution is with
                        <br>
                        AI Tutor Assitance</span><br>
                    <span class="text-2">Let's get connected</span>

                </div>
            </div>
            <div class="back">
                <img class="backImg" src="images/aiImage.png" alt="">
                <div class="text">
                    <span class="text-1">Complete miles of journey
                        <br>
                        with one step</span>
                    <span class="text-2">Let's get started</span>
                </div>
            </div>
        </div>
        <form runat="server">
            <div class="forms">
                <div class="form-content">
                    <div class="login-form">
                        <div class="title">Login</div>

                        <div class="input-boxes">
                            <div class="input-box">
                                <i class="fas fa-envelope"></i>
                                <asp:TextBox runat="server" ID="txtUsername" CssClass="alpha-only" placeholder="Enter your username"></asp:TextBox>

                            </div>
                            <div>
                                <asp:Label runat="server" ID="lblErrUserMsg" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="input-box">
                                <i class="fas fa-lock"></i>

                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
                            </div>

                            <div>
                                <asp:Label runat="server" ID="lblErrPassMsg" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="button input-box">

                                <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClientClick="return validation();" OnClick="btnSubmit_Click" />
                            </div>
                            <div class="text sign-up-text">
                                Don't have an account?
                                    <label for="flip">Sigup now</label>
                            </div>
                        </div>

                    </div>
                    <div class="signup-form">
                        <div class="title">Signup</div>

                        <div class="input-boxes">
                            <div class="input-box">
                                <i class="fas fa-user"></i>
                                <asp:TextBox runat="server" ID="txtFullName" placeholder="Enter full your name*" CssClass="alpha-only"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label runat="server" ID="errlblFullName" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="input-box">
                                <i class="fas fa-envelope"></i>
                                <asp:TextBox runat="server" ID="txtMobile" MaxLength="10" CssClass="number-only" placeholder="Enter your mobile number*" oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label runat="server" ID="errlblMobile" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="input-box">
                                <i class="fas fa-lock"></i>
                                <asp:TextBox runat="server" ID="txtUsernameVal" placeholder="Enter your username*"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label runat="server" ID="errlblUsernameVal" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="input-box">
                                <i class="fas fa-lock"></i>
                                <asp:TextBox runat="server" ID="txtPaswordVal" TextMode="Password" placeholder="Enter your password*"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label runat="server" ID="errlblPasswordVal" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="button input-box">
                                <asp:Button ID="Button1" Text="Submit" runat="server" OnClientClick="return signUpValidation();" OnClick="btnSubmitSignUp_Click" />


                            </div>
                            <div class="text sign-up-text">
                                Already have an account?
                                    <label for="flip">Login now</label>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
<script>

    $('.alpha-only').bind('keyup blur', function () {
        $(this).val($(this).val().replace(/[^A-Za-z_\s]/, ''));
    }
    );
    $('.number-only').bind('keyup blur', function () {
        $(this).val($(this).val().replace(/[^0-9\+\s\-\()]/, ''));
    }
    );


    function validation() {
        document.getElementById('lblErrUserMsg').innerText = "";
        document.getElementById('lblErrPassMsg').innerText = "";

        let username = document.getElementById('txtUsername').value;
        let password = document.getElementById('txtPassword').value;

        if (username != "" && password != "") {
            return true;
        }
        else {

            if (username == "") {
                document.getElementById('lblErrUserMsg').innerText = "Please enter username";
                return false;
            }
            if (password == "") {

                document.getElementById('lblErrPassMsg').innerText = "Please enter password";
                return false;
            }
        }

        return false;
    }

    function signUpValidation() {
        document.getElementById('errlblFullName').innerText = "";
        document.getElementById('errlblMobile').innerText = "";
        document.getElementById('errlblUsernameVal').innerText = "";
        document.getElementById('errlblPasswordVal').innerText = "";

        let txtFullName = document.getElementById('txtFullName').value;
        let txtMobile = document.getElementById('txtMobile').value;
        let txtUsernameVal = document.getElementById('txtUsernameVal').value;
        let txtPaswordVal = document.getElementById('txtPaswordVal').value;

        if (txtFullName != "" && txtMobile != "" && txtUsernameVal != "" && txtPaswordVal != "") {
            var mobileLen = txtMobile.length;
            if (mobileLen === 10) {
                return true;
            }
            else {
                document.getElementById('errlblMobile').innerText = "Please enter 10 digit mobile no";
                return false;
            }
        }
        else {
            if (txtFullName == "") {
                document.getElementById('errlblFullName').innerText = "Please enter fullname";
                return false;
            }
            if (txtMobile == "") {
                document.getElementById('errlblMobile').innerText = "Please enter mobile no";
                return false;
            }
            if (txtUsernameVal == "") {
                document.getElementById('errlblUsernameVal').innerText = "Please enter username";
                return false;
            }
            if (txtPaswordVal == "") {
                document.getElementById('errlblPasswordVal').innerText = "Please enter password";
                return false;
            }
        }

        return false;
    }
</script>
</html>
