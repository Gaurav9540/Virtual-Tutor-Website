using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Data;
using System.Configuration;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Web.Security;

namespace HR_Web_Application
{
    public partial class admin : System.Web.UI.MasterPage
    {

        string CS = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
        string parameterValueOfnameid = "";
        string parameterValueOfLevel = "";
        string parameterValueOfMob = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //getEmployeeData("1001");
                //Session["WelcomeName"] = getEmpName;
                //Session["EmpID"] = getEmpId;
                // authenticateMenu();
                // welcomeName.Text = new CultureInfo("en-US", false).TextInfo.ToTitleCase(Session["Fname"].ToString()) + " " + new CultureInfo("en-US", false).TextInfo.ToTitleCase(Session["Lname"].ToString());
                // lblDesignation.Text = new CultureInfo("en-US", false).TextInfo.ToTitleCase(Session["Desgination"].ToString());
                //welcomeName.Text = Session["Fname"].ToString().ToUpper() + " " + Session["Lname"].ToString();
                //lblDesignation.Text = Session["Desgination"].ToString();

                parameterValueOfnameid = HttpContext.Current.Request.QueryString["nameid"];
                parameterValueOfLevel = HttpContext.Current.Request.QueryString["level"];
                parameterValueOfMob = HttpContext.Current.Request.QueryString["mob"];

                //remove once it will donw as dynmic
                /* parameterValueOfnameid = "abcd";
                 parameterValueOfLevel = "admin";
                 parameterValueOfMob = "7893214566";*/

                Session["parameterValueOfnameid"] = parameterValueOfnameid;
                Session["parameterValueOfLevel"] = parameterValueOfLevel;
                Session["parameterValueOfMob"] = parameterValueOfMob;

                // Check if the parameter exists
                if (!string.IsNullOrEmpty(parameterValueOfnameid) && !string.IsNullOrEmpty(parameterValueOfLevel) && !string.IsNullOrEmpty(parameterValueOfMob))
                {
                    welcomeName.Text = parameterValueOfnameid.ToUpper();
                    showAccess(parameterValueOfLevel);
                    //lblShowName.Text = Security.Decryption(parameterValueOfnameid).ToUpper();

                }
                else
                {
                    Response.Redirect("~/loginPage/login.aspx");
                }


            }

        }

        protected void dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());
        }
        protected void progressReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("progressreport.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());
        }
        protected void result_Click(object sender, EventArgs e)
        {
            Response.Redirect("result.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());
        }

        protected void myprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("myprofile.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());
        }
        protected void viewupdateprofile_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewprofile.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginPage/login.aspx");
        }

        protected void addsubjectcontent_Click(object sender, EventArgs e)
        {
            Response.Redirect("addsubjectcontent.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());
        }
        protected void addquestion_Click(object sender, EventArgs e)
        {
            Response.Redirect("addquestion.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());
        }
        protected void viewupdatequestion_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewupdatequestion.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());
        }



        protected void changepassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("changepassword.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());
        }
        protected void viewupdatesubjectcontent_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewupdatesubjectcontent.aspx?nameid=" + Session["parameterValueOfnameid"].ToString() + "&level=" + Session["parameterValueOfLevel"].ToString() + "&mob=" + Session["parameterValueOfMob"].ToString());
        }
        public void showAccess(string role)
        {
            if (role == "user")
            {
                question.Visible = false;
                content.Visible = false;
            }
            else if (role == "admin")
            {
                question.Visible = true;
                content.Visible = true;
            }
        }

    }
}