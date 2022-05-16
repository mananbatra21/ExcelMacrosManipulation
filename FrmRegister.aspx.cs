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
    public partial class FrmRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string conStr = "Data Source=(localdb)\\MSSqlLocalDb;Initial Catalog=SignUp;Integrated Security=True";
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                string selQuery = "select * from tblUser_Details where UserName = '" + txtUsername.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(selQuery, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    lblMessage.Text = "user already exists please try to login.";
                }
                else
                {
                    if(txtUsername.Text==null || txtPassword.Text==null || txtConfirmPass.Text == null)
                    {
                        lblMessage.Text = "please fill all the details to register.";
                    }
                    else
                    {
                        if (txtConfirmPass.Text == txtPassword.Text)
                        {
                            conn.Open();
                            string st = "insert into TblUser_Details values('" + txtUsername.Text + "'," + txtPassword.Text + ")";
                            SqlCommand sqlcom = new SqlCommand(st, conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();

                            lblMessage.Text = "user registered successfully.";
                        }
                        else
                        {
                            lblMessage.Text = "password and confirm password does not match.";
                        }
                       
                    }
                    
                }
            } 
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmHome.aspx");
        }
    }
}