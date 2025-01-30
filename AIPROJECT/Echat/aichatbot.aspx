<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="aichatbot.aspx.cs" Inherits="AI_Project.Echat.aichatbot" %>

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

        #chatContainer {
            overflow-y: auto;
            max-height: 300px; /* Adjust as needed */
        }

        .message {
            /* display: flex;*/
            align-items: flex-start;
            margin-bottom: 15px;
            word-wrap: break-word;
        }

            .message.user {
                justify-content: flex-end;
            }

        .avatar {
            width: 46px;
            height: 30px;
            background-color: #ccc;
            border-radius: 10%;
            margin-right: 10px;
            float: left;
            font-size: 15px;
            padding: 4px;
        }
            /* Avatar for User */
            .avatar.You:after {
                content: "You:";
            }

            /* Avatar for Bot */
            .avatar.Me:after {
                content: "Me:";
            }

        .text {
            padding: 15px;
            border-radius: 10px;
            background-color: #f0f0f0;
            font-size: 16px;
            line-height: 1.4;
            /*max-width: 70%;*/
            margin-bottom: 10px;
            text-align: center;
        }

        .inputContainer {
            display: flex;
            margin-top: 20px;
        }

        input[type="text"] {
            flex: 1;
            padding: 15px;
            border-radius: 30px;
            border: 1px solid #ccc;
            font-size: 16px;
        }

        #sendMessage {
            padding: 15px 25px;
            border: none;
            border-radius: 30px;
            background-color: #007bff;
            color: #fff;
            font-size: 16px;
            cursor: pointer;
        }

        #userInput {
            width: calc(100% - 120px); /* Adjust width to fit the container */
            height: 60px; /* Set the height */
            padding: 10px; /* Add padding */
            border: 1px solid #ccc; /* Add border */
            border-radius: 5px; /* Add border radius */
            resize: none; /* Disable textarea resizing */
            font-size: 16px; /* Set font size */
            font-family: Arial, sans-serif; /* Set font family */
            margin-right: 10px; /* Adjust margins */
        }

        /* CSS styles for typewriter text */
        .typewriter-text {
            overflow: hidden; /* Hide overflow characters */
            border-right: .15em solid orange; /* Cursor effect */
            white-space: nowrap; /* Keep text in one line */
            margin: 0 auto; /* Center text */
            letter-spacing: .15em; /* Spacing between characters */
            animation: typing 3.5s steps(40, end), blink-caret .75s step-end infinite; /* Typing animation */
        }

        /* Animation keyframes */
        @keyframes typing {
            from {
                width: 0;
            }

            to {
                width: 100%;
            }
        }

        @keyframes blink-caret {
            from, to {
                border-color: transparent;
            }

            50% {
                border-color: orange;
            }
        }

        #loader {
            position: fixed;
            z-index: 9999;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(255, 255, 255, 0.5);
            text-align: center;
            padding-top: 20%;
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
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <!-- Add ScriptManager -->
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>

                                    <div class="card-body">
                                        <div class="" style="font-size: 23px; font-weight: 800;">
                                            <center>
                                                <span class="text-muted text-center text-sm-left">Welcome to AI Chat Tutor</span>
                                                <br />
                                                <%--<p style="font-size: 16px;">Test your skills with a quiz.</p>--%>
                                            </center>

                                            <div id="chatContainer" runat="server">
                                                <div class="message user">
                                                    <!-- <div class="avatar"></div>
                                            <div class="text">Hello!</div>-->
                                                </div>
                                                <div class="message bot">
                                                    <!--<div class="avatar"></div>-->
                                                    <div class="text">Hi there! How can I help you?</div>
                                                </div>
                                            </div>
                                            <div class="inputContainer">


                                                <textarea id="userInput" placeholder="Type your message..." runat="server"></textarea>


                                                <%--<asp:TextBox runat="server" ID="userInput" placeholder="Type your message..."></asp:TextBox>--%>
                                                <%-- <input type="text" id="userInput" placeholder="Type your message..." runat="server" />--%>

                                                <asp:Button ID="sendMessage" Text="Submit" runat="server" OnClientClick="return SendMessagefunc();" OnClick="SendMessage_Click" /><br />
                                                <%--<button type="button" id="sendMessage" onclick="SendMessage()">Send</button>--%>
                                            </div>
                                            <div>
                                                <asp:Label runat="server" ID="lblerror" ForeColor="Red" Style="font-size: 19px; color: Red; font-weight: 600;"></asp:Label>
                                            </div>



                                        </div>
                                    </div>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="sendMessage" EventName="Click" />
                                    
                                </Triggers>
                            </asp:UpdatePanel>
                            <div id="loader" style="display: none;">
                                <!-- Loader HTML -->
                                <img src="image/loder.gif" alt="Loading..." style="height: 50%;" /><p>Loading...</p>

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

            function showLoader() {

                document.getElementById("loader").style.display = "block";
            }

            function hideLoader() {

                document.getElementById("loader").style.display = "none";
            }

            function SendMessagefunc() {

                document.getElementById('lblerror').innerText = "";

                let username = document.getElementById('userInput').value;
                if (username == "") {
                    document.getElementById('lblerror').innerText = "Please enter your query";
                    return false;
                }

                showLoader();
                return true;
                <%--var userInput = document.getElementById('<%= userInput.ClientID %>').value;
                var chatContainer = document.getElementById('<%= chatContainer.ClientID %>');


                // Append user message to chat container
                chatContainer.innerHTML += '<div class="message"><div class="avatar"></div><div class="userMessage" style="font-size: 18px;font-weight: 100;">' + userInput + '</div></div>';

                // Clear input field
               // document.getElementById('<%= userInput.ClientID %>').value = '';

                // Scroll to bottom of chat container
                chatContainer.scrollTop = chatContainer.scrollHeight;--%>
            }


            // JavaScript code to simulate typewriter typing effect and scroll to bottom
            //function displayTypewriterText(text) {
            //    const element = document.getElementById('response');
            //    let delay = 100; // Delay between each character (milliseconds)
            //    let index = 0;

            //    function type() {
            //        if (index < text.length) {
            //            element.textContent += text.charAt(index);
            //            index++;
            //            setTimeout(type, delay);
            //        } else {
            //            // Scroll to bottom after typing is complete
            //            const chatContainer = document.getElementById('chatContainer');
            //            chatContainer.scrollTop = chatContainer.scrollHeight;
            //        }
            //    }


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
