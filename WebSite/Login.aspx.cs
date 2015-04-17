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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text.Length > 0 && txtPwd.Text.Length > 0) // If username and password are not empty
        {
            // Retrieve data from database
            string SqlString = "";
            int test = 0;
            try
            {
                test = Int32.Parse(txtUsername.Text);
                SqlString = "SELECT * FROM [user] WHERE [userid] = @username";
            }
            catch
            {
                SqlString = "SELECT * FROM [user] WHERE [username] = @username";
            }
            
            SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
            cmd.Parameters.AddWithValue("username", txtUsername.Text);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
            if (dr.Read() == true) // if username found in database
            {
                string Pwd = dr["pwd"].ToString(); // Encrypted DB Password
                int salt = Int32.Parse(dr["salt"].ToString()); // DB Salt
                string UserPwd = this.HashPass(txtPwd.Text, salt); // Call encryption function

                if (UserPwd == Pwd) // If passwords match Set Session with appropriate account level
                {
                    if (dr["account"].ToString() == "1") // Manager Account
                    {
                        Session["account"] = "manager";
                    }
                    else if (dr["account"].ToString() == "2") // Client Account
                    {
                        Session["account"] = "client";
                    }
                    else // 3 - Staff Account
                    {
                        Session["account"] = "staff";
                    }
                    
                    // Save userid and username into a Session
                    Session["userid"] = Int32.Parse(dr["userid"].ToString());
                    Session["username"] = dr["username"].ToString();

                    // Redirect user to appropriate site
                    if (Session["account"].ToString() == "manager")
                    {
                        Response.Redirect("~/Manage_contracts.aspx");
                    }
                    else if (Session["account"].ToString() == "client")
                    {
                        Response.Redirect("~/Manage_contracts.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Search.aspx");
                    }
                }
                else // if passwords do not match
                {
                    lblError.Text = "Invalid Login Information";
                    lblError.Visible = true;
                }

            }
            else // if username not found
            {
                lblError.Text = "Invalid Login Information";
                lblError.Visible = true;
            }
            dr.Close();
        }
        else // if either username or password are empty
        {
            lblError.Text = "Required field missing";
            lblError.Visible = true;
        }
    }


    // encrypt password and salt
    protected string HashPass(string pwd, int salt)
    {
        byte[] pwdBytes = Encoding.ASCII.GetBytes(String.Concat(pwd, salt.ToString()));

        SHA1 sha = new SHA1CryptoServiceProvider();

        byte[] SHA1pwd = sha.ComputeHash(pwdBytes);

        pwd = BitConverter.ToString(SHA1pwd).Replace("-", "");

        return pwd;
    }

    // retrieve connection string
    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["tpsonlineConnectionString"].ConnectionString;
    }
}