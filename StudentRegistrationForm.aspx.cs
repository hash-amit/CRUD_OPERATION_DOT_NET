using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace School
{
    public partial class StudentRegistrationForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-IOJE25P\\SQLEXPRESS;initial catalog=DB_School;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                showClass();
                showGender();
                showStudentsRecords();
            }
        }

        public void showGender() 
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from TBL_Gender", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            textrbl_gender.DataValueField = "GID";
            textrbl_gender.DataTextField = "G_NAME";
            textrbl_gender.DataSource = dt;
            textrbl_gender.DataBind();
        }

        public void showClass()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from TBL_Class", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            textddl_class.DataValueField = "CID";
            textddl_class.DataTextField = "CLASS_NUMBER";
            textddl_class.DataSource = dt;
            textddl_class.DataBind();
            textddl_class.Items.Insert(0, new ListItem("---Select Class---", "0"));
        }

        public void showStudentsRecords()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from TBL_Student join TBL_Gender on GID=GENDER JOIN TBL_Class on CID=CLASS", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            gv_students.DataSource = dt;
            gv_students.DataBind();
        }

        public void clearTextBox()
        {
            text_fullname.Text = string.Empty;
            text_fathersname.Text = string.Empty;
            textrbl_gender.ClearSelection();
            text_age.Text = string.Empty;
            text_address.Text = string.Empty;
            textddl_class.ClearSelection();
            text_mobile.Text = string.Empty;
        }

        protected void savebtn_Click(object sender, EventArgs e)
        {
            if(savebtn.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into TBL_Student(FULL_NAME,FATHERS_NAME,CLASS,GENDER,AGE,ADDRESS,MOBILE)Values('" + text_fullname.Text + "','" + text_fathersname.Text + "','" + textddl_class.SelectedValue + "','" + textrbl_gender.SelectedValue + "','" + text_age.Text + "','" + text_address.Text + "','" + text_mobile.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                showStudentsRecords();
                clearTextBox();
            }
            else if(savebtn.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update TBL_Student set FULL_NAME='"+ text_fullname.Text +"',FATHERS_NAME='"+ text_fathersname.Text +"', CLASS='"+ textddl_class.SelectedValue +"',GENDER='"+ textrbl_gender.SelectedValue +"',AGE='"+ text_age.Text +"',ADDRESS='"+ text_address.Text +"',MOBILE='"+ text_mobile.Text +"' WHERE ID='"+ ViewState["caid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                showStudentsRecords();
                clearTextBox();
                savebtn.Text = "Save";
            }
        }

        protected void gv_students_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "D")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from TBL_Student where ID='" + e.CommandArgument + "'", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                con.Close();
                showStudentsRecords();
            }
            else if(e.CommandName == "E")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from TBL_Student where ID='"+ e.CommandArgument +"'", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                text_fullname.Text = dt.Rows[0]["FULL_NAME"].ToString();
                text_fathersname.Text = dt.Rows[0]["FATHERS_NAME"].ToString();
                textddl_class.Text = dt.Rows[0]["CLASS"].ToString();
                textrbl_gender.Text = dt.Rows[0]["GENDER"].ToString();
                text_age.Text = dt.Rows[0]["AGE"].ToString();
                text_address.Text = dt.Rows[0]["ADDRESS"].ToString();
                text_mobile.Text = dt.Rows[0]["MOBILE"].ToString();
                savebtn.Text = "Update";
                ViewState["caid"] = e.CommandArgument;
            }
        }
    }
}