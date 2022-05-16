using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace ExcelMacrosManipulation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string conStr = "Data Source=(localdb)\\MSSqlLocalDb;Initial Catalog=SignUp;Integrated Security=True";

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text =="" || txtPassword.Text == "")
            {
                lblMessage.Text = "please enter username and password.";
            }
            else
            {
                using(SqlConnection conn = new SqlConnection(conStr))
                {
                    string selQuery = "select * from tblUser_Details";
                    SqlDataAdapter da = new SqlDataAdapter(selQuery, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if(dt.Rows.Count == 0)
                    {
                        lblMessage.Text = "please enter a valid username and password or register and try to login again";
                    }
                    else
                    {
                        Boolean notFound = false;
                        for(int i = 0; i < dt.Rows.Count; i++)
                        {
                            if(dt.Rows[i][1].ToString() == txtUsername.Text && dt.Rows[i][2].ToString() == txtPassword.Text)
                            {
                                Response.Redirect("ExcelFunctionality.aspx");
                            }
                            else
                            {
                                notFound= true;
                            }
                        }
                        if (notFound == true)
                        {
                            lblMessage.Text= "please enter a valid username and password or register and try to login again";
                        }
                    }
                }
            }
        }

        public void emptyTxt()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            lblMessage.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            emptyTxt();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmRegister.aspx");
        }
    }
}