using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Update_client : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
        if (Session["account"] != null && Session["account"].ToString() == "client")
        {
            if (!IsPostBack)
            {
                string SqlString = "SELECT * FROM [client] WHERE userid = @userid";
                SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                cmd.Parameters.AddWithValue("userid", Int32.Parse(Session["userid"].ToString()));
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read() == true)
                {
                    TxtCompany.Text = dr["company"].ToString();
                }
                else
                {
                    Session["account"] = null;
                    Session["userid"] = null;
                    Session["username"] = null;
                    Response.Redirect("~/Default.aspx");
                }
            }

        }
        else if (Session["account"] != null)
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["tpsonlineConnectionString"].ConnectionString;
    }


    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            string SqlString = "UPDATE [client] SET company = @company WHERE userid = @userid";
            SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
            cmd.Parameters.AddWithValue("company", TxtCompany.Text);
            cmd.Parameters.AddWithValue("userid", Int32.Parse(Session["userid"].ToString()));
            cmd.Connection.Open();

            if (cmd.ExecuteNonQuery().Equals(1))
            {
                lblError.Text = "Update successful";
            }
            else
            {
                lblError.Text = "Update failed";
            }
            lblError.Visible = true;
        }
    }
}