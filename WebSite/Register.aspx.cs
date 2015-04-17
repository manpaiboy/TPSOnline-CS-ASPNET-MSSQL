using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

using System.Text.RegularExpressions;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["account"] != null)
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            lblAdminKey.Visible = RadioManager.Checked;
            txtAdminKey.Visible = RadioManager.Checked;
        }
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["tpsonlineConnectionString"].ConnectionString;
    }

    
    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            int salt = (DateTime.Now.Millisecond + 5) * (DateTime.Now.Hour + 5) * (DateTime.Now.Minute + 5);
            string pwd = this.HashPass(txtPwd.Text, salt);

            int account = 3;
            string accountName = "";

            if (RadioManager.Checked) { account = 1; accountName = "manager";  }
            else if (RadioClient.Checked) { account = 2; accountName = "client";  }
            else { account = 3; accountName = "staff"; }
            
            string SqlString = "INSERT INTO [user] (username, pwd, salt, account, fname, lname, phone, email) VALUES (@username, @pwd, @salt, @account, @fname, @lname, @phone, @email)";
            SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
            cmd.Parameters.AddWithValue("username", txtUsername.Text);
            cmd.Parameters.AddWithValue("pwd", pwd);
            cmd.Parameters.AddWithValue("salt", salt);
            cmd.Parameters.AddWithValue("account", account);
            cmd.Parameters.AddWithValue("fname", txtFname.Text);
            cmd.Parameters.AddWithValue("lname", txtLname.Text);
            cmd.Parameters.AddWithValue("phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("email", txtEmail.Text);
            cmd.Connection.Open();
            //cmd.ExecuteNonQuery();
            
            if (cmd.ExecuteNonQuery().Equals(1))
            {
                int userid = 0;
               
                    SqlString = "SELECT * FROM [user] WHERE [username] = @username";
                    cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                    cmd.Parameters.AddWithValue("username", txtUsername.Text);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (dr.Read() == true)
                    {
                        userid = Int32.Parse(dr["userid"].ToString());
                        if (account == 3) // Insert userid into Staff table
                        {
                            SqlString = "INSERT INTO [staff] (userid, pic, status) VALUES (@userid, @pic, 0)";
                            cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                            cmd.Parameters.AddWithValue("userid", userid);
                            cmd.Parameters.AddWithValue("pic", "~/images/user/Default.jpg");
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();

                            Session["userid"] = userid;
                            Session["username"] = txtUsername.Text;
                            Session["account"] = accountName;

                            Response.Redirect("~/Update_staff.aspx");
                        }
                        else if (account == 2) // Insert userid into Client table
                        {
                            SqlString = "INSERT INTO [client] (userid) VALUES (@userid)";
                            cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                            cmd.Parameters.AddWithValue("userid", userid);
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();

                            Session["userid"] = userid;
                            Session["username"] = txtUsername.Text;
                            Session["account"] = accountName;

                            Response.Redirect("~/Update_client.aspx");
                        }
                        else // If Manager
                        {
                            Session["userid"] = userid;
                            Session["username"] = txtUsername.Text;
                            Session["account"] = accountName;

                            Response.Redirect("~/View_requests.aspx");
                        }

                    }
                    else
                    {
                        lblError.Text = "An error occurred with the database, Please try again at another time.";
                    }

                    dr.Close();                
            }
            else // If user was not able to be saved to database
            {
                lblError.Text = "There was an error, Please try again.";
            }

        }
    }

    protected void RadioAccount_CheckedChanged(object sender, EventArgs e)
    {
        lblAdminKey.Visible = RadioManager.Checked;
        txtAdminKey.Visible = RadioManager.Checked;
    }

    // If Manager account is being created, check to see if this is a valid user
    protected void checkManagerCode_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (RadioManager.Checked && txtAdminKey.Text != "cis470")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected string HashPass(string pwd, int salt)
    {
        byte[] pwdBytes = Encoding.ASCII.GetBytes(String.Concat(pwd, salt.ToString()));

        SHA1 sha = new SHA1CryptoServiceProvider();

        byte[] SHA1pwd = sha.ComputeHash(pwdBytes);

        pwd = BitConverter.ToString(SHA1pwd).Replace("-", "");

        return pwd;
    }

    protected void UsernameValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtUsername.Text.Length > 0)
        {
            string SqlString = "SELECT * FROM [user] WHERE [username] = @username";
            SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
            cmd.Parameters.AddWithValue("username", txtUsername.Text);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read() == true)
            {
                UsernameValidator.Text = "* Username not available";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }

            dr.Close();
        }
        else
        {
            args.IsValid = false;
            UsernameValidator.Text = "* Username cannot be empty";
        }
    }
    protected void PwdStrngthValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        int Strength = 0;
        if (txtPwd.Text.Length < 6 || Regex.IsMatch(txtPwd.Text, @"\s"))
        {
            args.IsValid = false;
        }
        else
        {
            if (Regex.IsMatch(txtPwd.Text, @"[a-z]"))
            {
                Strength++;
            }
            if (Regex.IsMatch(txtPwd.Text, @"[A-Z]"))
            {
                Strength++;
            }
            if (Regex.IsMatch(txtPwd.Text, @"[0-9]"))
            {
                Strength++;                
            }

            if (Strength < 2)
            {
                args.IsValid = false;
            }
        }
    }
    protected void PwdMatchValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtPwd.Text != txtPwd2.Text)
        {
            args.IsValid = false;
        }
    }
    protected void FnameValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtFname.Text.Length < 1)
        {
            args.IsValid = false;
        }
    }
    protected void LnameValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtLname.Text.Length < 1)
        {
            args.IsValid = false;
        }
    }
    protected void PhoneValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtPhone.Text.Length < 10)
        {
            args.IsValid = false;
        }
    }
    protected void EmailValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!IsValidEmail(txtEmail.Text))
        {
            args.IsValid = false;
        }
    }

    public static bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
    }
}