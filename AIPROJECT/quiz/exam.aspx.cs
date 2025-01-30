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

namespace AI_Project.quiz
{
    public partial class exam : Page
    {
        string CS = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
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
                parameterValueOfnameid = HttpContext.Current.Request.QueryString["nameid"];
                parameterValueOfLevel = HttpContext.Current.Request.QueryString["level"];
                parameterValueOfMob = HttpContext.Current.Request.QueryString["mob"];

                Session["QuestionNUmber"]=null;
                // Check if the parameter exists
                if (!string.IsNullOrEmpty(parameterValueOfnameid) && !string.IsNullOrEmpty(parameterValueOfLevel) && !string.IsNullOrEmpty(parameterValueOfMob))
                {
                    lblShowName.Text = parameterValueOfnameid.ToUpper();
                    Session["parameterValueOfnameid"] = parameterValueOfnameid;
                    Session["parameterValueOfLevel"] = parameterValueOfLevel;
                    Session["parameterValueOfMob"] = parameterValueOfMob;
                    //lblShowName.Text = Security.Decryption(parameterValueOfnameid).ToUpper();
                    ScriptManager.RegisterStartupScript(this, GetType(), "secondPage2", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                    ScriptManager.RegisterStartupScript(this, GetType(), "mainPage2", "<script>document.getElementById('mainPage').style.display = 'block';</script>", false);
                    ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);

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

        protected void addcontent_Click(object sender, EventArgs e)
        {

            string getquestresult = getQuestionCode();
            if (getquestresult == "pass")
            {
                examquestion.Visible = false;
                formArea.Visible = false;
                rules.Visible = true;
            }
            else
            {
                lblmessage.Visible = true;
                lblmessage.Text = "No question is available right now, please try with other options";
                clear();
            }
        }

        public void clear()
        {
            // txtAttendanceDate.Text = "";
            ddlsubject.SelectedValue = ddlsubject.Items.FindByText("-Select Subject-").Value;
            ddlclass.SelectedValue = ddlclass.Items.FindByText("-Select Class-").Value;

        }

        /*public string getrandomQuescode()
        {
            List<string> columnValues = (List<string>)Session["columnValues"];

            // Check if columnValues is null or empty
            if (columnValues == null || columnValues.Count == 0)
            {
                return "No values available";
            }

            string[] columnArray = columnValues.ToArray();
            string getRandomCode = "";

            Random random = new Random();
            int numberOfRandomValues = 3;

            // Check if numberOfRandomValues is greater than the length of columnArray
            if (numberOfRandomValues > columnArray.Length)
            {
                return "numberOfRandomValues exceeds columnArray length";
            }

            List<string> randomValues = new List<string>();

            for (int i = 0; i < numberOfRandomValues; i++)
            {
                int randomIndex = random.Next(0, columnArray.Length);
                randomValues.Add(columnArray[randomIndex]);
            }

            // Here, you're only returning the last value, consider returning the list if you need all random values
            getRandomCode = randomValues.LastOrDefault();

            return getRandomCode;
        }*/
        public string getrandomQuescode()
        {
            // string[] columnArray = Session["columnValues"].ToArray();
            List<string> columnValues = (List<string>)Session["columnValues"];
            string[] columnArray = columnValues.ToArray();
            string getRandomCode = "";

            // Do something with the array...
            // Take random values from the array
            Random random = new Random();
            int numberOfRandomValues = 5; // Change this to the number of random values you want to take
            List<string> randomValues = new List<string>();

            for (int i = 0; i < numberOfRandomValues; i++)
            {
                int randomIndex = random.Next(0, columnArray.Length);
                randomValues.Add(columnArray[randomIndex]);
            }

            // Output the random values
            //Console.WriteLine("Random Values:");
            foreach (var value in randomValues)
            {
                //Console.WriteLine(value);
                getRandomCode = value;
            }
            return getRandomCode;

        }

        protected void btnsubmitrules_Click(object sender, EventArgs e)
        {
            // Response.Redirect("~/LoginPage/login.aspx");
            examquestion.Visible = true;
            formArea.Visible = false;
            rules.Visible = false;
            string getExamRandom = GenerateRandomNumbers();
            Session["getExamRandom"] = getExamRandom;
            insertResultData(getExamRandom);

            string getrandomcode = getrandomQuescode();
            getQuestionSet(getrandomcode);



            



        }

        public void insertResultData(string getExamRandom)
        {

            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_result";
            sqlcon.Open();
            string classvalue = "";
            if (ddlclass.SelectedItem.Text == "Class V")
            {
                classvalue = "fifth";
            }
            else if (ddlclass.SelectedItem.Text == "Class VI")
            {
                classvalue = "sixth";
            }
            else if (ddlclass.SelectedItem.Text == "Class VII")
            {
                classvalue = "seventh";
            }
            else if (ddlclass.SelectedItem.Text == "Class VIII")
            {
                classvalue = "eighth";
            }
            else if (ddlclass.SelectedItem.Text == "Class IX")
            {
                classvalue = "nineth";
            }
            else if (ddlclass.SelectedItem.Text == "Class X")
            {
                classvalue = "tenth";
            }
            try
            {

                lblShowClass.Text = ddlclass.SelectedItem.Text.Replace("Class","");
                lblShowSubject.Text = ddlsubject.SelectedItem.Text;
                string currentDateAsString = DateTime.Now.ToString("yyyy-MM-dd");

                //  Session["parameterValueOfnameid"] = parameterValueOfnameid;
                //Session["parameterValueOfLevel"] = parameterValueOfLevel;
                //Session["parameterValueOfMob"] = parameterValueOfMob;

                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "insert");
                com.Parameters.AddWithValue("@examcode", getExamRandom);
                com.Parameters.AddWithValue("@dateOfExam", currentDateAsString);
                com.Parameters.AddWithValue("@mobileNumber", Session["parameterValueOfMob"].ToString());
                com.Parameters.AddWithValue("@username", Session["parameterValueOfnameid"].ToString()); //Name Of User
                com.Parameters.AddWithValue("@Class", classvalue.ToString().Trim());
                com.Parameters.AddWithValue("@subject", ddlsubject.SelectedItem.Text.ToString().Trim());
                com.Parameters.AddWithValue("@attemptQuestion", "0");
                com.Parameters.AddWithValue("@correctAnswer", "0");
                com.Parameters.AddWithValue("@wrongAnswer", "0");
                com.Parameters.AddWithValue("@percentage", "0");
                com.Parameters.AddWithValue("@grade", "");
                com.Parameters.AddWithValue("@examDateTime", "");


                var columnValues = new List<string>();
                //   SqlDataReader reader = com.ExecuteReader();

                int i = com.ExecuteNonQuery();
                if (i != 0)
                {

                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Inserted sucessfully');", true);
                    Session["attemptQuestion"] = 1;
                   // clear();

                }


                sqlcon.Close();

            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
                sqlcon.Close();

            }
            finally
            {
                sqlcon.Close();
            }
        }



        public string getQuestionCode()
        {
            string result = "";
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_questionbank";
            sqlcon.Open();
            string classvalue = "";
            if (ddlclass.SelectedItem.Text == "Class V")
            {
                classvalue = "fifth";
            }
            else if (ddlclass.SelectedItem.Text == "Class VI")
            {
                classvalue = "sixth";
            }
            else if (ddlclass.SelectedItem.Text == "Class VII")
            {
                classvalue = "seventh";
            }
            else if (ddlclass.SelectedItem.Text == "Class VIII")
            {
                classvalue = "eighth";
            }
            else if (ddlclass.SelectedItem.Text == "Class IX")
            {
                classvalue = "nineth";
            }
            else if (ddlclass.SelectedItem.Text == "Class X")
            {
                classvalue = "tenth";
            }
            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "getexamcode");
                com.Parameters.AddWithValue("@QuesCode", "");
                com.Parameters.AddWithValue("@QuestName", "");
                com.Parameters.AddWithValue("@option1", "");
                com.Parameters.AddWithValue("@option2", "");
                com.Parameters.AddWithValue("@option3", "");
                com.Parameters.AddWithValue("@option4", "");
                com.Parameters.AddWithValue("@Correctanw", "");
                com.Parameters.AddWithValue("@Class", classvalue.ToString().Trim());
                com.Parameters.AddWithValue("@Subject", ddlsubject.SelectedItem.Text.ToString().Trim());
                com.Parameters.AddWithValue("@UpdatedDate", "");

                var columnValues = new List<string>();
                //   SqlDataReader reader = com.ExecuteReader();

                using (SqlDataReader reader = com.ExecuteReader())
                {
                    List<string> mobileNumbers = new List<string>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string QuesCode = reader["QuesCode"].ToString(); // Replace MobileNumberColumn with actual column name
                            columnValues.Add(reader.GetString(0));
                            result = "pass";
                        }
                        System.Web.HttpContext.Current.Session["columnValues"] = columnValues;
                    }
                    else
                    {
                        result = "fail";
                    }

                }





                sqlcon.Close();

            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
                sqlcon.Close();
                result = "fail";

            }
            finally
            {
                sqlcon.Close();
            }
            return result;
        }
        private List<string> List<T1>(object p)
        {
            throw new NotImplementedException();
        }

        protected void btnsubmitNext_Click(object sender, EventArgs e)
        {


            // Response.Write(resStr + "<br>");
            string getvalueqq = Session["QuestionNUmber"].ToString();
            //int getquesno = Convert.ToInt32(lblQno.Text);
            if (Convert.ToInt32(Session["QuestionNUmber"]) < 31)
            // if (getquesno < 4)
            {
                string getrandomcode = getrandomQuescode();
                if (rdbOpt1.Checked == true)
                {
                    SelectedAnswer = rdbOpt1.Text.ToString().Trim();
                }
                else if (rdbOpt2.Checked == true)
                {
                    SelectedAnswer = rdbOpt2.Text.ToString().Trim();
                }
                else if (rdbOpt3.Checked == true)
                {
                    SelectedAnswer = rdbOpt3.Text.ToString().Trim();
                }
                else if (rdbOpt4.Checked == true)
                {
                    SelectedAnswer = rdbOpt4.Text.ToString().Trim();
                }
                else
                {
                    SelectedAnswer = "InCorrectWrong";
                }
                //Response.Write(SelectedAnswer + "<br>" + "Correct:-" + Session["Correct"].ToString() + "<br>");
                if (SelectedAnswer == Session["Correct"].ToString())
                {
                    string marks = "correct";
                    updateExamMarks(marks);

                }
                else
                {
                    string marks = "incorrect";
                    updateExamMarks(marks);
                }
                 
                //questionID = getRandomNo();
                if (Convert.ToInt32(Session["QuestionNUmber"]) < 30)
                {
                    getQuestionSet(getrandomcode);
                }
                else
                {

                    Div1.Visible = false;
                    examend.Visible = true;
                    // ExamPage1.Attributes.Add("style", "display:none");
                    //examend.Attributes.Add("style", "display:block");
                    //Response.Redirect("Result.aspx?ID=" + queryStrValue.ToString());
                }


            }
            else
            {

                Div1.Visible = false;
                examend.Visible = true;
                // ExamPage1.Attributes.Add("style", "display:none");
                //examend.Attributes.Add("style", "display:block");
                //Response.Redirect("Result.aspx?ID=" + queryStrValue.ToString());
            }

        }


        public string getquestionno()
        {
            string getquestionno = "";

            SqlConnection con = new SqlConnection(CS);
            con.Open();
            SqlCommand com;
            SqlDataReader sdr;
            string sqlquery = "select attemptQuestion from tbl_result where examcode='" + Session["getExamRandom"].ToString() + "' ";

            try
            {
                com = new SqlCommand(sqlquery, con);
                sdr = com.ExecuteReader();
                while (sdr.Read())
                {

                    getquestionno = sdr["attemptQuestion"].ToString();


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                con.Close();
            }
            finally
            {
                con.Close();

            }
            return getquestionno;


        }

        public void updatequestionattempt(string quesAttemptNo)
        {
            string result = "";
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_result";
            sqlcon.Open();

            try
            {


                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "updateattemptQuestion");
                com.Parameters.AddWithValue("@examcode", Session["getExamRandom"].ToString());
                com.Parameters.AddWithValue("@dateOfExam", "");
                com.Parameters.AddWithValue("@mobileNumber", "");
                com.Parameters.AddWithValue("@username", ""); //Name Of User
                com.Parameters.AddWithValue("@Class", "");
                com.Parameters.AddWithValue("@subject", "");
                com.Parameters.AddWithValue("@attemptQuestion", quesAttemptNo);
                com.Parameters.AddWithValue("@correctAnswer", "");
                com.Parameters.AddWithValue("@wrongAnswer", "");
                com.Parameters.AddWithValue("@percentage", "");
                com.Parameters.AddWithValue("@grade", "");
                com.Parameters.AddWithValue("@examDateTime", "");

                int i = com.ExecuteNonQuery();
                if (i != 0)
                {

                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Inserted sucessfully');", true);
                    result = "pass";

                }


                sqlcon.Close();

            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
                result = "fail";
                sqlcon.Close();

            }
            finally
            {
                sqlcon.Close();
            }


        }
        public void getQuestionSet(string quesNo)
        {

            //string getexamquestionno = getquestionno();
            string output = "";
            string correctansNo = "";
            SqlConnection con = new SqlConnection(CS);
            con.Open();
            SqlCommand com;
            SqlDataReader sdr;
            string sqlquery = "select * from QuestionBank where QuesCode='" + quesNo.ToString().Trim() + "'";
            //string sqlquery = "select * from QuestionBank where QuesSrno='" + Session["QuestionNumber"].ToString().Trim() + "'";
            //string sqlquery = "select * from QuestionBank where QuesSrno='" + quesNo.ToString().Trim() + "' and examcode='" + Security.Decryption(Request.QueryString["code"].ToString().Trim()) + "'";
            try
            {
                com = new SqlCommand(sqlquery, con);
                sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    //quesno = quesno + 1;
                    //Session["QuestionNumber"] = "";
                    Session["QuestionNumber"] = Convert.ToInt32(Session["QuestionNumber"]) + 1;
                    lblQno.Text = Session["QuestionNumber"].ToString();
                    // lblQno.Text = getexamquestionno.ToString();
                    lblQuestion.Text = sdr["QuestName"].ToString();
                    rdbOpt1.Text = sdr["option1"].ToString();
                    rdbOpt2.Text = sdr["option2"].ToString();
                    rdbOpt3.Text = sdr["option3"].ToString();
                    rdbOpt4.Text = sdr["option4"].ToString();
                    correctans = sdr["Correctanw"].ToString();
                    //correctansNo = sdr["CorrectAnwNo"].ToString();
                    Session["Correct"] = correctans;
                    updatequestionattempt(Session["QuestionNUmber"].ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                con.Close();
            }
            finally
            {
                con.Close();

            }

        }
        public string getMarkTable()
        {
            string result = "", attemptQuestion = "", correctAnswer = "", wrongAnswer = "", percentage = "", grade = "";

            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select attemptQuestion,correctAnswer, wrongAnswer, percentage, grade from tbl_result where examcode='" + Session["getExamRandom"].ToString() + "' ", con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        attemptQuestion = rdr["attemptQuestion"].ToString();
                        correctAnswer = rdr["correctAnswer"].ToString();
                        wrongAnswer = rdr["wrongAnswer"].ToString();
                        percentage = rdr["percentage"].ToString();
                        grade = rdr["grade"].ToString();



                    }
                    result = attemptQuestion + "|" + correctAnswer + "|" + wrongAnswer + "|" + percentage + "|" + grade;

                }
                catch (Exception ex)
                {
                    con.Close();
                }
                finally { con.Close(); }
            }
            return result;

        }

        public void updateExamMarks(string value)
        {

            string getExamRandom = "", attemptQuestion = "", correctAnswer = "", wrongAnswer = "", percentage = "", grade = "";

            string questionCountString = "";



            string getResultData = getMarkTable();
            if (getResultData != "")
            {
                string[] strArray = getResultData.Split('|');
                attemptQuestion = strArray[0].ToString();
                correctAnswer = strArray[1].ToString();
                wrongAnswer = strArray[2].ToString();
                percentage = strArray[3].ToString();
                grade = strArray[4].ToString();

                //int questionCount = Convert.ToInt32(Session["attemptQuestion"]) + 1;
                //string questionCountString = attemptQuestion.ToString();

                int questionCount = Convert.ToInt32(Session["QuestionNumber"].ToString()) + 1;
                questionCountString = questionCount.ToString();


                if (value == "correct")
                {
                    //correct answer=1
                    int getcorrectAnswerCount = Convert.ToInt32(correctAnswer) + 1;
                    correctAnswer = getcorrectAnswerCount.ToString();

                    decimal getpercentage = 0, divValue = 0, calculatePercentage=0;
                    divValue = (decimal)getcorrectAnswerCount / 30; // Convert one of the operands to decimal to get decimal division
                    //decimal pervalue = (decimal)System.Math.Round(divValue, 2); // Assuming getpercentage is supposed to be used here
                    calculatePercentage = divValue * 100;
                    percentage = calculatePercentage.ToString();
                    decimal pervalue = divValue; // Assuming getpercentage is supposed to be used here
                    if (pervalue >= 0.8m) // Using decimal literal m for comparison
                    {
                        grade = "A+";
                    }
                    else if (pervalue >= 0.6m) // Using decimal literal m for comparison
                    {
                        grade = "A";
                    }
                    else if (pervalue >= 0.4m) // Using decimal literal m for comparison
                    {
                        grade = "B";
                    }
                    else
                    {
                        grade = "C";
                    }


                }
                else if (value == "incorrect")
                {
                    //incorrect answer=1
                    int getwrongAnswerCount = Convert.ToInt32(wrongAnswer) + 1;
                    wrongAnswer = getwrongAnswerCount.ToString();
                }
            }




            /*   if (correctmarks != "0")
               {
                   string grade = "";
                   decimal myMark = 0, newMark = 0;
                   myMark = Convert.ToDecimal(marks);
                   newMark = Convert.ToDecimal(value);
                   decimal addMark = myMark + newMark;
                   string newMarkValue = Convert.ToString(addMark);
                   decimal getpercentage, mulValue, divValue;
                   //divValue = (addMark / 30);
                   divValue = (addMark / 4);
                   getpercentage = divValue * 100;
                   decimal pervalue = (decimal)System.Math.Round(getpercentage, 2);
                   //Response.Write(pervalue);
                   // int getperce = ((finalMark / 5) * 100);
                   if (pervalue >= 80)
                   {
                       grade = "A+";
                   }
                   else if (pervalue >= 60)
                   {
                       grade = "A";
                   }
                   else if (pervalue >= 40)
                   {
                       grade = "B";
                   }
                   else
                   {
                       grade = "C";
                   }


               }
               else
               {

               }*/
            getExamRandom = Session["getExamRandom"].ToString();
            string getresult = updateData(getExamRandom, questionCountString, correctAnswer, wrongAnswer, percentage, grade);
            if (getresult == "pass")
            {

            }
        }

        public string updateData(string getExamRandom, string attemptQuestion, string correctAnswer, string wrongAnswer, string percentage, string grade)
        {
            string result = "";
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_result";
            sqlcon.Open();
            attemptQuestion = "";

            try
            {


                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "update");
                com.Parameters.AddWithValue("@examcode", getExamRandom);
                com.Parameters.AddWithValue("@dateOfExam", "");
                com.Parameters.AddWithValue("@mobileNumber", "");
                com.Parameters.AddWithValue("@username", ""); //Name Of User
                com.Parameters.AddWithValue("@Class", "");
                com.Parameters.AddWithValue("@subject", "");
                com.Parameters.AddWithValue("@attemptQuestion", attemptQuestion.ToString());
                com.Parameters.AddWithValue("@correctAnswer", correctAnswer.ToString());
                com.Parameters.AddWithValue("@wrongAnswer", wrongAnswer.ToString());
                com.Parameters.AddWithValue("@percentage", percentage.ToString());
                com.Parameters.AddWithValue("@grade", grade.ToString());
                com.Parameters.AddWithValue("@examDateTime", "");

                int i = com.ExecuteNonQuery();
                if (i != 0)
                {

                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Inserted sucessfully');", true);
                    result = "pass";

                }


                sqlcon.Close();

            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
                result = "fail";
                sqlcon.Close();

            }
            finally
            {
                sqlcon.Close();
            }
            return result;

        }


    }
}