<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="exam.aspx.cs" Inherits="AI_Project.quiz.exam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>AI E-Tutor</title>
    <link rel="stylesheet" href="vendors/typicons/typicons.css" />
    <link rel="stylesheet" href="vendors/css/vendor.bundle.base.css" />
    <link rel="stylesheet" href="css/vertical-layout-light/style.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <style>
.blink_me {
  animation: blinker 1s linear infinite;
}

@keyframes blinker {  
  50% { opacity: 2; }
}
paracapitalize
{
	text-transform:capitalize;
}

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

        .video-box {
            width: 140px; /* Adjust width as needed */
            height: 100px; /* Adjust height as needed */
            border: 1px solid #ccc;
            padding: 10px;
        }

            .video-box a {
                text-decoration: none;
                color: #333;
            }

            .video-box:hover {
                background-color: #f9f9f9;
            }

        .float {
            padding: 10px;
            position: fixed;
            /*width: 130px;*/
            height: 40px;
            bottom: 140px;
            right: 15px;
            background-color: #844fc1;
            color: #FFF;
            border-radius: 5px;
            text-align: center;
            font-size: 21px;
            font-weight: 700;
            z-index: 9999999999;
        }

        .float1 {
            padding: 10px;
            position: fixed;
            /*width: 130px;*/
            height: 40px;
            bottom: 90px;
            right: 15px;
            background-color: #844fc1;
            color: #FFF;
            border-radius: 5px;
            text-align: center;
            font-size: 21px;
            font-weight: 700;
            z-index: 9999999999;
        }

        .my-float {
            margin-top: 16px;
        }

        .blink_me {
            animation: blinker 1s linear infinite;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }
    </style>


</head>

<body style="background: white;">


    <form runat="server">
        <asp:Button ID="btnAichattutor" runat="server" CssClass="float" Text="AI Chat Tutor" OnClick="btnAichattutor_Click" />

        <asp:Button ID="btnQuiz" runat="server" CssClass="float1" Text="Quiz" OnClick="btnQuiz_Click" />

        <div class="container-scroller">
            <!-- partial:partials/_navbar.html -->
            <nav class="navbar col-lg-12 col-12 p-0 fixed-top d-flex flex-row">
                <div class="navbar-brand-wrapper d-flex justify-content-center">
                    <div class="navbar-brand-inner-wrapper d-flex justify-content-between align-items-center w-100">
                        <a class="navbar-brand brand-logo" href="index.html"><span style="font-size: 20px; color: white; font-weight: 800">AI E-Tutor</span></a>
                        <a class="navbar-brand brand-logo-mini" href="index.html">
                            <img src="images/logo-mini.svg" alt="logo" /></a>

                    </div>
                </div>
                <div class="navbar-menu-wrapper d-flex align-items-center justify-content-end">
                    <ul class="navbar-nav mr-lg-2">

                        <label class="form-check-label" style="padding: 28px; font-size: 23px; font-weight: 800;">
                            WELCOME 
                           <asp:Label runat="server" ID="lblShowName"></asp:Label>
                        </label>
                        <p style="padding-top: 17px;">
                            <asp:Button ID="btnDashboard" runat="server" class="btn btn-danger btn-rounded mt-1" Text="Go To Dashboard" OnClick="dashboard_Click" />
                            <asp:Button ID="btnLogout" Text="Logout" runat="server" class="btn btn-danger btn-rounded mt-1" Style="margin-left: 10px;" OnClick="btnLogout_Click" />
                        </p>
                    </ul>


                </div>

                <marquee style="font-size: 25px; font-weight: 700; color: #2b0b50; background: #fad75f; border-top: 4px solid #844fc1;">
                    Get personalized learning experiences! Start your learning today with e-tutor !
        Explore the e-learning material and get succed in all your academic assignment</marquee>
            </nav>
            <!-- partial -->

            <div class="container page-body-wrapper" style="background: white; display: block; padding-top: 130px;">

                <div id="mainPage" style="display: block;">

                    <footer class="footer" style="background: white;">
                        <div class="card">
                            <div class="card-body">
                                <div class="" style="font-size: 23px; font-weight: 800;">
                                    <center>
                                        <span class="text-muted text-center text-sm-left">Welcome to Quiz Master</span>
                                        <br />
                                        <p style="font-size: 16px;">Test your skills with a quiz.</p>

                                    </center>

                                    <div runat="server" id="formArea" visible="true">

                                        <form class="needs-validation">
                                            <div class="row">
                                                <div class="col-md-4" style="margin-bottom: 1rem !important">
                                                    <label for="role" style="font-size: 18px; margin-bottom: 0px;">Select Class*: </label>

                                                    <asp:DropDownList ID="ddlclass" runat="server" CssClass="dobcss">
                                                        <asp:ListItem Value="0">-Select Class-</asp:ListItem>
                                                        <asp:ListItem Value="1">Class V</asp:ListItem>
                                                        <asp:ListItem Value="2">Class VI</asp:ListItem>
                                                        <asp:ListItem Value="3">Class VII</asp:ListItem>
                                                        <asp:ListItem Value="4">Class VIII</asp:ListItem>
                                                        <asp:ListItem Value="5">Class IX</asp:ListItem>
                                                        <asp:ListItem Value="6">Class X</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvClass" Style="font-size: 15px;"
                                                        ControlToValidate="ddlclass"
                                                        ErrorMessage="Select Class"
                                                        ValidationGroup="attendance" InitialValue="0"
                                                        Display="Dynamic"
                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4" style="margin-bottom: 1rem !important">
                                                    <label for="role" style="font-size: 18px; margin-bottom: 0px;">Select Subject*: </label>

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
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvSubject" Style="font-size: 15px;"
                                                        ControlToValidate="ddlsubject"
                                                        ErrorMessage="Select Subject"
                                                        ValidationGroup="attendance" InitialValue="0"
                                                        Display="Dynamic"
                                                        ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-md-12 mb-3">

                                                    <asp:Button ID="addcontent" runat="server" Text="Submit" ValidationGroup="attendance" class="btn btn-sm btn-rounded btn-success" Style="border-radius: 5px !important; padding: 8px; font-size: 17px; font-weight: 800;"
                                                        OnClick="addcontent_Click" />
                                                </div>
                                            </div>
                                            <div class="row">
    <div class="col-md-12 mb-3">

         <asp:Label runat="server" ID="lblmessage" Text="" Visible="false" ForeColor="red"></asp:Label>
    </div>
</div>
                                            <div class="row">
                                                <div class="col-md-12 mb-3">
                                                    <p style="font-size: 16px;">If you don't know, we suggest that you read our Tutorial from scratch.</p>
                                                </div>
                                            </div>
                                        </form>
                                    </div>


                                    <div class="container containerOuter" style="text-align: left;" id="rules" runat="server" visible="false">
                                        <div runat="server" id="ExamPage1" style="display: ''">


                                            <div style="margin-bottom: 10px;">
                                                <p>
                                                    Rules & Regulations
                                                </p>
                                                <ul>
                                                    <li>Total 30 marks question will appear.</li>
                                                    <li>Per question you will get 30 seconds to solve and 1 marks for each question.</li>
                                                    <li>If time finished for single question, you will automatically move to next question.</li>
                                                    <li>Click the below start button to start your exam,"BEST OF LUCK"</li>
                                                </ul>
                                            </div>
                                            <div style="text-align: center;">
                                                <asp:Button ID="btnsubmit" Text="Start" runat="server" CssClass="btn btn-success"
                                                    OnClick="btnsubmitrules_Click" />

                                            </div>
                                        </div>

                                    </div>

                                    <div class="container containerOuter" runat="server" id="examquestion" visible="false">
                                        <div runat="server" id="Div1">
                                            <asp:HiddenField runat="server" ID="hdfRdbValue" />

                                            <div class="inline" style="margin-bottom: 10px; float: left;color:#cc11cc">
  Subject:   <asp:Label runat="server" ID="lblShowSubject" Text=""></asp:Label>
</div>
<div class="inline" style="float: Right; margin-bottom: 10px;color:#cc11cc">
   Class:  <asp:Label runat="server" ID="lblShowClass" Text="">
       </asp:Label>
</div><br />
                                            <br />

                                            <div class="inline" style="margin-bottom: 10px; float: left">
                                                <asp:Label runat="server" ID="lblMarks" Text="Marks: 30"></asp:Label>
                                            </div>
                                            <div class="inline" style="float: Right; margin-bottom: 10px;">
                                                <asp:Label runat="server" ID="lblTime"><span>Left Time : </span>
                                                    <p class="blink_me" style="display: inline;z-index: 9999999999;border-radius: 50%;font-size: 23px; padding:10px;background: yellow;"><span runat="server" id="time"></span></p> Second</asp:Label>
                                            </div>
                                            <table id="tblquestion" cellpadding="7" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblQno"></asp:Label>.<asp:Label runat="server" ID="lblQuestion"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:RadioButton ID="rdbOpt1" runat="server" onclick="rdbSelection(1)" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:RadioButton ID="rdbOpt2" runat="server" onclick="rdbSelection(2)" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:RadioButton ID="rdbOpt3" runat="server" onclick="rdbSelection(3)" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:RadioButton ID="rdbOpt4" runat="server" onclick="rdbSelection(4)" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                      <center> <asp:Button ID="Button1" CssClass="btn btn-success" Text="Submit" runat="server" OnClick="btnsubmitNext_Click" /></center> 
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div runat="server" id="examend" runat="server" visible="false">
                                            Congratulation You have Finished With Your Exam, Now You can View Your Result in your dashboard.
                                            <br />
                                             <asp:Button ID="Button2" runat="server" class="btn btn-danger btn-rounded mt-1" Text="Go To Dashboard" OnClick="dashboard_Click" />
                                        </div>
                                    </div>




                                </div>
                            </div>
                        </div>
                    </footer>




                </div>



            </div>



            <!-- main-panel ends -->
        </div>
        <!-- page-body-wrapper ends -->
        </div>
  <!-- container-scroller -->

        <script type="text/javascript">
            function startTimer(duration, display) {
                var timer = duration, minutes, seconds;
                setInterval(function () {
                    minutes = parseInt(timer / 60, 10)
                    seconds = parseInt(timer % 60, 10);

                    minutes = minutes < 10 ? "0" + minutes : minutes;
                    seconds = seconds < 10 ? "0" + seconds : seconds;

                    display.textContent = minutes + ":" + seconds;

                    if (--timer < 0) {
                        timer = duration;
                    }
                }, 1000);
            }


            window.onload = function () {
                var duration = 30, // Set the duration to 30 seconds
                    display = document.querySelector('#<%= time.ClientID %>');
                startTimer(duration, display);

                setTimeout(function () {
                    document.getElementById('Button1').click();
                }, duration * 1000); // Click the button after the specified duration in milliseconds
            };

            $(document).ready(function () {

                document.getElementById('<%= rdbOpt1.ClientID %>').checked = false;
                document.getElementById('<%= rdbOpt2.ClientID %>').checked = false;
                document.getElementById('<%= rdbOpt3.ClientID %>').checked = false;
                document.getElementById('<%= rdbOpt4.ClientID %>').checked = false;

            });

            function validation() {
                var spanTimeValue = document.getElementById('<%= time.ClientID %>').innerHTML;
                // alert("html" + spanTimeValue);

                var rdb1 = $('#<%= rdbOpt1.ClientID %>').is(':checked');
                var rdb2 = $('#<%= rdbOpt2.ClientID %>').is(':checked');
                var rdb3 = $('#<%= rdbOpt3.ClientID %>').is(':checked');
                var rdb4 = $('#<%= rdbOpt4.ClientID %>').is(':checked');
                if (spanTimeValue == "00:01") {

                }
                else {
                    if (rdb1 == false && rdb2 == false && rdb3 == false && rdb4 == false) {
                        //alert("Please Select one option");
                        return false;
                    }
                }

            }

            function rdbSelection(id) {
                var rdbValue = "";
                if (id == 1) {
                    rdbValue = document.getElementById('<%= rdbOpt1.ClientID %>').value;
                    document.getElementById('<%= rdbOpt1.ClientID %>').checked = true;
                    document.getElementById('<%= rdbOpt2.ClientID %>').checked = false;
                    document.getElementById('<%= rdbOpt3.ClientID %>').checked = false;
                    document.getElementById('<%= rdbOpt4.ClientID %>').checked = false;
                }
                if (id == 2) {
                    rdbValue = document.getElementById('<%= rdbOpt2.ClientID %>').value;
                    document.getElementById('<%= rdbOpt1.ClientID %>').checked = false;
                    document.getElementById('<%= rdbOpt2.ClientID %>').checked = true;
                    document.getElementById('<%= rdbOpt3.ClientID %>').checked = false;
                    document.getElementById('<%= rdbOpt4.ClientID %>').checked = false;
                }
                if (id == 3) {
                    rdbValue = document.getElementById('<%= rdbOpt3.ClientID %>').value;
                    document.getElementById('<%= rdbOpt1.ClientID %>').checked = false;
                    document.getElementById('<%= rdbOpt2.ClientID %>').checked = false;
                    document.getElementById('<%= rdbOpt3.ClientID %>').checked = true;
                    document.getElementById('<%= rdbOpt4.ClientID %>').checked = false;
                }
                if (id == 4) {

                //    alert($('#<%= rdbOpt4.ClientID %>').val());
                    document.getElementById('<%= rdbOpt1.ClientID %>').checked = false;
                    document.getElementById('<%= rdbOpt2.ClientID %>').checked = false;
                    document.getElementById('<%= rdbOpt3.ClientID %>').checked = false;
                    document.getElementById('<%= rdbOpt4.ClientID %>').checked = true;
                }
            //  alert(document.getElementById('<%= hdfRdbValue.ClientID %>').value = rdbValue);

            }
        </script>


        <!-- base:js -->
        <script src="vendors/js/vendor.bundle.base.js"></script>
        <!-- endinject -->
        <!-- Plugin js for this page-->
        <script src="vendors/chart.js/Chart.min.js"></script>
        <!-- End plugin js for this page-->
        <!-- inject:js -->
        <script src="js/off-canvas.js"></script>
        <script src="js/hoverable-collapse.js"></script>
        <script src="js/template.js"></script>
        <script src="js/settings.js"></script>
        <script src="js/todolist.js"></script>
        <!-- endinject -->
        <!-- Custom js for this page-->
        <script src="js/dashboard.js"></script>
        <!-- End custom js for this page-->
    </form>
</body>

</html>
