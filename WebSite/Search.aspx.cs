using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["account"] != null) // if user is valid
        {

        }
        else // invalid user
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text.Length > 0)
        {
            string SqlString = "";
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            string search = txtSearch.Text.Trim();
            // account, (userid/contractid) as id, position, location, (fname+lname,cname) as name
            SqlString = "SELECT [user].account, [user].userid as id, ([user].fname + ' ' + [user].lname) as name, null as company,"  
                + " [staff].field, [staff].zip"
                + " FROM [user]"
                + " INNER JOIN [staff] ON [user].userid = [staff].userid"                
                + " WHERE [staff].status <> 0 AND [user].account = 3"
                + " AND ( LOWER(([user].fname + ' ' + [user].lname)) LIKE '%'+LOWER(@search)+'%'"
                + " OR LOWER([staff].field) LIKE'%'+LOWER(@search)+'%'"
                + " OR CAST([user].userid as varchar(11)) = @search"
                + " OR CAST([staff].zip as varchar(5)) = @search"
                //+ " OR LOWER([user].username) LIKE '%'+LOWER(@search)+'%'"
                + " )"
                + " UNION ALL"
                + " SELECT [user].account, [contract].contractid as id, [contract].cname as name, [client].company,"
                + " [contract].field, [contract].zip"
                + " FROM [contract]"
                + " INNER JOIN [client] ON [contract].userid = [client].userid"
                + " INNER JOIN [user] ON [contract].userid = [user].userid"
                + " WHERE ( LOWER([contract].cname) LIKE '%'+LOWER(@search)+'%'"
                + " OR LOWER([contract].field) LIKE '%'+LOWER(@search)+'%'"
                + " OR CAST([contract].contractid as varchar(11)) = @search"
                + " OR CAST([contract].zip as varchar(5)) = @search"
                + " ) ";
            cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
            cmd.Parameters.AddWithValue("search", search);
            cmd.Connection.Open();
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //string rowcolor = "r0";
            int counter = 0;

            while (dr.Read()) // while there are rows to read in the db
            {
                if (counter == 0) // if this is the first row add titles to the table
                {
                    TableRow hr = new TableRow();
                    hr.CssClass = "ctitle";

                    TableCell h0 = new TableCell();
                    h0.Controls.Add(new LiteralControl("Results"));
                    hr.Cells.Add(h0);

                    tblSearch.Rows.Add(hr);


                }

                string title = "";
                string link = "";
                string description = "";
                
                int account = Int32.Parse(dr["account"].ToString());

                if (account == 2) // Client
                {
                    title = "(contract #" + dr["id"].ToString() + ") " + dr["name"].ToString();
                    description = dr["company"].ToString() + " - Position:" + dr["field"].ToString() + " Location:" + dr["zip"].ToString();
                    link = "View_contract.aspx?id=" + dr["id"].ToString();
                }
                else if (account == 3) // Staff
                {
                    title = "(staff #" + dr["id"].ToString() + ") " + dr["name"].ToString();
                    description = " Position:" + dr["field"].ToString() + " Location:" + dr["zip"].ToString();
                    link = "View_staff.aspx?id=" + dr["id"].ToString();
                }
                else
                {
                    title = "Error";
                    link = "";
                    description = "Error";
                }

                // Create a new table row
                TableRow r = new TableRow();

                TableCell c0 = new TableCell();
                c0.Controls.Add(new LiteralControl("<a href='" + link + "'>"
                    + title + "</a> : " + description));
                r.Cells.Add(c0);

                // insert new row into table
                tblSearch.Rows.Add(r);

                // Modify counter/rowcolor data for next row
                counter++;

                // Commented out so row color is always the same
                /*if (rowcolor == "r0")
                {
                    rowcolor = "r1";
                }
                else
                {
                    rowcolor = "r0";
                }*/
            }

            if (counter == 0)
            {
                TableRow hr = new TableRow();
                hr.CssClass = "ctitle";
                TableCell h0 = new TableCell();
                h0.Controls.Add(new LiteralControl("Results"));
                hr.Cells.Add(h0);
                tblSearch.Rows.Add(hr);


                TableRow r2 = new TableRow();
                TableCell c1 = new TableCell();
                c1.Controls.Add(new LiteralControl("0 Results"));
                r2.Cells.Add(c1);
                tblSearch.Rows.Add(r2);
            }

            dr.Close();
            dr.Dispose();
            cmd.Connection.Close();
            cmd.Connection.Dispose();
        }
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["tpsonlineConnectionString"].ConnectionString;
    }
}