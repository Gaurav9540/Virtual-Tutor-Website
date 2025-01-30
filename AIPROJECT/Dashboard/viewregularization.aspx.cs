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

namespace HR_Web_Application
{
    public partial class viewregularization : System.Web.UI.Page
    {
        string todate = "", fromdate = "";
        string mergedate = "";
        string CS = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
        public static string Empid = "", role = "";

        public static string Employeeid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EmpID"].ToString() != null)
                {
                    Employeeid = Session["EmpID"].ToString();

                    txtFromdate.Attributes.Add("readonly", "false");
                    txtTodate.Attributes.Add("readonly", "false");
                }


            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                GridView1.PageIndex = e.NewPageIndex;
                gvbind(Employeeid);
            }
            catch (Exception ex)
            { }
        }
        protected void btnviewRegAttendance_Click(object sender, EventArgs e)
        {

            gvbind(Employeeid);
        }

        public void clear()
        {
            txtFromdate.Text = "";
            txtTodate.Text = "";
        }

        protected void gvbind(string empid)
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sproc_RegAttendence";
            sqlcon.Open();

            todate = txtTodate.Text.ToString().Trim();
            fromdate = txtFromdate.Text.ToString().Trim();
            mergedate = fromdate + "|" + todate;
            
            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "getRegAttendance".ToString().Trim());
                com.Parameters.AddWithValue("@Empid", empid.ToString().Trim());
                com.Parameters.AddWithValue("@Attendance_date", mergedate.ToString().Trim());
                com.Parameters.AddWithValue("@Checkin_time", "");
                com.Parameters.AddWithValue("@Category", "");
                com.Parameters.AddWithValue("@Checkout_time", "");
                com.Parameters.AddWithValue("@Updated_date", "");
                com.Parameters.AddWithValue("@Updated_by", "");
                com.Parameters.AddWithValue("@Reason", "");
                com.Parameters.AddWithValue("@Att_Status", "");




                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                sqlcon.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    int columncount = GridView1.Rows[0].Cells.Count;
                    GridView1.Rows[0].Cells.Clear();
                    GridView1.Rows[0].Cells.Add(new TableCell());
                    GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                    GridView1.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
            catch (Exception ex)
            {

                sqlcon.Close();
                Response.Write(ex.ToString());

            }

        }


    }
}