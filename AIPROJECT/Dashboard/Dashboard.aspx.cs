using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Web_Application
{
    public partial class Dashboard : System.Web.UI.Page
    {
        string parameterValueOfnameid = "";
        string parameterValueOfLevel = "";
        string parameterValueOfMob = "";
        string CS = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                parameterValueOfnameid = Session["parameterValueOfnameid"].ToString();
                parameterValueOfLevel = Session["parameterValueOfLevel"].ToString();
                parameterValueOfMob = Session["parameterValueOfMob"].ToString();

                lblShowUser.Text = parameterValueOfLevel.ToString();
                if (parameterValueOfLevel == "user")
                {
                    lblgetEnrolledActiveStd.Text = getEnrolledStudent(parameterValueOfLevel, parameterValueOfMob);
                }
                else
                {
                    lblgetEnrolledActiveStd.Text = getEnrolledStudent("", "");
                }
                

                lblExamGivenData.Text = getExamGivenData();
                lblAiTutorUse.Text = getAiTutorUse();
            }



        }
        public string getEnrolledStudent(string roleLevel, string mobileNumber)
        {
            string getCount = "";

            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_dashboardData";
            sqlcon.Open();
            string adminLevel = "";
            try
            {
                if (parameterValueOfLevel == "user")
                {
                    adminLevel = "getprofiledata";
                }
                else
                {
                    adminLevel = "getprofileadmindata";
                }
                
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", adminLevel);
                com.Parameters.AddWithValue("@level", roleLevel);
                com.Parameters.AddWithValue("@mobilnumber", mobileNumber);

                using (SqlDataReader reader = com.ExecuteReader())
                {

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string getdatafromdb = reader["noOfProfile"].ToString();
                            getCount = getdatafromdb;
                        }

                    }
                    else
                    {
                        getCount = "No Record Found";
                    }

                }
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                getCount = "No Record Found";
                sqlcon.Close();
            }
            finally
            {
                sqlcon.Close();
            }


            return getCount;

        }

        public string getAiTutorUse()
        {
            string getCount = "";

            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_dashboardData";
            sqlcon.Open();

            try
            {

                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "getaitutordata");
                com.Parameters.AddWithValue("@level", "");
                com.Parameters.AddWithValue("@mobilnumber", "");

                using (SqlDataReader reader = com.ExecuteReader())
                {

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string getdatafromdb = reader["noOfAiTutorData"].ToString();
                            getCount = getdatafromdb;
                        }

                    }
                    else
                    {
                        getCount = "No Record Found";
                    }

                }
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                getCount = "No Record Found";
                sqlcon.Close();
            }
            finally
            {
                sqlcon.Close();
            }


            return getCount;

        }
        public string getExamGivenData()
        {
            string getCount = "";

            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_dashboardData";
            sqlcon.Open();

            try
            {

                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "getexamgivendata");
                com.Parameters.AddWithValue("@level", "");
                com.Parameters.AddWithValue("@mobilnumber", "");

                using (SqlDataReader reader = com.ExecuteReader())
                {

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string getdatafromdb = reader["noOfStudExamGiven"].ToString();
                            getCount = getdatafromdb;
                        }

                    }
                    else
                    {
                        getCount = "No Record Found";
                    }

                }
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                getCount = "No Record Found";
                sqlcon.Close();
            }
            finally
            {
                sqlcon.Close();
            }


            return getCount;

        }

    }
}