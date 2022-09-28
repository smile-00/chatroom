using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WebApplication1
{
    public partial class User_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string u_id = "", u_hobby = "";
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-PUOG4VQ1;Initial Catalog=user_data;Integrated Security=SSPI");
            string sqlstr = @"Select ID, hobby from user_table where Account = '" + Session["account"] + "'";
            //SqlCommand command = new SqlCommand(sqlstr, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                u_id = row[0].ToString();
                u_hobby = row[1].ToString();
            }
            id.Text = u_id;
            hobby.Text = u_hobby;
            Pairing(u_hobby);
            Friend_list();
        }

        protected bool check_firend_list(string str)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-PUOG4VQ1;Initial Catalog=user_data;Integrated Security=SSPI");
            string sqlstr = @"Select friends from " + Session["account"].ToString() + " where friends = '" + str + "'";
            SqlCommand command = new SqlCommand(sqlstr, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader.HasRows;
        }

        protected void Pairing(string hob)
        {
            string acc = Session["account"].ToString();
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-PUOG4VQ1;Initial Catalog=user_data;Integrated Security=SSPI");
            string sqlstr = @"Select account from user_table where Hobby = '" + hob + "' and Account != '"+ acc +"'";
            //SqlCommand command = new SqlCommand(sqlstr, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = 1;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if ( !check_firend_list( row[0].ToString() ) )
                {
                    string btn_str = "<asp:Button ID=\"pair" + i + "\" class=\"btn2\" runat=\"server\" Text=\"" + row[0].ToString() + "\" /> ";
                    System.Web.UI.Control c = ParseControl(btn_str);
                    this.Panel1.Controls.Add(c);
                    System.Web.UI.WebControls.Button myButton = (System.Web.UI.WebControls.Button)Page.FindControl("Pair" + i);
                    myButton.Command += new CommandEventHandler(Pair_Click);
                    i++;
                }             
            }
            conn.Close();
        }

        protected void Pair_Click(object sender, EventArgs e)
        {
            //string s = (sender as Button).Text;
            string recom = ((System.Web.UI.WebControls.Button)sender).Text;
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-PUOG4VQ1;Initial Catalog=user_data;Integrated Security=SSPI");
            string sqlstr = @"insert into " + Session["account"].ToString() + " ( friends ) values ('" + recom + "')";
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
            sqlstr = @"insert into " + recom + " ( friends ) values ('" + Session["account"] + "')";
            cmd = new SqlCommand(sqlstr, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ae)
            {
                MessageBox.Show(ae.Message.ToString());
            }
            conn.Close();
        }

        protected void Friend_list()
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-PUOG4VQ1;Initial Catalog=user_data;Integrated Security=SSPI");
            string sqlstr = @"Select friends from " + Session["account"].ToString();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = 1;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string btn_str = "<asp:Button ID=\"friend" + i + "\" class=\"btn2\" runat=\"server\" Text=\"" + row[0].ToString() + "\" /> ";
                System.Web.UI.Control c = ParseControl(btn_str);
                this.Panel2.Controls.Add(c);
                System.Web.UI.WebControls.Button myButton = (System.Web.UI.WebControls.Button)Page.FindControl("friend" + i);
                myButton.Command += new CommandEventHandler(Friend_Click);
                i++;
            }
            conn.Close();
        }

        protected void Friend_Click(object sender, EventArgs e)
        {
            string reciver = ((System.Web.UI.WebControls.Button)sender).Text;
            Session["reciver"] = reciver;
            //Response.Write("<script>window.showModelessDialog('chat_page.aspx')</script>");
            Response.Write("<script>window.open('chat_page.aspx','_blank')</script>");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-PUOG4VQ1;Initial Catalog=user_data;Integrated Security=SSPI");
            string sqlstr = @"update user_table set status = 'off' where account = '" + Session["account"] + "'";
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
            conn.Close();
            Response.Redirect("Login_page.aspx", false);
        }

    }
}