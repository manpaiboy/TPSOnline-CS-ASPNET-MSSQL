using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Update_contract : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["account"] == null || Session["account"].ToString() != "client")
        {
            Response.Redirect("~/Default.aspx");
        }
        else if (Request.Params["id"] == null)
        {
            Response.Redirect("~/Manage_contracts.aspx");
        }
        else
        {
            int contractid = 0;

            try
            {
                contractid = Int32.Parse(Request.Params["id"].ToString());
            }
            catch
            {
                Response.Redirect("~/Manage_contracts.aspx");
            }

            if (!IsPostBack)
            {
                string SqlString = "SELECT [contract].*, [user].* FROM [contract] INNER JOIN [user] ON [contract].userid = [user].userid"
                    + " WHERE [user].userid = @userid"
                    + " AND [contract].contractid = @contractid";
                SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                cmd.Parameters.AddWithValue("userid", Int32.Parse(Session["userid"].ToString()));
                cmd.Parameters.AddWithValue("contractid", contractid);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read() == true)
                {
                    TxtCname.Text = dr["cname"].ToString();
                    TxtDescription.Text = dr["description"].ToString();
                    TxtZip.Text = dr["zip"].ToString();

                    if (dr["field"].ToString() == "")
                    {
                        DdField.SelectedIndex = 0;
                    }
                    else
                    {
                        DdField.SelectedValue = dr["field"].ToString();
                    }

                    if (dr["edu"].ToString() == "")
                    {
                        DdEdu.SelectedIndex = 0;
                    }
                    else
                    {
                        DdEdu.SelectedIndex = Int32.Parse(dr["edu"].ToString());
                    }

                    if (dr["exp"].ToString() == "")
                    {
                        DdExp.SelectedIndex = 0;
                    }
                    else
                    {
                        DdExp.SelectedValue = dr["exp"].ToString();
                    }

                    if (dr["sal"].ToString() == "")
                    {
                        DdSal.SelectedIndex = 0;
                    }
                    else
                    {
                        DdSal.SelectedIndex = Int32.Parse(dr["sal"].ToString());
                    }
                }
                dr.Close();
                dr.Dispose();
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            int contractid = Int32.Parse(Request.Params["id"].ToString());

            string SqlString = "UPDATE [contract] SET cname = @cname, description = @description, field = @field, zip = @zip, sal = @sal, exp = @exp, edu = @edu WHERE contractid = @contractid";
            SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
            cmd.Parameters.AddWithValue("cname", TxtCname.Text);
            cmd.Parameters.AddWithValue("description", TxtDescription.Text);
            cmd.Parameters.AddWithValue("field", DdField.SelectedValue);
            cmd.Parameters.AddWithValue("zip", TxtZip.Text);
            cmd.Parameters.AddWithValue("sal", Int32.Parse(DdSal.SelectedValue));
            cmd.Parameters.AddWithValue("exp", Int32.Parse(DdExp.SelectedValue));
            cmd.Parameters.AddWithValue("edu", Int32.Parse(DdEdu.SelectedValue));
            cmd.Parameters.AddWithValue("contractid", contractid);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("~/Manage_contracts.aspx");
        }
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["tpsonlineConnectionString"].ConnectionString;
    }

}

