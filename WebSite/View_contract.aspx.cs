using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class View_contract : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BtnEditContract.Visible = false;
        if (Session["account"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        else if (Request.Params["id"] == null)
        {
            Response.Redirect("~/Default.aspx");
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
                Response.Redirect("~/Default.aspx");
            }

            if (!IsPostBack)
            {
                string SqlString = "SELECT [contract].*, [user].* FROM [contract] INNER JOIN [user] ON [contract].userid = [user].userid"
                    + " WHERE [contract].contractid = @contractid";
                SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                cmd.Parameters.AddWithValue("contractid", contractid);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read() == true)
                {
                    if (Session["userid"].ToString() == dr["userid"].ToString())
                    {
                        BtnEditContract.Visible = true;
                        BtnEditContract.PostBackUrl = "~/Update_contract.aspx?id=" + contractid.ToString();
                    }

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

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["tpsonlineConnectionString"].ConnectionString;
    }
}