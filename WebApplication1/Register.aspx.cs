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
    public partial class register_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            Name.Text = "";
            Account.Text = "";
            Password.Text = "";
            Comfirm_Password.Text = "";
            Answer.Text = "";
        }
        protected void creat_user_data(string account)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-PUOG4VQ1;Initial Catalog=user_data;Integrated Security=SSPI");
            string sqlstr = @"CREATE TABLE " + account + " ( friends nvarchar(50) )";
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

        protected void insert_user_data()
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-PUOG4VQ1;Initial Catalog=user_data;Integrated Security=SSPI");
            string sqlstr = @"insert into user_table ( account, password, ID, hobby, question, answer) values 
                               ('" + Account.Text + "','" + Password.Text + "','" + Name.Text + "','"
                               + Hobby.Text + "','" + ddl_question.Text + "','" + Answer.Text + "')";
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

        protected void Summit_Click(object sender, EventArgs e)
        {
            if(Password.Text != Comfirm_Password.Text)
            {     
                Response.Write("<script>alert('請確認密碼!')</script>");
            }
            else 
            {
                if (Account.Text == "" || Password.Text == "" || Name.Text == "" || Hobby.Text == "" || Answer.Text == "")
                {
                    Response.Write("<script>alert('請輸入完整資料!')</script>");
                }
                else
                {
                    SqlConnection conn = new SqlConnection("Data Source=helical-yeti-362606:asia-east1:miles0629;");
                    string sqlstr = @"select * from user_table where account = '"+ Account.Text +"'";
                    SqlCommand command = new SqlCommand(sqlstr, conn);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Name.Text = "";
                        Account.Text = "";
                        Password.Text = "";
                        Comfirm_Password.Text = "";
                        Answer.Text = "";
                        Response.Write("<script>alert('此帳號已有人使用!')</script>");
                    }
                    else
                    {
                        creat_user_data(Account.Text);
                        insert_user_data();
                        Response.Write("<script>alert('註冊成功!');location.href='Login_page.aspx';</script>");
                        //Response.Redirect("Login_page.aspx", false);
                    }                    
                }
            }
        }   
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Write("<script language=javascript>history.go(-2);</script>");
        }

    }
}