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

namespace AI_Project.Website
{
    public partial class tutorial : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["dbconn"].ToString();

        string parameterValueOfnameid = "";
        string parameterValueOfLevel = "";
        string parameterValueOfMob = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                parameterValueOfnameid = HttpContext.Current.Request.QueryString["nameid"];
                parameterValueOfLevel = HttpContext.Current.Request.QueryString["level"];
                parameterValueOfMob = HttpContext.Current.Request.QueryString["mob"];


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
        protected void btnQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/quiz/exam.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());

        }
        protected void dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard/Dashboard.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());

        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginPage/login.aspx");
        }

        protected void btnCloseFront_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "secondPage1", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "mainPage1", "<script>document.getElementById('mainPage').style.display = 'block';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);


        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

            string classData = txtclasswise.Text;
            if (classData == "Fifth Class")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage1", "<script>document.getElementById('secondPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage1", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectValue", "<script>document.getElementById('subjectValue').innerHTML = '" + classData + "';</script>", false);

                ScriptManager.RegisterStartupScript(this, GetType(), "fithClass", "<script>document.getElementById('fithClass').style.display = 'block';</script>", false);


            }
            else if (classData == "Sixth Class")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage1", "<script>document.getElementById('secondPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage1", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectValue", "<script>document.getElementById('subjectValue').innerHTML = '" + classData + "';</script>", false);

                ScriptManager.RegisterStartupScript(this, GetType(), "sixthClass", "<script>document.getElementById('sixthClass').style.display = 'block';</script>", false);


            }
            else if (classData == "Seventh Class")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage1", "<script>document.getElementById('secondPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage1", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectValue", "<script>document.getElementById('subjectValue').innerHTML = '" + classData + "';</script>", false);

                ScriptManager.RegisterStartupScript(this, GetType(), "seventhClass", "<script>document.getElementById('seventhClass').style.display = 'block';</script>", false);


            }

            else if (classData == "Eighth Class")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage1", "<script>document.getElementById('secondPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage1", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectValue", "<script>document.getElementById('subjectValue').innerHTML = '" + classData + "';</script>", false);

                ScriptManager.RegisterStartupScript(this, GetType(), "eighthClass", "<script>document.getElementById('eighthClass').style.display = 'block';</script>", false);


            }
            else if (classData == "Nineth Class")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage1", "<script>document.getElementById('secondPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage1", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectValue", "<script>document.getElementById('subjectValue').innerHTML = '" + classData + "';</script>", false);

                ScriptManager.RegisterStartupScript(this, GetType(), "ninethClass", "<script>document.getElementById('ninethClass').style.display = 'block';</script>", false);


            }

            else if (classData == "Tenth Class")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage1", "<script>document.getElementById('secondPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage1", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectValue", "<script>document.getElementById('subjectValue').innerHTML = '" + classData + "';</script>", false);

                ScriptManager.RegisterStartupScript(this, GetType(), "tenthClass", "<script>document.getElementById('tenthClass').style.display = 'block';</script>", false);


            }

        }

        private string getDescriptionData(string getTitleValue, string getSubjectCode, string subjectValue)
        {
            SqlConnection sqlcon = new SqlConnection(CS);

            string getresult = "";

            string param = "sp_subjectdata";
            sqlcon.Open();
            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "select");
                com.Parameters.AddWithValue("@class", "");
                com.Parameters.AddWithValue("@subject", "");
                com.Parameters.AddWithValue("@subjectcode", getSubjectCode);
                com.Parameters.AddWithValue("@title", getTitleValue);
                com.Parameters.AddWithValue("@decription", "");
                com.Parameters.AddWithValue("@videolink", "");
                com.Parameters.AddWithValue("@createdOn", "");
                com.Parameters.AddWithValue("@lastupdatedon", "");
                SqlDataReader reader = com.ExecuteReader();

                StringBuilder htmlTable = new StringBuilder();
                Literal1.Text = "";
                htmlTable.Append("<table>");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Read data from each row and add to the HTML table
                        string decription = reader["decription"].ToString();
                        //string column2Data = reader["title"].ToString();
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style='padding: 10px;'>" + decription + "</td>");

                        //htmlTable.Append("<td>" + column2Data + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</table>");
                    Literal1.Text = htmlTable.ToString();


                    getresult = "pass";

                }
                else
                {
                    //reader has no row
                    Literal1.Text = "Records not found, try again after sometime".ToString();
                    getresult = "fail";
                }
                reader.Close(); // Close the SqlDataReader

            }
            catch (Exception ex)
            {
                Literal1.Text = "Records not found, try again after sometime".ToString();
                getresult = "fail";
            }
            return getresult;

        }

        protected void showDescriptionData(object sender, EventArgs e)
        {
            // Yogesh Sir will do this code dont touch
            //Response.Cookies["hdGetTitle"].Value
            string getTitleValue = txtgetTitleValue.Text;
            string getSubjectCode = txtgetSubjectCode.Text;
            string subjectValue = txtsubjectValue.Text;

            string result = "";
            string getVidoResult = "";
            result = getDescriptionData(getTitleValue, getSubjectCode, subjectValue);
            getVidoResult = getVideoLink(getTitleValue,getSubjectCode);
            if (result == "pass" || getVidoResult == "pass")
            {
                getSubject.Text = subjectValue + " Tutorial";
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = '" + getTitleValue + "';</script>", false);

            }
            else
            {

            }

        }

        protected void getValueForNextPage(object sender, EventArgs e)
        {

            string classData = "Fifth Class";
            txtclasswise.Text = "Fifth Class";
            ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'block';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);

            ScriptManager.RegisterStartupScript(this, GetType(), "subjectValue", "<script>document.getElementById('subjectValue').innerHTML = '" + classData + "';</script>", false);

            ScriptManager.RegisterStartupScript(this, GetType(), "fithClass", "<script>document.getElementById('fithClass').style.display = 'block';</script>", false);



        }

        protected void getValueForNextPage6(object sender, EventArgs e)
        {
            string classData = "Sixth Class";
            txtclasswise.Text = "Sixth Class";
            ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'block';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);

            ScriptManager.RegisterStartupScript(this, GetType(), "subjectValue", "<script>document.getElementById('subjectValue').innerHTML = '" + classData + "';</script>", false);

            ScriptManager.RegisterStartupScript(this, GetType(), "sixthClass", "<script>document.getElementById('sixthClass').style.display = 'block';</script>", false);


        }
        protected void getValueForNextPage7(object sender, EventArgs e)
        {
            string classData = "Seventh Class";
            txtclasswise.Text = "Seventh Class";
            ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'block';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);

            ScriptManager.RegisterStartupScript(this, GetType(), "subjectValue", "<script>document.getElementById('subjectValue').innerHTML = '" + classData + "';</script>", false);

            ScriptManager.RegisterStartupScript(this, GetType(), "sixthClass", "<script>document.getElementById('seventhClass').style.display = 'block';</script>", false);

        }
        protected void getValueForNextPage8(object sender, EventArgs e)
        {
            string classData = "Eighth Class";
            txtclasswise.Text = "Eighth Class";
            ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'block';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);

            ScriptManager.RegisterStartupScript(this, GetType(), "subjectValue", "<script>document.getElementById('subjectValue').innerHTML = '" + classData + "';</script>", false);

            ScriptManager.RegisterStartupScript(this, GetType(), "eighthClass", "<script>document.getElementById('eighthClass').style.display = 'block';</script>", false);

        }
        protected void getValueForNextPage9(object sender, EventArgs e)
        {
            string classData = "Nineth Class";
            txtclasswise.Text = "Nineth Class";
            ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'block';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);

            ScriptManager.RegisterStartupScript(this, GetType(), "subjectValue", "<script>document.getElementById('subjectValue').innerHTML = '" + classData + "';</script>", false);

            ScriptManager.RegisterStartupScript(this, GetType(), "ninethClass", "<script>document.getElementById('ninethClass').style.display = 'block';</script>", false);

        }
        protected void getValueForNextPage10(object sender, EventArgs e)
        {
            string classData = "Tenth Class";
            txtclasswise.Text = "Tenth Class";
            ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'none';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'block';</script>", false);
            ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);

            ScriptManager.RegisterStartupScript(this, GetType(), "subjectValue", "<script>document.getElementById('subjectValue').innerHTML = '" + classData + "';</script>", false);

            ScriptManager.RegisterStartupScript(this, GetType(), "tenthClass", "<script>document.getElementById('tenthClass').style.display = 'block';</script>", false);

        }
        protected void btngetselectsubject(object sender, EventArgs e)
        {
            string classValue = "fifth";
            string subjectValue = "English";
            string subjectCodeValue = "51";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }


        protected void btngetselectsubject52(object sender, EventArgs e)
        {
            string classValue = "fifth";
            string subjectValue = "EVS";
            string subjectCodeValue = "52";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }


        protected void btngetselectsubject53(object sender, EventArgs e)
        {
            string classValue = "fifth";
            string subjectValue = "Mathematics";
            string subjectCodeValue = "53";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject61(object sender, EventArgs e)
        {
            string classValue = "sixth";
            string subjectValue = "English";
            string subjectCodeValue = "61";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);
            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject62(object sender, EventArgs e)
        {
            string classValue = "sixth";
            string subjectValue = "Science";
            string subjectCodeValue = "62";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);


            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject63(object sender, EventArgs e)
        {
            string classValue = "sixth";
            string subjectValue = "Mathematics";
            string subjectCodeValue = "63";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject64(object sender, EventArgs e)
        {
            string classValue = "sixth";
            string subjectValue = "Social And Political Life";
            string subjectCodeValue = "64";
            string getResult = "";
            string getVidoResult = "";
getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject65(object sender, EventArgs e)
        {
            string classValue = "sixth";
            string subjectValue = "Social Science";
            string subjectCodeValue = "65";
            string getResult = "";
            string getVidoResult = "";
getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject71(object sender, EventArgs e)
        {
            string classValue = "seventh";
            string subjectValue = "English";
            string subjectCodeValue = "71";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject72(object sender, EventArgs e)
        {
            string classValue = "seventh";
            string subjectValue = "Science";
            string subjectCodeValue = "72";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }



        protected void btngetselectsubject73(object sender, EventArgs e)
        {
            string classValue = "seventh";
            string subjectValue = "Mathematics";
            string subjectCodeValue = "73";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject74(object sender, EventArgs e)
        {
            string classValue = "seventh";
            string subjectValue = "Social Science";
            string subjectCodeValue = "74";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject81(object sender, EventArgs e)
        {
            string classValue = "eighth";
            string subjectValue = "English";
            string subjectCodeValue = "81";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject82(object sender, EventArgs e)
        {
            string classValue = "eighth";
            string subjectValue = "Science";
            string subjectCodeValue = "82";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject83(object sender, EventArgs e)
        {
            string classValue = "eighth";
            string subjectValue = "Mathematics";
            string subjectCodeValue = "83";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject84(object sender, EventArgs e)
        {
            string classValue = "eighth";
            string subjectValue = "Social Science";
            string subjectCodeValue = "84";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject91(object sender, EventArgs e)
        {
            string classValue = "nineth";
            string subjectValue = "English";
            string subjectCodeValue = "91";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }
        protected void btngetselectsubject92(object sender, EventArgs e)
        {
            string classValue = "nineth";
            string subjectValue = "Science";
            string subjectCodeValue = "92";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }
        protected void btngetselectsubject93(object sender, EventArgs e)
        {
            string classValue = "nineth";
            string subjectValue = "Mathematics";
            string subjectCodeValue = "93";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
               
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }
        protected void btngetselectsubject94(object sender, EventArgs e)
        {
            string classValue = "nineth";
            string subjectValue = "Social Science";
            string subjectCodeValue = "94";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject101(object sender, EventArgs e)
        {
            string classValue = "tenth";
            string subjectValue = "English";
            string subjectCodeValue = "101";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }
        protected void btngetselectsubject102(object sender, EventArgs e)
        {
            string classValue = "tenth";
            string subjectValue = "Science";
            string subjectCodeValue = "102";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
               
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }
        protected void btngetselectsubject103(object sender, EventArgs e)
        {
            string classValue = "tenth";
            string subjectValue = "Mathematics";
            string subjectCodeValue = "103";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }
        protected void btngetselectsubject104(object sender, EventArgs e)
        {
            string classValue = "tenth";
            string subjectValue = "Social Science";
            string subjectCodeValue = "104";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }

        protected void btngetselectsubject105(object sender, EventArgs e)
        {
            string classValue = "tenth";
            string subjectValue = "ICT";
            string subjectCodeValue = "105";
            string getResult = "";
            string getVidoResult = "";
            getSubject.Text = subjectValue + " Tutorial";
            getResult = getTitle(classValue, subjectValue, subjectCodeValue);

            if (getResult == "pass")
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                Literal1.Text = "";
                videoLiteral.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTutor", "<script>document.getElementById('subjectTutor').innerHTML = '" + subjectValue + "';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "thirdPage", "<script>document.getElementById('thirdPage').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "secondPage", "<script>document.getElementById('secondPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "mainPage", "<script>document.getElementById('mainPage').style.display = 'none';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "descriptionarea", "<script>document.getElementById('descriptionarea').style.display = 'block';</script>", false);
                ScriptManager.RegisterStartupScript(this, GetType(), "subjectTitleDescription", "<script>document.getElementById('subjectTitleDescription').innerHTML = 'Searching content are not available, please try after sometime.';</script>", false);

            }
        }



        private string getVideoLink(string getTitleValue,string subjectCodeValue)
        {
            string getResult = "";


            SqlConnection sqlcon = new SqlConnection(CS);
            StringBuilder htmlTable = new StringBuilder();

            string param = "sp_subjectdata";
            sqlcon.Open();
            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "getvideo");
                com.Parameters.AddWithValue("@class", "");
                com.Parameters.AddWithValue("@subject", "");
                com.Parameters.AddWithValue("@subjectcode", subjectCodeValue);
                com.Parameters.AddWithValue("@title", getTitleValue);
                com.Parameters.AddWithValue("@decription", "");
                com.Parameters.AddWithValue("@videolink", "");
                com.Parameters.AddWithValue("@createdOn", "");
                com.Parameters.AddWithValue("@lastupdatedon", "");
                SqlDataReader reader = com.ExecuteReader();
                videoLiteral.Text = "";
                htmlTable.Append("<table  border='1'>");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Read data from each row
                        //string title = reader["title"].ToString();
                        string videoLink = reader["videolink"].ToString(); // Assuming "video_link" is the column name in your database

                        // Add the data to the HTML table
                        if (videoLink != " ")
                        {
                            if (IsValidYouTubeLink(videoLink))
                            {
                                // Add the video link to the HTML table
                                htmlTable.Append("<tr>");
                                htmlTable.Append("<td style='padding: 10px;'>");
                                htmlTable.Append("<div class='video-container'>");
                                htmlTable.Append("<iframe width='140' height='100' src='" + videoLink + "' frameborder='0' allowfullscreen></iframe>");
                                htmlTable.Append("</div>");
                                htmlTable.Append("</td>");
                                htmlTable.Append("</tr>");
                            }
                            else
                            {
                                // Invalid YouTube video link
                                // You can handle this case as needed
                            }

                            // htmlTable.Append("<td style='padding: 10px;'><div class='video-box' data-video='" + videoLink + "'><a href='javascript:void(0);' onclick='playVideo(\"" + videoLink + "\");'>Play Video</a></div></td>");
                            //htmlTable.Append("<tr>");
                            //htmlTable.Append("<td style='padding: 10px;'>");
                            //htmlTable.Append("<div class='video-container'>");
                            //htmlTable.Append("<iframe width='140' height='100' src='" + videoLink + "' frameborder='0' allowfullscreen></iframe>");
                            //htmlTable.Append("</div>");
                            //htmlTable.Append("</td>");

                            //htmlTable.Append("</tr>");
                        }
                    }
                    htmlTable.Append("</table>");
                    videoLiteral.Text = htmlTable.ToString();
                    getResult = "pass";
                }
                else
                {
                    // No rows returned from the database
                    getResult = "fail";
                }

                reader.Close(); // Close the SqlDataReader

            }
            catch (Exception ex)
            {
                getResult = "fail" + ex.ToString();
            }


            return getResult;
        }

        private bool IsValidYouTubeLink(string videoLink)
        {
            // Check if the video link is a valid YouTube URL
            return Uri.TryCreate(videoLink, UriKind.Absolute, out Uri uriResult) &&
                   (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps) &&
                   uriResult.Host == "www.youtube.com";
        }

        // Function to convert YouTube URLs to the embed format
        private string ConvertToEmbedLink(string videoLink)
        {
            // Check if the link is already in the embed format
            if (videoLink.StartsWith("https://www.youtube.com/embed/"))
            {
                return videoLink; // Return the link as is
            }

            // Extract the video ID from the URL
            string videoId = videoLink.Substring(videoLink.LastIndexOf("v=") + 2);

            // Construct the embed link
            return "https://www.youtube.com/embed/" + videoId;
        }

        private string getTitle(string classValue, string subjectValue, string subjectCodeValue)
        {
            string getResult = "";


            SqlConnection sqlcon = new SqlConnection(CS);
            StringBuilder htmlTable = new StringBuilder();

            string param = "sp_subjectdata";
            sqlcon.Open();
            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "display_title");
                com.Parameters.AddWithValue("@class", classValue);
                com.Parameters.AddWithValue("@subject", subjectValue);
                com.Parameters.AddWithValue("@subjectcode", subjectCodeValue);
                com.Parameters.AddWithValue("@title", "");
                com.Parameters.AddWithValue("@decription", "");
                com.Parameters.AddWithValue("@videolink", "");
                com.Parameters.AddWithValue("@createdOn", "");
                com.Parameters.AddWithValue("@lastupdatedon", "");
                SqlDataReader reader = com.ExecuteReader();
                yourLiteralControl.Text = "";
                htmlTable.Append("<table  border='1'>");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Read data from each row and add to the HTML table
                        string column1Data = reader["title"].ToString();
                        //string column2Data = reader["title"].ToString();
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style='padding: 10px;'><a href='javascript:void(0);' onclick='getDecription(\"" + column1Data + "\",\"" + subjectValue + "\",\"" + subjectCodeValue + "\");'>" + column1Data + "</a></td>");

                        //htmlTable.Append("<td>" + column2Data + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</table>");
                    yourLiteralControl.Text = htmlTable.ToString();
                    getResult = "pass";


                }
                else
                {
                    //reader has no row
                    getResult = "fail";
                }


                reader.Close(); // Close the SqlDataReader

            }
            catch (Exception ex)
            {
                getResult = "faile" + ex.ToString();
            }


            return getResult;
        }


        [WebMethod]
        public static List<string> GetDataFromDatabase()
        {
            // Your code to retrieve data from the database
            // For demonstration purposes, let's return some sample data
            List<string> data = new List<string>();
            data.Add("Data 1");
            data.Add("Data 2");
            data.Add("Data 3");
            return data;
        }
    }
}