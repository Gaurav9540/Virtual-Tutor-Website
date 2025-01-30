using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Web.Services;
using System.Drawing.Drawing2D;
using System.Threading;
using Microsoft.Ajax.Utilities;
using System.Resources;
using System.Diagnostics;
using System.Net;
//using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace AI_Project.Echat
{
    public partial class aichatbot : Page
    {
        string CS = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
       // private static readonly HttpClient httpClient = new HttpClient();
        string parameterValueOfnameid = "";
        string parameterValueOfLevel = "";
        string parameterValueOfMob = "";
        string SelectedAnswer = "", correctans = "";
        public static string queryStrValue = "", questionID = "";
        List<string> quesList = new List<string>();
        List<string> code = new List<string>();
        int quesno = 0; int[] a = new int[15];
        int t;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadChatHistory();
                parameterValueOfnameid = HttpContext.Current.Request.QueryString["nameid"];
                parameterValueOfLevel = HttpContext.Current.Request.QueryString["level"];
                parameterValueOfMob = HttpContext.Current.Request.QueryString["mob"];


                // Check if the parameter exists
                if (!string.IsNullOrEmpty(parameterValueOfnameid) && !string.IsNullOrEmpty(parameterValueOfLevel) && !string.IsNullOrEmpty(parameterValueOfMob))
                {
                    //lblShowName.Text = parameterValueOfnameid.ToUpper();
                    Session["parameterValueOfnameid"] = parameterValueOfnameid;
                    Session["parameterValueOfLevel"] = parameterValueOfLevel;
                    Session["parameterValueOfMob"] = parameterValueOfMob;

                }
                else
                {
                    Response.Redirect("~/loginPage/login.aspx");
                }
            }
        }

        protected void btnAichattutor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Echat/aichatbot.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());

        }
        static string GenerateRandomNumbers()
        {
            string getrandom = "";
            Random random = new Random();

            while (true)
            {
                // Get current date and time
                DateTime now = DateTime.Now;

                // Format the date and time
                string formattedDate = now.ToString("HHmmssfff");

                // Generate a random number between 0 and 99999
                int randomNumber = random.Next(100000);

                // Append the random number to the formatted date and time
                string uniqueNumber = "EXAM" + formattedDate + randomNumber.ToString("D5");

                // Sleep for 1 second
                Thread.Sleep(1000);
                getrandom = uniqueNumber;

                // Break the loop and return the generated random number
                break;
            }

            return getrandom;
        }
        protected void dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard/Dashboard.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginPage/login.aspx");
        }
        protected void btnQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/quiz/exam.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());

        }


        
        private void LoadChatHistory()
        {
            List<ChatMessage> chatHistory = Session["ChatHistory"] as List<ChatMessage>;
            if (chatHistory != null)
            {
                foreach (ChatMessage message in chatHistory)
                {
                    AddMessageToChat(message.Text, message.Sender);
                }
            }
        }
        private void AddMessageToChat(string message, string sender)
        {
            // Determine avatar class based on the message sender
            string avatarClass = sender == "user" ? "You" : "Me";

            // Add message to chat container with appropriate styling and avatar
            chatContainer.InnerHtml += "<div class='message'><div class='avatar " + avatarClass + "'></div><div  style=\"font-size: 18px;font-weight: 100;\" class='" + sender + "Message'>" + message + "</div></div>";
        }

        private void SaveMessageToChatHistory(string message, string sender)
        {
            // Retrieve chat history from session or create new list
            List<ChatMessage> chatHistory = Session["ChatHistory"] as List<ChatMessage>;
            if (chatHistory == null)
            {
                chatHistory = new List<ChatMessage>();
            }

            // Add new message to chat history
            chatHistory.Add(new ChatMessage { Text = message, Sender = sender });

            // Save updated chat history back to session
            Session["ChatHistory"] = chatHistory;
        }
        protected void SendMessage_Click(object sender, EventArgs e)
        {

            // displaychat();

            // Access the user input text from the input field
            string userInputText = this.userInput.Value;

            // Add user message with avatar to chat container
            AddMessageToChat(userInputText, "user");

            // Save user message to chat history
            SaveMessageToChatHistory(userInputText, "user");

            // Call API to generate bot response
            string botResponse = CallApiFromDatabase(userInputText);

            // Process user input and generate bot response
            // string botResponse = GenerateBotResponse(userInputText);

            // Add bot response with avatar to chat container
            AddMessageToChat(botResponse, "bot");

            // Add bot response with typewriter effect
            // DisplayBotResponseWithTypewriter(botResponse);

            // Save bot response to chat history
            SaveMessageToChatHistory(botResponse, "bot");

            // Clear user input
            this.userInput.Value = "";

            // Scroll to bottom of chat container

            ScriptManager.RegisterStartupScript(this, GetType(), "scrollScript", "document.getElementById('" + chatContainer.ClientID + "').scrollTop = document.getElementById('" + chatContainer.ClientID + "').scrollHeight;", true);

            ScriptManager.RegisterStartupScript(this, GetType(), "hideLoaderScript", "hideLoader();", true);


        }
        // Method to display bot response with typewriter effect
        private void DisplayBotResponseWithTypewriter(string botResponse)
        {
            // Add bot response with avatar to chat container
            AddMessageToChat("...", "bot"); // Displaying initial dots before response

            // Execute JavaScript function to simulate typewriter typing effect
            string script = "<script>displayTypewriterText('" + botResponse + "');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "typewriterScript", script);
        }

        public string CallApiFromDatabase(string inputUser)
        {
            // Session["parameterValueOfnameid"] = parameterValueOfnameid;
            //Session["parameterValueOfLevel"] = parameterValueOfLevel;
            //Session["parameterValueOfMob"] = parameterValueOfMob;
            insertData(Session["parameterValueOfnameid"].ToString(), Session["parameterValueOfMob"].ToString());
            string getContent = "";
            string userInputValue = inputUser.ToLower();
            if (userInputValue.Contains("hello") || userInputValue.Contains("helo") || userInputValue.Contains("hi") || userInputValue.Contains("hii") || userInputValue.Contains("hey"))
            {
                getContent = "Hello! How can I assist you today?";
            }
            else if (userInputValue.Contains("what is your name") || userInputValue.Contains("name"))
            {
                getContent = "I'm an AI developed by student of BTech, so I don't have a personal name like humans do. You can just call me AI Chat Tutor! How can I help you?";
            }
            else if (userInputValue.Contains("happy") || userInputValue.Contains("sad"))
            {
                getContent = "As an AI I don't have emotions like humans do, so I can't feel happy, sad or any other emotion. However , I'm here to assist you with chat and hopefully help in anyway I can.";
            }
            else
            {
                getContent = getData(userInputValue);
                //  getContent = "I'm sorry, I couldn't generate a response for your input. Please try again later or ask something else, your query should be between 6th class to 10th class for CBSE board only.";
            }
            return getContent;
        }
        private string GenerateBotResponse(string userInput)
        {
            // Implement method to generate bot response based on user input
            // For demonstration purposes, let's return a static response
            return "Here is the information you requested.";
        }

        // Define a class to represent a chat message
        private class ChatMessage
        {
            public string Text { get; set; }
            public string Sender { get; set; }
        }

        public string getData(string searchTerm)
        {
            string getdata = "";

            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_aitutor";
            sqlcon.Open();
            string searchpersonname = "";
            string searchpersonmobile = "";
            string searchterm = searchTerm.ToString();
            try
            {

                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "getdata");
                com.Parameters.AddWithValue("@aitutorName", "");
                com.Parameters.AddWithValue("@aitutorMobile", "");
                com.Parameters.AddWithValue("@aitutorCreatedDate", "");
                com.Parameters.AddWithValue("@aitutorSearchQuestion", searchterm.Trim());

                using (SqlDataReader reader = com.ExecuteReader())
                {
                    List<string> mobileNumbers = new List<string>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string getdatafromdb = reader["getSearchData"].ToString(); // Replace MobileNumberColumn with actual column name
                            getdata = getdatafromdb;
                        }

                    }
                    else
                    {
                        getdata = "I'm sorry, I couldn't generate a response for your input. Please try again later or ask something else.";
                    }

                }
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                getdata = "I'm sorry, I couldn't generate a response for your input. Please try again later or ask something else.";
                sqlcon.Close();
            }
            finally
            {
                sqlcon.Close();
            }


            return getdata;

        }
        public void insertData(string searchpersonname, string searchpersonmobile)
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_aitutor";
            sqlcon.Open();

            string searchterm = "";
            try
            {

                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "insert");
                com.Parameters.AddWithValue("@aitutorName", searchpersonname.ToString());
                com.Parameters.AddWithValue("@aitutorMobile", searchpersonmobile.ToString());
                com.Parameters.AddWithValue("@aitutorCreatedDate", "");
                com.Parameters.AddWithValue("@aitutorSearchQuestion", searchterm.Trim());

                //Response.Write(DateTime.Now.ToString("yyyy-MM-dd").Trim());

                int i = com.ExecuteNonQuery();
                if (i != 0)
                {

                    //  ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Inserted sucessfully');", true);

                }
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                sqlcon.Close();
            }
            finally
            {
                sqlcon.Close();
            }
        }

    }
}