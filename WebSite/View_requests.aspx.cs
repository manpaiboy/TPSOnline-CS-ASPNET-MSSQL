using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class View_requests : System.Web.UI.Page
{
    public string SqlTable = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        lblEvent.Visible = false;
        if (Session["account"] != null && Session["account"].ToString() != "client")
        {
            string SqlString = "";
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            if (Session["account"].ToString() == "staff")
            {
                SqlString = "SELECT [user].*, client.*, contract.*, request.*, request.userid AS staffid FROM [user]"
                + " INNER JOIN client ON [user].userid = client.userid"
                + " INNER JOIN contract ON [user].userid = contract.userid"
                + " INNER JOIN request ON contract.contractid = request.contractid"
                + " WHERE request.userid = @userid AND request.approval > 0"
                + " ORDER BY request.approval DESC, request.requestid DESC";
                cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                cmd.Parameters.AddWithValue("userid", Int32.Parse(Session["userid"].ToString()));
                cmd.Connection.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            else
            {
                SqlString = "SELECT [user].*, client.*, contract.*, request.*, request.userid AS staffid FROM [user]"
                + " INNER JOIN client ON [user].userid = client.userid"
                + " INNER JOIN contract ON [user].userid = contract.userid"
                + " INNER JOIN request ON contract.contractid = request.contractid"
                + " WHERE request.approval < 2"
                + " ORDER BY request.approval ASC, request.requestid DESC";
                cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
                cmd.Connection.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }

            string rowcolor = "r0";
            int counter = 0;
            while (dr.Read())
            {
                if (counter == 0)
                {
                    TableRow hr = new TableRow();
                    hr.CssClass = "ctitle";

                    TableCell h0 = new TableCell();
                    h0.Controls.Add(new LiteralControl("Request ID"));
                    hr.Cells.Add(h0);

                    if (Session["account"].ToString() == "manager")
                    {
                        TableCell h1 = new TableCell();
                        h1.Controls.Add(new LiteralControl("Staff ID"));
                        hr.Cells.Add(h1);
                    }

                    TableCell h2 = new TableCell();
                    h2.Controls.Add(new LiteralControl("Contract (ID)"));
                    hr.Cells.Add(h2);

                    TableCell h3 = new TableCell();
                    h3.Controls.Add(new LiteralControl("Position"));
                    hr.Cells.Add(h3);

                    TableCell h4 = new TableCell();
                    h4.Controls.Add(new LiteralControl("Company"));
                    hr.Cells.Add(h4);

                    TableCell h5 = new TableCell();
                    h5.Controls.Add(new LiteralControl("Salary Range"));
                    hr.Cells.Add(h5);

                    TableCell h6 = new TableCell();
                    h6.Controls.Add(new LiteralControl("Location"));
                    hr.Cells.Add(h6);

                    TableCell h7 = new TableCell();
                    h7.Controls.Add(new LiteralControl("&nbsp;"));
                    hr.Cells.Add(h7);

                    TableCell h8 = new TableCell();
                    h8.Controls.Add(new LiteralControl("&nbsp;"));
                    hr.Cells.Add(h8);

                    tblRequest.Rows.Add(hr);
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

                

                int contractid = Int32.Parse(dr["contractid"].ToString());
                int staffid = Int32.Parse(dr["staffid"].ToString());
                
                TableRow r = new TableRow();
                r.CssClass = rowcolor;

                TableCell c0 = new TableCell();
                c0.Controls.Add(new LiteralControl(dr["requestid"].ToString()));
                r.Cells.Add(c0);

                if (Session["account"].ToString() == "manager")
                {
                    TableCell c1 = new TableCell();
                    c1.Controls.Add(new LiteralControl("<a href='View_staff.aspx?id=" + dr["staffid"].ToString() + "'>#" + dr["staffid"].ToString() + "</a>"));
                    r.Cells.Add(c1);
                }

                TableCell c2 = new TableCell();
                c2.Controls.Add(new LiteralControl("<a href='View_Contract.aspx?id=" + dr["contractid"] + "'>" + dr["cname"] + " (#" + dr["contractid"] + ")</a>"));
                r.Cells.Add(c2);
                TableCell c3 = new TableCell();
                c3.Controls.Add(new LiteralControl(dr["field"].ToString()));
                r.Cells.Add(c3);
                TableCell c4 = new TableCell();
                c4.Controls.Add(new LiteralControl(dr["company"].ToString()));
                r.Cells.Add(c4);
                TableCell c5 = new TableCell();
                c5.Controls.Add(new LiteralControl(salary));
                r.Cells.Add(c5);
                TableCell c6 = new TableCell();
                c6.Controls.Add(new LiteralControl(dr["zip"].ToString()));
                r.Cells.Add(c6);

                TableCell c7 = new TableCell();
                Button Btn01 = new Button();
                Btn01.ID = "Btn01" + counter.ToString();
                Btn01.CssClass = "btn-sm btn-primary";
                Btn01.CommandArgument = contractid.ToString() + "," + staffid.ToString();

                if (Session["account"].ToString() == "manager")
                {

                    Btn01.Text = "Approve";
                    Btn01.Click += new System.EventHandler(this.BtnAdminApprove_Click);


                }
                else
                {
                    Btn01.Text = "Accept";
                    Btn01.Click += new System.EventHandler(this.BtnStaffAccept_Click);
                }

                if (Int32.Parse(dr["approval"].ToString()) < 2)
                {
                    if (Int32.Parse(dr["approval"].ToString()) == 1 && Session["account"].ToString() == "manager")
                    {
                        c7.Controls.Add(new LiteralControl("Approved"));
                    }
                    else
                    {
                        c7.Controls.Add(Btn01);
                    }
                }
                else
                {
                    c7.Controls.Add(new LiteralControl("Accepted"));
                }
                r.Cells.Add(c7);

                TableCell c8 = new TableCell();
                Button Btn02 = new Button();
                Btn02.ID = "Btn02" + counter.ToString();
                Btn02.CssClass = "btn-sm btn-primary";
                Btn02.CommandArgument = contractid.ToString() + "," + staffid.ToString();
                Btn02.Text = "Remove";
                Btn02.Click += new System.EventHandler(this.BtnRemoveRequest_Click);

                c8.Controls.Add(Btn02);
                r.Cells.Add(c8);
                
                tblRequest.Rows.Add(r);

                counter++;

                if (rowcolor == "r0")
                {
                    rowcolor = "r1";
                }
                else
                {
                    rowcolor = "r0";
                }
                
            }
            cmd.Connection.Close();
            cmd.Connection.Dispose();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["tpsonlineConnectionString"].ConnectionString;
    }

    protected void BtnStaffAccept_Click(object sender, EventArgs e)
    {
        Button Btn = (Button)sender;

        string[] arguments = Btn.CommandArgument.ToString().Split(new char[] { ',' });
        int contractid = Int32.Parse(arguments[0]);
        int staffid = Int32.Parse(arguments[1]);

        string SqlString = "UPDATE [request] SET approval = 2 WHERE userid = @userid AND contractid = @contractid";
        SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
        cmd.Parameters.AddWithValue("userid", staffid);
        cmd.Parameters.AddWithValue("contractid", contractid);
        cmd.Connection.Open();
        if (cmd.ExecuteNonQuery().Equals(1))
        {
            lblEvent.Text = "Request Accepted";
            lblEvent.Visible = true;

            SqlString = "DELETE FROM [request] WHERE userid <> @userid AND contractid = @contractid";
            cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
            cmd.Parameters.AddWithValue("userid", staffid);
            cmd.Parameters.AddWithValue("contractid", contractid);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();

            SqlString = "UPDATE [staff] SET status = 0 WHERE userid = @userid";
            cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
            cmd.Parameters.AddWithValue("userid", staffid);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();

            SqlString = "UPDATE [contract] SET status = 2 WHERE contractid = @contractid";
            cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
            cmd.Parameters.AddWithValue("contractid", contractid);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
        }


        cmd.Connection.Close();
        cmd.Connection.Dispose();
        Response.Redirect("~/View_requests.aspx");
    }

    protected void BtnAdminApprove_Click(object sender, EventArgs e)
    {
        Button Btn = (Button)sender;

        string[] arguments = Btn.CommandArgument.ToString().Split(new char[] { ',' });
        int contractid = Int32.Parse(arguments[0]);
        int staffid = Int32.Parse(arguments[1]);

        string SqlString = "UPDATE [request] SET approval = 1 WHERE userid = @userid AND contractid = @contractid";
        SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
        cmd.Parameters.AddWithValue("userid", staffid);
        cmd.Parameters.AddWithValue("contractid", contractid);
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        cmd.Connection.Dispose();
        Response.Redirect("~/View_Requests.aspx");

    }
    protected void BtnRemoveRequest_Click(object sender, EventArgs e)
    {
        Button Btn = (Button)sender;

        string[] arguments = Btn.CommandArgument.ToString().Split(new char[] { ',' });
        int contractid = Int32.Parse(arguments[0]);
        int staffid = Int32.Parse(arguments[1]);

        string SqlString = "DELETE FROM [request] WHERE userid = @userid AND contractid = @contractid";
        SqlCommand cmd = new SqlCommand(SqlString, new SqlConnection(GetConnectionString()));
        cmd.Parameters.AddWithValue("userid", staffid);
        cmd.Parameters.AddWithValue("contractid", contractid);
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        cmd.Connection.Dispose();
        Response.Redirect("~/View_Requests.aspx");
        
    }
}