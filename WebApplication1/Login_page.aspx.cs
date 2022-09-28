using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Web
{
    public partial class Login_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //HttpContext.Current.Response.Cache.SetNoServerCaching();
            //HttpContext.Current.Response.Cache.SetNoStore();
            //Account.Text = "";
            //Password.Text = "";
        }

        protected void change_status(string account)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-PUOG4VQ1;Initial Catalog=user_data;Integrated Security=SSPI");
            string sqlstr = @"update user_table set status = 'on' where account = '" + account + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlstr, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ae)
            {
                MessageBox.Show(ae.Message.ToString());
            }
        } 

        protected void login_Click(object sender, EventArgs e)
        {
            if(Account.Text != "" && Password.Text != "")
            {
                SqlConnection conn = new SqlConnection("Data Source=LAPTOP-PUOG4VQ1;Initial Catalog=user_data;Integrated Security=SSPI");
                string sqlstr = @"Select account from user_table where password = '"+ Password.Text + "' and account = '" + Account.Text +"'";
                SqlCommand command = new SqlCommand(sqlstr, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Session["account"] = Account.Text;
                    Session["password"] = Password.Text;
                    change_status(Account.Text);
                    Response.Redirect("User_page.aspx", false);
                }
                else
                {
                    Response.Write("<script>alert('帳號密碼錯誤!')</script>");
                    Account.Text = "";
                    Password.Text = "";
                }                
            }
            else if(Account.Text == "")
            {
                Response.Write("<script>alert('請輸入帳號!')</script>");
            }
            else if (Password.Text == "")
            {
                Response.Write("<script>alert('請輸入密碼!')</script>");
            }
        }
    }
}