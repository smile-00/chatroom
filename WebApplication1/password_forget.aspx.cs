using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace WebApplication1
{
    public partial class Home_page : System.Web.UI.Page
    {
        public void SendEmail(string receiver, string pas)
        {
            MailMessage mail = new MailMessage();
            //前面是發信email後面是顯示的名稱
            mail.From = new MailAddress("make.friend@gmail.com", "test");
            //收信者email
            mail.To.Add(receiver);
            //設定優先權
            mail.Priority = MailPriority.Normal;
            //標題
            mail.Subject = "Your Password";
            //內容
            mail.Body = "Your Password: "+pas;
            //內容使用html
            mail.IsBodyHtml = false;
            //設定gmail的smtp (這是google的)
            SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);
            //您在gmail的帳號密碼
            MySmtp.Credentials = new System.Net.NetworkCredential("sw.webproject@gmail.com", "swproject");
            //開啟ssl
            MySmtp.EnableSsl = true;
            //發送郵件
            MySmtp.Send(mail);
            //放掉宣告出來的MySmtp
            MySmtp = null;
            //放掉宣告出來的mail
            mail.Dispose();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                account.Text = "";
                mail.Text = "";
                Answer.Text = "";
            }
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            account.Text = "";           
            mail.Text = "";
            Answer.Text = "";
        }
        protected void Summit_Click(object sender, EventArgs e)
        {
            string password = "",qus = "",ans = "";
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-PUOG4VQ1;Initial Catalog=user_data;Integrated Security=SSPI");
            string sqlstr = @"Select password, question, answer from user_table where account = '"+account.Text+ 
                "' and question = '"+ ddl_question.Text + "' and answer = '"+ Answer.Text + "'";
            //SqlCommand command = new SqlCommand(sqlstr, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                password = row[0].ToString();
                qus = row[1].ToString();
                ans = row[2].ToString();
            }
            if (password == "")
                Response.Write("<script>alert('帳號錯誤!')</script>");
            else if (Answer.Text != ans || ddl_question.Text != qus)
            {
                Response.Write("<script>alert('問題錯誤!')</script>");
            }
            else
            {
                SendEmail(mail.Text, password);
                Response.Redirect("Login_page.aspx", false);
                //Response.Write("<script>alert('密碼:" + password + "');location.href='Login_page.aspx';</script>");
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Write("<script language=javascript>history.go(-2);</script>");
        }
    }
}