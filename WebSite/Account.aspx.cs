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

public partial class Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["account"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                string SqlString = "SELECT * FROM [user] WHERE [userid] = @userid";
                SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                cmd.Parameters.AddWithValue("userid", Int32.Parse(Session["userid"].ToString()));
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read() == true)
                {
                    txtUsername.Text = dr["username"].ToString();
                    HiddenPwd.Value = dr["pwd"].ToString();
                    HiddenSalt.Value = dr["salt"].ToString();
                    txtFname.Text = dr["fname"].ToString();
                    txtLname.Text = dr["lname"].ToString();
                    txtPhone.Text = dr["phone"].ToString();
                    txtEmail.Text = dr["email"].ToString();
                }
                else
                {
                    dr.Close();
                    Session["userid"] = null;
                    Session["username"] = null;
                    Session["account"] = null;
                    Response.Redirect("~/Login.aspx");
                }
                dr.Close();
            }
            lblError.Text = "";
        }

    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["tpsonlineConnectionString"].ConnectionString;
    }

    protected string HashPass(string pwd, int salt)
    {
        byte[] pwdBytes = Encoding.ASCII.GetBytes(String.Concat(pwd, salt.ToString()));

        SHA1 sha = new SHA1CryptoServiceProvider();

        byte[] SHA1pwd = sha.ComputeHash(pwdBytes);

        pwd = BitConverter.ToString(SHA1pwd).Replace("-", "");

        return pwd;
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (IsValid)
        {
            int salt = Int32.Parse(HiddenSalt.Value);
            string pwd = HiddenPwd.Value;

            if (txtPwd.Text.Length > 0)
            {
                salt = (DateTime.Now.Millisecond + 5) * (DateTime.Now.Hour + 5) * (DateTime.Now.Minute + 5);
                pwd = this.HashPass(txtPwd.Text, salt);
            }

            int account = 3;
            if (Session["account"].ToString() == "manager")
            {
                account = 1;
            }
            else if (Session["account"].ToString() == "client")
            {
                account = 2;
            }

            string SqlString = "UPDATE [user] SET username = @username, pwd = @pwd, salt = @salt, account = @account, fname = @fname, lname = @lname, phone = @phone, email = @email WHERE userid = @userid";
            SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
            cmd.Parameters.AddWithValue("username", txtUsername.Text);
            cmd.Parameters.AddWithValue("pwd", pwd);
            cmd.Parameters.AddWithValue("salt", salt);
            cmd.Parameters.AddWithValue("account", account);
            cmd.Parameters.AddWithValue("fname", txtFname.Text);
            cmd.Parameters.AddWithValue("lname", txtLname.Text);
            cmd.Parameters.AddWithValue("phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("email", txtEmail.Text);
            cmd.Parameters.AddWithValue("userid", Int32.Parse(Session["userid"].ToString()));
            cmd.Connection.Open();
            //cmd.ExecuteNonQuery();

            if (cmd.ExecuteNonQuery().Equals(1))
            {
                Session["username"] = txtUsername.Text;
                lblError.Text = "Update Successful";
            }
            else // If user was not able to be saved to database
            {
                lblError.Text = "There was an error, Please try again.";
            }

        }
    }

    protected void UsernameValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtUsername.Text != Session["username"].ToString())
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
    }
    protected void PwdStrngthValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtPwd.Text.Length > 0)
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
    }
    protected void PwdMatchValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtPwd.Text.Length > 0 && (txtPwd.Text != txtPwd2.Text))
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