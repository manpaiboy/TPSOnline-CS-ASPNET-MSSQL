using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class New_contract : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["account"] == null || Session["account"].ToString() != "client")
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            string SqlString = "INSERT INTO [contract] (userid, cname, description, field, zip, sal, exp, edu, status) VALUES (@userid, @cname, @description, @field, @zip, @sal, @exp, @edu, 1)";
            SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
            cmd.Parameters.AddWithValue("userid", Int32.Parse(Session["userid"].ToString()));
            cmd.Parameters.AddWithValue("cname", TxtCname.Text);
            cmd.Parameters.AddWithValue("description", TxtDescription.Text);
            cmd.Parameters.AddWithValue("field", DdField.SelectedValue);
            cmd.Parameters.AddWithValue("zip", TxtZip.Text);
            cmd.Parameters.AddWithValue("sal", Int32.Parse(DdSal.SelectedValue));
            cmd.Parameters.AddWithValue("exp", Int32.Parse(DdExp.SelectedValue));
            cmd.Parameters.AddWithValue("edu", Int32.Parse(DdEdu.SelectedValue));
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