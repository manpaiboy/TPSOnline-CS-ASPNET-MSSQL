using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;

public partial class View_Staff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
        PnlViewStaff.Visible = false;
        Btn_admin_SetActive.Visible = false;
        Btn_admin_SetInactive.Visible = false;
        Dd_Client_Contracts.Visible = false;
        Btn_Client_Request.Visible = false;

        if (Session["account"] != null) // If user has been authenticated
        {
            if (Request.Params["id"] != null) // if user is requesting to see a specific user
            {
                int staffid = 0;

                try
                {
                    staffid = Int32.Parse(Request.Params["id"].ToString());
                }
                catch
                {
                    Response.Redirect("~/Default.aspx");
                }

                string SqlString = "SELECT [user].*, staff.* FROM [user] INNER JOIN staff ON [user].userid = staff.userid WHERE [user].userid = @userid AND [user].account = 3";
                SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                cmd.Parameters.AddWithValue("userid", staffid);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                
                if (dr.Read() == true)
                {
                    PnlViewStaff.Visible = true;
                    ImgPic.ImageUrl = dr["pic"].ToString();
                    lblPhone.Text = dr["phone"].ToString();
                    lblEmail.Text = dr["email"].ToString();
                    lblField.Text = dr["field"].ToString();
                    lblZip.Text = dr["zip"].ToString();
                    lblResume.Text = dr["resume"].ToString();

                    lblName.Text = dr["fname"].ToString() + " " + dr["lname"].ToString();

                    int status = Int32.Parse(dr["status"].ToString());

                    if (Session["account"].ToString() == "manager")
                    {
                        if (status == 1)
                        {
                            Btn_admin_SetInactive.Visible = true;
                        }
                        else
                        {
                            Btn_admin_SetActive.Visible = true;
                        }
                    }
                    else if (Session["account"].ToString() == "client" && status == 1)
                    {
                        SqlString = "SELECT * FROM [contract] WHERE userid = @userid AND status = 1";
                        cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                        cmd.Parameters.AddWithValue("userid", Int32.Parse(Session["userid"].ToString()));
                        cmd.Connection.Open();
                        SqlDataReader cdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        if (cdr.Read() == true)
                        {
                            Dd_Client_Contracts.Visible = true;
                            Btn_Client_Request.Visible = true;
                        }
                        cdr.Close();
                    }

                    int edu = Int32.Parse(dr["edu"].ToString());
                    int exp = Int32.Parse(dr["exp"].ToString());
                    int sal = Int32.Parse(dr["sal"].ToString());

                    // Set education label
                    if (edu == 1)
                    {
                        lblEdu.Text = "High School";
                    }
                    else if (edu == 2)
                    {
                        lblEdu.Text = "Associate";
                    }
                    else if (edu == 3)
                    {
                        lblEdu.Text = "Bachelors";
                    }
                    else if (edu == 4)
                    {
                        lblEdu.Text = "Advanced Degree";
                    }
                    else
                    {
                        lblEdu.Text = "Unspecified";
                    }

                    // set experience label
                    if (exp == 0)
                    {
                        lblExp.Text = "None";
                    }
                    else if (exp == 1)
                    {
                        lblExp.Text = "1+ Years";
                    }
                    else if (exp == 2)
                    {
                        lblExp.Text = "2+ Years";
                    }
                    else if (exp == 3)
                    {
                        lblExp.Text = "3+ Years";
                    }
                    else if (exp == 4)
                    {
                        lblExp.Text = "4+ Years";
                    }
                    else if (exp == 5)
                    {
                        lblExp.Text = "5+ Years";
                    }
                    else if (exp == 6)
                    {
                        lblExp.Text = "6+ Years";
                    }
                    else if (exp == 7)
                    {
                        lblExp.Text = "7+ Years";
                    }
                    else if (exp == 8)
                    {
                        lblExp.Text = "8+ Years";
                    }
                    else if (exp == 9)
                    {
                        lblExp.Text = "9+ Years";
                    }
                    else if (exp == 10)
                    {
                        lblExp.Text = "10+ Years";
                    }
                    else if (exp == 11)
                    {
                        lblExp.Text = "11+ Years";
                    }
                    else if (exp == 12)
                    {
                        lblExp.Text = "12+ Years";
                    }
                    else if (exp == 13)
                    {
                        lblExp.Text = "13+ Years";
                    }
                    else if (exp == 14)
                    {
                        lblExp.Text = "14+ Years";
                    }
                    else if (exp == 15)
                    {
                        lblExp.Text = "15+ Years";
                    }
                    else{
                        lblExp.Text = "Unspecified";
                    }

                    // set salary label
                    if (sal == 1)
                    {
                        lblSal.Text = "$10,000+";
                    }
                    else if (sal == 2)
                    {
                        lblSal.Text = "$20,000+";
                    }
                    else if (sal == 3)
                    {
                        lblSal.Text = "$30,000+";
                    }
                    else if (sal == 4)
                    {
                        lblSal.Text = "$40,000+";
                    }
                    else if (sal == 5)
                    {
                        lblSal.Text = "$50,000+";
                    }
                    else if (sal == 6)
                    {
                        lblSal.Text = "$60,000+";
                    }
                    else if (sal == 7)
                    {
                        lblSal.Text = "$70,000+";
                    }
                    else if (sal == 8)
                    {
                        lblSal.Text = "$80,000+";
                    }
                    else if (sal == 9)
                    {
                        lblSal.Text = "$90,000+";
                    }
                    else if (sal == 10)
                    {
                        lblSal.Text = "$100,000+";
                    }
                    else if (sal == 11)
                    {
                        lblSal.Text = "$110,000+";
                    }
                    else if (sal == 12)
                    {
                        lblSal.Text = "$120,000+";
                    }
                    else if (sal == 13)
                    {
                        lblSal.Text = "$130,000+";
                    }
                    else if (sal == 14)
                    {
                        lblSal.Text = "$140,000+";
                    }
                    else if (sal == 15)
                    {
                        lblSal.Text = "$150,000+";
                    }
                    else
                    {
                        lblSal.Text = "Unspecified";
                    }

                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Invalid Request";
                }
                dr.Close();
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
            else // if id is empty page will be unable to get results
            {
                lblError.Visible = true;
                lblError.Text = "Invalid Request";
            }
        }
        else // If user not authenticated redirect to login
        {
            Response.Redirect("~/Login.aspx");
        }

        
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["tpsonlineConnectionString"].ConnectionString;
    }
    protected void Btn_Client_Request_Click(object sender, EventArgs e)
    {
         string SqlString = "SELECT * FROM [request] WHERE userid = @userid AND contractid = @contractid";
         SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
         cmd.Parameters.AddWithValue("userid", Int32.Parse(Request.Params["id"]));
         cmd.Parameters.AddWithValue("contractid", Int32.Parse(Dd_Client_Contracts.SelectedValue));
         cmd.Connection.Open();
         SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

         if (dr.Read() == true)
         {
             lblError.Text = "This staff has already been requested.";
         }
         else
         {
             dr.Close();
             SqlString = "SELECT * FROM [request] WHERE contractid = @contractid";
             cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
             cmd.Parameters.AddWithValue("contractid", Int32.Parse(Dd_Client_Contracts.SelectedValue));
             cmd.Connection.Open();
             dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

             int counter = 0;
             while (dr.Read())
             {
                 counter++;
             }

             if (counter > 2)
             {
                 lblError.Text = "Only 3 requests can be made per contract.";
             }
             else
             {

                 SqlString = "INSERT INTO [request] (contractid, userid, approval) VALUES (@contractid, @userid, 0)";
                 cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                 cmd.Parameters.AddWithValue("contractid", Int32.Parse(Dd_Client_Contracts.SelectedValue));
                 cmd.Parameters.AddWithValue("userid", Int32.Parse(Request.Params["id"]));
                 cmd.Connection.Open();

                 if (cmd.ExecuteNonQuery().Equals(1))
                 {
                     lblError.Text = "Request was successful";
                 }
                 else
                 {
                     lblError.Text = "Request failed";
                 }
             }
         }
        dr.Close();
        dr.Dispose();
        lblError.Visible = true;
        cmd.Connection.Close();
        cmd.Connection.Dispose();
    }
    protected void Btn_admin_SetActive_Click(object sender, EventArgs e)
    {
        string SqlString = "UPDATE [staff] SET status = 1 WHERE userid = @userid";
        SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
        cmd.Parameters.AddWithValue("userid", Int32.Parse(Request.Params["id"]));
        cmd.Connection.Open();
        //cmd.ExecuteNonQuery();

        if (cmd.ExecuteNonQuery().Equals(1))
        {
            string redirectAddr = "~/View_staff.aspx?id=" + Request.Params["id"];
            Response.Redirect(redirectAddr);
        }
        else
        {
            lblError.Text = "There was an error, please try again.";
            lblError.Visible = true;
        }
        cmd.Connection.Close();
        cmd.Connection.Dispose();
        
    }
    protected void Btn_admin_SetInactive_Click(object sender, EventArgs e)
    {
        string SqlString = "UPDATE [staff] SET status = 0 WHERE userid = @userid";
        SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
        cmd.Parameters.AddWithValue("userid", Int32.Parse(Request.Params["id"]));
        cmd.Connection.Open();
        //cmd.ExecuteNonQuery();

        if (cmd.ExecuteNonQuery().Equals(1))
        {
            string redirectAddr = "~/View_staff.aspx?id=" + Request.Params["id"];
            Response.Redirect(redirectAddr);
        }
        else
        {
            lblError.Text = "There was an error, please try again.";
            lblError.Visible = true;
        }

        cmd.Connection.Close();
        cmd.Connection.Dispose();
    }
}