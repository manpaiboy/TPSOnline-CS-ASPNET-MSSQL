using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Find_staff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BtnModifyContract.Visible = false;
        if (Session["account"] != null)
        {
            if (Session["account"].ToString() == "client" || Session["account"].ToString() == "manager")
            {
                if (Request.Params["id"] != null)
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

                    string SqlString = "";
                    SqlCommand cmd = null;
                    SqlDataReader dr = null;

                    if (Session["account"].ToString() == "client")
                    {
                        BtnModifyContract.PostBackUrl = "~/Update_contract.aspx?id=" + contractid.ToString();
                        BtnModifyContract.Visible = true;
                        SqlString = "SELECT * FROM [contract]"
                            + " WHERE userid = @userid"
                            + " AND contractid = @contractid";
                        cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                        cmd.Parameters.AddWithValue("userid", Int32.Parse(Session["userid"].ToString()));
                        cmd.Parameters.AddWithValue("contractid", contractid);
                        cmd.Connection.Open();
                        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                    else // manager
                    {
                        SqlString = "SELECT * FROM [contract]"
                            + " WHERE contractid = @contractid";
                        cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                        cmd.Parameters.AddWithValue("contractid", contractid);
                        cmd.Connection.Open();
                        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    }

                    string cposition = "";
                    int czip = 0;
                    int cminzip = 0;
                    int cmaxzip = 0;
                    int csal = 0;
                    int cminsal = 0;
                    int cmaxsal = 0;
                    int cexp = 0;
                    int cedu = 0;

                    if (dr.Read())
                    {
                        lblCName.Text = dr["cname"].ToString();
                        cposition = dr["field"].ToString();
                        czip = Int32.Parse(dr["zip"].ToString());
                        csal = Int32.Parse(dr["sal"].ToString());
                        cexp = Int32.Parse(dr["exp"].ToString());
                        cedu = Int32.Parse(dr["edu"].ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Manage_contracts.aspx");
                    }

                    dr.Close();
                    dr.Dispose();
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();

                    cminzip = czip - 500;
                    cmaxzip = czip + 500;
                    cminsal = csal - 1;
                    cmaxsal = csal + 1;

                    SqlString = "SELECT [user].*, staff.* FROM [user]"
                        + " INNER JOIN staff ON [user].userid = staff.userid"
                        + " WHERE field = @position"
                        + " AND zip <= @maxzip AND zip >= @minzip"
                        + " AND exp >= @exp"
                        + " AND sal <= @maxsal AND sal >= @minsal"
                        + " AND edu >= @edu"
                        + " AND status = 1";
                    cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                    cmd.Parameters.AddWithValue("position", cposition);
                    cmd.Parameters.AddWithValue("maxzip", cmaxzip);
                    cmd.Parameters.AddWithValue("minzip", cminzip);
                    cmd.Parameters.AddWithValue("exp", cexp);
                    cmd.Parameters.AddWithValue("maxsal", cmaxsal);
                    cmd.Parameters.AddWithValue("minsal", cminsal);
                    cmd.Parameters.AddWithValue("edu", cedu);
                    cmd.Connection.Open();
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    string rowcolor = "r0";
                    int counter = 0;

                    while (dr.Read()) // while there are rows to read in the db
                    {
                        if (counter == 0) // if this is the first row add titles to the table
                        {
                            TableRow hr = new TableRow();
                            hr.CssClass = "ctitle";

                            TableCell h0 = new TableCell();
                            h0.Controls.Add(new LiteralControl("&nbsp;"));
                            hr.Cells.Add(h0);

                            TableCell h1 = new TableCell();
                            h1.Controls.Add(new LiteralControl("Name"));
                            hr.Cells.Add(h1);

                            TableCell h2 = new TableCell();
                            h2.Controls.Add(new LiteralControl("Position"));
                            hr.Cells.Add(h2);

                            TableCell h3 = new TableCell();
                            h3.Controls.Add(new LiteralControl("Salary Range"));
                            hr.Cells.Add(h3);

                            TableCell h4 = new TableCell();
                            h4.Controls.Add(new LiteralControl("Education"));
                            hr.Cells.Add(h4);

                            TableCell h5 = new TableCell();
                            h5.Controls.Add(new LiteralControl("Location"));
                            hr.Cells.Add(h5);

                            tblStaff.Rows.Add(hr);


                        }

                        string salary = "";
                        int sal = Int32.Parse(dr["sal"].ToString());

                        if (sal == 1)
                        {
                            salary = "$10,000+";
                        }
                        else if (sal == 2)
                        {
                            salary = "$20,000+";
                        }
                        else if (sal == 3)
                        {
                            salary = "$30,000+";
                        }
                        else if (sal == 4)
                        {
                            salary = "$40,000+";
                        }
                        else if (sal == 5)
                        {
                            salary = "$50,000+";
                        }
                        else if (sal == 6)
                        {
                            salary = "$60,000+";
                        }
                        else if (sal == 7)
                        {
                            salary = "$70,000+";
                        }
                        else if (sal == 8)
                        {
                            salary = "$80,000+";
                        }
                        else if (sal == 9)
                        {
                            salary = "$90,000+";
                        }
                        else if (sal == 10)
                        {
                            salary = "$100,000+";
                        }
                        else if (sal == 11)
                        {
                            salary = "$110,000+";
                        }
                        else if (sal == 12)
                        {
                            salary = "$120,000+";
                        }
                        else if (sal == 13)
                        {
                            salary = "$130,000+";
                        }
                        else if (sal == 14)
                        {
                            salary = "$140,000+";
                        }
                        else if (sal == 15)
                        {
                            salary = "$150,000+";
                        }
                        else
                        {
                            salary = "Unspecified";
                        }

                        string education = "";
                        int edu = Int32.Parse(dr["edu"].ToString());

                        if (edu == 1)
                        {
                            education = "High School";
                        }
                        else if (edu == 2)
                        {
                            education = "Associate";
                        }
                        else if (edu == 3)
                        {
                            education = "Bachelors";
                        }
                        else if (edu == 4)
                        {
                            education = "Advanced Degree";
                        }
                        else
                        {
                            education = "Unspecified";
                        }

                        string img = dr["pic"].ToString().Replace("~/", "");
                        int staffid = Int32.Parse(dr["userid"].ToString());
                        string staffname = dr["fname"].ToString() + " " + dr["lname"].ToString();
                        string position = dr["field"].ToString();
                        string location = dr["zip"].ToString();

                        // Create a new table row
                        TableRow r = new TableRow();
                        r.CssClass = rowcolor;

                        // Add cells to the new table row
                        // pic, name, position, sal, edu, loc
                        TableCell c0 = new TableCell();
                        c0.Controls.Add(new LiteralControl("<a href='View_staff.aspx?id=" + staffid.ToString() + "'>"
                            + "<img src='" + img + "' style='border:0px;max-height:25px;max-width:25px;'/></a>"));
                        r.Cells.Add(c0);
                        TableCell c1 = new TableCell();
                        c1.Controls.Add(new LiteralControl("<a href='View_staff.aspx?id=" + staffid.ToString() + "'>"
                            + staffname + " (#" + staffid.ToString() + ")</a>"));
                        r.Cells.Add(c1);
                        TableCell c2 = new TableCell();
                        c2.Controls.Add(new LiteralControl(position));
                        r.Cells.Add(c2);
                        TableCell c3 = new TableCell();
                        c3.Controls.Add(new LiteralControl(salary));
                        r.Cells.Add(c3);
                        TableCell c4 = new TableCell();
                        c4.Controls.Add(new LiteralControl(education));
                        r.Cells.Add(c4);
                        TableCell c5 = new TableCell();
                        c5.Controls.Add(new LiteralControl(location));
                        r.Cells.Add(c5);

                        // insert new row into table
                        tblStaff.Rows.Add(r);

                        // Modify counter/rowcolor data for next row
                        counter++;

                        // Commented out so row color is always the same
                        if (rowcolor == "r0")
                        {
                            rowcolor = "r1";
                        }
                        else
                        {
                            rowcolor = "r0";
                        }
                    }

                    dr.Close();
                    dr.Dispose();
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

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
}